using System;
using System.Text.RegularExpressions;

namespace _102019_Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex validReg = new Regex(@"U\$(?<name>[A-Z][a-z]{2,})U\$P\@\$(?<pass>[A-z]{5,}\d+)P\@\$");
            int numberOfInput = int.Parse(Console.ReadLine());
            int countRegistrations = 0;
            for (int i = 0; i < numberOfInput; i++)
            {
                string registration = Console.ReadLine();
                var matches = validReg.Match(registration);
                if (matches.Success)
                {
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {matches.Groups["name"].Value}, Password: {matches.Groups["pass"].Value}");
                    countRegistrations++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {countRegistrations}");
        }
    }
}
