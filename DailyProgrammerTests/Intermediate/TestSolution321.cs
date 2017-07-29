using System;
using DailyProgrammerCsharp.Intermediate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DailyProgrammerTests.Intermediate
{
    [TestClass]
    public class TestSolution321
    {
        [TestMethod]
        public void TestUncipher()
        {
            string cipher = "tuuhed";

            string plaintext = Solution321.Uncipher(cipher);

            Console.WriteLine(plaintext);

            Assert.AreEqual("foobar", plaintext);

            cipher = "NLWC WC M NECN";

            plaintext = Solution321.Uncipher(cipher);

            Console.WriteLine(plaintext);

            Assert.AreEqual("this is a test", plaintext);
        }

        [TestMethod]
        public void TestDecipherWord()
        {
            string word = "tuuhed";
            int[] chars = Solution321.CharConversion(word);

            foreach (var c in chars)
            {
                Console.WriteLine(c);
            }

            string cipher = Solution321.DecipherWord(chars, 3, 2);

            Console.WriteLine(cipher);

            Assert.AreEqual("foobar", cipher);
        }

        [TestMethod]
        public void TestCharConversionFromString()
        {
            int[] result = Solution321.CharConversion("foobar");

            int[] expected = {
                6, 15, 15, 2, 1, 18
            };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCharConversionFromInt()
        {
            int[] letters = {
                6, 15, 15, 2, 1, 18
            };

            string result = Solution321.CharConversion(letters);

            Assert.AreEqual("foobar", result);
        }
    }
}