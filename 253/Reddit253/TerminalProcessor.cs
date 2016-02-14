using System;
using Reddit253.CursorMovers;
using Reddit253.TerminalClearers;
using Reddit253.TerminalWriters;

namespace Reddit253
{
    internal class TerminalProcessor : ITerminalProcessor
    {
        public bool IsInsertMode { get; private set; }

        private readonly ICursorMover _cursorMover;
        private readonly ITerminalClearer _terminalClearer;
        private readonly ITerminalWriter _insertWriter;
        private readonly ITerminalWriter _overrideWriter;

        private ITerminalWriter Writer
        {
            get
            {
                return IsInsertMode ? _insertWriter : _overrideWriter;
            }
        }

        public TerminalProcessor(ICursorMover cursorMover = null, ITerminalClearer terminalClearer = null,
            ITerminalWriter insertWriter = null, ITerminalWriter overrideWriter = null)
        {
            _cursorMover = cursorMover ?? new CursorMover();
            _terminalClearer = terminalClearer ?? new TerminalClearer();
            _insertWriter = insertWriter;
            _overrideWriter = overrideWriter;
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
