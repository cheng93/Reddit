using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reddit253.UnitTest.Mock;
using Reddit253.UnitTest.Mock.MockTerminals;

namespace Reddit253.UnitTest.TerminalProcessorTests
{
    [TestClass]
    public class WriteTest
    {
        private readonly ITerminalProcessor _terminalProcessor = new TerminalProcessor(new MockCursorMover(),
            new MockTerminalClearer());

        [TestMethod]
        public void Insert_Empty()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "A");

            var actual = terminal.GetValue(0, 0);
            var expected = 'A';

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetOverride()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^o");

            var actual = _terminalProcessor.IsInsertMode;
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void SetOverrideThanInsert()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^o^i");

            var actual = _terminalProcessor.IsInsertMode;
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Override_Empty()
        {
            var terminal = new MockTerminal();
            _terminalProcessor.Process(terminal, "^oA");

            var actual = terminal.GetValue(0, 0);
            var expected = 'A';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_NonEmpty()
        {
            var terminal = new MockTerminal_NonEmpty();
            _terminalProcessor.Process(terminal, "B");

            var actual = terminal.GetValue(0, 0);
            char? expected = 'B';
            Assert.AreEqual(expected, actual);

            actual = terminal.GetValue(0, 1);
            expected = 'A';
            Assert.AreEqual(expected, actual);

            actual = terminal.GetValue(0, 2);
            expected = ' ';
            Assert.AreEqual(expected, actual);

            actual = terminal.GetValue(0, 3);
            Assert.IsNull(actual);

            actual = terminal.GetValue(0, 4);
            expected = 'C';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Override_NonEmpty()
        {
            var terminal = new MockTerminal_NonEmpty();
            _terminalProcessor.Process(terminal, "^oB");

            var actual = terminal.GetValue(0, 0);
            char? expected = 'B';
            Assert.AreEqual(expected, actual);

            actual = terminal.GetValue(0, 1);
            expected = ' ';
            Assert.AreEqual(expected, actual);

            actual = terminal.GetValue(0, 2);
            Assert.IsNull(actual);

            actual = terminal.GetValue(0, 3);
            expected = 'C';
            Assert.AreEqual(expected, actual);
        }
    }
}