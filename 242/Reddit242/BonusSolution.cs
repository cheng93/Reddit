using System.Collections.Generic;
using System.Linq;

namespace Reddit242
{
    public class BonusSolution : Solution, IBonusReddit242
    {
        public IReadOnlyCollection<Show> Solve(IReadOnlyCollection<Show> show, string preferredShowName)
        {
            var preferredShow = show.FirstOrDefault(s => s.Name == preferredShowName);
            if (preferredShow == null)
            {
                return Solve(show);
            }

            var output = new List<Show> { preferredShow };
            output.AddRange(Solve(show.Where(s => s.Start >= preferredShow.End).ToList()));
            output.AddRange(Solve(show.Where(s => s.End <= preferredShow.Start).ToList()));

            return output;
        }
    }
}