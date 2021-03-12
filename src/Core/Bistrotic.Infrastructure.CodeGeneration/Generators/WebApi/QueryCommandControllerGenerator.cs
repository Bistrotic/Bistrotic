namespace Bistrotic.Infrastructure.CodeGeneration.Generators.WebApi
{
    using System.Collections.Generic;
    using System.Linq;
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
            context.RegisterForSyntaxNotifications(() => new QueryCommandSyntaxReceiver());
        }

        protected override void Execute(GeneratorExecutionContext context, string moduleName, string namespaceName)
        {
            if (context.SyntaxReceiver is QueryCommandSyntaxReceiver receiver)
            {
                var usings = new List<string>()
                {
                    "Bistrotic.Application.Messages",
                    "Bistrotic.Application.Queries",
                    "Bistrotic.Infrastructure.WebServer.Controllers",
                    "Microsoft.AspNetCore.Authorization",
                    "Microsoft.AspNetCore.Mvc",
                    "Microsoft.Extensions.Logging",
                };
                usings.AddRange(receiver.Messages
                        .Where(p => string.IsNullOrWhiteSpace(p.Namespace))
                        .Select(p => p.Namespace)
                        .Distinct());
                var className = moduleName + "ApiController";
                var template = Template.Parse(QueryCommandControllerTemplate.Value);
                var result = template.Render(new
                {
                    ModuleName = moduleName,
                    Namespace = namespaceName,
                    Queries = receiver.Messages.OfType<QueryDefinition>().ToList(),
                    Commands = receiver.Messages.OfType<CommandDefinition>().ToList(),
                    Usings = usings.Distinct().OrderBy(p => p).ToList()
                });
                var sourceText = SourceText.From(result, Encoding.UTF8);
                context.AddSource(className + ".cs", sourceText);
            }
        }
    }
}