using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count { get { return this.data.Count; } }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            var heroToRemove = this.data.FirstOrDefault(h => h.Name == name);

            if (heroToRemove != null)
            {
                this.data.Remove(heroToRemove);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            var hero = this.data.OrderByDescending(h => h.Item.Strength).FirstOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var hero = this.data.OrderByDescending(h => h.Item.Ability).FirstOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var hero = this.data.OrderByDescending(h => h.Item.Intelligence).FirstOrDefault();

            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
