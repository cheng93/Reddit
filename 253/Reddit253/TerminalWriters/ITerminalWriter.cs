namespace Reddit253.TerminalWriters
{
    public interface ITerminalWriter
    {
        void Write(ITerminal terminal, char value);
    }
}