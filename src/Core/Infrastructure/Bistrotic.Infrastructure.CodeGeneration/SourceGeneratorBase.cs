namespace Bistrotic.Infrastructure.CodeGeneration
{
    using System;

    using Bistrotic.Infrastructure.CodeGeneration.Helpers;

    using Microsoft.CodeAnalysis;

#pragma warning disable CA1031 // Do not catch general exception types

    public abstract class SourceGeneratorBase : ISourceGenerator
    {
        private static readonly DiagnosticDescriptor BistroticCodeGenerationError = new(id: "BCG0001",
                                                                                              title: "Bistrotic code generation error",
                                                                                              messageFormat: "Couldn't not generate code with code generator '{0}'.\nError : {1}",
                                                                                              category: "Design",
                                                                                              DiagnosticSeverity.Error,
                                                                                              isEnabledByDefault: true);

        private static readonly DiagnosticDescriptor BistroticCodeGenerationInfo = new(id: "BCG0002",
                                                                                               title: "Bistrotic code generation",
                                                                                               messageFormat: "Generating code with '{0}'.",
                                                                                               category: "Design",
                                                                                               DiagnosticSeverity.Info,
                                                                                               isEnabledByDefault: true);

        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                string moduleName = context.GetMSBuildProperty("ModuleName");
                if (string.IsNullOrWhiteSpace(moduleName))
                {
                    moduleName = nameof(Bistrotic) + "Undefined";
                }
                string namespaceName = context.GetMSBuildProperty("RootNamespace");
                if (string.IsNullOrWhiteSpace(namespaceName))
                {
                    namespaceName = nameof(Bistrotic) + "." + moduleName;
                }
                context.ReportDiagnostic(Diagnostic.Create(BistroticCodeGenerationInfo, Location.None, GetType().Name));
                Execute(context, moduleName, namespaceName);
            }
            catch (Exception e)
            {
                context.ReportDiagnostic(Diagnostic.Create(BistroticCodeGenerationError, Location.None, GetType().Name, e.Message));
            }
        }

        public virtual void Initialize(GeneratorInitializationContext context)
        {
        }

        protected abstract void Execute(GeneratorExecutionContext context, string moduleName, string namespaceName);
    }
}