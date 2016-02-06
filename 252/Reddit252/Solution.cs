using System;

namespace Reddit252
{
    public class Solution
    {
        private readonly IPairGetter _pairGetter;

        public Solution(IPairGetter pairGetter)
        {
            _pairGetter = pairGetter;
        }

        public string Solve(string input)
        {
            var pair = _pairGetter.GetWidestLeftMostPair(input);
            while (pair != null)
            {
                throw new NotImplementedException();
                pair = _pairGetter.GetWidestLeftMostPair(input);
            }

            throw new NotImplementedException();
        }
    }
}
