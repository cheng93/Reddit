using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Reddit242;

namespace ConsoleApp
{
    class Program
    {
        private static readonly IBonusReddit242 Reddit242 = new BonusSolution();

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
                //"1555 1630",
                //"1600 1635",
                //"1600 1640",
                //"1610 1640",
                //"1625 1720",
                //"1635 1720",
                //"1645 1740",
                //"1650 1720",
                //"1710 1730",
                //"1715 1810",
                //"1720 1740",
                //"1725 1810"

                //Challenge Input 3
                "1535 1610 Pokémon",
                "1610 1705 Law & Order",
                "1615 1635 ER",
                "1615 1635 Ellen",
                "1615 1705 Family Matters",
                "1725 1810 The Fresh Prince of Bel-Air"
            };

            var shows = new List<Show>();
            foreach (var line in input)
            {
                var startTime = DateTime.ParseExact(line.Substring(0, 4), "HHmm", CultureInfo.InvariantCulture);
                var endTime = DateTime.ParseExact(line.Substring(5, 4), "HHmm", CultureInfo.InvariantCulture);
                string name = null;
                if (line.Length > 9)
                {
                    name = line.Substring(10);
                }
                shows.Add(new Show(startTime, endTime, name));
            }

            var recordedShows = Reddit242.Solve(shows);

            foreach (var show in recordedShows.OrderBy(s => s.Start))
            {
                var startTime = show.Start.ToString("HHmm");
                var endTime = show.End.ToString("HHmm");
                Console.WriteLine("{0} {1} {2}", startTime, endTime, show.Name);
            }
            Console.WriteLine(recordedShows.Count);
            Console.ReadLine();
        }
    }
}
