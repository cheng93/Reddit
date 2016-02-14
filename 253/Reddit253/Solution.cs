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
    }
}
