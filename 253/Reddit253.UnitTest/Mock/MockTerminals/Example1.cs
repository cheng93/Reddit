
namespace Reddit253.UnitTest.Mock.MockTerminals
{
    internal class Example1 : MockTerminal
    {
        private static readonly char?[,] Characters = new char?[10, 10]
            {
                {'D', 'D', 'D', ' ', ' ', 'P', 'P', 'P', 'P', null},
                {'D', ' ', ' ', 'D', ' ', 'P', ' ', ' ', ' ', 'P'},
                {'D', ' ', ' ', 'D', ' ', 'P', 'P', 'P', 'P', null},
                {'D', ' ', ' ', 'D', ' ', 'P', null, null, null, null},
                {'D', 'D', 'D', ' ', ' ', 'P', null, null, null, null},
                {null, null, null, null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null, null, null, null},
                {null, null, null, null, null, null, null, null, null, null}
            };

        public Example1()
            : base(Characters)
        {
        }
    }
}
