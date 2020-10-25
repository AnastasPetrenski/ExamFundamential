using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        //private string rank = "Trial";
        //private string descpription = "n/a";

        public Player(string name, string clas)
        {
            this.Name = name;
            this.Class = clas;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Player {this.Name}: {this.Class}")
                .AppendLine($"Rank: {this.Rank}")
                .Append($"Description: {this.Description}");

            return sb.ToString().TrimEnd();
        }
    }
}
