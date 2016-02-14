using System;

namespace Reddit253.UnitTest.TerminalWriterTests.MockTerminals
{
    internal class Empty : ITerminal
    {
        private readonly char?[,] _characters;

        public Empty()
        {
            _characters = new char?[10, 10];
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
