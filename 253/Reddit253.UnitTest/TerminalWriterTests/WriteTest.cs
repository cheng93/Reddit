﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reddit253.UnitTest.TerminalWriterTests.MockTerminals;

namespace Reddit253.UnitTest.TerminalWriterTests
{
    [TestClass]
    public class WriteTest
    {
        private readonly ITerminalWriter _terminalWriter = new TerminalWriter();

        [TestMethod]
        public void Empty()
        {
            var terminal = new Empty();
            var actual = _terminalWriter.Write(terminal);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Example_1()
        {
            var terminal = new Example1();
            var actual = _terminalWriter.Write(terminal);
            var expected = string.Format(
                    "DDD  PPPP{0}" +
                    "D  D P   P{0}" +
                    "D  D PPPP{0}" +
                    "D  D P{0}" +
                    "DDD  P{0}",
                    Environment.NewLine
                );


            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Example_2()
        {
            var terminal = new Example2();
            var actual = _terminalWriter.Write(terminal);
            var expected = string.Format(
                    @"    ^{0}" +
                    @"   / \{0}" +
                    @"  /   \{0}" +
                    @" /     \{0}" +
                    @"<       >{0}" +
                    @" \     /{0}" +
                    @"  \   /{0}" +
                    @"   \ /{0}" +
                    @"    v{0}" +
                    @"====A====={0}",
                    Environment.NewLine
                );


            Assert.AreEqual(expected, actual);
        }
    }
}