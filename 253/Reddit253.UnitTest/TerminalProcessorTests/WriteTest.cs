using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reddit253.UnitTest.Mock;

namespace Reddit253.UnitTest.TerminalProcessorTests
{
    [TestClass]
    public class WriteTest
    {
        private readonly ITerminalProcessor _terminalProcessor = new TerminalProcessor(new MockCursorMover(),
            new MockTerminalClearer());

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}