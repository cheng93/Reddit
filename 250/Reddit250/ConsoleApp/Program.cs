using System;
using System.Linq;
using Reddit250;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new NewSolution();
            Console.WriteLine("Enter your length.");
            var length = uint.Parse(Console.ReadLine());
            var numbers = solution.GetSelfDescriptiveNumberOfLength(length).ToList();
            if (numbers.Any())
            {
                foreach (var number in numbers)
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