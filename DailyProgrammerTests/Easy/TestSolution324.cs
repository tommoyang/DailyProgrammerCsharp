using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyProgrammerTests.Easy
{
    [TestClass]
    public class TestSolution324
    {
        [TestMethod]
        public void TestSqRoot()
        {
            var input = 125348;
            var expected = "354.045";

            var output = DailyProgrammerCsharp.Easy.Solution324.SqRoot(input);
            var result = DailyProgrammerCsharp.Easy.Solution324.Round(output, 3);

            Assert.AreEqual(expected, result);

            Assert.AreEqual(expected, DailyProgrammerCsharp.Easy.Solution324.SqRootAndRound(input, 3));
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
            Assert.AreEqual("87", DailyProgrammerCsharp.Easy.Solution324.SqRootAndRound(7720.17, 0));
            Assert.AreEqual("87.8", DailyProgrammerCsharp.Easy.Solution324.SqRootAndRound(7720.17, 1));
            Assert.AreEqual("87.86", DailyProgrammerCsharp.Easy.Solution324.SqRootAndRound(7720.17, 2));
            Assert.AreEqual("111", DailyProgrammerCsharp.Easy.Solution324.SqRootAndRound(12345, 0));
            Assert.AreEqual("351.36306009", DailyProgrammerCsharp.Easy.Solution324.SqRootAndRound(123456, 8));
        }
    }
}
 