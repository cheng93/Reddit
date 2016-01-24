using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit250.UnitTest
{
    [TestClass]
    public class GetSelfDescriptiveNumberOfLengthTest
    {
        private Solution _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new Solution();
        }

        [TestMethod]
        public void One_Empty()
        {
            var actual = _solution.GetSelfDescriptiveNumberOfLength(1);
            Assert.IsTrue(!actual.Any());
        }

        [TestMethod]
        public void Three_Empty()
        {
            var actual = _solution.GetSelfDescriptiveNumberOfLength(3);
            Assert.IsTrue(!actual.Any());
        }

        [TestMethod]
        public void Four()
        {
            var actual = _solution.GetSelfDescriptiveNumberOfLength(4).ToList();
            var expected = new List<long> { 1210, 2020 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Five()
        {
            var actual = _solution.GetSelfDescriptiveNumberOfLength(5).ToList();
            var expected = new List<long> { 21200 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
