using System;
using Reddit257.Intermediate;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var wordBank = new WordBank();
            var solution = new Solution(new WordGrabber(wordBank.Get()), new LettersUtils());

            foreach (var word in solution.Solve(5, "aabbeeeeeeeehmosrrrruttvv"))
            {
                Console.WriteLine(word);
            }
            Console.ReadLine();
        }
    }
}