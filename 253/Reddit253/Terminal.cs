using System.Drawing;

namespace Reddit253
{
    public class Terminal : ITerminal
    {
        private readonly char?[,] _characters;
        private Point _cursor;

        public Terminal()
        {
            _characters = new char?[10, 10];
            _cursor = new Point(0, 0);
        }

        public char? GetValue(int row, int column)
        {
            return _characters[row, column];
        }

        public void SetValue(int row, int column, char value)
        {
            _characters[row, column] = value;
        }

        public void ClearValue(int row, int column)
        {
            _characters[row, column] = null;
        }

        public Point GetCursor()
        {
            return _cursor;
        }

        public void SetCursor(int row, int column)
        {
            _cursor.Y = row;
            _cursor.X = column;
        }
    }
}