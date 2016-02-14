namespace Reddit253
{
    public interface ITerminalProcessor
    {
        bool IsInsertMode { get; }
        void Process(ITerminal terminal, string input);
    }
}
