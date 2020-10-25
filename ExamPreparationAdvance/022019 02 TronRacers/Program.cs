using System;

namespace _022019_02_TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            Position firstPlayer = null;
            Position secondPlayer = null;

            for (int rows = 0; rows < n; rows++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (input[cols] == 'f')
                    {
                        firstPlayer = new Position(rows, cols);
                    }
                    if (input[cols] == 's')
                    {
                        secondPlayer = new Position(rows, cols);
                    }
                }
            }

            while (true)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                NextPosition(matrix, n, commands[0], firstPlayer);
                if (matrix[firstPlayer.Row, firstPlayer.Col] != '*')
                {
                    matrix[firstPlayer.Row, firstPlayer.Col] = 'x';
                    break;
                }
                else
                {
                    matrix[firstPlayer.Row, firstPlayer.Col] = 'f';
                }
                NextPosition(matrix, n, commands[1], secondPlayer);
                if (matrix[secondPlayer.Row, secondPlayer.Col] != '*')
                {
                    matrix[secondPlayer.Row, secondPlayer.Col] = 'x';
                    break;
                }
                else
                {
                    matrix[secondPlayer.Row, secondPlayer.Col] = 's';
                }
            }

            PrintMatrix(matrix);
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

        public static bool IsOutOfMatrix(int n, Position bee)
        {
            if (bee.Row < 0 || bee.Col < 0)
            {
                return true;
            }
            if (bee.Row >= n || bee.Col >= n)
            {
                return true;
            }

            return false;
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
