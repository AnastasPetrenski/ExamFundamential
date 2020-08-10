using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task02_09082020
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"([\=\/])(?<name>[A-Z][A-z]{2,})\1");
            string input = Console.ReadLine();
            var destinations = pattern.Matches(input);
            if (destinations.Count > 0)
            {
                int points = 0;
                List<string> travelPlaces = new List<string>();
                foreach (Match destination in destinations)
                {
                    string lengthDestination = destination.Groups["name"].Value;
                    travelPlaces.Add(lengthDestination);
                    points += lengthDestination.Length;
                }
                Console.Write($"Destinations: ");
                Console.WriteLine(string.Join(", ", travelPlaces));
                Console.WriteLine($"Travel Points: {points}");
            }
            else
            {
                Console.WriteLine("Destinations:");
                Console.WriteLine("Travel Points: 0");
            }
        }
    }
}
