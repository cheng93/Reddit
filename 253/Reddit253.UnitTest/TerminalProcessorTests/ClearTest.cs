using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reddit253.UnitTest.Mock;
using Reddit253.UnitTest.Mock.MockTerminals;

namespace Reddit253.UnitTest.TerminalProcessorTests
{
    [TestClass]
    public class ClearTest
    {
        private readonly ITerminalProcessor _terminalProcessor = new TerminalProcessor(new MockCursorMover(), null,
            new MockTerminalWriter(), new MockTerminalWriter());

        [TestMethod]
        public void Clear() 
        {
            var terminal = new MockTerminal_NonEmpty();
            _terminalProcessor.Process(terminal, "^c");

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    var actual = terminal.GetValue(i, j);
                    Assert.IsNull(actual);
                }
            }
        }

        [TestMethod]
        public void Erase()
        {
            var terminal = new MockTerminal_NonEmpty();
            _terminalProcessor.Process(terminal, "^e");

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    var actual = terminal.GetValue(i, j);
                    Assert.IsNull(actual);
                }
            }
        }

        [TestMethod]
        public void Erase_CursorNotAtStart()
        {
            var terminal = new MockTerminal_NonEmpty();
            terminal.SetCursor(0, 1);
            _terminalProcessor.Process(terminal, "^e");

            var actual = terminal.GetValue(0, 0);
            var expected = 'A';
            Assert.AreEqual(expected, actual);

            for (var j = 1; j < 10; j++)
            {
                actual = terminal.GetValue(0, j);
                Assert.IsNull(actual);
            }

            for (var i = 1; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    actual = terminal.GetValue(i, j);
                    Assert.IsNull(actual);
                }
            }
        }
    }
}
