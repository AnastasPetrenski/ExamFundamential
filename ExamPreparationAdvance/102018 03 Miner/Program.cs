using System;
using System.Linq;

namespace _102018_03_Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int coalCount = 0;
            Position player = null;
            var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int rows = 0; rows < n; rows++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (input[cols] == 's')
                    {
                        player = new Position(rows, cols);
                    }
                    if (input[cols] == 'c')
                    {
                        coalCount++;
                    }
                }
            }

            bool noMoreCommands = true;
            for (int i = 0; i < commands.Length; i++)
            {
                NextPosition(matrix, n, commands[i], player);

                if (matrix[player.Row, player.Col] == 'c')
                {
                    matrix[player.Row, player.Col] = '*';
                    coalCount--;
                    if (coalCount == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({player.Row}, {player.Col})");
                        noMoreCommands = false;
                        break;
                    }
                }
                else if (matrix[player.Row, player.Col] == 'e')
                {
                    Console.WriteLine($"Game over! ({player.Row}, {player.Col})");
                    noMoreCommands = false;
                    break;
                }
            }

            if (noMoreCommands)
            {
                Console.WriteLine($"{coalCount} coals left. ({player.Row}, {player.Col})");
            }
        }

        public static void NextPosition(char[,] matrix, int n, string command, Position player)
        {
            if (command == "up")
            {
                player.Row--;
                if (IsOutOfMatrix(n, player))
                {
                    player.Row++;
                }
            }
            if (command == "down")
            {
                player.Row++;
                if (IsOutOfMatrix(n, player))
                {
                    player.Row--;
                }
            }
            if (command == "left")
            {
                player.Col--;
                if (IsOutOfMatrix(n, player))
                {
                    player.Col++;
                }
            }
            if (command == "right")
            {
                player.Col++;
                if (IsOutOfMatrix(n, player))
                {
                    player.Col--;
                }
            }
        }

        public static bool IsOutOfMatrix(int n, Position player)
        {
            if (player.Row < 0 || player.Col < 0)
            {
                return true;
            }
            if (player.Row >= n || player.Col >= n)
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
