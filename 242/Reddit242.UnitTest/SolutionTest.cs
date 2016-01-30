using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit242.UnitTest
{
    [TestClass]
    public class SolutionTest
    {
        private readonly Solution _solution = new Solution();

        [TestMethod]
        public void Single()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0))
            };

            var expected = 1;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Double()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 00, 0), new DateTime(2000, 1, 1, 16, 30, 0))
            };

            var expected = 2;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void Double_Overlap()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0)),
                new Show(new DateTime(2000, 1, 1, 15, 55, 0), new DateTime(2000, 1, 1, 16, 30, 0))
            };

            var expected = 1;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Double_Unordered()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 55, 0), new DateTime(2000, 1, 1, 16, 30, 0)),
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0))
            };

            var expected = 1;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triple_OneOverlap()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0)),
                new Show(new DateTime(2000, 1, 1, 15, 55, 0), new DateTime(2000, 1, 1, 16, 30, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 00, 0), new DateTime(2000, 1, 1, 16, 30, 0))                
            };

            var expected = 2;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Triple_LongStart()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 30, 0)),
                new Show(new DateTime(2000, 1, 1, 15, 35, 0), new DateTime(2000, 1, 1, 15, 55, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 00, 0), new DateTime(2000, 1, 1, 16, 10, 0))                
            };

            var expected = 2;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example_1()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0)),
                new Show(new DateTime(2000, 1, 1, 15, 55, 0), new DateTime(2000, 1, 1, 16, 45, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 00, 0), new DateTime(2000, 1, 1, 16, 30, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 35, 0), new DateTime(2000, 1, 1, 17, 15, 0))
            };

            var expected = 3;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example_2()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 30, 0), new DateTime(2000, 1, 1, 16, 00, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 05, 0), new DateTime(2000, 1, 1, 16, 30, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 45, 0), new DateTime(2000, 1, 1, 17, 25, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 00, 0), new DateTime(2000, 1, 1, 17, 30, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 00, 0), new DateTime(2000, 1, 1, 17, 45, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 05, 0), new DateTime(2000, 1, 1, 17, 45, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 20, 0), new DateTime(2000, 1, 1, 18, 15, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 25, 0), new DateTime(2000, 1, 1, 18, 10, 0))
            };

            var expected = 4;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example_3()
        {
            var input = new List<Show>()
            {
                new Show(new DateTime(2000, 1, 1, 15, 55, 0), new DateTime(2000, 1, 1, 16, 30, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 00, 0), new DateTime(2000, 1, 1, 16, 35, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 00, 0), new DateTime(2000, 1, 1, 16, 40, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 10, 0), new DateTime(2000, 1, 1, 16, 40, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 25, 0), new DateTime(2000, 1, 1, 17, 20, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 35, 0), new DateTime(2000, 1, 1, 17, 20, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 45, 0), new DateTime(2000, 1, 1, 17, 40, 0)),
                new Show(new DateTime(2000, 1, 1, 16, 50, 0), new DateTime(2000, 1, 1, 17, 20, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 10, 0), new DateTime(2000, 1, 1, 17, 30, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 15, 0), new DateTime(2000, 1, 1, 18, 10, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 20, 0), new DateTime(2000, 1, 1, 17, 40, 0)),
                new Show(new DateTime(2000, 1, 1, 17, 25, 0), new DateTime(2000, 1, 1, 18, 10, 0))
            };

            var expected = 3;
            var actual = _solution.Solve(input).Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
