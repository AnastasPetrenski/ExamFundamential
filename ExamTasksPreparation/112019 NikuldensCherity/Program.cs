using System;
using System.Collections.Generic;
using System.Linq;

namespace _112019_NikuldensCherity
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Finish")
            {
                List<string> commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands.Contains("Replace"))
                {
                    var oldExpression = commands[1];
                    var substitute = commands[2];
                    input = input.Replace(oldExpression, substitute);
                }
                else if (commands.Contains("Cut"))
                {
                    int firstIndex = int.Parse(commands[1]);
                    int secondIndex = int.Parse(commands[2]);
                    int startIndex = Math.Min(firstIndex, secondIndex);
                    int endIndex = Math.Max(firstIndex, secondIndex);
                    int count = Math.Abs(endIndex - startIndex);
                    if ((startIndex >= 0 && startIndex <= input.Length - 1) && (endIndex >= 0 && endIndex <= input.Length - 1))
                    {
                        input = input.Remove(startIndex, count+1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                        continue;
                    }

                }
                else if (commands.Contains("Make"))
                {
                    if (commands[1] == "Upper")
                    {
                        input = input.ToUpper();
                    }
                    else if (commands[1] == "Lower")
                    {
                        input = input.ToLower();
                    }
                }
                else if (commands.Contains("Check"))
                {
                    string lookUpString = commands[1];
                    int checkIndex = input.IndexOf(lookUpString);
                    if (checkIndex == -1)
                    {
                        Console.WriteLine($"Message doesn't contain {lookUpString}");
                        continue;
                    }
                    else if (checkIndex != -1)
                    {
                        Console.WriteLine($"Message contains {lookUpString}");
                        continue;
                    }
                }
                else if (commands.Contains("Sum"))
                {
                    int firstIndex = int.Parse(commands[1]);
                    int secondIndex = int.Parse(commands[2]);
                    int startIndex = Math.Min(firstIndex, secondIndex);
                    int endIndex = Math.Max(firstIndex, secondIndex);
                    int count = Math.Abs(endIndex - startIndex);
                    if ((startIndex >= 0 && startIndex <= input.Length - 1) && (endIndex >= 0 && endIndex <= input.Length - 1))
                    {
                        string substring = input.Substring(startIndex, count+1);
                        int result = 0;
                        for (int i = 0; i < substring.Length; i++)
                        {
                            result += substring[i];
                        }
                        Console.WriteLine(result);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                        continue;
                    }
                    
                }
                Console.WriteLine(input);
            }
        }
    }
}
