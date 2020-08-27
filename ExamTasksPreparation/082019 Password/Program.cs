using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _082019_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            Regex passPattern = new Regex(@"(.+)>(\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^\<\>]{3})<\1");
            for (int i = 0; i < inputNumber; i++)
            {
                var input = passPattern.Match(Console.ReadLine());
                if (input.Success)
                {
                    StringBuilder encryptPass = new StringBuilder();
                    encryptPass.Append(input.Groups[2]);
                    encryptPass.Append(input.Groups[3]);
                    encryptPass.Append(input.Groups[4]);
                    encryptPass.Append(input.Groups[5]);
                    Console.WriteLine($"Password: {encryptPass.ToString()}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
