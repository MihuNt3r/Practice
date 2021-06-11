using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Footballer> Players { get; set; }

        public Team()
        {
            Players = new List<Footballer>();
        }

        public override string ToString()
        {
            return String.Format("|Id: {0,-5}|{1,-10}|{2,-11}|{3,-10}|", Id, Name, City, Country);
        }

        public string GetFullInfo()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Team\n");
            builder.Append(this.ToString() + "\n");
            builder.Append("Squad\n");
            Players.ForEach(p => builder.Append(p + "\n"));

            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Team team = obj as Team;

            if (this.Id == team.Id)
                return true;
            else
                return false;
        }
    }
}
