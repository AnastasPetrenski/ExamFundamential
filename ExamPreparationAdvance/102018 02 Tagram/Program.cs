using System;
using System.Collections.Generic;
using System.Linq;

namespace _102018_02_Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                var commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                commands.RemoveAll(x => x == "->");
                string name = commands[0];
                string tag = commands[1];
                //int likes = int.Parse(commands[2]);

                if (name == "ban" && users.ContainsKey(tag))
                {
                    users.Remove(tag);
                    continue;
                }

                if (!users.ContainsKey(name))
                {
                    users.Add(name, new Dictionary<string, int>());
                }

                if (users.ContainsKey(name))
                {
                    if (!users[name].ContainsKey(tag))
                    {
                        users[name].Add(tag, 0);
                    }

                    users[name][tag] += int.Parse(commands[2]);
                }

            }

            foreach (var username in users.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Keys.Count))
            {
                Console.WriteLine(username.Key);
                foreach (var item in username.Value)
                {
                    Console.WriteLine($"- {item.Key}: {item.Value}");
                }
            }
        }

    }
}
