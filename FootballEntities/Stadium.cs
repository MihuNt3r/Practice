namespace FootballEntities
{
    using System;
    using System.Collections.Generic;
    
    public class Stadium
    {    
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int MaxCapacity { get; set; }
        public List<Match> Matches { get; set; }

        public Stadium()
        {
            Matches = new List<Match>();
        }

        public override string ToString()
        {
            return String.Format("|Id: {0,-5}|{1,-20}|{2,-11}|{3,-11}|", Id, Name, City, MaxCapacity);
        }

        public string GetFullInfo()
        {
            return this.ToString();
        }

    }
}
