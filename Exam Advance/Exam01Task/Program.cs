using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam01Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(ReadInput1());
            Queue<int> threads = new Queue<int>(ReadInput());
            int taskToBeKilled = int.Parse(Console.ReadLine());

            while (tasks.Count > 0 && threads.Count > 0)
            {
                int task = tasks.Pop();
                int thread = threads.Dequeue();

                if (task == taskToBeKilled)
                {
                    StringBuilder sb = new StringBuilder();
                    sb
                        .AppendLine($"Thread with value {thread} killed task {taskToBeKilled}")
                        .Append($"{thread} {string.Join(" ", threads)}");
                    Console.WriteLine(sb.ToString().Trim());
                    break;
                }
                if (task <= thread)
                {
                    continue;
                }
                else
                {
                    tasks.Push(task);
                }
            }
        }

        public static int[] ReadInput1()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            return input;
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
