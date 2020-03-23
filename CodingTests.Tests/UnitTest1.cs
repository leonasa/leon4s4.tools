using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingTests.Tests
{
    [TestClass()]
    public class HackerRankTests
    {
        [TestMethod()]
        public void RepeatedStringTest_Sample1()
        {
            var repeatedString = HackerRank.RepeatedString("aba", 10);
            Assert.AreEqual(7, repeatedString);
        }

        [TestMethod()]
        public void RepeatedStringTest_LongSample_Simple()
        {
            var repeatedString = HackerRank.RepeatedString("a", 1000000000000);
            Assert.AreEqual(1000000000000, repeatedString);
        }

        [TestMethod()]
        public void RepeatedStringTest_LongSample_Double()
        {
            var repeatedString = HackerRank.RepeatedString("ab", 1000000000000);
            Assert.AreEqual(500000000000, repeatedString);
        }
    }
}