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

        [TestMethod]
        public void Up()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^44^u");

            var actual = terminal.GetCursor();
            var expected = new Point(4, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Up_CursorAtTop()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^u");

            var actual = terminal.GetCursor();
            var expected = new Point(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Down()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^d");

            var actual = terminal.GetCursor();
            var expected = new Point(0, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Down_CursorAtBottom()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^90^d");

            var actual = terminal.GetCursor();
            var expected = new Point(0, 9);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Left()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^44^l");

            var actual = terminal.GetCursor();
            var expected = new Point(3, 4);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Left_CursorOnLeftSide()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^l");

            var actual = terminal.GetCursor();
            var expected = new Point(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Right()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^r");

            var actual = terminal.GetCursor();
            var expected = new Point(1, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Right_CursorOnRightSide()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^09^r");

            var actual = terminal.GetCursor();
            var expected = new Point(9, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Home()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^h");

            var actual = terminal.GetCursor();
            var expected = new Point(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Home_NotStartAtHome()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^44^h");

            var actual = terminal.GetCursor();
            var expected = new Point(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Beginning()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^b");

            var actual = terminal.GetCursor();
            var expected = new Point(0, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Beginning_NotStartAtHome()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^44^b");

            var actual = terminal.GetCursor();
            var expected = new Point(0, 4);
            Assert.AreEqual(expected, actual);
        }
    }
}
