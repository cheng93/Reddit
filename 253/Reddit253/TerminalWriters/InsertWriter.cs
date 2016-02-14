namespace Reddit253.TerminalWriters
{
    internal class InsertWriter : ITerminalWriter
    {
        public void Write(ITerminal terminal, char value)
        {
            var cursor = terminal.GetCursor();
            var row = cursor.Y;
            var column = cursor.X;
            ShiftRight(terminal, row, column);
            terminal.SetValue(row, column, value);
        }

        private void ShiftRight(ITerminal terminal, int row, int startingColumn)
        {
            for (var i = 9; i > startingColumn; i--)
            {
                var leftValue = terminal.GetValue(row, i - 1);
                if (leftValue.HasValue)
                {
                    terminal.SetValue(row, i, leftValue.Value);
                }
                else
                {
                    terminal.ClearValue(row, i);
                }
            }
        }
    }
}