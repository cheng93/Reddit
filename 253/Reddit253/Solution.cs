namespace Reddit253
{
    public class Solution
    {
        private readonly ITerminalProcessor _terminalProcessor;
        private readonly ITerminalOutputter _terminalOutputter;
      
        public Solution(ITerminalProcessor terminalProcessor = null, ITerminalOutputter terminalOutputter = null)
        {
            _terminalProcessor = terminalProcessor ?? new TerminalProcessor();
            _terminalOutputter = terminalOutputter ?? new TerminalOutputter();
        }

        public ITerminal Process(string input)
        {
            var terminal = new Terminal();
            _terminalProcessor.Process(terminal, input);
            return terminal;
        }

        public string Output(ITerminal terminal)
        {
            var output = _terminalOutputter.Output(terminal);
            return output;
        }
    }
}
