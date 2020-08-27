using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _052020_PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Done")
            {
                List<string> commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                StringBuilder password = new StringBuilder();
                if (commands.Contains("TakeOdd"))
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            password.Append(input[i].ToString());
                        }
                    }
                    input = password.ToString();
                }
                else if (commands.Contains("Cut"))
                {
                    input = input.Remove(int.Parse(commands[1]), int.Parse(commands[2]));
                }
                else if (commands.Contains("Substitute"))
                {
                    int index = input.IndexOf(commands[1]);
                    if (index == -1)
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                    else
                    {
                        while (index != -1)
                        {
                            input = input.Replace(commands[1], commands[2]);
                            index = input.IndexOf(commands[1]);
                        }
                    }
                }

                Console.WriteLine(input);                
            }

            Console.WriteLine($"Your password is: {input}");
        }
    }
}
