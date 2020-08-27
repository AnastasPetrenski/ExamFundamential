using System;
using System.Collections.Generic;
using System.Linq;

namespace _112019_NikuldensMeal
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            int unlikedMealCount = 0;
            while ((command = Console.ReadLine()) != "Stop")
            {
                List<string> commands = command.Split("-", StringSplitOptions.RemoveEmptyEntries).ToList();
                string action = commands[0];
                string guest = commands[1];
                string meal = commands[2];
                if (action == "Like")
                {
                    if (!guests.ContainsKey(guest))
                    {
                        guests.Add(guest, new List<string>());
                        guests[guest].Add(meal);
                    }
                    else
                    {
                        if (!guests[guest].Contains(meal))
                        {
                            guests[guest].Add(meal);
                        }
                    }
                }
                else if (action == "Unlike")
                {
                    if (!guests.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else
                    {
                        if (!guests[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            guests[guest].Remove(meal);
                            unlikedMealCount++;
                        }
                    }
                }
            }

            foreach (var guest in guests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"{guest.Key}: ");
                Console.WriteLine(string.Join(", ", guest.Value));
            }
            Console.WriteLine($"Unliked meals: {unlikedMealCount}");
        }
    }
}
