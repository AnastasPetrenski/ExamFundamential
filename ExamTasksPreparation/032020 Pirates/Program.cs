using System;
using System.Collections.Generic;
using System.Linq;

namespace _032020_Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> targets = new Dictionary<string, List<int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Sail")
            {
                List<string> targetsData = input.Split("||", StringSplitOptions.RemoveEmptyEntries).ToList();
                string town = targetsData[0];
                int population = int.Parse(targetsData[1]);
                int gold = int.Parse(targetsData[2]);
                if (!targets.ContainsKey(town))
                {
                    targets.Add(town, new List<int>());
                    targets[town].Add(population);
                    targets[town].Add(gold);
                }
                else
                {
                    foreach (var item in targets.Where(x => x.Key == town))
                    {
                        item.Value[0] += population;
                        item.Value[1] += gold;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                List<string> commands = command.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands.Contains("Plunder"))
                {
                    string town = commands[1];
                    int people = int.Parse(commands[2]);
                    int gold = int.Parse(commands[3]);
                    int killedPeopple = 0;
                    int stolenGold = 0;
                    if (targets[town][0] < people)
                    {
                        killedPeopple = targets[town][0];
                    }
                    else
                    {
                        killedPeopple = people;
                    }

                    if (targets[town][1] < gold)
                    {
                        stolenGold = targets[town][1];
                    }
                    else
                    {
                        stolenGold = gold;
                    }

                    targets[town][0] -= people;
                    targets[town][1] -= gold;
                    Console.WriteLine($"{town} plundered! {stolenGold} gold stolen, {killedPeopple} citizens killed.");
                    if (targets[town][0] <= 0 || targets[town][1] <= 0)
                    {
                        Console.WriteLine($"{town} has been wiped off the map!");
                        targets.Remove(town);
                    }
                }
                else if (commands.Contains("Prosper"))
                {
                    string town = commands[1];
                    int gold = int.Parse(commands[2]);
                    //zero is not negative but we are considering it like negative
                    if (gold > 0)
                    {
                        targets[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {targets[town][1]} gold.");
                    }
                    else
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                }
            }

            if (targets.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {targets.Count} wealthy settlements to go to:");
                foreach (var town in targets.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value[0]} citizens, Gold: {town.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
