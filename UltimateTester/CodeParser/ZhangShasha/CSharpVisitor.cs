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
    /// <summary>
    /// Implementation of Zhang-Shasha tree-based algorithm.
    /// </summary>
    internal partial class CSharpVisitor : CSharpParserBaseVisitor<Node>
    {
        Node _root;

        public override Node VisitCompilation_unit([NotNull] CSharpParser.Compilation_unitContext context)
        {
            int i = 0;
            _root = CreateNode(context.GetChild(i));

            //var child = context.GetChild(i);
            //for (int j = 0; j < child.ChildCount; ++j)
            //{
            //    i++;
            //    _root.Children.Add(CreateNode(context.GetChild(i)));
            //}
            //var child2 = context.GetChild(i);
            //for (int j = 0; j < child.ChildCount; ++j)
            //{
            //    i++;
            //    _root.Children.Add(CreateNode(context.GetChild(i)));
            //}
            //var child3 = context.GetChild(i);

            //VisitChildren(context);
            Preorder(context);
            return _root;
        }

        public void Preorder(IParseTree tree)
        {
            for (int i = 0; i < tree.ChildCount; ++i)
            {
                var child = tree.GetChild(i);

                var child2 = tree.GetChild(i + 1); // если след элемент дочерний - добавить в child.Children?
                if (child2 != null && child == child2.Parent)
                {
                    Console.WriteLine("\tchild == child2");
                }

                if (child is Antlr4.Runtime.RuleContext) // Node with [numbers]
                {
                    var nodeLabel = child.Payload.ToString();
                    Console.WriteLine(nodeLabel + " has " + child.ChildCount + " children");
                }
                else // Node with Text
                {
                    var nodeLabel = ((TerminalNodeImpl)child).Payload.Text;
                    Console.WriteLine(nodeLabel + " has " + child.ChildCount + " children");
                }

                Preorder(child);
            }
        }

        Node CreateNode(ITree child)
        {
            string nodeLabel;
            if (child is null)
            {
                return new Node(); // end.
            }
            if (child is Antlr4.Runtime.RuleContext) // Node with [numbers]
            {
                nodeLabel = child.Payload.ToString();
                Console.WriteLine(nodeLabel + " has " + child.ChildCount + " children");
            }
            else // Node with Text
            {
                nodeLabel = ((TerminalNodeImpl)child).Payload.Text;
                Console.WriteLine(nodeLabel + " has " + child.ChildCount + " children");
            }
            return new Node(nodeLabel);
        }
    }
}
