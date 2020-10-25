using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.roster.Count; } }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            var playerToRemove = this.roster.FirstOrDefault(p => p.Name == name);
            if (playerToRemove != null)
            {
                this.roster.Remove(playerToRemove);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = this.roster.FirstOrDefault(p => p.Name == name);
            if (playerToPromote != null && playerToPromote.Rank == "Trial")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var playerToPromote = this.roster.FirstOrDefault(p => p.Name == name);
            if (playerToPromote != null && playerToPromote.Rank != "Trial")
            {
                playerToPromote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] players = this.roster.FindAll(p => p.Class == clas).ToArray();
            this.roster.RemoveAll(p => p.Class == clas);

            return players;
        }

        //public string Report()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("Players in the guild: {guildName}");
        //    foreach (var item in roster)
        //    {
        //        sb.AppendLine(item.ToString());
        //    }

        //    return sb.ToString().Trim();
        //}

        public string Report()
        {
            StringBuilder myString = new StringBuilder();
            myString.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                myString.AppendLine($"Player {player.Name}: {player.Class}");
                myString.AppendLine($"Rank: {player.Rank}");
                myString.AppendLine($"Description: {player.Description}");
            }
            return myString.ToString().TrimEnd();
        }
    }
}
