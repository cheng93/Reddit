namespace Reddit253.TerminalWriters
{
    internal class OverrideWriter : ITerminalWriter
    {
        public void Write(ITerminal terminal, char value)
        {
            var cursor = terminal.GetCursor();
            var row = cursor.Y;
            var column = cursor.X;
            terminal.SetValue(row, column, value);
        }
    }
}