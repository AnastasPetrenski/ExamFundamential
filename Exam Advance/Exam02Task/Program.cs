using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam02Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int n = input[0];
            int m = input[1];

            int[,] matrix = new int[n, m];
            List<Position> flowers = new List<Position>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                if (command == string.Empty)
                {
                    return;
                }
                int[] coordinates = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Position newFlower = new Position(coordinates[0], coordinates[1]);
                if (IsNotOutOfMatrix(n, newFlower))
                {
                    flowers.Add(newFlower);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            for (int i = 0; i < flowers.Count; i++)
            {
                var current = flowers[i];
                var explorer = new Position(flowers[i].Row, flowers[i].Col);
                matrix[current.Row, current.Col]++;
                while (true)
                {
                    explorer.Row++;
                    if (IsNotOutOfMatrix(n, explorer))
                    {
                        matrix[explorer.Row, explorer.Col]++;
                    }
                    else
                    {
                        explorer = new Position(flowers[i].Row, flowers[i].Col);
                        break;
                    }
                }

                while (true)
                {
                    explorer.Row--;
                    if (IsNotOutOfMatrix(n, explorer))
                    {
                        matrix[explorer.Row, explorer.Col]++;
                    }
                    else
                    {
                        explorer = new Position(flowers[i].Row, flowers[i].Col);
                        break;
                    }
                }

                while (true)
                {
                    explorer.Col--;
                    if (IsNotOutOfMatrix(n, explorer))
                    {
                        matrix[explorer.Row, explorer.Col]++;
                    }
                    else
                    {
                        explorer = new Position(flowers[i].Row, flowers[i].Col);
                        break;
                    }
                }

                while (true)
                {
                    explorer.Col++;
                    if (IsNotOutOfMatrix(n, explorer))
                    {
                        matrix[explorer.Row, explorer.Col]++;
                    }
                    else
                    {
                        explorer = new Position(flowers[i].Row, flowers[i].Col);
                        break;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public static bool IsNotOutOfMatrix(int n, Position flowerToBePlanted)
        {
            if (flowerToBePlanted.Row < 0 || flowerToBePlanted.Col < 0)
            {
                return false;
            }
            if (flowerToBePlanted.Row >= n || flowerToBePlanted.Col >= n)
            {
                return false;
            }

            return true;
        }
    }

    public class Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}

