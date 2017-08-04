using System;
using System.Collections.Generic;
using DailyProgrammerCsharp.Easy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyProgrammerTests.Easy
{
    [TestClass]
    public class TestSolution325
    {
        private string[,] maze =
        {
            {"B", "O", "R", "O", "Y"},
            {"O", "R", "B", "G", "R"},
            {"B", "O", "G", "O", "Y"},
            {"Y", "G", "B", "Y", "G"},
            {"R", "O", "R", "B", "R"},
        };

        [TestMethod]
        public void TestSolveMaze()
        {
            var sequence = new Queue<string>(new[] { "G", "O" });
            var history = new Stack<int[]>();
            var done = Solution325.Navigate(3, 1, sequence, maze, history);

            Console.WriteLine(done);
        }


        [TestMethod]
        public void TestFindNext()
        {
            var next = Solution325.FindNext(1, 4, "G", maze);

            Assert.AreEqual(1, next.Count);

            Assert.AreEqual("G", maze[next[0][1], next[0][0]]);
        }

    }
}
 