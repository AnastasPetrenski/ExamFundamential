using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _102019_01_DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(ReadInput());
            Queue<int> females = new Queue<int>(ReadInput());
            int matchesCount = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                if (males.Peek() <= 0 || females.Peek() <= 0)
                {
                    if (males.Peek() <= 0)
                    {
                        males.Pop();
                    }
                    if (females.Peek() <= 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                if (males.Peek() % 25 == 0 || females.Peek() % 25 == 0)
                {
                    if (males.Peek() % 25 == 0)
                    {
                        males.Pop();
                        males.Pop();
                    }
                    if (females.Peek() % 25 == 0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }
                    continue;
                }

                int male = males.Pop();
                int female = females.Dequeue();
                if (male == female)
                {
                    matchesCount++;
                }
                else
                {
                    males.Push(male - 2);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Matches: {matchesCount}")
                .AppendLine(males.Count > 0 ? $"Males left: {string.Join(", ", males)}" : "Males left: none")
                .AppendLine(females.Count > 0 ? $"Females left: {string.Join(", ", females)}" : "Females left: none");

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        public static int[] ReadInput()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            return input;
        }
    }
}
