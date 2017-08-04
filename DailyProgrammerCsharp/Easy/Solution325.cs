using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DailyProgrammerCsharp.Easy
{
    // https://www.reddit.com/r/dailyprogrammer/comments/6qutez/20170801_challenge_325_easy_color_maze/
    public class Solution325 : ISolution
    {
        public void Run()
        {
            Console.WriteLine("Please input a sequence");

            var sequence = Console.ReadLine().Split(' ');

            var seq = new Queue<string>(sequence);

            Console.WriteLine("Please input your maze");

            string mazeLine;

            var mazeLines = new List<string[]>();

            while ((mazeLine = Console.ReadLine()) != "" && mazeLine != null)
            {
                mazeLines.Add(mazeLine.Split(' '));
            }

            var maze = MakeArray(mazeLines);

            SolveMaze(seq, maze);
        }

        public string[,] MakeArray(List<string[]> list)
        {
            var array = new string[list.Count, list[0].Length];

            for (var i = 0; i < list.Count; i++)
            {
                for (var j = 0; j < list[i].Length; j++)
                {
                    array[i, j] = list[i][j];
                }
            }

            return array;
        }

        public static void SolveMaze(Queue<string> sequence, string[,] maze)
        {
            var height = maze.GetLength(0);
            var width = maze.GetLength(1);

            var history = new Stack<int[]>();

            Console.WriteLine("Starting");

            for (var i = 0; i < width; i++)
            {
                if (maze[height - 1, i] == sequence.Peek())
                {
                    history.Push(new []{i, height - 1});
                    var found = Navigate(i, height - 1, sequence, maze, history);

                    if (found)
                    {
                        break;
                    }
                }

                history = new Stack<int[]>();
            }

            Console.WriteLine("History: " + history.Count);

            if (history.Count > 0)
            {
                foreach (var coord in history)
                {
                    Console.WriteLine($@"({coord[0]},{coord[1]})");
                }
            }
        }

        public static bool Navigate(int x, int y, Queue<string> sequence, string[,] maze, Stack<int[]> history)
        {
            if (x == 0) return true;

            Console.WriteLine("Current: " + sequence.Peek());

            // Cycles sequence
            sequence.Enqueue(sequence.Dequeue());

            Console.WriteLine(x + " " + y + " " + sequence.Peek());
            var next = FindNext(x, y, sequence.Peek(), maze);

            Console.WriteLine("Next: " + next.Count);

            foreach (var nextxy in next)
            {
                if (!history.Contains(nextxy))
                {
                    var found = Navigate(nextxy[0], nextxy[1], sequence, maze, history);

                    if (found)
                    {
                        history.Push(nextxy);

                        return true;
                    }
                }
            }

            return false;
        }

        public static List<int[]> FindNext(int x, int y, string item, string[,] maze)
        {
            var list = new List<int[]>();
            if (x - 1 >= 0 && maze[y, x - 1].Equals(item))
            {
                list.Add(new[] { x - 1, y });
            }
            
            // This one again
            Console.WriteLine(maze[y - 1, x] + " " + (y - 1) + " " + x);
            if (y - 1 >= 0 && maze[y - 1, x].Equals(item))
            {
                list.Add(new[] { x, y - 1 });
            }

            if (x + 1 < maze.GetLength(1) && maze[y, x + 1].Equals(item))
            {
                list.Add(new[] { x + 1, y });
            }

            if (y + 1 < maze.GetLength(0) && maze[y + 1, x].Equals(item))
            {
                list.Add(new[] { x, y + 1 });
            }

            return list;
        }
    }
}