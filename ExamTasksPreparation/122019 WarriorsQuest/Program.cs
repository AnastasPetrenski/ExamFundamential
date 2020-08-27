using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _122019_WarriorsQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "For Azeroth")
            {
                List<string> commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands[0] == "GladiatorStance")
                {
                    skill = skill.ToUpper();
                }
                else if (commands[0] == "DefensiveStance")
                {
                    skill = skill.ToLower();
                }
                else if (commands[0] == "Dispel")
                {
                    int index = int.Parse(commands[1]);
                    char substitute = char.Parse(commands[2]);
                    if (index >= 0 && index < skill.Length)
                    {
                        skill = skill.Remove(index, 1);
                        skill = skill.Insert(index, substitute.ToString());
                        //char[] temp = skill.ToCharArray();
                        //temp[index] = substitute;
                        //skill = new string(temp);
                        Console.WriteLine("Success!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                        continue;
                    }
                }
                else if (commands[1] == "Change" && commands[0] == "Target")
                {
                    var start = skill.IndexOf(commands[2]);
                    if (start != -1)
                    {
                        //skill = skill.Remove(start, commands[2].Length);
                        //skill = skill.Insert(start, commands[3]);
                        skill = skill.Replace(commands[2], commands[3]);
                    }
                }
                else if (commands[1] == "Remove" && commands[0] == "Target")
                {
                    var start = skill.IndexOf(commands[2]);
                    while (start != -1)
                    {
                        skill = skill.Remove(start, commands[2].Length);
                        start = skill.IndexOf(commands[2]);
                    }
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                    continue;
                }
                Console.WriteLine(skill);
            }
        }
    }
}
