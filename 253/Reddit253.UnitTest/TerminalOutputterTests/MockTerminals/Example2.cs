using System;
using System.Drawing;

namespace Reddit253.UnitTest.TerminalOutputterTests.MockTerminals
{
    internal class Example2 : ITerminal
    {
        private readonly char?[,] _characters;

        public Example2()
        {
            _characters = new char?[10, 10]
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

        public Point GetCursor()
        {
            throw new NotImplementedException();
        }

        public void SetCursor(int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}