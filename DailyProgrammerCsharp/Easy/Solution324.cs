using System;

namespace DailyProgrammerCsharp.Easy
{
    public class Solution324 : ISolution
    {
        // https://www.reddit.com/r/dailyprogrammer/comments/6nstip/20170717_challenge_324_easy_manual_square_root/
        public void Run()
        {
            do
            {
                int precision;
                do
                {
                    try
                    {
                        Console.Write("Precision: ");
                        precision = int.Parse(Console.ReadLine());

                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                } while (true);

                double input;
                do
                {
                    try
                    {
                        Console.Write("Input: ");
                        input = double.Parse(Console.ReadLine());

                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                } while (true);

                Console.WriteLine("Output: " + SqRootAndRound(input, precision));

                Console.WriteLine("Exit? y/n");
            } while (Console.ReadLine() != "y");
        }

        public static string SqRootAndRound(double input, int precision)
        {
            var result = SqRoot(input);

            return Round(result, precision);
        }

        // https://en.wikipedia.org/wiki/Methods_of_computing_square_roots#Babylonian_method
        public static double SqRoot(double input)
        {
            int precision = input.ToString().Length;

            double x = precision * 100;

            for (var i = 0; i < (precision + 1); i++)
            {
                x = (x + input / x) / 2;
            }

            return x;
        }

        public static string Round(double input, int precision)
        {
            var inputStr = input.ToString();

            var dp = inputStr.IndexOf(".");

            var length = dp > 0 ? dp : inputStr.Length;

            if (dp > 0 && precision > 0)
            {
                length += precision + 1;
            }

            var modified = inputStr;

            if (inputStr.Length < length)
            {
                modified = modified.PadRight(length - modified.Length).Replace(" ", "0");
            }
            else
            {
                modified = modified.Substring(0, length);
            }

            return modified;
        }
    }
}
