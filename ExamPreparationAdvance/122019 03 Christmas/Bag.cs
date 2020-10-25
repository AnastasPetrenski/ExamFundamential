using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }

        public void Add(Present present)
        {
            if (this.data.Count < Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var presentToRemove = this.data.FirstOrDefault(p => p.Name == name);
            if (presentToRemove != null)
            {
                this.data.Remove(presentToRemove);
                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            var heaviest = this.data.OrderByDescending(p => p.Weight).FirstOrDefault();

            return heaviest;
        }

        public Present GetPresent(string name)
        {
            var present = this.data.FirstOrDefault(p => p.Name == name);

            return present;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"{this.Color} bag contains:");
            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
