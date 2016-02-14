using System;
using Reddit253;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();

            var input = "";

            var terminal = solution.Process(input);
            var output = solution.Output(terminal);

            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}