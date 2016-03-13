using System.Collections.Generic;
using System.Linq;

namespace Reddit257.Intermediate
{
    public class WordGrabber : IWordGrabber
    {
        private readonly IEnumerable<string> _wordBank;

        private readonly IDictionary<string, IEnumerable<string>> _cache;

        public WordGrabber(IEnumerable<string> wordBank)
        {
            _wordBank = wordBank;
            _cache = new Dictionary<string, IEnumerable<string>>();
        }

        public IEnumerable<string> Grab(string prefix, int length)
        {
            if (_cache.ContainsKey(prefix))
            {
                return _cache[prefix];
            }
            _cache.Add(prefix, _wordBank.Where(w => w.StartsWith(prefix) && w.Length == length));
            return _cache[prefix];
        }
    }
}