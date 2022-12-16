using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System.Text.RegularExpressions;

namespace AD.BaseTypes.Generator;

[Generator]
public class StaticBaseTypeValidationGenerator : ISourceGenerator
{
    static readonly Regex StaticBaseTypeValidationAttributeRegex = new("^AD.BaseTypes.StaticBaseTypeValidationAttribute<(?<type>.+)>$", RegexOptions.Compiled);

    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new StaticBaseTypeValidationsReceiver());
    }

    class StaticBaseTypeValidationsReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax @class &&
                @class.Modifiers.Any(SyntaxKind.PartialKeyword) &&
                @class.AttributeLists.SelectMany(_ => _.Attributes).Any())
            {
                Classes.Add(@class);
            }
        }
    }

    public void Execute(GeneratorExecutionContext context)
    {
        foreach (var @class in (context.SyntaxReceiver as StaticBaseTypeValidationsReceiver)?.Classes ?? Enumerable.Empty<ClassDeclarationSyntax>())
        {
            var semantics = context.Compilation.GetSemanticModel(@class.SyntaxTree);
            var attributes = GetAllStaticBaseTypeValidationAttributes(semantics, @class).ToArray();
            if (attributes.Length != 1) continue;
        }
    }

    static IEnumerable<string> GetAllStaticBaseTypeValidationAttributes(SemanticModel semantics, ClassDeclarationSyntax @class) =>
        @class.AttributeLists.SelectMany(_ => _.Attributes).Select(a =>
        {
            var match = StaticBaseTypeValidationAttributeRegex.Match(semantics.GetSymbolInfo(a).Symbol?.ToDisplayString() ?? "");
            return match.Success ? match.Groups["type"].Value : null;
        }).Where(_ => _ is not null).OfType<string>().Distinct();

}
