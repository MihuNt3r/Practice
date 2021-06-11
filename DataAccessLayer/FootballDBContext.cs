using System.Data.Entity;
using BusinessEntities;

namespace DataAccessLayer
{
    public class FootballDBContext : DbContext
    {
        public FootballDBContext()
            : base("name=FootballDBContext")
        {
        }

        public virtual DbSet<Footballer> Players { get; set; }
        public virtual DbSet<Stadium> Stadiums { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
    }
}