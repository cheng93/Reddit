using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit242.UnitTest
{
    [TestClass]
    public class BonusSolutionTest
    {
        private readonly IBonusReddit242 _reddit242 = new BonusSolution();

        [TestMethod]
        public void NoPreferredMatch()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0), "Show2"),
                new Show(new DateTime(2000, 1, 1, 15, 35, 0), new DateTime(2000, 1, 1, 17, 00, 0), "Show3"),
                new Show(new DateTime(2000, 1, 1, 17, 00, 0), new DateTime(2000, 1, 1, 17, 30, 0), "Show4"),
                new Show(new DateTime(2000, 1, 1, 16, 00, 0), new DateTime(2000, 1, 1, 17, 00, 0), "Show5")
            };

            var expected = 3;
            var actual = _reddit242.Solve(input, "Show1").Count;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PreferredMatchFound()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0), "Show2"),
                new Show(new DateTime(2000, 1, 1, 15, 35, 0), new DateTime(2000, 1, 1, 17, 00, 0), "Show1"),
                new Show(new DateTime(2000, 1, 1, 17, 00, 0), new DateTime(2000, 1, 1, 17, 30, 0), "Show4")
            };

            var expected = 2;
            var actual = _reddit242.Solve(input, "Show1").Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
