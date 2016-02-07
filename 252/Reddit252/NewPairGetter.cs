using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Reddit252.UnitTest")]

namespace Reddit252
{
    internal class NewPairGetter : IPairGetter
    {
        public Pair GetWidestLeftMostPair(string input)
        {
            Pair output = null;
            var possiblePairStartIndex = new Dictionary<char, int>();
            var previousIndex = new Dictionary<char, int>();

            for (var i = 0; i < input.Length; i++)
            {
                var character = input[i];

                if (!possiblePairStartIndex.ContainsKey(character))
                {
                    possiblePairStartIndex.Add(character, i);

                    if (previousIndex.ContainsKey(character))
                    {
                        previousIndex[character] = i;
                    }
                    else
                    {
                        previousIndex.Add(character, i);
                    }
                }
                else
                {
                    var startIndex = possiblePairStartIndex[character];

                    if (output == null || (output.EndIndex - output.StartIndex) < i - startIndex)
                    {
                        output = new Pair(character, startIndex, i);
                    }

                    possiblePairStartIndex = possiblePairStartIndex.Where(kvp => previousIndex[kvp.Key] >= previousIndex[character]).ToDictionary(kvp => kvp.Key, kvp => previousIndex[kvp.Key]);
                    
                    previousIndex[character] = i;
                }
            }
            return output;
        }
    }
}