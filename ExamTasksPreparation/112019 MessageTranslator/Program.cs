using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _112019_MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());
            Regex messageValidator = new Regex(@"!(?<command>[A-Z][a-z]{2,})!:\[(?<message>[A-z]{8,})\]");
            for (int i = 0; i < numberOfMessages; i++)
            {
                string input = Console.ReadLine();
                var validator = messageValidator.Match(input);
                if (validator.Success)
                {
                    string message = validator.Groups["message"].Value;
                    List<int> encrypted = new List<int>();
                    for (int j = 0; j < message.Length; j++)
                    {
                        int letter = message[j];
                        encrypted.Add(letter);
                    }
                    Console.Write($"{validator.Groups["command"].Value}: ");
                    Console.WriteLine(string.Join(" ", encrypted)); ;
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
