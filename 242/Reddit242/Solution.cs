using System.Collections.Generic;
using System.Linq;

namespace Reddit242
{
    public class Solution
    {
        public IReadOnlyCollection<Show> Solve(IReadOnlyCollection<Show> shows)
        {
            var output = new List<Show>();
            foreach (var show in shows)
            {
                var otherShows = Solve(shows.Where(s => s.Start >= show.End).ToList());
                if (otherShows.Count >= output.Count)
                {
                    output = new List<Show>(otherShows) {show};
                }
            }
            return output;
        }
    }
}
