using System.Collections.Generic;

namespace Reddit242
{
    public interface IReddit242
    {
        IReadOnlyCollection<Show> Solve(IReadOnlyCollection<Show> shows);
    }
}