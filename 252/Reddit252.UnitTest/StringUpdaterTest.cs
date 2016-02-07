using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reddit252.UnitTest
{
    [TestClass]
    public class StringUpdaterTest
    {
        private readonly IStringUpdater _stringUpdater = new StringUpdater();

        [TestMethod]
        public void Example_1()
        {
            const string input = "abcbba";
            var pair = new Pair('b', 1, 4);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "acbab";

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Example_2()
        {
            const string input = "aabcbded";
            var pair = new Pair('b', 2, 4);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "aacdedb";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_NothingInBetween()
        {
            const string input = "aa";
            var pair = new Pair('a', 0, 1);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "a";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_SomethingInBetween()
        {
            const string input = "aba";
            var pair = new Pair('a', 0, 2);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "ba";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair()
        {
            const string input = "bacadae";
            var pair = new Pair('a', 1, 5);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "bcadea";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair_EqualLength()
        {
            const string input = "bacacad";
            var pair = new Pair('a', 1, 3);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "bccada";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair_LeftLonger()
        {
            const string input = "bacdacae";
            var pair = new Pair('a', 1, 4);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "bcdcaea";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair_RightLonger()
        {
            const string input = "bacacdae";
            var pair = new Pair('a', 3, 6);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "baccdea";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair_LeftLonger_HasDuplicate()
        {
            const string input = "baccadae";
            var pair = new Pair('a', 4, 6);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "baccdea";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair_RightLonger_HasDuplicate()
        {
            const string input = "bacaddae";
            var pair = new Pair('a', 1, 3);

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "bcddaea";

            Assert.AreEqual(expected, actual);
        }
    }
}
