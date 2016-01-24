using System;
using System.Linq;
using Reddit250;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();
            Console.WriteLine("Enter your length.");
            var length = int.Parse(Console.ReadLine());
            var numbers = solution.GetSelfDescriptiveNumberOfLength(length);
            if (numbers.Any())
            {
                foreach (var number in solution.GetSelfDescriptiveNumberOfLength(length))
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("No self-descriptive number found");
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}