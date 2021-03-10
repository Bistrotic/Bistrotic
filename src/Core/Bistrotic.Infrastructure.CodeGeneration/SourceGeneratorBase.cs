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

        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                string moduleName = context.GetMSBuildProperty("ModuleName");
                if (string.IsNullOrWhiteSpace(moduleName))
                {
                    moduleName = nameof(Bistrotic) + "Module";
                }
                string namespaceName = context.GetMSBuildProperty("RootNamespace");
                if (string.IsNullOrWhiteSpace(namespaceName))
                {
                    namespaceName = nameof(Bistrotic) + "." + moduleName;
                }
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