using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _032020_ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Generate")
            {
                List<string> commands = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands.Contains("Contains"))
                {
                    string substring = commands[1];
                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (commands.Contains("Flip"))
                {
                    if (commands[1] == "Upper")
                    {
                        int count = int.Parse(commands[3]) - int.Parse(commands[2]);
                        string substring = key.Substring(int.Parse(commands[2]), count);
                        string toUpper = substring.ToUpper();
                        key = key.Remove(int.Parse(commands[2]), count);
                        key = key.Insert(int.Parse(commands[2]), toUpper);
                        Console.WriteLine(key);
                    }
                    else if (commands[1] == "Lower")
                    {
                        int count = int.Parse(commands[3]) - int.Parse(commands[2]);
                        string substring = key.Substring(int.Parse(commands[2]), count);
                        string toUpper = substring.ToLower();
                        key = key.Remove(int.Parse(commands[2]), count);
                        key = key.Insert(int.Parse(commands[2]), toUpper);
                        Console.WriteLine(key);
                    }
                }
                else if (commands.Contains("Slice"))
                {
                    int start = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]) - int.Parse(commands[1]);
                    key = key.Remove(start, count);
                    Console.WriteLine(key);
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
