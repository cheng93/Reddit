using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit252.UnitTest
{
    [TestClass]
    public class PairGetterTest
    {
        private readonly IPairGetter _pairGetter = new NewPairGetter();

        [TestMethod]
        public void Example_1()
        {
            const string input = "abcbba";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('b', 1, 4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Example_2()
        {
            const string input = "aabcbded";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('b', 2, 4);

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
            var expected = new Pair('a', 0, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_WithNoPairInBetween()
        {
            const string input = "aba";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 0, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_WithPairInBetween()
        {
            const string input = "abba";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('b', 1, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_Underscore()
        {
            const string input = "_b_";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('_', 0, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_SameLength()
        {
            const string input = "aabb";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 0, 1);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_SameLength_Alternate()
        {
            const string input = "abab";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 0, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_SameLength_Consecutive()
        {
            const string input = "aaaa";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 0, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_LeftLongerLength()
        {
            const string input = "acabb";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 0, 2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_LeftLongerLength_SameCharacters()
        {
            const string input = "abcaca";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 0, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_RightLongerLength()
        {
            const string input = "aabcb";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('b', 2, 4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultiplePair_RightLongerLength_SameCharacters()
        {
            const string input = "ababca";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 2, 5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PairInAPair_LeftLongerLength()
        {
            const string input = "acbab";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 0, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PairInAPair_RightLongerLength()
        {
            const string input = "abacb";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('b', 1, 4);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HardSituation()
        {
            const string input = "abcababcda";

            var actual = _pairGetter.GetWidestLeftMostPair(input);
            var expected = new Pair('a', 5, 9);

            Assert.AreEqual(expected, actual);
        }
    }
}
