using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Reddit252.UnitTest")]
namespace Reddit252
{
    internal class PairGetter : IPairGetter
    {
        public char? GetWidestLeftMostPair(string input)
        {
            char? output = null;
            int? lengthBetweenPair = null;

            for (var i = 0; i < input.Length - 1; i++)
            {
                var character = input[i];

                if (input.Count(c => c == character) == 1)
                {
                    continue;
                }
                
                foreach (var index in GetIndexesOfChar(input, character).Where(x => x > i))
                {
                    var lengthBetweenIndexes = index - (i + 1);

                    if (lengthBetweenIndexes > 0)
                    {
                        var innerString = input.Substring(i + 1, lengthBetweenIndexes);
                        
                        if (innerString.Select(c => c).Distinct().Count() != lengthBetweenIndexes)
                        {
                            break;
                        }
                    }

                    if (!lengthBetweenPair.HasValue || lengthBetweenIndexes > lengthBetweenPair)
                    {
                        output = character;
                        lengthBetweenPair = lengthBetweenIndexes;
                    }
                }
            }
            return output;
        }

        private IEnumerable<int> GetIndexesOfChar(string input, char character)
        {
            var index = input.IndexOf(character);

            while (index > -1)
            {
                yield return index;
                index = input.IndexOf(character, index + 1);
            }
        }
    }
}
