using System;

namespace _102019_02_BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            Position player = null;

            for (int rows = 0; rows < n; rows++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < n; cols++)
                {
                    matrix[rows, cols] = input[cols];
                    if (input[cols] == 'P')
                    {
                        player = new Position(rows, cols);
                    }
                }
            }

            string command = string.Empty;
            matrix[player.Row, player.Col] = '-';
            while ((command = Console.ReadLine()) != "end")
            {
                Position current = new Position(player.Row, player.Col); 

                NextPosition(command, player);

                if (IsOutOfMatrix(n, player))
                {
                    if (str.Length > 0)
                    {
                        str = str.Remove(str.Length - 1, 1);
                    }

                    player = current;
                    continue;
                }
                
                if (char.IsLetter(matrix[player.Row, player.Col]))
                {
                    str += matrix[player.Row, player.Col];
                    matrix[player.Row, player.Col] = '-';
                }

            }

            matrix[player.Row, player.Col] = 'P';
            Console.WriteLine(str);
            PrintMatrix(matrix);
        }

        public static void NextPosition(string command, Position player)
        {
            if (command == "up")
            {
                player.Row--;
            }
            if (command == "down")
            {
                player.Row++;
            }
            if (command == "left")
            {
                player.Col--;
            }
            if (command == "right")
            {
                player.Col++;
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

