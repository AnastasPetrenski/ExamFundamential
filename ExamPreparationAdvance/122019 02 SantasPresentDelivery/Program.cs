using System;

namespace _122019_02_SantasPresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            Position santa = null;

            for (int rows = 0; rows < n; rows++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (input[cols] == "S")
                    {
                        santa = new Position(rows, cols);
                    }
                }
            }

            int happyKids = 0;
            string command = string.Empty;
            matrix[santa.Row, santa.Col] = "-";
            bool isRunOutPresents = false;
            bool isOutTheMatrix = false;
            while ((command = Console.ReadLine()) != "Christmas morning")
            {
                if (command == "left")
                {
                    santa.Col--;
                }
                if (command == "right")
                {
                    santa.Col++;
                }
                if (command == "up")
                {
                    santa.Row--;
                }
                if (command == "down")
                {
                    santa.Row++;
                }

                if (IsOutOfMatrix(n, santa))
                {
                    isOutTheMatrix = true;
                    break;
                }

                if (presentsCount <= 0)
                {
                    isRunOutPresents = true;
                    break;
                }

                if (matrix[santa.Row, santa.Col] == "V")
                {
                    presentsCount--;
                    happyKids++;
                    matrix[santa.Row, santa.Col] = "-";
                }
                else if (matrix[santa.Row, santa.Col] == "X")
                {
                    matrix[santa.Row, santa.Col] = "-";
                }
                else if (matrix[santa.Row, santa.Col] == "C")
                {
                    if (matrix[santa.Row, santa.Col-1] == "V" || matrix[santa.Row, santa.Col-1] == "X")
                    {
                        presentsCount--;
                        happyKids++;
                        matrix[santa.Row, santa.Col-1] = "-";
                        if (presentsCount <= 0)
                        {
                            isRunOutPresents = true;
                            break;
                        }
                    }
                    if (matrix[santa.Row, santa.Col+1] == "V" || matrix[santa.Row, santa.Col+1] == "X")
                    {
                        presentsCount--;
                        happyKids++;
                        matrix[santa.Row, santa.Col+1] = "-";
                        if (presentsCount <= 0)
                        {
                            isRunOutPresents = true;
                            break;
                        }
                    }
                    if (matrix[santa.Row-1, santa.Col] == "V" || matrix[santa.Row-1, santa.Col] == "X")
                    {
                        presentsCount--;
                        happyKids++;
                        matrix[santa.Row-1, santa.Col] = "-";
                        if (presentsCount <= 0)
                        {
                            isRunOutPresents = true;
                            break;
                        }
                    }
                    if (matrix[santa.Row+1, santa.Col] == "V" || matrix[santa.Row+1, santa.Col] == "X")
                    {
                        presentsCount--;
                        happyKids++;
                        matrix[santa.Row+1, santa.Col] = "-";
                        if (presentsCount <= 0)
                        {
                            isRunOutPresents = true;
                            break;
                        }
                    }

                    matrix[santa.Row, santa.Col] = "-";
                }
            }
            

            if (isRunOutPresents)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            if (isOutTheMatrix)
            {
                matrix[santa.Row, santa.Col] = "-";
            }
            else
            {
                matrix[santa.Row, santa.Col] = "S";
            }

            int noPresent = PrintMatrix(matrix);
            Console.WriteLine(noPresent > 0 ? $"No presents for {noPresent} nice kid/s." 
                                            : $"Good job, Santa! {happyKids} happy nice kid/s.");

        }

        public static bool IsOutOfMatrix(int n, Position santa)
        {
            if (santa.Row < 0 || santa.Col < 0)
            {
                return true;
            }
            if (santa.Row >= n || santa.Col >= n)
            {
                return true;
            }

            return false;
        }

        public static int PrintMatrix(string[,] matrix)
        {
            int count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                    if (matrix[row, col] == "V")
                    {
                        count++;
                    }
                }
                Console.WriteLine();
            }

            return count;
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

