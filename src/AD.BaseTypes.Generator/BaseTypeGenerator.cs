using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AD.BaseTypes.Generator
{
    [Generator]
    public class BaseTypeGenerator : ISourceGenerator
    {
        static readonly Regex
            BaseTypeRegex = new Regex("^AD.BaseTypes.IBaseType<(?<type>.+)>$"),
            ValidatedBaseTypeRegex = new Regex("^AD.BaseTypes.IValidatedBaseType<(?<type>.+)>$");

        public void Initialize(GeneratorInitializationContext context)
        { }

        public void Execute(GeneratorExecutionContext context)
        {
#if DEBUG
            //if (!System.Diagnostics.Debugger.IsAttached)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
#endif
            foreach (var tree in context.Compilation.SyntaxTrees)
            {
                var semantics = context.Compilation.GetSemanticModel(tree);
                var sources = new List<string>();

                foreach (var record in FindAllPartialRecords(tree))
                {
                    var attributes = GetAllAttributes(record);
                    if (!TryGetBaseType(semantics, attributes, out var baseType)) continue;

                    var sourceBuilder = new IndentedStringBuilder();

                    var @namespace = GetNamespace(record);
                    var hasNamespace = !string.IsNullOrEmpty(@namespace);
                    if (hasNamespace)
                    {
                        //namespace start
                        sourceBuilder.AppendLine($"namespace {@namespace}");
                        sourceBuilder.AppendLine("{");
                        sourceBuilder.IncreaseIndent();
                        //*****
                    }

                    //record start
                    sourceBuilder.AppendLine($"partial record {record.Identifier.Text} : System.IComparable<{record.Identifier.Text}>, System.IComparable, AD.BaseTypes.IValue<{baseType}>");
                    sourceBuilder.AppendLine("{");
                    sourceBuilder.IncreaseIndent();
                    //*****

                    //constructor start
                    sourceBuilder.AppendLine($"public {record.Identifier.Text}({baseType} value)");
                    sourceBuilder.AppendLine("{");
                    sourceBuilder.IncreaseIndent();
                    //*****

                    AppendValidations(sourceBuilder, semantics, attributes, baseType);
                    sourceBuilder.AppendLine("this.Value = value;");

                    //constructor end
                    sourceBuilder.DecreaseIndent();
                    sourceBuilder.AppendLine("}");
                    //*****

                    sourceBuilder.AppendLine($"public {baseType} Value {{ get; }}");
                    sourceBuilder.AppendLine("public override string ToString() => Value.ToString();");
                    sourceBuilder.AppendLine($"public int CompareTo(object obj) => CompareTo(obj as {record.Identifier.Text});");
                    sourceBuilder.AppendLine($"public int CompareTo({record.Identifier.Text} other) => other is null ? 1 : System.Collections.Generic.Comparer<{baseType}>.Default.Compare(Value, other.Value);");
                    sourceBuilder.AppendLine($"public static implicit operator {baseType}({record.Identifier.Text} item) => item.Value;");
                    sourceBuilder.AppendLine($"public static {record.Identifier.Text} Create({baseType} value) => new(value);");

                    //record end
                    sourceBuilder.DecreaseIndent();
                    sourceBuilder.AppendLine("}");
                    //*****

                    if (hasNamespace)
                    {
                        //namespace end
                        sourceBuilder.DecreaseIndent();
                        sourceBuilder.AppendLine("}");
                        //*****
                    }

                    sources.Add(sourceBuilder.ToString());
                }

                if (sources.Count > 0)
                {
                    context.AddSource(Path.GetFileNameWithoutExtension(tree.FilePath) + ".generated", string.Join(Environment.NewLine, sources));
                }
            }
        }

        static IEnumerable<RecordDeclarationSyntax> FindAllPartialRecords(SyntaxTree tree) =>
            tree.GetRoot().DescendantNodes()
            .Where(_ => _.IsKind(SyntaxKind.RecordDeclaration))
            .OfType<RecordDeclarationSyntax>()
            .Where(_ => _.Modifiers.Any(SyntaxKind.PartialKeyword));

        static IEnumerable<AttributeSyntax> GetAllAttributes(RecordDeclarationSyntax record) =>
            record.AttributeLists.SelectMany(_ => _.Attributes);

        static bool TryGetBaseType(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes, out string baseType)
        {
            var baseTypes = GetBaseTypes(semantics, attributes);
            if (baseTypes.Length != 1)
            {
                baseType = default;
                return false;
            }
            baseType = baseTypes[0];
            return true;
        }

        static string[] GetBaseTypes(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes) =>
            attributes.SelectMany(attribute =>
                semantics.GetSymbolInfo(attribute).Symbol.ContainingType.AllInterfaces.Select(@interface =>
                {
                    var match = BaseTypeRegex.Match(@interface.ToDisplayString());
                    return match.Success ? match.Groups["type"].Value : null;
                }))
            .Where(_ => _ != null).Distinct().ToArray();

        static string GetNamespace(RecordDeclarationSyntax record)
        {
            var namespaces = FindParentNamespaces(record).Select(_ => _.Name).Reverse();
            return string.Join(".", namespaces);
        }

        static IEnumerable<NamespaceDeclarationSyntax> FindParentNamespaces(SyntaxNode node)
        {
            for (; node != null; node = node.Parent)
            {
                if (node is NamespaceDeclarationSyntax @namespace) yield return @namespace;
            }
        }

        static void AppendValidations(IndentedStringBuilder sourceBuilder, SemanticModel semantics, IEnumerable<AttributeSyntax> attributes, string baseType)
        {
            foreach (var validation in GetAllValidations(semantics, attributes, baseType))
            {
                var validationType = semantics.GetSymbolInfo(validation).Symbol.ContainingType;
                var args = validation?.ArgumentList?.Arguments.ToString() ?? "";
                sourceBuilder.AppendLine($"new {validationType.ToDisplayString()}({args}).Validate(value);");
            }
        }

        static IEnumerable<AttributeSyntax> GetAllValidations(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes, string baseType) =>
            attributes.Where(a =>
                semantics.GetSymbolInfo(a).Symbol.ContainingType.AllInterfaces.Any(i =>
                {
                    var match = ValidatedBaseTypeRegex.Match(i.ToDisplayString());
                    return match.Success && match.Groups["type"].Value == baseType;
                }));
    }
}
