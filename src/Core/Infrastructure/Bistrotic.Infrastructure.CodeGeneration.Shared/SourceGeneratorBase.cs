namespace Bistrotic.Infrastructure.CodeGeneration
{
    using System;

    using Bistrotic.Infrastructure.CodeGeneration.Abstractions.Diagnostics;
    using Bistrotic.Infrastructure.CodeGeneration.Helpers;

    using Microsoft.CodeAnalysis;

#pragma warning disable CA1031 // Do not catch general exception types

    public abstract class SourceGeneratorBase : ISourceGenerator
    {
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
                context.ReportDiagnostic(Diagnostic.Create(DiagnosticMessages.CodeGenerationInfo, Location.None, GetType().Name));
                Execute(context, moduleName, namespaceName);
            }
            catch (Exception e)
            {
                context.ReportDiagnostic(Diagnostic.Create(DiagnosticMessages.CodeGenerationError, Location.None, GetType().Name, e.Message));
            }
        }

        public virtual void Initialize(GeneratorInitializationContext context)
        {
        }

        protected abstract void Execute(GeneratorExecutionContext context, string moduleName, string namespaceName);
    }
}