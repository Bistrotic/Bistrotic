namespace Bistrotic.Infrastructure.CodeGeneration.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.Contracts.Commands;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Infrastructure.CodeGeneration.Generators.WebApi;
    using Bistrotic.Infrastructure.CodeGeneration.Tests.Fixtures;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Controllers;

    using FluentAssertions;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.Extensions.Logging;

    using Xunit;

    public class QueryCommandControllerGeneratorTest
    {
        [Fact]
        public void Generate_command_action()
        {
            // Create the 'input' compilation that the generator will act on
            Compilation inputCompilation = CreateCompilation(@"
namespace MyCode.Commands
{
    using Bistrotic.Application.Commands;

    [ApiCommand]
    public class MyTestCommand
    {
        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
    }}
");
            // directly create an instance of the generator (Note: in the compiler this is loaded
            // from an assembly, and created via reflection at runtime)
            var generator = new QueryCommandControllerGenerator();

            // Create the driver that will control the generation, passing in our generator
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

            // Run the generation pass (Note: the generator driver itself is immutable, and all
            // calls return an updated version of the driver that you should use for subsequent calls)
            driver = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out var outputCompilation, out var diagnostics);

            // We can now assert things about the resulting compilation:
            diagnostics.IsEmpty.Should().BeTrue(); // there were no diagnostics created by the generators
            outputCompilation.SyntaxTrees.Should().HaveCount(2); // we have two syntax trees, the original 'user' provided one, and the one added by the generator
            var syntaxTree = outputCompilation.SyntaxTrees.Skip(1).First();
            var text = syntaxTree.GetText().ToString();
            text.Should().NotBeNullOrWhiteSpace();
            foreach (var diag in outputCompilation.GetDiagnostics())
            {
                diag.GetMessage().Should().BeNullOrWhiteSpace(); // verify the compilation with the added source has no diagnostics
            }

            // Or we can look at the results directly:
            GeneratorDriverRunResult runResult = driver.GetRunResult();

            // The runResult contains the combined results of all generators passed to the driver
            runResult.GeneratedTrees.Length.Should().Be(1);
            runResult.Diagnostics.IsEmpty.Should().BeTrue();

            // Or you can access the individual results on a by-generator basis
            GeneratorRunResult generatorResult = runResult.Results[0];
            generatorResult.Generator.Should().Be(generator);
            generatorResult.Diagnostics.IsEmpty.Should().BeTrue();
            generatorResult.GeneratedSources.Length.Should().Be(1);
            generatorResult.Exception.Should().BeNull();
        }

        private static Compilation CreateCompilation(string source)
        {
            byte[] netstandard = typeof(QueryCommandControllerGeneratorTest).Assembly.GetResource("netstandard20.netstandard");
            var references = new List<PortableExecutableReference>
            {
                AssemblyMetadata.CreateFromImage(netstandard).GetReference(display: "netstandard (netstandard20)"),
                MetadataReference.CreateFromFile(typeof(Object).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Attribute).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(CommandAttribute).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(MessageId).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(IQuery).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(QueryCommandControllerBase).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ControllerBase).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ApiControllerAttribute).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(RouteAttribute).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(AuthorizeAttribute).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ApiControllerAttribute).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(IQueryBus).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(IMessageFactory).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ILogger).GetTypeInfo().Assembly.Location),
                MetadataReference.CreateFromFile(typeof(TestCommand).GetTypeInfo().Assembly.Location)
            };
            Assembly
                .GetEntryAssembly()?
                .GetReferencedAssemblies()
                .ToList()
                .ForEach(a => references.Add(MetadataReference.CreateFromFile(Assembly.Load(a).Location)));
            return CSharpCompilation
                .Create("compilation")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddSyntaxTrees(new[] { CSharpSyntaxTree.ParseText(source) })
                .AddReferences(references);
        }
    }
}