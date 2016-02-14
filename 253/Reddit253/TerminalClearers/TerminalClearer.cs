namespace Reddit253.TerminalClearers
{
    internal class TerminalClearer : ITerminalClearer
    {
        public void Clear(ITerminal terminal)
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    terminal.ClearValue(i, j);
                }
            }
        }

        public void Erase(ITerminal terminal)
        {
            var cursor = terminal.GetCursor();
            var row = cursor.Y;
            var column = cursor.X;

            for (var i = column; i < 10; i++)
            {
                terminal.ClearValue(row, i);
            }
        }
    }
}