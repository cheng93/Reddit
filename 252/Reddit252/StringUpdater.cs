using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Reddit252.UnitTest")]
namespace Reddit252
{
    internal class StringUpdater : IStringUpdater
    {
        public string UpdateWithPair(string input, char pair)
        {
            int? indexA = null;
            int? indexB = null;

            foreach (var index in GetIndexesOfChar(input, pair))
            {
                foreach (var otherIndex in GetIndexesOfChar(input, pair).Where(i => i > index))
                {
                    var lengthInsideIndexes = otherIndex - (index + 1);
                    var innerString = input.Substring(index + 1, lengthInsideIndexes);
                    if (innerString.Select(c => c).Distinct().Count() != lengthInsideIndexes)
                    {
                        break;
                    }

                    if ((!indexA.HasValue) || lengthInsideIndexes > indexB - (indexA + 1))
                    {
                        indexA = index;
                        indexB = otherIndex;
                    }
                }
            }

            var output = UpdateWithPair(input, indexA.Value, indexB.Value);
            return output;
        }

        private string UpdateWithPair(string input, int pairIndexA, int pairIndexB)
        {
            input = input.Remove(pairIndexB, 1);
            var pair = input[pairIndexA];
            input = input + pair;
            input = input.Remove(pairIndexA, 1);
            return input;
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