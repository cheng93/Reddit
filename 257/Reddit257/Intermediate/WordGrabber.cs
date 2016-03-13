using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }
    }
}