using System;
using System.Collections.Generic;

namespace BusinessEntities
{
    public class Footballer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Position Position { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public decimal Salary { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public override string ToString()
        {
            return String.Format("|Id: {0,-5}|{1,-10}|{2,-11}|{3,-10}|{4,-15}|", Id, FirstName, LastName, Position.ToString(), Team.Name);
        }

        public string GetFullInfo()
        {
            return this.ToString();
        }
    }
}
