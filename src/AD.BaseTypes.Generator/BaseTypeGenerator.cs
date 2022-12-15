﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text.RegularExpressions;

namespace AD.BaseTypes.Generator
{
    [Generator]
    public class BaseTypeGenerator : ISourceGenerator
    {
        static readonly Regex
            BaseTypeDefinitionRegex = new("^AD.BaseTypes.IBaseTypeDefinition<(?<type>.+)>$"),
            BaseTypeValidatedRegex = new("^AD.BaseTypes.IBaseTypeValidation<(?<type>.+)>$"),
            StaticBaseTypeValidatedRegex = new("^AD.BaseTypes.IStaticBaseTypeValidation<(?<type>.+)>$");
        const string
            BaseTypeAttributeName = "AD.BaseTypes.BaseTypeAttribute",
            Cast_Explicit = "Explicit",
            Cast_Implicit = "Implicit",
            Cast_None = "None";

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new PartialRecordsWithAttributesReceiver());
        }

        class PartialRecordsWithAttributesReceiver : ISyntaxReceiver
        {
            public List<RecordDeclarationSyntax> Records { get; } = new List<RecordDeclarationSyntax>();

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is RecordDeclarationSyntax record &&
                    record.Modifiers.Any(SyntaxKind.PartialKeyword) &&
                    GetAllAttributes(record).Any())
                {
                    Records.Add(record);
                }
            }
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var config = ReadConfig(context);

            foreach (var record in (context.SyntaxReceiver as PartialRecordsWithAttributesReceiver)?.Records ?? Enumerable.Empty<RecordDeclarationSyntax>())
            {
                var semantics = context.Compilation.GetSemanticModel(record.SyntaxTree);

                var attributes = GetAllAttributes(record);
                if (!TryGetBaseType(semantics, attributes, out var baseType)) continue;
                var isStruct = record.ClassOrStructKeyword.IsKind(SyntaxKind.StructKeyword);
                var validations = GetAllValidations(semantics, attributes, baseType).ToList();
                if (isStruct && validations.Count > 0) continue;

                var @sealed = isStruct ? "" : "sealed ";
                var recordType = isStruct ? " struct" : "";

                var sourceBuilder = new IndentedStringBuilder();

                sourceBuilder.AppendLine("// <auto-generated> This file was generated by AD.BaseTypes. </auto-generated>");
                sourceBuilder.AppendLine("#nullable enable");

                var @namespace = GetNamespace(record, semantics);
                if (!string.IsNullOrEmpty(@namespace))
                {
                    //namespace
                    sourceBuilder.AppendLine($"namespace {@namespace};");
                    sourceBuilder.AppendLine("");
                }

                //record start
                var recordName = record.Identifier.Text;
                if (!isStruct && config?.AllowNullLiteral == false)
                {
                    sourceBuilder.AppendLine("[Microsoft.FSharp.Core.AllowNullLiteral(false)]");
                }
                sourceBuilder.AppendLine($"[System.ComponentModel.TypeConverter(typeof(AD.BaseTypes.Converters.BaseTypeTypeConverter<{recordName}, {baseType}>))]");
                sourceBuilder.AppendLine($"[System.Text.Json.Serialization.JsonConverter(typeof(AD.BaseTypes.Json.BaseTypeJsonConverter<{recordName}, {baseType}>))]");
                sourceBuilder.AppendLine($"{@sealed}partial record{recordType} {recordName} : System.IComparable<{recordName}>, System.IComparable, AD.BaseTypes.IBaseType<{recordName}, {baseType}>");
                sourceBuilder.AppendLine("{");
                sourceBuilder.IncreaseIndent();
                //*****

                sourceBuilder.AppendLine($"readonly {baseType} value;");

                //constructor start
                AppendSummaryComment(sourceBuilder, $"Creates the <see cref=\"{recordName}\"/>.");
                AppendParamComment(sourceBuilder, "value", $"The underlying <see cref=\"{baseType}\"/>.");
                AppendExceptionComment(sourceBuilder, "System.ArgumentException", "The parameter <paramref name=\"value\"/> is invalid.");
                sourceBuilder.AppendLine($"public {recordName}({baseType} value)");
                sourceBuilder.AppendLine("{");
                sourceBuilder.IncreaseIndent();
                //*****

                AppendValidations(sourceBuilder, semantics, validations);
                sourceBuilder.AppendLine("this.value = value;");

                //constructor end
                sourceBuilder.DecreaseIndent();
                sourceBuilder.AppendLine("}");
                //*****

                sourceBuilder.AppendLine($"{baseType} AD.BaseTypes.IBaseType<{baseType}>.Value => value;");
                AppendInheritDoc(sourceBuilder);
                sourceBuilder.AppendLine("public override string ToString() => value.ToString();");
                AppendInheritDoc(sourceBuilder);
                if (isStruct)
                {
                    sourceBuilder.AppendLine($"public int CompareTo(object? obj)");
                    sourceBuilder.AppendLine("{");
                    sourceBuilder.IncreaseIndent();
                    sourceBuilder.AppendLine($"if(obj is not {recordName} other) return 1;");
                    sourceBuilder.AppendLine("return CompareTo(other);");
                    sourceBuilder.DecreaseIndent();
                    sourceBuilder.AppendLine("}");
                }
                else
                {
                    sourceBuilder.AppendLine($"public int CompareTo(object? obj) => CompareTo(obj as {recordName});");
                }
                AppendInheritDoc(sourceBuilder);
                if (isStruct)
                {
                    sourceBuilder.AppendLine($"public int CompareTo({recordName} other) => System.Collections.Generic.Comparer<{baseType}>.Default.Compare(value, other.value);");
                }
                else
                {
                    sourceBuilder.AppendLine($"public int CompareTo({recordName}? other) => other is null ? 1 : System.Collections.Generic.Comparer<{baseType}>.Default.Compare(value, other.value);");
                }
                AppendCast(sourceBuilder, semantics, attributes, baseType, recordName);
                AppendSummaryComment(sourceBuilder, $"Creates the <see cref=\"{recordName}\"/>.");
                AppendParamComment(sourceBuilder, "value", $"The underlying <see cref=\"{baseType}\"/>.");
                AppendExceptionComment(sourceBuilder, "System.ArgumentException", "The parameter <paramref name=\"value\"/> is invalid.");
                AppendReturnsComment(sourceBuilder, $"The created <see cref=\"{recordName}\"/>.");
                sourceBuilder.AppendLine($"public static {recordName} From({baseType} value) => new(value);");
                if (validations.Count > 0)
                {
                    AppendSummaryComment(sourceBuilder, $"Tries to create the <see cref=\"{recordName}\"/>.");
                    AppendParamComment(sourceBuilder, "value", $"The underlying <see cref=\"{baseType}\"/>.");
                    AppendParamComment(sourceBuilder, "baseType", $"The created <see cref=\"{recordName}\"/>.");
                    AppendParamComment(sourceBuilder, "errorMessage", "The error message.");
                    AppendReturnsComment(sourceBuilder, $"True, if the <see cref=\"{recordName}\"/> is created.");
                    sourceBuilder.AppendLine($"public static bool TryFrom({baseType} value, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out {recordName} baseType, [System.Diagnostics.CodeAnalysis.MaybeNullWhen(true)] out string errorMessage) =>");
                    sourceBuilder.IncreaseIndent();
                    sourceBuilder.AppendLine($"AD.BaseTypes.BaseType<{recordName}, {baseType}>.TryFrom(value, out baseType, out errorMessage);");
                    sourceBuilder.DecreaseIndent();
                }

                //record end
                sourceBuilder.DecreaseIndent();
                sourceBuilder.AppendLine("}");
                //*****

                var fileHint = !string.IsNullOrEmpty(@namespace) ? $"{@namespace}.{recordName}" : recordName;
                context.AddSource($"{fileHint}.g", sourceBuilder.ToString());
            }
        }

        static readonly Regex ConfigKeyValueRegex = new(@"""(?<key>.+)""\s*:\s*(?<value>.+);?");

        static Config? ReadConfig(GeneratorExecutionContext context)
        {
            var configFile = context.AdditionalFiles.FirstOrDefault(_ => _.Path.EndsWith("AD.BaseTypes.Generator.json"));
            if (configFile == null) return default;
            var text = File.ReadAllText(configFile.Path);

            var config = new Config();
            foreach (Match match in ConfigKeyValueRegex.Matches(text))
            {
                switch (match.Groups["key"].Value)
                {
                    case nameof(config.AllowNullLiteral):
                        if (bool.TryParse(match.Groups["value"].Value, out var allowNullLiteral))
                        {
                            config.AllowNullLiteral = allowNullLiteral;
                        }
                        break;
                }
            }
            return config;
        }

        static IEnumerable<AttributeSyntax> GetAllAttributes(RecordDeclarationSyntax record) =>
            record.AttributeLists.SelectMany(_ => _.Attributes);

        static bool TryGetBaseType(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes, out string baseType)
        {
            var baseTypes = GetBaseTypes(semantics, attributes);
            if (baseTypes.Length != 1)
            {
                baseType = default!;
                return false;
            }
            baseType = baseTypes[0];
            return true;
        }

        static string[] GetBaseTypes(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes) =>
            attributes.SelectMany(attribute =>
                semantics.GetSymbolInfo(attribute).Symbol?.ContainingType.AllInterfaces.Select(@interface =>
                {
                    var match = BaseTypeDefinitionRegex.Match(@interface.ToDisplayString());
                    return match.Success ? match.Groups["type"].Value : null;
                }) ?? Enumerable.Empty<string>())
            .Where(_ => _ != null).Distinct().ToArray()!;

        static string GetNamespace(RecordDeclarationSyntax record, SemanticModel semantics) =>
            semantics.GetDeclaredSymbol(record)?.ContainingNamespace?.ToDisplayString() ?? "";

        static void AppendSummaryComment(IndentedStringBuilder sourceBuilder, string summary)
        {
            sourceBuilder.AppendLine("/// <summary>");
            sourceBuilder.AppendLine($"/// {summary}");
            sourceBuilder.AppendLine("/// </summary>");
        }

        static void AppendParamComment(IndentedStringBuilder sourceBuilder, string name, string comment) =>
            sourceBuilder.AppendLine($"/// <param name=\"{name}\">{comment}</param>");

        static void AppendExceptionComment(IndentedStringBuilder sourceBuilder, string name, string comment) =>
            sourceBuilder.AppendLine($"/// <exception cref=\"{name}\">{comment}</exception>");

        static void AppendInheritDoc(IndentedStringBuilder sourceBuilder) =>
            sourceBuilder.AppendLine("/// <inheritdoc/>");

        static void AppendReturnsComment(IndentedStringBuilder sourceBuilder, string comment) =>
            sourceBuilder.AppendLine($"/// <returns>{comment}</returns>");

        static void AppendValidations(IndentedStringBuilder sourceBuilder, SemanticModel semantics, IEnumerable<(AttributeSyntax, bool IsStatic)> validations)
        {
            foreach (var validation in validations)
            {
                var (attribute, isStatic) = validation;
                var validationType = semantics.GetSymbolInfo(attribute).Symbol?.ContainingType;
                if (validationType is null) continue;
                var args = attribute?.ArgumentList?.Arguments;
                var argsText = args?.ToString() ?? "";
                if (isStatic)
                {
                    if (args?.Count > 0)
                    {
                        sourceBuilder.AppendLine($"{validationType.ToDisplayString()}.Validate(value, {argsText});");
                    }
                    else
                    {
                        sourceBuilder.AppendLine($"{validationType.ToDisplayString()}.Validate(value);");
                    }
                }
                else
                {
                    sourceBuilder.AppendLine($"new {validationType.ToDisplayString()}({argsText}).Validate(value);");
                }
            }
        }

        static void AppendCast(IndentedStringBuilder sourceBuilder, SemanticModel semantics, IEnumerable<AttributeSyntax> attributes, string baseType, string recordName)
        {
            switch (GetCast(semantics, attributes))
            {
                default:
                case Cast_Explicit:
                    AppendComment();
                    sourceBuilder.AppendLine($"public static explicit operator {baseType}({recordName} baseType) => baseType.value;");
                    break;
                case Cast_Implicit:
                    AppendComment();
                    sourceBuilder.AppendLine($"public static implicit operator {baseType}({recordName} baseType) => baseType.value;");
                    break;
                case Cast_None:
                    break;
            }

            void AppendComment()
            {
                AppendSummaryComment(sourceBuilder, $"Casts the <see cref=\"{recordName}\"/> to <see cref=\"{baseType}\"/>.");
                AppendParamComment(sourceBuilder, "baseType", $"The <see cref=\"{recordName}\"/> to cast.");
                AppendReturnsComment(sourceBuilder, $"The underlying <see cref=\"{baseType}\"/>.");
            }
        }

        static string? GetCast(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes)
        {
            var configs = attributes.Where(attribute => semantics.GetSymbolInfo(attribute).Symbol?.ContainingType.ToDisplayString() == BaseTypeAttributeName).ToArray();
            if (configs.Length != 1) return null;
            var args = configs[0].ArgumentList?.Arguments;
            if (args is null) return null;
            if (args.Value.Count != 1) return null;

            if (args.Value[0].Expression is not MemberAccessExpressionSyntax expression) return null;

            return expression.Name.Identifier.Text;
        }

        static IEnumerable<(AttributeSyntax, bool IsStatic)> GetAllValidations(SemanticModel semantics, IEnumerable<AttributeSyntax> attributes, string baseType) =>
            attributes.Select(a =>
            {
                foreach (var i in semantics.GetSymbolInfo(a).Symbol?.ContainingType.AllInterfaces ?? Enumerable.Empty<INamedTypeSymbol>())
                {
                    var validationMatch = BaseTypeValidatedRegex.Match(i.ToDisplayString());
                    if (validationMatch.Success && validationMatch.Groups["type"].Value == baseType) return (a, false);

                    var staticMatch = StaticBaseTypeValidatedRegex.Match(i.ToDisplayString());
                    if (staticMatch.Success && staticMatch.Groups["type"].Value == baseType) return (a, true);
                }
                return default;
            }).Where(_ => _.a != null);
    }
}
