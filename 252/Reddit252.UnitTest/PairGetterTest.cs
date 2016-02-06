using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit252.UnitTest
{
    [TestClass]
    public class PairGetterTest
    {
        private readonly IPairGetter _pairGetter = new PairGetter();

        [TestMethod]
        public void Example_1()
        {
            const string input = "abcbba";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = 'b';

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example_2()
        {
            const string input = "aabcbded";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = 'b';

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void EmptyString_Null()
        {
            const string input = "";

            var actual = _pairGetter.GetWidestLeftMostPair(input);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void NoPair_Null()
        {
            const string input = "ab";

            var actual = _pairGetter.GetWidestLeftMostPair(input);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void SimplePair()
        {
            const string input = "aa";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = 'a';
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_WithNoPairInBetween()
        {
            const string input = "aba";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = 'a';

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_WithPairInBetween()
        {
            const string input = "abba";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = 'b';

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_Underscore()
        {
            const string input = "_b_";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = '_';

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_SameLength()
        {
            const string input = "aabb";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = 'a';

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_LeftLongerLength()
        {
            const string input = "acabb";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = 'a';

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_RightLongerLength()
        {
            const string input = "aabcb";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            const char expected = 'b';

            Assert.AreEqual(expected, actual);
        }
    }
}
