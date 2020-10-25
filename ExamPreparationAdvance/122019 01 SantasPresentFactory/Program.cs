using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _122019_01_SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> materials = new Stack<int>(ReadInput());
            Queue<int> magics = new Queue<int>(ReadInput());
            SortedDictionary<string, int> toys = new SortedDictionary<string, int>();

            while (materials.Count > 0 && magics.Count > 0)
            {

                if (materials.Peek() == 0 || magics.Peek() == 0)
                {
                    if (materials.Peek() == 0)
                    {
                        materials.Pop();
                    }
                    if (magics.Peek() == 0)
                    {
                        magics.Dequeue();
                    }
                    continue;
                }

                int material = materials.Pop();
                int magic = magics.Dequeue();
                int result = material * magic;
                if (result > 0)
                {
                    if (result == 150)
                    {
                        if (!toys.ContainsKey("Doll"))
                        {
                            toys.Add("Doll", 0);
                        }
                        toys["Doll"]++;
                    }
                    else if (result == 250)
                    {
                        if (!toys.ContainsKey("Wooden train"))
                        {
                            toys.Add("Wooden train", 0);
                        }
                        toys["Wooden train"]++;
                    }
                    else if (result == 300)
                    {
                        if (!toys.ContainsKey("Teddy bear"))
                        {
                            toys.Add("Teddy bear", 0);
                        }
                        toys["Teddy bear"]++;
                    }
                    else if (result == 400)
                    {
                        if (!toys.ContainsKey("Bicycle"))
                        {
                            toys.Add("Bicycle", 0);
                        }
                        toys["Bicycle"]++;
                    }
                    else
                    {
                        materials.Push(material + 15);
                    }
                }
                else
                {
                    materials.Push(material + magic);
                }

                /*
                 *  Present	        Magic needed
                    Doll	        150
                    Wooden train	250
                    Teddy bear	    300
                    Bicycle 	    400

                 */
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(toys.ContainsKey("Doll") && toys.ContainsKey("Wooden train") ||
                              toys.ContainsKey("Teddy bear") && toys.ContainsKey("Bicycle") 
                ? "The presents are crafted! Merry Christmas!" 
                : "No presents this Christmas!");

            if (materials.Count > 0)
            {
                sb
                    .Append("Materials left: ")
                    .AppendLine(string.Join(", ", materials));
            }

            if (magics.Count > 0)
            {
                sb
                    .Append("Magic left: ")
                    .AppendLine(string.Join(", ", magics));
            }

            foreach (var item in toys)
            {
                sb.AppendLine($"{item.Key}: {item.Value}");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        public static int[] ReadInput()
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            return input;
        }
    }
}
