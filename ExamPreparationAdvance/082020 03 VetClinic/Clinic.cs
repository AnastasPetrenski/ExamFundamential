using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count { get { return this.data.Count; } }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            var petToRemove = this.data.FirstOrDefault(p => p.Name == name);
            if (petToRemove != null)
            {
                data.Remove(petToRemove);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet oldestPet = this.data.OrderByDescending(p => p.Age).FirstOrDefault();

            return oldestPet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var item in this.data)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }

            return sb.ToString();
        }
    }
}
