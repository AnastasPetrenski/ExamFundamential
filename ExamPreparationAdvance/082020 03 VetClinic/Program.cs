using System;

namespace _082020_02_Bee
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

            int flowerPollinated = 0;
            matrix[bee.Row, bee.Col] = '.';
            
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    matrix[bee.Row, bee.Col] = 'B';
                    break;
                }

                NextPosition(command, bee);

                if (!IsOutOfMatrix(n, bee))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[bee.Row, bee.Col] == 'f')
                {
                    flowerPollinated++;
                    matrix[bee.Row, bee.Col] = '.';
                }
                else if (matrix[bee.Row, bee.Col] == 'O')
                {
                    matrix[bee.Row, bee.Col] = '.';

                    NextPosition(command, bee);

                    if (matrix[bee.Row, bee.Col] == 'f')
                    {
                        flowerPollinated++;
                        matrix[bee.Row, bee.Col] = '.';
                    }
                }
            }

            string result = flowerPollinated >= 5 ? $"Great job, the bee managed to pollinate {flowerPollinated} flowers!"
                                                  : $"The bee couldn't pollinate the flowers, she needed {5 - flowerPollinated} flowers more";
            Console.WriteLine(result);
            PrintMatrix(matrix);

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
