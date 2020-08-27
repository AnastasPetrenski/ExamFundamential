using System;
using System.Collections.Generic;
using System.Linq;

namespace Task01_09082020
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Travel")
            {
                List<string> commands = command.Split(":", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands.Contains("Add Stop"))
                {
                    int index = int.Parse(commands[1]);
                    if (index >= 0 && index <= input.Length - 1)
                    {
                        string insertDestination = commands[2];
                        input = input.Insert(index, insertDestination);
                    }
                    
                }
                else if (commands.Contains("Remove Stop"))
                {
                    int firstIndex = int.Parse(commands[1]);
                    int secondIndex = int.Parse(commands[2]);
                    int startIndex = Math.Min(firstIndex, secondIndex);
                    int endIndex = Math.Max(firstIndex, secondIndex);
                    int count = Math.Abs(endIndex - startIndex);
                    if ((startIndex >= 0 && startIndex <= input.Length - 1) && (endIndex >= 0 && endIndex <= input.Length - 1))
                    {
                        input = input.Remove(startIndex, count + 1);
                    }
                }
                else if (commands.Contains("Switch"))
                {
                    string oldString = commands[1];
                    string newString = commands[2];
                    input = input.Replace(oldString, newString);
                }
                Console.WriteLine(input);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }

        //public void printText(text)
        //{
        //    Console.WriteLine("I love" + text);
        //}
        //printText("C#");
        //string name = "George";
        //name[2] = "m";
        //Console.WriteLine(name[2]);

        //bool isTrue = 100f != 100d;
        //Console.WriteLine(isTrue);
    }

}
