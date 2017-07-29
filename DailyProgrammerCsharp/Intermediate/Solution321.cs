using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DailyProgrammerCsharp.Intermediate
{
    // https://www.reddit.com/r/dailyprogrammer/comments/6k123x/20170629_challenge_321_intermediate_affine_cipher/
    public class Solution321 : ISolution
    {
        private static int[] factors = {3, 5, 7, 9, 11, 15, 17, 19, 21, 23, 25};

        public void Run()
        {
            do
            {
                Console.WriteLine("Input your string to decipher");

                string cipher = Console.ReadLine();

                string result = Uncipher(cipher);

                Console.WriteLine("Result found:");
                Console.WriteLine(result);

                Console.WriteLine("Exit? y/n");
            } while (Console.ReadLine() != "y") ;
        }

        public static string Uncipher(string toConvert)
        {
            toConvert = toConvert.ToLower();

            var words = Regex.Split(toConvert, "[^A-Za-z]");

            string longest = "";

            foreach (var word in words)
            {
                if (longest.Length < word.Length)
                {
                    longest = word;
                }
            }

            var numbers = CharConversion(longest);

            int a = 0;
            int b = 0;

            void FindFactors()
            {
                for (int i = 0; i < factors.Length; i++)
                {
                    a = factors[i];

                    for (b = 0; b < 26; b++)
                    {

                        // "Decoding is done in the same fashion as encoding: P ≡ aC + b"
                        var result = DecipherWord(numbers, a, b);

                        Console.WriteLine("a: " + a + " b: " + b + " result: " + result);

                        if (Regex.Match(Properties.Resources.enable1, "^" + result + "$").Success)
                        {
                            Console.WriteLine("Found!");
                            return;
                        }
                    }
                }

                a = 1;
                b = 0;
            }

            // Is there a better way of breaking out? Dont feel like using booleans or gotos
            FindFactors();

            foreach (var word in words)
            {
                // Manually replacing to ensure no overlap with other word fragments
                int start = toConvert.IndexOf("word");
                toConvert = toConvert.Substring(0, start) + DecipherWord(CharConversion(word), a, b) +
                            toConvert.Substring(start + word.Length + 1);
            }

            return toConvert;
        }

        public static string DecipherWord(int[] toConvert, int a, int b)
        {
            int[] intResult = new int[toConvert.Length];

            Console.WriteLine("Deciphering a:" + a + " b:" + b);

            for (var i = 0; i < toConvert.Length; i++)
            {
                intResult[i] = (toConvert[i] * a + b) % 26;

                Console.WriteLine(intResult[i]);
            }

            return CharConversion(intResult);
        }

        /*
         * C# uppercase chars start at 65
         * C# lowercase chars start at 97
         */
        public static int[] CharConversion(string toConvert)
        {
            var array = toConvert.ToCharArray();

            var converted = new int[toConvert.Length];

            for (var i = 0; i < array.Length; i++)
            {
                converted[i] = ((int) array[i]) - 96;
            }

            return converted;
        }

        public static string CharConversion(int[] toConvert)
        {
            var output = "";

            foreach (var i in toConvert)
            {
                output += (char) (i + 96);
            }

            return output;
        }
    }
}