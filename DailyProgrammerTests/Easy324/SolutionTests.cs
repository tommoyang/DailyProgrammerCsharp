using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyProgrammerCsharp.Easy324;

namespace DailyProgrammerTests.Easy324
{
    [TestClass]
    public class SolutionTests
    {
        [TestMethod]
        public void TestSqRoot()
        {
            var input = 125348;
            var expected = "354.045";

            var output = Solution.SqRoot(input);
            var result = Solution.Round(output, 3);

            Assert.AreEqual(expected, result);

            Assert.AreEqual(expected, Solution.SqRootAndRound(input, 3));
        }

        /*
         * 0 7720.17 => 87.0
         * 1 7720.17 => 87.8
         * 2 7720.17 => 87.86
         * 0 12345 => 111.0
         * 8 123456 => 351.36306009
         */
        [TestMethod]
        public void DailyProgrammerTest()
        {
            Assert.AreEqual("87", Solution.SqRootAndRound(7720.17, 0));
            Assert.AreEqual("87.8", Solution.SqRootAndRound(7720.17, 1));
            Assert.AreEqual("87.86", Solution.SqRootAndRound(7720.17, 2));
            Assert.AreEqual("111", Solution.SqRootAndRound(12345, 0));
            Assert.AreEqual("351.36306009", Solution.SqRootAndRound(123456, 8));
        }
    }
}
 