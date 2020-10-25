using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _022020_01_LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(ReadInput());
            Stack<int> secondBox = new Stack<int>(ReadInput());
            var totalCount = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                if (!firstBox.TryPeek(out int first))
                {
                    break;
                }

                if (!secondBox.TryPeek(out int second))
                {
                    break;
                }

                var result = first + second;
                if (result % 2 == 0)
                {
                    totalCount += result;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(firstBox.Count > 0 ? "Second lootbox is empty" : "First lootbox is empty")
              .AppendLine(totalCount >= 100 ? $"Your loot was epic! Value: {totalCount}" : $"Your loot was poor... Value: {totalCount}");

            Console.WriteLine(sb.ToString());
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
