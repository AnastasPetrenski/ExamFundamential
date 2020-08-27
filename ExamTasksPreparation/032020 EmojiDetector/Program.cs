using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _032020_EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex digits = new Regex(@"\d");
            var matchedDigits = digits.Matches(input);
            var digitsFound = matchedDigits.Select(x => int.Parse(x.Value)).ToArray();
            long treshold = 1;
            treshold = digitsFound.Aggregate(1, (a, b) => a * b);
            //foreach (Match digit in matchedDigits)
            //{
            //    int value = int.Parse(digit.Value);
            //    treshold *= value;
            //}

            Console.WriteLine($"Cool threshold: {treshold}");

            Regex emojisPattern = new Regex(@"([:]{2}|[*]{2})(?<name>[A-Z][a-z]{2,})\1");
            var emojis = emojisPattern.Matches(input);
            if (emojis.Count > 0)
            {
                Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
                foreach (Match emoji in emojis)
                {
                    int totalSum = 0;
                    string emojiValue = emoji.Groups["name"].Value;
                    for (int i = 0; i < emojiValue.Length; i++)
                    {
                        totalSum += emojiValue[i];
                    }

                    if (totalSum > treshold)
                    {
                        Console.WriteLine($"{emoji}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            }

        }
    }
}
