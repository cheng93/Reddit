namespace Reddit253.TerminalClearers
{
    public interface ITerminalClearer
    {
        void Clear(ITerminal terminal);
        void Erase(ITerminal terminal);
    }
}