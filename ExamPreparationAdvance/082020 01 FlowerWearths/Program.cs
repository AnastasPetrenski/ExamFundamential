using System;
using System.Collections.Generic;
using System.Linq;

namespace _082020_01_FlowerWearths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(ReadInput());
            Queue<int> roses = new Queue<int>(ReadInput());
            int leftFlowers = 0;
            int totalWearths = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                if(!lilies.TryPeek(out int lily))
                {
                    break;
                }

                if (!roses.TryPeek(out int rose))
                {
                    break;
                }

                int sum = lily + rose;
                if (sum < 15)
                {
                    leftFlowers += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum == 15)
                {
                    totalWearths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    lilies.Pop();
                    lilies.Push(lily - 2);
                }
            }

            if (leftFlowers > 0)
            {
                totalWearths += (leftFlowers / 15);
            }

            string result = totalWearths >= 5 ? $"You made it, you are going to the competition with {totalWearths} wreaths!" 
                                              : $"You didn't make it, you need {5 - totalWearths} wreaths more!";
            Console.WriteLine(result);
        }

        public static int[] ReadInput()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            return input;
        }
    }
}
