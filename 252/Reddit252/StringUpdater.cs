using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Reddit252.UnitTest")]
namespace Reddit252
{
    internal class StringUpdater : IStringUpdater
    {
        private readonly IPairGetter _pairGetter;

        public StringUpdater(IPairGetter pairGetter)
        {
            _pairGetter = pairGetter;
        }

        public string UpdateWithPair(string input, char pair)
        {
            var indexesOfPair = GetIndexesOfChar(input, pair);
            int? indexA = null;
            int? indexB = null;

            foreach (var index in indexesOfPair)
            {
                foreach (var otherIndex in indexesOfPair.Where(i => i > index))
                {
                    var lengthInsideIndexes = otherIndex - (index + 1);
                    var pairBetweenIndex = _pairGetter.GetWidestLeftMostPair(input.Substring(index + 1, lengthInsideIndexes));
                    
                    if (pairBetweenIndex.HasValue)
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

        private List<int> GetIndexesOfChar(string input, char character)
        {
            var indexes = new List<int>();
            var index = input.IndexOf(character);

            while (index > -1)
            {
                indexes.Add(index);
                index = input.IndexOf(character, index + 1);
            }

            return indexes;
        }
    }
}