﻿namespace StyleCop.Analyzers.Helpers
{
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    internal class TypeDeclarationSyntaxHelper
    {
        /// <summary>
        /// Adds a modifier token for <paramref name="modifierKeyword"/> to the beginning of
        /// <paramref name="modifiers"/>. The trivia for the new modifier and the trivia for the token that follows it
        /// are updated to ensure that the new modifier is placed immediately before the syntax token that follows it,
        /// separated by exactly one space.
        /// </summary>
        /// <typeparam name="T">The type of syntax node which follows the modifier list.</typeparam>
        /// <param name="modifiers">The existing modifiers. This may be empty if no modifiers are present.</param>
        /// <param name="leadingTriviaNode">The syntax node which follows the modifiers. The trivia for this node is
        /// updated if (and only if) the existing <paramref name="modifiers"/> list is empty.</param>
        /// <param name="modifierKeyword">The modifier keyword to add.</param>
        /// <returns>A <see cref="SyntaxTokenList"/> representing the original modifiers (if any) with the addition of a
        /// modifier of the specified <paramref name="modifierKeyword"/> at the beginning of the list.</returns>
        internal static SyntaxTokenList AddModifier<T>(SyntaxTokenList modifiers, ref T leadingTriviaNode, SyntaxKind modifierKeyword)
            where T : SyntaxNode
        {
            SyntaxToken modifier = SyntaxFactory.Token(modifierKeyword);
            if (modifiers.Count > 0)
            {
                modifier = modifier.WithLeadingTrivia(modifiers[0].LeadingTrivia);
                modifiers = modifiers.Replace(modifiers[0], modifiers[0].WithLeadingTrivia(SyntaxFactory.ElasticSpace));
                modifiers = modifiers.Insert(0, modifier);
            }
            else
            {
                modifiers = SyntaxTokenList.Create(modifier.WithLeadingTrivia(leadingTriviaNode.GetLeadingTrivia()));
                leadingTriviaNode = leadingTriviaNode.WithLeadingTrivia(SyntaxFactory.ElasticSpace);
            }

            return modifiers;
        }

        /// <summary>
        /// Adds a modifier token for <paramref name="modifierKeyword"/> to the beginning of
        /// <paramref name="modifiers"/>. The trivia for the new modifier and the trivia for the token that follows it
        /// are updated to ensure that the new modifier is placed immediately before the syntax token that follows it,
        /// separated by exactly one space.
        /// </summary>
        /// <param name="modifiers">The existing modifiers. This may be empty if no modifiers are present.</param>
        /// <param name="leadingTriviaToken">The syntax token which follows the modifiers. The trivia for this token is
        /// updated if (and only if) the existing <paramref name="modifiers"/> list is empty.</param>
        /// <param name="modifierKeyword">The modifier keyword to add.</param>
        /// <returns>A <see cref="SyntaxTokenList"/> representing the original modifiers (if any) with the addition of a
        /// modifier of the specified <paramref name="modifierKeyword"/> at the beginning of the list.</returns>
        internal static SyntaxTokenList AddModifier(SyntaxTokenList modifiers, ref SyntaxToken leadingTriviaToken, SyntaxKind modifierKeyword)
        {
            SyntaxToken modifier = SyntaxFactory.Token(modifierKeyword);
            if (modifiers.Count > 0)
            {
                modifier = modifier.WithLeadingTrivia(modifiers[0].LeadingTrivia);
                modifiers = modifiers.Replace(modifiers[0], modifiers[0].WithLeadingTrivia(SyntaxFactory.ElasticSpace));
                modifiers = modifiers.Insert(0, modifier);
            }
            else
            {
                modifiers = SyntaxTokenList.Create(modifier.WithLeadingTrivia(leadingTriviaToken.LeadingTrivia));
                leadingTriviaToken = leadingTriviaToken.WithLeadingTrivia(SyntaxFactory.ElasticSpace);
            }

            return modifiers;
        }
    }
}
