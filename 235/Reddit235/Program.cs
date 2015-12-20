using System;

namespace Reddit235
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Key");
            var key = Console.ReadLine();
            Console.WriteLine("Message");
            var message = Console.ReadLine();

            Console.WriteLine();

            var decrypter = new Decrypter(key, message);
            Console.WriteLine(decrypter.Decrypt());
            Console.Read();
        }
    }
}