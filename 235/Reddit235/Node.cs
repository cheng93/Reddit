using System.Collections.Generic;

namespace Reddit235
{
    internal class Node
    {
        public Node Left;
        public Node Right;
        public char Letter;
        public int Value;
        public string G;

        public Node()
        {
            
        }

        public Node(char letter, int value)
        {
            Letter = letter;
            Value = value;
        }

        public List<Node> Traverse(char letter, List<Node> data)
        {
            if (Left == null & Right == null)
            {
                data.Add(this);
                return letter == Letter ? data : null;
            }

            List<Node> left = null;
            List<Node> right = null;

            if (Left != null)
            {
                var leftPath = new List<Node>();
                leftPath.AddRange(data);
                leftPath.Add(this);

                left = Left.Traverse(letter, leftPath);
            }

            if (Right != null)
            {
                var rightPath = new List<Node>();
                rightPath.AddRange(data);
                rightPath.Add(this);
                right = Right.Traverse(letter, rightPath);
            }

            return left ?? right;
        }
    }
}