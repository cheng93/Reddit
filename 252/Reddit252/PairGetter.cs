using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Reddit252.UnitTest")]
namespace Reddit252
{
    internal class PairGetter : IPairGetter
    {
        public Pair GetWidestLeftMostPair(string input)
        {
            Pair output = null;

            for (var i = 0; i < input.Length - 1; i++)
            {
                var character = input[i];

                if (input.Count(c => c == character) == 1)
                {
                    continue;
                }
                
                foreach (var index in GetIndexesOfChar(input, character).Where(x => x > i).Reverse())
                {
                    var lengthBetweenIndexes = index - (i + 1);

                    if (output != null && lengthBetweenIndexes <= output.EndIndex - (output.StartIndex + 1))
                    {
                        continue;
                    }

                    if (lengthBetweenIndexes > 0)
                    {
                        var innerString = input.Substring(i + 1, lengthBetweenIndexes);
                        
                        if (innerString.Select(c => c).Distinct().Count() != lengthBetweenIndexes)
                        {
                            break;
                        }
                    }

                    if (output == null || lengthBetweenIndexes > output.EndIndex - (output.StartIndex + 1))
                    {
                        output = new Pair(character, i, index);
                        break;
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
