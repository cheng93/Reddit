using System.Collections.Generic;
using System.IO;

namespace Reddit257.Intermediate
{
    internal class WordBank : IWordBank
    {
        public IEnumerable<string> Get()
        {
            return File.ReadLines("../enable1.txt");
        }
    }
}
