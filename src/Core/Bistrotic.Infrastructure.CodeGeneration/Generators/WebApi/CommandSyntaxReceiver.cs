namespace Bistrotic.Infrastructure.CodeGeneration.Generators.WebApi
{
    using System.Collections.Generic;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal class CommandSyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> CandidateProxies { get; } = new List<ClassDeclarationSyntax>();

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classSyntax && !IsAbstract(classSyntax) && HasInterface("Bistrotic.Application.Commands.ICommand", classSyntax))
            {
                CandidateProxies.Add(classSyntax);
            }
        }

        private static bool Implements(INamedTypeSymbol symbol, ITypeSymbol type)
        {
            foreach (var s in symbol.AllInterfaces)
            {
                if (SymbolEqualityComparer.Default.Equals(s, type))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsAbstract(ClassDeclarationSyntax node)
        {
            foreach (var modifier in node.Modifiers)
            {
                if (modifier.IsKind(SyntaxKind.AbstractKeyword))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasInterface(string commandInterfaceFullName, ClassDeclarationSyntax classSyntax)
        {
            var types = classSyntax.BaseList?.Types;
            if (types != null)
            {
                foreach (var t in types)
                {
                }
            }
            return false;
        }
    }
}