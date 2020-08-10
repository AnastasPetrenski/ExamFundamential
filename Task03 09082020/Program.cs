using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task03_09082020
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());
            Dictionary<string, int> plantsRarity = new Dictionary<string, int>();
            Dictionary<string, List<int>> plantsRating = new Dictionary<string, List<int>>();
            
            for (int i = 0; i < numberOfInput; i++)
            {
                List<string> plantData = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries).ToList();
                string plantName = plantData[0];
                int rarity = int.Parse(plantData[1]);
                if (!plantsRarity.ContainsKey(plantName))
                {
                    int raiting = 0;
                    int count = 0;
                    plantsRarity.Add(plantName, rarity);
                    plantsRating.Add(plantName, new List<int>());
                    plantsRating[plantName].Add(raiting);
                    plantsRating[plantName].Add(count);
                }
                else
                {
                    plantsRarity[plantName] = rarity;
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                List<string> commands = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (commands[0] == "Rate")
                {
                    List<string> plantInfo = commands[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    string plant = plantInfo[0];
                    int addRaiting = int.Parse(plantInfo[1]);
                    if (plantsRating.ContainsKey(plant))
                    {
                        plantsRating[plant][0] += addRaiting;
                        plantsRating[plant][1] += 1;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commands[0] == "Update")
                {
                    List<string> plantInfo = commands[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    string plant = plantInfo[0];
                    int updateRarity = int.Parse(plantInfo[1]);
                    if (plantsRarity.ContainsKey(plant))
                    {
                        plantsRarity[plant] = updateRarity;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (commands[0] == "Reset")
                {
                    string plant = commands[1];
                    if (plantsRating.ContainsKey(plant))
                    {
                        plantsRating[plant][0] = 0;
                        plantsRating[plant][1] = 0;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            plantsRarity = plantsRarity.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            //- Woodii; Rarity: 5; Rating: 7.50
            StringBuilder result = new StringBuilder();
            result.Append("Plants for the exhibition:");
            if (plantsRarity.Keys.Count > 0)
            {
                result.AppendLine();
                foreach (var plant in plantsRarity)
                {
                    result.Append($"- {plant.Key}; Rarity: {plant.Value}; ");
                    foreach (var raiting in plantsRating)
                    {
                        if (raiting.Key == plant.Key)
                        {
                            var x = raiting.Value[1];
                            double avgRaiting = (raiting.Value[0] * 1.00) / (raiting.Value[1]);
                            if (x != 0)
                            {
                                result.Append($"Rating: {avgRaiting:f2}");
                            }
                            else
                            {
                                result.Append($"Rating: 0.00");
                            }
                        }  
                    }

                    result.AppendLine();
                }

                Console.WriteLine(result.ToString());
            }
            else
            {
                Console.WriteLine(result.ToString());
            }



        }
    }
}
