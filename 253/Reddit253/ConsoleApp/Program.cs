using System;
using Reddit253;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solution = new Solution();
            
            // Example 1
            var input = @"
^h^c^i
DDD^r^rPPPP^d^b
D^r^rD^rP^19P^d^b
D^r^rD^rPPPP^d^b
D^r^rD^rP^d^b
DDD^r^rP  
";
            // Example 2, however input is bad.
            input = @"
^h^c^i
^04^^
^13/ \^d^b  /   \
^u^d^d^l^l^l^l^l^l^l^l^l
^r^r^l^l^d<^49>^l^l^d/^b \
^d^r^r^66/^b  \
^b^d   \ /
^d^l^lv^d^b===========^i^94O123456
789^94A=======^u^u^u^u^u^u^l^l\^o^b^r/
";
            // Correct input for example 2, notice the ^o on line 5
            input = @"
^h^c^i
^04^^
^13/ \^d^b  /   \
^u^d^d^l^l^l^l^l^l^l^l^l
^r^r^l^l^d<^48>^l^l^d/^b^o \
^d^r^r^66/^b  \
^b^d   \ /
^d^l^lv^d^b===========^i^94O123456
789^94A=======^u^u^u^u^u^u^l^l\^o^b^r/
";
            var terminal = solution.Process(input);
            var output = solution.Output(terminal);

            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}