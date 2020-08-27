using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _042020_MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"([@#])([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1");
            string input = Console.ReadLine();
            var pairs = pattern.Matches(input);
            if (pairs.Count > 0)
            {
                Console.WriteLine($"{pairs.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine($"No word pairs found!");
            }

            List<string> words = new List<string>();
            foreach (Match pair in pairs)
            {
                string firstWord = pair.Groups[2].Value;
                string secondWord = pair.Groups[3].Value;
                if (firstWord.Length == secondWord.Length)
                {
                    var reverseSecondWord = secondWord.Reverse();
                    StringBuilder reversedWord = new StringBuilder(); 
                    foreach (var item in reverseSecondWord)
                    {
                        reversedWord.Append(item);
                    }
                    if (firstWord == reversedWord.ToString())
                    {
                        string addPairWors = $"{pair.Groups[2].Value} <=> {pair.Groups[3].Value}";
                        words.Add(addPairWors);
                    }
                }
            }

            if (words.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", words));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
