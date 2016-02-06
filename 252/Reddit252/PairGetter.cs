﻿using System.Collections.Generic;
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

                var indexesOfCharacter = GetIndexesOfChar(input, character);

                foreach (var index in indexesOfCharacter.Where(x => x > i))
                {
                    var lengthBetweenIndexes = index - (i + 1);

                    if (lengthBetweenIndexes > 0)
                    {
                        var pairWithinIndexes = GetWidestLeftMostPair(input.Substring(i + 1, lengthBetweenIndexes));

                        if (pairWithinIndexes != null)
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

                return output;
            }
            return output;
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
