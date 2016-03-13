using System.Collections.Generic;
using System.Linq;

namespace Reddit257.Intermediate
{
    internal class WordGrabber : IWordGrabber
    {
        private readonly IEnumerable<string> _wordBank;

        public WordGrabber(IEnumerable<string> wordBank)
        {
            _wordBank = wordBank;
        }

        public IEnumerable<string> Grab(string prefix, int length)
        {
            return _wordBank.Where(w => w.StartsWith(prefix) && w.Length == length);
        }
    }
}