using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AD.BaseTypes.Generator
{
    [Generator]
    public class BaseTypeGenerator : ISourceGenerator
    {
        static readonly Regex BaseTypeRegex = new Regex("^AD.BaseTypes.IBaseType<(?<type>.+)>$");
        static readonly Regex ValidatedBaseTypeRegex = new Regex("^AD.BaseTypes.IValidatedBaseType<(?<type>.+)>$");

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
                    var attributes = record.AttributeLists.SelectMany(_ => _.Attributes);

                    if (!TryGetBaseType(semantics, attributes, out var baseType)) continue;

                    var validations = GetAllValidations(semantics, attributes, baseType);
                    var validationsBuilder = BuildValidations(semantics, validations);

                    var @namespace = GetNamespace(record);
                    var source = string.IsNullOrEmpty(@namespace) ?
$@"partial record {record.Identifier.Text} : System.IComparable<{record.Identifier.Text}>, System.IComparable, AD.BaseTypes.IValue<{baseType}>
{{
    public {record.Identifier.Text}({baseType} value)
    {{
        {validationsBuilder}
        this.Value = value;
    }}

    public {baseType} Value {{ get; }}
    public override string ToString() => Value.ToString();
    public int CompareTo(object obj) => CompareTo(obj as {record.Identifier.Text});
    public int CompareTo({record.Identifier.Text} other) => other is null ? 1 : System.Collections.Generic.Comparer<{baseType}>.Default.Compare(Value, other.Value);
    public static implicit operator {baseType}({record.Identifier.Text} item) => item.Value;
    public static {record.Identifier.Text} Create({baseType} value) => new(value);
}}" :
$@"namespace {@namespace}
{{
    partial record {record.Identifier.Text} : System.IComparable<{record.Identifier.Text}>, System.IComparable, AD.BaseTypes.IValue<{baseType}>
    {{
        public {record.Identifier.Text}({baseType} value)
        {{
            {validationsBuilder}
            this.Value = value;
        }}

        public {baseType} Value {{ get; }}
        public override string ToString() => Value.ToString();
        public int CompareTo(object obj) => CompareTo(obj as {record.Identifier.Text});
        public int CompareTo({record.Identifier.Text} other) => other is null ? 1 : System.Collections.Generic.Comparer<{baseType}>.Default.Compare(Value, other.Value);
        public static implicit operator {baseType}({record.Identifier.Text} item) => item.Value;
        public static {record.Identifier.Text} Create({baseType} value) => new(value);
    }}
}}";
                    sources.Add(source);
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

        static bool TryGetBaseType(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes, out string baseType)
        {
            var baseTypes = GetBaseTypeAttributes(semantics, attributes);
            if (baseTypes.Length != 1)
            {
                baseType = default;
                return false;
            }
            baseType = baseTypes[0];
            return true;
        }

        static string[] GetBaseTypeAttributes(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes) =>
            attributes.SelectMany(attribute =>
                semantics.GetSymbolInfo(attribute).Symbol.ContainingType.AllInterfaces.Select(@interface =>
                {
                    var match = BaseTypeRegex.Match(@interface.ToDisplayString());
                    return match.Success ? match.Groups["type"].Value : null;
                }))
            .Where(_ => _ != null).Distinct().ToArray();

        static IEnumerable<AttributeSyntax> GetAllValidations(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes, string baseType) =>
            attributes.Where(a =>
                semantics.GetSymbolInfo(a).Symbol.ContainingType.AllInterfaces.Any(i =>
                {
                    var match = ValidatedBaseTypeRegex.Match(i.ToDisplayString());
                    return match.Success && match.Groups["type"].Value == baseType;
                }));

        static StringBuilder BuildValidations(SemanticModel semantics, IEnumerable<AttributeSyntax> validations)
        {
            var validationsBuilder = new StringBuilder();
            foreach (var validation in validations)
            {
                var validationType = semantics.GetSymbolInfo(validation).Symbol.ContainingType;
                var args = validation?.ArgumentList?.Arguments.ToString() ?? "";
                validationsBuilder.AppendLine($"new {validationType.ToDisplayString()}({args}).Validate(value);");
            }
            return validationsBuilder;
        }

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
    }
}
