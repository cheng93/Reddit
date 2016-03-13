using System.Collections.Generic;

namespace Reddit257.Intermediate
{
    public interface IWordGrabber
    {
        IEnumerable<string> Grab(string prefix, int length);
    }
}