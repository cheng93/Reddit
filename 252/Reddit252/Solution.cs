using System;

namespace Reddit252
{
    public class Solution
    {
        private readonly IPairGetter _pairGetter;

        private readonly IStringUpdater _stringUpdater;

        public Solution(IPairGetter pairGetter, IStringUpdater stringUpdater)
        {
            _pairGetter = pairGetter;
            _stringUpdater = stringUpdater;
        }

        public string Solve(string input)
        {
            var pair = _pairGetter.GetWidestLeftMostPair(input);
            while (pair != null)
            {
                input = _stringUpdater.UpdateWithPair(input, pair.Value);
                pair = _pairGetter.GetWidestLeftMostPair(input);
            }

            var output = TrimAfterUnderscore(input);
            return TrimAfterUnderscore(output);
        }

        private string TrimAfterUnderscore(string input)
        {
            var index = input.IndexOf('_');
            input = index == -1 ? input : input.Substring(0, index - 1);
            return input;
        }
    }
}
