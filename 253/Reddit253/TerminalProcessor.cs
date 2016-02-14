using System;

namespace Reddit253
{
    internal class TerminalProcessor : ITerminalProcessor
    {
        public bool IsInsertMode { get; private set; }

        private readonly ICursorMover _cursorMover;

        public TerminalProcessor(ICursorMover cursorMover = null)
        {
            _cursorMover = cursorMover ?? new CursorMover();
        }

        public void Process(ITerminal terminal, string input)
        {
            throw new NotImplementedException();
        }

        private void SetInsertMode()
        {
            IsInsertMode = true;
        }

        private void SetOverrideMode()
        {
            IsInsertMode = false;
        }
    }
}
