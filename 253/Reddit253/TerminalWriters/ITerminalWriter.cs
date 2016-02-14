namespace Reddit253.TerminalWriters
{
    internal interface ITerminalWriter
    {
        void Write(ITerminal terminal, char value);
    }
}