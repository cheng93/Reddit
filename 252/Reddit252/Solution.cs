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

            throw new NotImplementedException();
        }
    }
}
