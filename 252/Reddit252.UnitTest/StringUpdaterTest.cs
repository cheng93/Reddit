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
            const char pair = 'b';

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "acbab";

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Example_2()
        {
            const string input = "aabcbded";
            const char pair = 'b';

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "aacdedb";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_NothingInBetween()
        {
            const string input = "aa";
            const char pair = 'a';

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "a";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimplePair_SomethingInBetween()
        {
            const string input = "aba";
            const char pair = 'a';

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "ba";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair()
        {
            const string input = "bacadae";
            const char pair = 'a';

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "bcadea";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair_EqualLength()
        {
            const string input = "bacacad";
            const char pair = 'a';

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "bccada";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair_LeftLonger()
        {
            const string input = "bacdacae";
            const char pair = 'a';

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "bcdcaea";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleOccuranceOfPair_RightLonger()
        {
            const string input = "bacacdae";
            const char pair = 'a';

            var actual = _stringUpdater.UpdateWithPair(input, pair);
            var expected = "baccdea";

            Assert.AreEqual(expected, actual);
        }
    }
}
