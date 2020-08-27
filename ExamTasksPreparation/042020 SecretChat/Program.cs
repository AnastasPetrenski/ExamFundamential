using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _042020_SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                List<string> commands = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands.Contains("InsertSpace"))
                {
                    int index = int.Parse(commands[1]);
                    message = message.Insert(index, " ");
                }
                else if (commands.Contains("Reverse"))
                {
                    var partToReverse = commands[1];
                    int index = message.IndexOf(commands[1]);
                    if (index != -1)
                    {
                        message = message.Remove(index, partToReverse.Length);
                        var reversedSubstring = partToReverse.Reverse();
                        StringBuilder messageForAdding = new StringBuilder();
                        foreach (var item in reversedSubstring)
                        {
                            messageForAdding.Append(item);
                        }
                        message = message + messageForAdding;

                    }
                    else if (index == -1)
                    {
                        Console.WriteLine("error");
                        continue;
                    }
                }
                else if (commands.Contains("ChangeAll"))
                {
                    //string substring = commands[1];
                    //string replacement = commands[2];
                    message = message.Replace(commands[1], commands[2]);
                }
                Console.WriteLine(message);
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
