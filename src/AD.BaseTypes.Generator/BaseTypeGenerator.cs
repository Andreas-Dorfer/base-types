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

                var allPartialRecords =
                    tree.GetRoot().DescendantNodes()
                    .Where(_ => _.IsKind(SyntaxKind.RecordDeclaration))
                    .OfType<RecordDeclarationSyntax>()
                    .Where(_ => _.Modifiers.Any(SyntaxKind.PartialKeyword));
                foreach (var record in allPartialRecords)
                {
                    var attributes = record.AttributeLists.SelectMany(_ => _.Attributes);
                    var baseTypes = attributes.SelectMany(a =>
                        semantics.GetSymbolInfo(a).Symbol.ContainingType.AllInterfaces.Select(i =>
                        {
                            var match = BaseTypeRegex.Match(i.ToDisplayString());
                            return match.Success ?
                                match.Groups["type"].Value :
                                null;
                        })).Where(_ => _ != null).Distinct().ToArray();
                    if (baseTypes.Length != 1) continue;

                    var validations = attributes.Where(a =>
                        semantics.GetSymbolInfo(a).Symbol.ContainingType.AllInterfaces.Any(i =>
                        {
                            var match = ValidatedBaseTypeRegex.Match(i.ToDisplayString());
                            return match.Success && match.Groups["type"].Value == baseTypes[0];
                        }));

                    var validationBuilder = new StringBuilder();
                    foreach (var validation in validations)
                    {
                        var validationType = semantics.GetSymbolInfo(validation).Symbol.ContainingType;
                        validationBuilder.AppendLine($"new {validationType.ToDisplayString()}().Validate(value);");
                    }

                    var @namespace = GetNamespace(record);
                    var source = string.IsNullOrEmpty(@namespace) ?
$@"partial record {record.Identifier.Text}
{{
    public {record.Identifier.Text}({baseTypes[0]} value)
    {{
        {validationBuilder}
        this.Value = value;
    }}

    public {baseTypes[0]} Value {{ get; }}
    public override string ToString() => Value.ToString();
    public static implicit operator {baseTypes[0]}({record.Identifier.Text} x) => x.Value;
}}" :
$@"namespace {@namespace}
{{
    partial record {record.Identifier.Text}
    {{
        public {record.Identifier.Text}({baseTypes[0]} value)
        {{
            {validationBuilder}
            this.Value = value;
        }}

        public {baseTypes[0]} Value {{ get; }}
        public override string ToString() => Value.ToString();
        public static implicit operator {baseTypes[0]}({record.Identifier.Text} x) => x.Value;
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

        public void Initialize(GeneratorInitializationContext context)
        {
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
