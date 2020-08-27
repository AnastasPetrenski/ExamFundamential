using System;
using System.Collections.Generic;
using System.Linq;

namespace _082019_Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> followers = new Dictionary<string, List<int>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Log out")
            {
                List<string> commands = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string user = commands[1];
                if (commands.Contains("New follower"))
                {
                    if (!followers.ContainsKey(user))
                    {
                        followers.Add(user, new List<int>());
                        followers[user].Add(0);
                        followers[user].Add(0);
                    }
                }
                else if (commands.Contains("Like"))
                {
                    if (!followers.ContainsKey(user))
                    {
                        followers.Add(user, new List<int>());
                        followers[user].Add(0);
                        followers[user].Add(0);
                        followers[user][0] += int.Parse(commands[2]);
                    }
                    else
                    {
                        followers[user][0] += int.Parse(commands[2]);
                    }
                }
                else if (commands.Contains("Comment"))
                {
                    if (!followers.ContainsKey(user))
                    {
                        followers.Add(user, new List<int>());
                        followers[user].Add(0);
                        followers[user].Add(1);
                    }
                    else
                    {
                        followers[user][1]++;
                    }
                }
                else if (commands.Contains("Blocked"))
                {
                    if (!followers.ContainsKey(user))
                    {
                        Console.WriteLine($"{user} doesn't exist.");
                    }
                    else
                    {
                        followers.Remove(user);
                    }
                }
            }

            var orderedFollwers = followers.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value.Sum());
            Console.WriteLine($"{followers.Keys.Count} followers");
            foreach (var item in orderedFollwers)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
