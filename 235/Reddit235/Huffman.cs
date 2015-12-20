using System;
using System.Collections.Generic;
using System.Linq;

namespace Reddit235
{
    internal class Huffman
    {
        private Node _root;

        private Dictionary<char, int> _lettersCount;

        public void Build(string message)
        {
            _lettersCount = message.Distinct().ToDictionary(letter => letter, letter => message.Count(m => m == letter));
            var originalQueue = new Queue<Node>();
            var newQueue = new Queue<Node>();

            foreach (var keyValuePair in _lettersCount.OrderBy(e => e.Value))
            {
                originalQueue.Enqueue(new Node(keyValuePair.Key, keyValuePair.Value));
            }
            while (originalQueue.Count + newQueue.Count > 1)
            {
                newQueue.Enqueue(DoHuffman(originalQueue, newQueue));
            }
            _root = newQueue.Dequeue();
        }

        private Node DoHuffman(Queue<Node> originalQueue, Queue<Node> newQueue)
        {
            var twoSmallestNodes = GetTwoSmallestNode(originalQueue, newQueue);
            twoSmallestNodes.Item1.G = "G";
            twoSmallestNodes.Item2.G = "g";
            return new Node()
            {
                Left = twoSmallestNodes.Item1,
                Right = twoSmallestNodes.Item2,
                Value = twoSmallestNodes.Item1.Value + twoSmallestNodes.Item2.Value
            };
        }

        private Tuple<Node, Node> GetTwoSmallestNode(Queue<Node> originalQueue, Queue<Node> newQueue)
        {
            Node nodeOne;
            Node nodeTwo;
            if (originalQueue.Count == 0)
            {
                nodeOne = newQueue.Dequeue();
                nodeTwo = newQueue.Dequeue();
            }
            else if (newQueue.Count == 0)
            {
                nodeOne = originalQueue.Dequeue();
                nodeTwo = originalQueue.Dequeue();
            }
            else
            {
                nodeOne = originalQueue.Peek().Value <= newQueue.Peek().Value
                    ? originalQueue.Dequeue()
                    : newQueue.Dequeue();

                if (originalQueue.Count == 0)
                {
                    nodeTwo = newQueue.Dequeue();
                }
                else if (newQueue.Count == 0)
                {
                    nodeTwo = originalQueue.Dequeue();
                }
                else
                {
                    nodeTwo = originalQueue.Peek().Value <= newQueue.Peek().Value
                        ? originalQueue.Dequeue()
                        : newQueue.Dequeue();
                }
            }
            return new Tuple<Node, Node>(nodeOne, nodeTwo);
        }

        public Dictionary<char, string> GetCipher()
        {
            var cipher = new Dictionary<char, string>();
            foreach (var keyValuePair in _lettersCount)
            {
                string value = null;
                foreach (var node in _root.Traverse(keyValuePair.Key, new List<Node>()))
                {
                    value += node.G;
                }

                cipher.Add(keyValuePair.Key, value);
            }
            return cipher;
        }
    }
}
