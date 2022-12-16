using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace AD.BaseTypes.Generator;

static class Utils
{
    public static string GetNamespace(TypeDeclarationSyntax type, SemanticModel semantics) =>
        semantics.GetDeclaredSymbol(type)?.ContainingNamespace?.ToDisplayString() ?? "";
}
