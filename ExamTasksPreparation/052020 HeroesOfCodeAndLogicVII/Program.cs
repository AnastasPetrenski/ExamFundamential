using System;
using System.Collections.Generic;
using System.Linq;

namespace _052020_HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int herosNumber = int.Parse(Console.ReadLine());
            List<Hero> heros = new List<Hero>();
            for (int i = 0; i < herosNumber; i++)
            {
                List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                heros.Add(Hero.AddHero(input));
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                List<string> commands = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string heroName = commands[1];
                if (commands.Contains("CastSpell"))
                {
                    var currentMana = heros.Where(x => x.Name == commands[1]).Select(x => x.ManaPoints).ToList();
                    int neededMana = int.Parse(commands[2]);
                    if (currentMana[0] >= neededMana)
                    {
                        heros.Where(x => x.Name == commands[1]).Select(x => x.ManaPoints -= neededMana).ToList();
                        Console.WriteLine($"{heroName} has successfully cast {commands[3]} and now has {currentMana[0] - neededMana} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {commands[3]}!");
                    }
                }
                else if (commands.Contains("TakeDamage"))
                {
                    var currentHp = heros.Where(x => x.Name == heroName).Select(x => x.HitPoints).ToList();
                    int damage = int.Parse(commands[2]);
                    if (currentHp[0] - damage > 0)
                    {
                        heros.Where(x => x.Name == heroName).Select(x => x.HitPoints -= damage).ToList();
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {commands[3]} and now has {currentHp[0] - damage} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {commands[3]}!");
                        heros.RemoveAll(x => x.Name == heroName);
                    }
                }
                else if (commands.Contains("Recharge"))
                {
                    var currentMana = heros.Where(x => x.Name == commands[1]).Select(x => x.ManaPoints).ToList();
                    int addMana = int.Parse(commands[2]);
                    int maxMana = 200;
                    if (currentMana[0] + addMana > maxMana)
                    {
                        heros.Where(x => x.Name == heroName).Select(x => x.ManaPoints = maxMana).ToList();
                        Console.WriteLine($"{heroName} recharged for {maxMana - currentMana[0]} MP!");
                    }
                    else
                    {
                        heros.Where(x => x.Name == heroName).Select(x => x.ManaPoints += addMana).ToList();
                        Console.WriteLine($"{heroName} recharged for {addMana} MP!");
                    }
                }
                else if (commands.Contains("Heal"))
                {
                    var currentHp = heros.Where(x => x.Name == heroName).Select(x => x.HitPoints).ToList();
                    int addHp = int.Parse(commands[2]);
                    int maxHp = 100;
                    if (currentHp[0] + addHp > 100)
                    {
                        Console.WriteLine($"{heroName} healed for {maxHp - currentHp[0]} HP!");
                        currentHp = heros.Where(x => x.Name == heroName).Select(x => x.HitPoints = maxHp).ToList();
                    }
                    else
                    {
                        currentHp = heros.Where(x => x.Name == heroName).Select(x => x.HitPoints += addHp).ToList();
                        Console.WriteLine($"{heroName} healed for {addHp} HP!");
                    }
                }
            }

            foreach (var hero in heros.OrderByDescending(x => x.HitPoints).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"  HP: {hero.HitPoints}");
                Console.WriteLine($"  MP: {hero.ManaPoints}");
            }
        }
    }

    public class Hero
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }

        public static Hero AddHero(List<string> input)
        {
            Hero hero = new Hero();
            hero.Name = input[0];
            if (int.Parse(input[1]) > 100)
            {
                hero.HitPoints = 100;
            }
            else
            {
                hero.HitPoints = int.Parse(input[1]);
            }

            if (int.Parse(input[2]) > 200)
            {
                hero.ManaPoints = 200;
            }
            else
            {
                hero.ManaPoints = int.Parse(input[2]);
            }
            
            return hero;
        }
    }
}
