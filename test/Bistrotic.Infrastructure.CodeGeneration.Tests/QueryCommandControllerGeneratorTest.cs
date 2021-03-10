namespace Bistrotic.Infrastructure.CodeGeneration.Tests
{
    using System.Linq;
    using System.Reflection;

    using Bistrotic.Infrastructure.CodeGeneration.Generators.WebApi;

    using FluentAssertions;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    using Xunit;

    public class QueryCommandControllerGeneratorTest
    {
        [Fact]
        public void Generate_command_action()
        {
            // Create the 'input' compilation that the generator will act on
            Compilation inputCompilation = CreateCompilation(@"
namespace MyCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
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
            var outputDiagnostics = outputCompilation.GetDiagnostics();
            outputDiagnostics.IsEmpty.Should().BeTrue(); // verify the compilation with the added source has no diagnostics

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
            => CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                new[] { MetadataReference.CreateFromFile(typeof(Binder).GetTypeInfo().Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
    }
}