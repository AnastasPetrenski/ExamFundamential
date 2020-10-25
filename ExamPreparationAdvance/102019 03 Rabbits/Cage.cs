using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }

        public void Add(Rabbit rabbit)
        {
            if (this.data.Count < Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            var rabbit = this.data.FirstOrDefault(r => r.Name == name);

            if (rabbit != null)
            {
                this.data.Remove(rabbit);
                return true;
            }

            return false;
        }

        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(r => r.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbit = this.data.FirstOrDefault(r => r.Name == name);
            if (rabbit != null)
            {
                rabbit.Available = false;
            }

            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            foreach (var item in this.data)
            {
                if (item.Species == species)
                {
                    item.Available = false;
                }
            }

            Rabbit[] soldRabbits = this.data.Where(r => r.Species == species).ToArray();

            return soldRabbits;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var item in this.data.Where(r => r.Available == true))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
