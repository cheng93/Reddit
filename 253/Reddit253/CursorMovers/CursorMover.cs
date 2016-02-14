namespace Reddit253.CursorMovers
{
    internal class CursorMover : ICursorMover
    {
        public void MoveTo(ITerminal terminal, int row, int column)
        {
            terminal.SetCursor(row, column);
        }

        public void Home(ITerminal terminal)
        {
            terminal.SetCursor(0, 0);
        }

        public void Beginning(ITerminal terminal)
        {
            var row = terminal.GetCursor().Y;
            terminal.SetCursor(row, 0);
        }

        public void Up(ITerminal terminal)
        {
            var cursor = terminal.GetCursor();
            var column = cursor.X;
            var row = cursor.Y == 0 ? 0 : cursor.Y - 1;
            terminal.SetCursor(row, column);
        }

        public void Down(ITerminal terminal)
        {
            var cursor = terminal.GetCursor();
            var column = cursor.X;
            var row = cursor.Y == 9 ? 9 : cursor.Y + 1;
            terminal.SetCursor(row, column);
        }

        public void Left(ITerminal terminal)
        {
            var cursor = terminal.GetCursor();
            var column = cursor.X == 9 ? 9 : cursor.X + 1;
            var row = cursor.Y;
            terminal.SetCursor(row, column);
        }

        public void Right(ITerminal terminal)
        {
            var cursor = terminal.GetCursor();
            var column = cursor.X == 0 ? 0 : cursor.X - 1;
            var row = cursor.Y;
            terminal.SetCursor(row, column);
        }
    }
}
