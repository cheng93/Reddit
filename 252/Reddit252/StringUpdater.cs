using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Reddit252.UnitTest")]
namespace Reddit252
{
    internal class StringUpdater : IStringUpdater
    {
        private IPairGetter _pairGetter;

        public StringUpdater(IPairGetter pairGetter)
        {
            _pairGetter = pairGetter;
        }
        public string UpdateWithPair(string input, char pair)
        {
            throw new System.NotImplementedException();
        }
    }
}