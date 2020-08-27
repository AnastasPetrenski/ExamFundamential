using System;
using System.Collections.Generic;
using System.Linq;

namespace _102019_InboxManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                List<string> commands = command.Split("->", StringSplitOptions.RemoveEmptyEntries).ToList();
                string user = commands[1];
                if (commands.Contains("Add"))
                {
                    if (!users.ContainsKey(user))
                    {
                        users.Add(user, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{user} is already registered");
                    }
                }
                else if (commands.Contains("Send"))
                {
                    if (users.ContainsKey(user))
                    {
                        users[user].Add(commands[2]);
                    }
                }
                else if (commands.Contains("Delete"))
                {
                    if (users.ContainsKey(user))
                    {
                        users.Remove(user);
                    }
                    else
                    {
                        Console.WriteLine($"{user} not found!");
                    }
                }
            }
            users = users.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine($"Users count: {users.Keys.Count}");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}");
                foreach (var item in user.Value)
                {
                    Console.WriteLine($" - {item}");
                }
            }
        }

        
    }
}
