namespace CodeParser.ZhangShasha
{
    internal class Node
    {
        public string Label { get; set; }

        // preorder index
        public int PostorderNumber { get; set; }

        public List<Node> Children = new List<Node>();

        // used by the recursive O(n) leftmost() function
        public Node Leftmost;

        public Node Parent;

        public Node()
        {

        }

        public Node(string label)
        {
            Label = label;
        }
    }
}
