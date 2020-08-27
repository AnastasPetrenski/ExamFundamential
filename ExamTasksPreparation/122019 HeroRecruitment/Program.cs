using System;
using System.Collections.Generic;
using System.Linq;

namespace _122019_HeroRecruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heros = new Dictionary<string, List<string>>(); 
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                List<string> commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands.Contains("Enroll"))
                {
                    string name = commands[1];
                    if (!heros.ContainsKey(name))
                    {
                        heros.Add(name, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already enrolled.");
                    }
                }
                else if (commands.Contains("Learn"))
                {
                    string name = commands[1];
                    string spell = commands[2];
                    if (!heros.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        if (heros[name].Contains(spell))
                        {
                            Console.WriteLine($"{name} has already learnt {spell}.");
                        }
                        else
                        {
                            heros[name].Add(spell);
                        }
                    }
                }
                else if (commands.Contains("Unlearn"))
                {
                    string name = commands[1];
                    string spell = commands[2];
                    if (!heros.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        if (!heros[name].Contains(spell))
                        {
                            Console.WriteLine($"{name} doesn't know {spell}.");
                        }
                        else
                        {
                            heros[name].Remove(spell);
                        }
                    }
                }
            }

            Console.WriteLine("Heroes:");
            foreach (var hero in heros.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.Write($"== {hero.Key}: ");
                Console.WriteLine(string.Join(", ", hero.Value));
            }
        }
    }
}
