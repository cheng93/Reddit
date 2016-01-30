using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Reddit242;

namespace ConsoleApp
{
    class Program
    {
        private static IReddit242 _reddit242 = new Solution();
        static void Main(string[] args)
        {
            var input = new List<string>()
            {
                // Challenge Input 1
                //"1530 1600",
                //"1605 1630",
                //"1645 1725",
                //"1700 1730",
                //"1700 1745",
                //"1705 1745",
                //"1720 1815",
                //"1725 1810"

                // Challenge Input 2
                "1555 1630",
                "1600 1635",
                "1600 1640",
                "1610 1640",
                "1625 1720",
                "1635 1720",
                "1645 1740",
                "1650 1720",
                "1710 1730",
                "1715 1810",
                "1720 1740",
                "1725 1810"
            };

            var shows = new List<Show>();
            foreach (var line in input)
            {
                var startTime = DateTime.ParseExact(line.Substring(0, 4), "HHmm", CultureInfo.InvariantCulture);
                var endTime = DateTime.ParseExact(line.Substring(5, 4), "HHmm", CultureInfo.InvariantCulture);
                shows.Add(new Show(startTime, endTime));
            }

            var recordedShows = _reddit242.Solve(shows);

            foreach (var show in recordedShows.OrderBy(s => s.Start))
            {
                var startTime = show.Start.ToString("HHmm");
                var endTime = show.End.ToString("HHmm");
                Console.WriteLine("{0} {1}", startTime, endTime);
            }
            Console.WriteLine(recordedShows.Count);
            Console.ReadLine();
        }
    }
}
