using System.Collections.Generic;

namespace Reddit242
{
    public interface IBonusReddit242 : IReddit242
    {
        IReadOnlyCollection<Show> Solve(IReadOnlyCollection<Show> shows, string preferredShowName);
    }
}