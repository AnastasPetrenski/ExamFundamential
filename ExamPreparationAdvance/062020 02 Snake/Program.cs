using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace _062020_02_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] field = new char[n, n];
            Position snake = null;
            List<Position> burrows = new List<Position>();
            for (int rows = 0; rows < n; rows++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    field[rows, cols] = input[cols];
                    if (input[cols] == 'S')
                    {
                        snake = new Position(rows, cols);
                    }
                    if (input[cols] == 'B')
                    {
                        burrows.Add(new Position(rows, cols));
                    }
                }
            }

            int foodEaten = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "up" && snake.Row - 1 >= 0)
                {
                    if (field[snake.Row - 1, snake.Col] == '*')
                    {
                        field[snake.Row, snake.Col] = '.';
                        foodEaten++;
                        snake.Row -= 1;
                        field[snake.Row, snake.Col] = 'S';
                    }
                    else if (field[snake.Row - 1, snake.Col] == '-')
                    {
                        field[snake.Row, snake.Col] = '.';
                        snake.Row -= 1;
                        field[snake.Row, snake.Col] = 'S';
                    }
                    else if (field[snake.Row - 1, snake.Col] == 'B')
                    {
                        for (int i = 0; i < burrows.Count; i++)
                        {
                            var curr = burrows[i];
                            if (curr.Row == snake.Row - 1 && curr.Col == snake.Col)
                            {
                                burrows.Remove(curr);
                            }
                        }
                        field[snake.Row, snake.Col] = '.';
                        field[snake.Row - 1, snake.Col] = '.';
                        snake.Row = burrows[0].Row;
                        snake.Col = burrows[0].Col;
                        field[snake.Row, snake.Col] = 'S';
                    }

                }
                else if (command == "down" && snake.Row + 1 < field.GetLength(0))
                {
                    if (field[snake.Row + 1, snake.Col] == '*')
                    {
                        field[snake.Row, snake.Col] = '.';
                        foodEaten++;
                        snake.Row += 1;
                        field[snake.Row, snake.Col] = 'S';
                    }
                    else if (field[snake.Row + 1, snake.Col] == '-')
                    {
                        field[snake.Row, snake.Col] = '.';
                        snake.Row += 1;
                        field[snake.Row, snake.Col] = 'S';
                    }
                    else if (field[snake.Row + 1, snake.Col] == 'B')
                    {
                        for (int i = 0; i < burrows.Count; i++)
                        {
                            var curr = burrows[i];
                            if (curr.Row == snake.Row + 1 && curr.Col == snake.Col)
                            {
                                burrows.Remove(curr);
                            }
                        }
                        field[snake.Row, snake.Col] = '.';
                        field[snake.Row + 1, snake.Col] = '.';
                        snake.Row = burrows[0].Row;
                        snake.Col = burrows[0].Col;
                        field[snake.Row, snake.Col] = 'S';
                    }
                }
                else if (command == "right" && snake.Col + 1 < field.GetLength(1))
                {
                    if (field[snake.Row, snake.Col + 1] == '*')
                    {
                        field[snake.Row, snake.Col] = '.';
                        foodEaten++;
                        snake.Col += 1;
                        field[snake.Row, snake.Col] = 'S';
                    }
                    else if (field[snake.Row, snake.Col + 1] == '-')
                    {
                        field[snake.Row, snake.Col] = '.';
                        snake.Col += 1;
                        field[snake.Row, snake.Col] = 'S';
                    }
                    else if (field[snake.Row, snake.Col + 1] == 'B')
                    {
                        for (int i = 0; i < burrows.Count; i++)
                        {
                            var curr = burrows[i];
                            if (curr.Row == snake.Row && curr.Col == snake.Col + 1)
                            {
                                burrows.Remove(curr);
                            }
                        }
                        field[snake.Row, snake.Col] = '.';
                        field[snake.Row, snake.Col + 1] = '.';
                        snake.Row = burrows[0].Row;
                        snake.Col = burrows[0].Col;
                        field[snake.Row, snake.Col] = 'S';
                    }
                }
                else if (command == "left" && snake.Col - 1 >= 0)
                {
                    if (field[snake.Row, snake.Col - 1] == '*')
                    {
                        field[snake.Row, snake.Col] = '.';
                        foodEaten++;
                        snake.Col -= 1;
                        field[snake.Row, snake.Col] = 'S';
                    }
                    else if (field[snake.Row, snake.Col - 1] == '-')
                    {
                        field[snake.Row, snake.Col] = '.';
                        snake.Col -= 1;
                        field[snake.Row, snake.Col] = 'S';
                    }
                    else if (field[snake.Row, snake.Col - 1] == 'B')
                    {
                        for (int i = 0; i < burrows.Count; i++)
                        {
                            var curr = burrows[i];
                            if (curr.Row == snake.Row && curr.Col == snake.Col - 1)
                            {
                                burrows.Remove(curr);
                            }
                        }
                        field[snake.Row, snake.Col] = '.';
                        field[snake.Row, snake.Col - 1] = '.';
                        snake.Row = burrows[0].Row;
                        snake.Col = burrows[0].Col;
                        field[snake.Row, snake.Col] = 'S';
                    }
                }
                else
                {
                    field[snake.Row, snake.Col] = '.';
                    break;
                }

                if (foodEaten >= 10)
                {
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine(foodEaten >= 10 ? "You won! You fed the snake." : "Game over!")
                .AppendLine($"Food eaten: {foodEaten}");
            Console.WriteLine(sb.ToString().Trim());

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < n; cols++)
                {
                    Console.Write(field[rows, cols]);
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
