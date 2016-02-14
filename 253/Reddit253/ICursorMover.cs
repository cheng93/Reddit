namespace Reddit253
{
    public interface ICursorMover
    {
        void MoveTo(ITerminal terminal, int row, int column);
        void Home(ITerminal terminal);
        void Beginning(ITerminal terminal);
        void Up(ITerminal terminal);
        void Down(ITerminal terminal);
        void Left(ITerminal terminal);
        void Right(ITerminal terminal);
    }
}
