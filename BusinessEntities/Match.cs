using System;
using System.Text;

namespace BusinessEntities
{
    public class Match
    {
        public int Id { get; set; }
        public int? HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int? GuestTeamId { get; set; }
        public Team GuestTeam { get; set; }
        public int? HomeTeamGoals { get; set; }
        public int? GuestTeamGoals { get; set; }
        public DateTime MatchDate { get; set; }
        public int? StadiumId { get; set; }
        public Stadium Stadium { get; set; }
        public MatchStatus Status { get; set; }

        public override string ToString()
        {
            return String.Format("|Id: {0,-5}|{1,-20}|{2,-11}|{3,-10}|", Id, HomeTeam.Name, GuestTeam.Name,
                Status == MatchStatus.Finished ? $"{HomeTeamGoals}:{GuestTeamGoals}" : $"Scheduled for {MatchDate.ToString()}");
        }

        public string GetFullInfo()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(this.ToString());

            builder.Append("Stadium: " + Stadium.Name);

            return builder.ToString();
        }

    }
}
