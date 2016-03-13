using System.Collections.Generic;

namespace Reddit257.Intermediate
{
    public interface IWordSquare : IList<string>
    {
        string GetWord(int column);
    }
}