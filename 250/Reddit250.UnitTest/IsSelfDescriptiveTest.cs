using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit250.UnitTest
{
    [TestClass]
    public class IsSelfDescriptiveTest
    {
        private IReddit250 _solution;

        [TestInitialize]
        public void Initialize()
        {
            _solution = new Solution();
        }

        [TestMethod]
        public void Zero_False()
        {
            Assert.IsFalse(_solution.IsSelfDescriptive(0));
        }

        [TestMethod]
        public void One_False()
        {
            Assert.IsFalse(_solution.IsSelfDescriptive(1));
        }

        [TestMethod]
        public void NineNineZero_False()
        {
            Assert.IsFalse(_solution.IsSelfDescriptive(990));
        }

        [TestMethod]
        public void OneTwoOneZero_True()
        {
            Assert.IsTrue(_solution.IsSelfDescriptive(1210));
        }

        [TestMethod]
        public void TwoZeroTwoZero_True()
        {
            Assert.IsTrue(_solution.IsSelfDescriptive(2020));
        }

        [TestMethod]
        public void TwoZeroThreeZero_False()
        {
            Assert.IsFalse(_solution.IsSelfDescriptive(2030));
        }

        [TestMethod]
        public void TwoOneTwoZeroZero_True()
        {
            Assert.IsTrue(_solution.IsSelfDescriptive(21200));
        }
    }
}
