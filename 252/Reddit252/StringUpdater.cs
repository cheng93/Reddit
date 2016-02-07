using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Reddit252.UnitTest")]
namespace Reddit252
{
    internal class StringUpdater : IStringUpdater
    {
        public string UpdateWithPair(string input, Pair pair)
        {
            input = input.Remove(pair.EndIndex, 1);
            input += pair.Character;
            input = input.Remove(pair.StartIndex, 1);
            return input;
        }
    }
}