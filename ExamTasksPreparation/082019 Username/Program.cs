using System;
using System.Collections.Generic;
using System.Linq;

namespace _082019_Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Sign up")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commands.Contains("Case"))
                {
                    username = ChangeLetterSize(username, commands);
                    Console.WriteLine(username);
                }
                else if (commands.Contains("Reverse"))
                {
                    GetSubstringAndReverseIt(username, commands);
                }
                else if (commands.Contains("Cut"))
                {
                    List<string> result = CutSubstring(username, commands);
                    int index = int.Parse(result[1]);
                    if (index != -1)
                    {
                        username = result[0];
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {result[2]}.");
                    }
                }
                else if (commands.Contains("Replace"))
                {
                    username = ReplaceChar(username, commands);
                    Console.WriteLine(username);
                }
                else if (commands.Contains("Check"))
                {
                    UserValidation(username, commands);
                }
            }
        }

        public static void UserValidation(string username, string[] commands)
        {
            char userMustContainChar = char.Parse(commands[1]);
            int index = username.IndexOf(userMustContainChar);
            if (index == -1)
            {
                Console.WriteLine($"Your username must contain {userMustContainChar}.");
            }
            else
            {
                Console.WriteLine("Valid");
            }
        }

        public static string ReplaceChar(string username, string[] commands)
        {
            char replaced = char.Parse(commands[1]);
            username = username.Replace(replaced, '*');
            return username;
        }

        public static List<string> CutSubstring(string username, string[] commands)
        {
            string substring = commands[1];
            int startIndex = username.IndexOf(substring);
            if (startIndex != -1)
            {
                username = username.Remove(startIndex, substring.Length);
            }
            List<string> result = new List<string>();
            result.Add(username);
            result.Add(startIndex.ToString());
            result.Add(substring);
            return result;
        }

        public static void GetSubstringAndReverseIt(string username, string[] commands)
        {
            int first = int.Parse(commands[1]);
            int second = int.Parse(commands[2]);
            int startIndex = Math.Min(first, second);
            int endIndex = Math.Max(first, second);
            int length = Math.Abs(first - second);
            if ((startIndex >= 0 && startIndex < username.Length) && (endIndex >= 0 && endIndex < username.Length))
            {
                string substring = username.Substring(startIndex, length+1);
                var reversed = substring.Reverse();
                Console.WriteLine(string.Join("", reversed));
            }
        }

        public static string ChangeLetterSize(string username, string[] commands)
        {
            if (commands[1] == "lower")
            {
                username = username.ToLower();
            }
            else if (commands[1] == "upper")
            {
                username = username.ToUpper();
            }
            return username;
        }
    }
}
