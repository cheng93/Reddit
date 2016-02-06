using System;
using Reddit252;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = Solution.Get();
            const string input = "ttvmswxjzdgzqxotby_lslonwqaipchgqdo_yz_fqdagixyrobdjtnl_jqzpptzfcdcjjcpjjnnvopmh";

            Console.WriteLine(solution.Solve(input));
            Console.ReadLine();
        }
    }
}
