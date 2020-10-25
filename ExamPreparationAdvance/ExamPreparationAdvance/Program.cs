using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            Position bee = null;

            for (int rows = 0; rows < n; rows++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (input[cols] == 'B')
                    {
                        bee = new Position(rows, cols);
                    }
                }
            }
        }

        public static void NextPosition(char[,] matrix, int n, string command, Position player)
        {
            if (command == "up")
            {
                player.Row--;
                if (IsOutOfMatrix(n, player))
                {
                    player.Row = n - 1;
                }
            }
            if (command == "down")
            {
                player.Row++;
                if (IsOutOfMatrix(n, player))
                {
                    player.Row = 0;
                }
            }
            if (command == "left")
            {
                player.Col--;
                if (IsOutOfMatrix(n, player))
                {
                    player.Col = n - 1;
                }
            }
            if (command == "right")
            {
                player.Col++;
                if (IsOutOfMatrix(n, player))
                {
                    player.Col = 0;
                }
            }
        }

        public static void NextPosition(string command, Position bee)
        {
            if (command == "up")
            {
                bee.Row--;
            }
            if (command == "down")
            {
                bee.Row++;
            }
            if (command == "left")
            {
                bee.Col--;
            }
            if (command == "right")
            {
                bee.Col++;
            }
        }

        public static bool IsOutOfMatrix(int n, Position bee)
        {
            if (bee.Row < 0 || bee.Col < 0)
            {
                return false;
            }
            if (bee.Row >= n || bee.Col >= n)
            {
                return false;
            }

            return true;
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
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