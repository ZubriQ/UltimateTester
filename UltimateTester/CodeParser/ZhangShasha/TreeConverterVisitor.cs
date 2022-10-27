using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CodeParser.ANTLR4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParser.ZhangShasha
{
    internal partial class TreeConverterVisitor : CSharpParserBaseVisitor<Node>
    {
        /// <summary>
        /// Recursively creates a tree.
        /// </summary>
        public override Node VisitCompilation_unit([NotNull] CSharpParser.Compilation_unitContext context)
        {
            Node node = new Node(context);
            return node;
        }
    }
}
