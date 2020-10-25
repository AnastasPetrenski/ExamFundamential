using System;
using System.Collections.Generic;
using System.Linq;

namespace _022019_01_ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Stack<string> input = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Queue<Hall> halls = new Queue<Hall>();

            while (input.Count > 0)
            {
                var current = input.Pop();
                if (char.TryParse(current, out char hall))
                {
                    if (char.IsLetter(hall))
                    {
                        Hall newHall = new Hall(hall, capacity);
                        halls.Enqueue(newHall);
                        continue;
                    }
                }

                int people = int.Parse(current);
                if (halls.Count == 0)
                {
                    continue;
                }
                else
                {
                    var currentHall = halls.Peek();
                    if (currentHall.people.Sum() + people <= capacity)
                    {
                        currentHall.people.Add(people);
                    }
                    else
                    {
                        var removeHall = halls.Dequeue();
                        Console.WriteLine($"{removeHall.Name} -> {string.Join(", ", removeHall.people)}");
                        input.Push(current);
                    }
                }

            }
        }
    }

    public class Hall
    {
        public List<int> people;

        public Hall(char name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.people = new List<int>();
        }

        public char Name { get; set; }
        public int Capacity { get; set; }

    }
}
