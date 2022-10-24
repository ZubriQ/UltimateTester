using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using static CodeParser.ANTLR4.CSharpParser;

namespace CodeParser.ZhangShasha
{
    internal class Node
    {
        public string Label { get; set; }

        // preorder index
        public int PostorderNumber { get; set; }

        public List<Node> Children { get; set; }

        // used by the recursive O(n) leftmost() function
        public Node Leftmost;

        public Node(Compilation_unitContext context)
        {
            // the root
            Label = Guid.NewGuid().ToString();
            Children = new List<Node>();
            for (int i = 0; i < context.ChildCount; i++)
            {
                Children.Add(new Node(context.GetChild(i)));
            }

        }
        public Node(ITree tree)
        {
            Label = Guid.NewGuid().ToString();
            Children = new List<Node>();
            for (int i = 0; i < tree.ChildCount; i++)
            {
                Children.Add(new Node(tree.GetChild(i)));
            }
        }
    }
}
