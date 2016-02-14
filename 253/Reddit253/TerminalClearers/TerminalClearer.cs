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
                    terminal.SetValue();
                }
            }
        }

        public void Erase(ITerminal terminal)
        {
            throw new System.NotImplementedException();
        }
    }
}