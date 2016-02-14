using System;

namespace Reddit253.UnitTest.TerminalWriterTests.MockTerminals
{
    internal class Example1 : ITerminal
    {
        private readonly char?[,] _characters;

        public Example1()
        {
            _characters = new char?[10, 10]
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
        }

        public char? GetValue(int row, int column)
        {
            return _characters[row, column];
        }

        public void SetValue(int row, int column, char value)
        {
            throw new NotImplementedException();
        }

        public void ClearValue(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void SetCursor(int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}
