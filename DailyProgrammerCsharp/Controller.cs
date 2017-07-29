using System;
using System.Reflection;

namespace DailyProgrammerCsharp
{
    public class Controller
    {
        static void Main(string[] args)
        {
            var difficulty = "";

            do
            {
                Console.WriteLine("Difficulty?");
                Console.WriteLine("e - Easy");
                Console.WriteLine("i - Intermediate");
                Console.WriteLine("h - hard");

                difficulty = Console.ReadLine();

                switch (difficulty)
                {
                    case "e":
                        difficulty = "Easy";
                        break;
                    case "i":
                        difficulty = "Intermediate";
                        break;
                    case "h":
                        difficulty = "Hard";
                        break;
                    default:
                        Console.WriteLine("Error - Please input a valid difficulty");
                        continue;
                }

                break;
            } while (true);

            do
            {
                Console.WriteLine("Solution?");

                try
                {
                    var solution = int.Parse(Console.ReadLine());

                    Assembly assembly = Assembly.Load("DailyProgrammerCsharp");
                    Type type = assembly.GetType("DailyProgrammerCsharp." + difficulty + ".Solution" + solution);

                    ISolution solutionObj = (ISolution) Activator.CreateInstance(type);

                    Console.WriteLine("Loading " + difficulty + " solution #" + solution);

                    solutionObj.Run();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Uh oh");
                    Console.WriteLine(e);
                    continue;
                }

                break;
            } while (true);
        }
    }
}