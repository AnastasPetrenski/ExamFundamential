using System;
using System.Collections.Generic;
using System.Linq;

namespace _022018_02_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            Position player = null;
            Position enemy = null;
            List<Position> guardians = new List<Position>();

            for (int rows = 0; rows < n; rows++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                matrix[rows] = new char[input.Length];
                for (int cols = 0; cols < input.Length; cols++)
                {
                    matrix[rows][cols] = input[cols];
                    if (input[cols] == 'S')
                    {
                        player = new Position(rows, cols);
                    }
                    else if (input[cols] == 'N')
                    {
                        enemy = new Position(rows, cols);
                    }
                    else if (input[cols] == 'b' || input[cols] == 'd')
                    {
                        Position position = new Position(rows, cols);
                        guardians.Add(position);
                    }
                }
            }

            if (true)
            {
                //start at same Row player and enemy?!
            }

            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                matrix[player.Row][player.Col] = '.';

                for (int g = 0; g < guardians.Count; g++)
                {
                    NextPositionGuardians(matrix, n, guardians[g]);
                }

                if (guardians.Any(x => x.Row == player.Row))
                {
                    var currentGuard = guardians.FirstOrDefault(g => g.Row == player.Row);
                    if (matrix[currentGuard.Row][currentGuard.Col] == 'd' && currentGuard.Col > player.Col)
                    {
                        matrix[player.Row][player.Col] = 'X';
                        Console.WriteLine($"Sam died at {player.Row}, {player.Col}");
                        break;
                    }
                    else if (matrix[currentGuard.Row][currentGuard.Col] == 'b' && currentGuard.Col < player.Col)
                    {
                        matrix[player.Row][player.Col] = 'X';
                        Console.WriteLine($"Sam died at {player.Row}, {player.Col}");
                        break;
                    }
                }

                NextPositionPlayer(commands[i], player);
                
                if (matrix[player.Row][player.Col] == 'b' || matrix[player.Row][player.Col] == 'd')
                {
                    var guardToRemove = guardians.FirstOrDefault(g => g.Row == player.Row && g.Col == player.Col);
                    guardians.Remove(guardToRemove);
                }
                
                if (player.Row == enemy.Row)
                {
                    matrix[enemy.Row][enemy.Col] = 'X';
                    matrix[player.Row][player.Col] = 'S';
                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            PrintMatrix(matrix);
        }

        public static void NextPositionPlayer(char command, Position player)
        {
            if (command == 'U')
            {
                player.Row--;
            }
            if (command == 'D')
            {
                player.Row++;
            }
            if (command == 'L')
            {
                player.Col--;
            }
            if (command == 'R')
            {
                player.Col++;
            }
        }

        public static void NextPositionGuardians(char[][] matrix, int n, Position guard)
        {
            
            if (matrix[guard.Row][guard.Col] == 'd')
            {
                if (!guard.isTurned)
                {
                    matrix[guard.Row][guard.Col] = '.';
                    guard.Col--;
                    if (IsOutOfMatrix(matrix[guard.Row].Length, guard))
                    {
                        guard.Col++;
                        matrix[guard.Row][guard.Col] = 'b';
                        guard.isTurned = true;
                    }
                    else
                    {
                        matrix[guard.Row][guard.Col] = 'd';
                    }
                }
                
            }
            if (matrix[guard.Row][guard.Col] == 'b')
            {
                if (!guard.isTurned)
                {
                    matrix[guard.Row][guard.Col] = '.';
                    guard.Col++;
                    if (IsOutOfMatrix(matrix[guard.Row].Length, guard))
                    {
                        guard.Col--;
                        matrix[guard.Row][guard.Col] = 'd';
                        guard.isTurned = true;
                    }
                    else
                    {
                        matrix[guard.Row][guard.Col] = 'b';
                    }
                }
                
            }
        }

        public static bool IsOutOfMatrix(int n, Position guard)
        {
            if (guard.Row < 0 || guard.Col < 0)
            {
                return true;
            }
            if (guard.Row > n-1 || guard.Col > n-1)
            {
                return true;
            }

            return false;
        }

        public static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }

    public class Position
    {
        public bool isTurned;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.isTurned = false;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
