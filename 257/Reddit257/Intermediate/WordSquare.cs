using System.Collections.Generic;
using System.Text;

namespace Reddit257.Intermediate
{
    internal class WordSquare : List<string>, IWordSquare
    {
        public string GetWord(int column)
        {
            if (Count > column)
            {
                return this[column];
            }
            return BuildPrefix(column);
        }

        private string BuildPrefix(int column)
        {
            var prefix = new StringBuilder();
            foreach (var word in this)
            {
                prefix.Append(word[column]);
            }
            return prefix.ToString();
        }
    }
}