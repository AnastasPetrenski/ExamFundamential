using System;
using System.Text.RegularExpressions;

namespace _122019_BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"\|(?<name>[A-Z]{4,})\|\:\#(?<title>[A-z]+ [A-z]+)\#");
            int inputNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputNumber; i++)
            {
                string input = Console.ReadLine();
                var result = pattern.Match(input);
                if (result.Success)
                {
                    Console.WriteLine($"{result.Groups["name"].Value}, The {result.Groups["title"].Value}");
                    Console.WriteLine($">> Strength: {result.Groups["name"].Length}");
                    Console.WriteLine($">> Armour: {result.Groups["title"].Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
