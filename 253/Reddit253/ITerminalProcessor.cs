namespace Reddit253
{
    public interface ITerminalProcessor
    {
        bool IsInsertMode { get; set; }
        void Process(ITerminal terminal, string input);
    }
}
