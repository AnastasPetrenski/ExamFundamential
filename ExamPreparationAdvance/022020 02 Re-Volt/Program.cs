using System;

namespace _022020_02_Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numberOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            Position player = null;

            for (int rows = 0; rows < n; rows++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (input[cols] == 'f')
                    {
                        player = new Position(rows, cols);
                    }
                }
            }

            bool isWon = false;
            matrix[player.Row, player.Col] = '-';
            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                Position oldPosition = new Position(player.Row, player.Col);
                NextPosition(matrix, n, command, player);

                if (matrix[player.Row, player.Col] == 'F')
                {
                    isWon = true;
                    break;
                }
                else if (matrix[player.Row, player.Col] == 'B')
                {
                    NextPosition(matrix, n, command, player);
                }
                else if (matrix[player.Row, player.Col] == 'T')
                {
                    player = oldPosition;
                }
            }

            matrix[player.Row, player.Col] = 'f';
            Console.WriteLine(isWon ? "Player won!" : "Player lost!");

            PrintMatrix(matrix);
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
