﻿namespace StyleCop.Analyzers.LayoutRules
{
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.Diagnostics;

    /// <summary>
    /// Within a C# property, indexer or event, at least one of the child accessors is written on a single line, and at
    /// least one of the child accessors is written across multiple lines.
    /// </summary>
    /// <remarks>
    /// <para>A violation of this rule occurs when the accessors within a property, indexer or event are not
    /// consistently written on a single line or on multiple lines. This rule is intended to increase the readability of
    /// the code by requiring all of the accessors within an element to be formatted in the same way.</para>
    ///
    /// <para>For example, the following property would generate a violation of this rule, because one accessor is
    /// written on a single line while the other accessor snaps multiple lines.</para>
    ///
    /// <code language="csharp">
    /// public bool Enabled
    /// {
    ///     get { return this.enabled; }
    ///
    ///     set
    ///     {
    ///         this.enabled = value;
    ///     }
    /// }
    /// </code>
    ///
    /// <para>The violation can be avoided by placing both accessors on a single line, or expanding both accessors
    /// across multiple lines:</para>
    ///
    /// <code language="csharp">
    /// public bool Enabled
    /// {
    ///     get { return this.enabled; }
    ///     set { this.enabled = value; }
    /// }
    ///
    /// public bool Enabled
    /// {
    ///     get
    ///     {
    ///         return this.enabled;
    ///     }
    ///
    ///     set
    ///     {
    ///         this.enabled = value;
    ///     }
    /// }
    /// </code>
    /// </remarks>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SA1504AllAccessorsMustBeSingleLineOrMultiLine : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "SA1504";
        private const string Title = "All accessors must be single-line or multi-line";
        private const string MessageFormat = "TODO: Message format";
        private const string Category = "StyleCop.CSharp.LayoutRules";
        private const string Description = "Within a C# property, indexer or event, at least one of the child accessors is written on a single line, and at least one of the child accessors is written across multiple lines.";
        private const string HelpLink = "http://www.stylecop.com/docs/SA1504.html";

        private static readonly DiagnosticDescriptor Descriptor =
            new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, AnalyzerConstants.DisabledNoTests, Description, HelpLink);

        private static readonly ImmutableArray<DiagnosticDescriptor> supportedDiagnostics =
            ImmutableArray.Create(Descriptor);

        /// <inheritdoc/>
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
        {
            get
            {
                return supportedDiagnostics;
            }
        }

        /// <inheritdoc/>
        public override void Initialize(AnalysisContext context)
        {
            // TODO: Implement analysis
        }
    }
}
