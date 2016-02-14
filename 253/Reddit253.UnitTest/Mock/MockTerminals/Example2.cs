namespace Reddit253.UnitTest.Mock.MockTerminals
{
    internal class Example2 : MockTerminal
    {
        private static readonly char?[,] Characters = new char?[10, 10]
            {
                {null, null, null, null, '^', null, null, null, null, null},
                {null, null, null, '/', ' ', '\\', null, null, null, null},
                {' ', ' ', '/', ' ', ' ', ' ', '\\', null, null, null},
                {null, '/', null, null, null, null, null, '\\', null, null},
                {'<', null, null, null, null, null, null, null, '>', null},
                {null, '\\', null, null, null, null, null, '/', null, null},
                {' ', ' ', '\\', null, null, null, '/', null, null, null},
                {' ', ' ', ' ', '\\', ' ', '/', null, null, null, null},
                {null, null, null, null, 'v', null, null, null, null, null},
                {'=', '=', '=', '=', 'A', '=', '=', '=', '=', '='}
            };

        public Example2()
            : base(Characters)
        {
        }
    }
}