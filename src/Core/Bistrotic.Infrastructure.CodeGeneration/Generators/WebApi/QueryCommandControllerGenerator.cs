namespace Bistrotic.Infrastructure.CodeGeneration.Generators.WebApi
{
    using System.Text;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Text;

    using Scriban;

    [Generator]
    public sealed class QueryCommandControllerGenerator : SourceGeneratorBase
    {
        public override void Initialize(GeneratorInitializationContext context)
        {
            base.Initialize(context);
            context.RegisterForSyntaxNotifications(() => new CommandSyntaxReceiver());
        }

        protected override void Execute(GeneratorExecutionContext context, string moduleName, string namespaceName)
        {
            var className = moduleName + "ApiController";
            if (context.SyntaxReceiver is CommandSyntaxReceiver commandSyntaxReciver)
            {
                foreach (var proxy in commandSyntaxReciver.CandidateProxies)
                {
                }
            }
            var template = Template.Parse(QueryCommandControllerTemplate.Value);
            var result = template.Render(new { ModuleName = moduleName, Namespace = namespaceName });
            var sourceText = SourceText.From(result, Encoding.UTF8);
            context.AddSource(className + ".cs", sourceText);
        }
    }
}