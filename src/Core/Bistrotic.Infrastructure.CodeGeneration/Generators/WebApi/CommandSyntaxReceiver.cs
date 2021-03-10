namespace Bistrotic.Infrastructure.CodeGeneration.Generators.WebApi
{
    using System.Collections.Generic;

    using Microsoft.CodeAnalysis;

    internal class CommandSyntaxReceiver : ISyntaxReceiver
    {
        public List<SyntaxNode> CandidateProxies { get; } = new List<SyntaxNode>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is SyntaxNode classSyntax && classSyntax.ContainsDirectives)
            {
                CandidateProxies.Add(classSyntax);
            }
        }
    }
}