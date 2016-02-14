using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reddit253.UnitTest.Mock;
using Reddit253.UnitTest.Mock.MockTerminals;

namespace Reddit253.UnitTest.TerminalProcessorTests
{
    [TestClass]
    public class CursorTest
    {
        private readonly ITerminalProcessor _terminalProcessor = new TerminalProcessor(null, new MockTerminalClearer(),
            new MockTerminalWriter(), new MockTerminalWriter());

        [TestMethod]
        public void MoveCursor()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^44");

            var actual = terminal.GetCursor();
            var expected = new Point(4, 4);
            Assert.AreEqual(expected, actual);
        }
    }
}
