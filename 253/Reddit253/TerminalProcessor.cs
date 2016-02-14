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
            _insertWriter = insertWriter ?? new InsertWriter();
            _overrideWriter = overrideWriter ?? new OverrideWriter();

            IsInsertMode = true;
        }

        public void Process(ITerminal terminal, string input)
        {
            input = input.Replace(Environment.NewLine, "");
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '^')
                {
                    if (i < input.Length - 1 && !char.IsDigit(input[i + 1]))
                    {
                        Process(terminal, input[i+1]);
                        i++;
                    }
                    else if (i < input.Length - 2 && char.IsDigit(input[i + 1]) && char.IsDigit(input[i + 2]))
                    {
                        MoveCursor(terminal, input[i + 1], input[i + 2]);
                        i++;
                        i++;
                    }
                }
                else
                {
                    Write(terminal, input[i]);
                }
            }
        }

        private void Process(ITerminal terminal, char character)
        {
            switch (character)
            {
                case 'c':
                    _terminalClearer.Clear(terminal);
                    break;
                case 'h':
                    _cursorMover.Home(terminal);
                    break;
                case 'b':
                    _cursorMover.Beginning(terminal);
                    break;
                case 'd':
                    _cursorMover.Down(terminal);
                    break;
                case 'u':
                    _cursorMover.Up(terminal);
                    break;
                case 'l':
                    _cursorMover.Left(terminal);
                    break;
                case 'r':
                    _cursorMover.Right(terminal);
                    break;
                case 'e':
                    _terminalClearer.Erase(terminal);
                    break;
                case 'i':
                    SetInsertMode();
                    break;
                case 'o':
                    SetOverrideMode();
                    break;
                case '^':
                    Write(terminal, character);
                    break;
                default:
                    throw new ArgumentException("character not recognised", "character");
            }
        }

        private void MoveCursor(ITerminal terminal, char rowChar, char columnChar)
        {
            int row, column;

            if (!int.TryParse(rowChar.ToString(), out row))
            {
                throw new ArgumentException("rowChar not a digit", "rowChar");
            }
            if (!int.TryParse(columnChar.ToString(), out column))
            {
                throw new ArgumentException("columnChar not a digit", "columnChar");
            }

            _cursorMover.MoveTo(terminal, row, column);
        }

        private void SetInsertMode()
        {
            IsInsertMode = true;
        }

        private void SetOverrideMode()
        {
            IsInsertMode = false;
        }

        private void Write(ITerminal terminal, char value)
        {
            Writer.Write(terminal, value);
            _cursorMover.Right(terminal);
        }
    }
}
