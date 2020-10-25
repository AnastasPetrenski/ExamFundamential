using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(ReadInput());
            Stack<int> casings = new Stack<int>(ReadInput());

            int daturaBomb = 0;
            int cherryBomb = 0;
            int smokeBomb = 0;
            bool isPouchFilled = false;
            while (true)
            {
                if (!effects.TryPeek(out int effect))
                {
                    break;
                }

                if (!casings.TryPeek(out int casing))
                {
                    break;
                }

                int result = (effect + casing);
                if (result == 40)
                {
                    daturaBomb++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (result == 60)
                {
                    cherryBomb++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else if (result == 120)
                {
                    smokeBomb++;
                    effects.Dequeue();
                    casings.Pop();
                }
                else
                {
                    casings.Pop();
                    casings.Push(casing - 5);
                }

                if (daturaBomb >= 3 && cherryBomb >= 3 && smokeBomb >= 3)
                {
                    isPouchFilled = true;
                    break;
                }

                /*
                 *  Datura Bombs: 40
                    Cherry Bombs: 60
                    Smoke Decoy Bombs: 120

                 */
            }

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(isPouchFilled ? "Bene! You have successfully filled the bomb pouch!"
                                : "You don't have enough materials to fill the bomb pouch.")
                .Append("Bomb Effects: ")
                .AppendLine(effects.Count <= 0 ? "empty" : string.Join(", ", effects))
                .Append("Bomb Casings: ")
                .AppendLine(casings.Count <= 0 ? "empty" : string.Join(", ", casings))
                .AppendLine($"Cherry Bombs: {cherryBomb}")
                .AppendLine($"Datura Bombs: {daturaBomb}")
                .AppendLine($"Smoke Decoy Bombs: {smokeBomb}");
            Console.WriteLine(sb.ToString().Trim());

        }

        public static int[] ReadInput()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            return input;
        }
    }
}
