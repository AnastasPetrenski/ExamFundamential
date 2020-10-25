using System;
using System.Collections.Generic;
using System.Linq;

namespace _102018_04_CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> cups = new Stack<int>(ReadInput().Reverse());
            Stack<int> bottles = new Stack<int>(ReadInput());
            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int cup = cups.Pop();
                int bottle = bottles.Pop();

                if (cup < bottle)
                {
                    int waste = bottle - cup;
                    wastedWater += waste;
                }
                else if (cup > bottle)
                {
                    cups.Push(cup - bottle);
                }
            }

            Console.WriteLine(cups.Count > 0 ? $"Cups: {string.Join(" ", cups)}" : $"Bottles: {string.Join(" ", bottles)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
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
