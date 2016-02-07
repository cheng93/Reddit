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
                input = _stringUpdater.UpdateWithPair(input, pair);
                pair = _pairGetter.GetWidestLeftMostPair(input);
            }

            var output = TrimAfterUnderscore(input);
            return TrimAfterUnderscore(output);
        }

        public static Solution Get()
        {
            return new Solution(new NewPairGetter(), new StringUpdater());
        }

        private string TrimAfterUnderscore(string input)
        {
            return input.Split('_')[0];
        }
    }
}
