using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;

namespace DataAccessLayer
{
    public class FootballDataStore
    {
        #region AddEntity

        public void AddTeam(Team team)
        {
            using (var dbContext = new FootballDBContext())
            {
                dbContext.Teams.Add(team);
                dbContext.SaveChanges();
            }
        }

        public void AddFootballer(Footballer player)
        {
            using (var dbContext = new FootballDBContext())
            {
                dbContext.Players.Add(player);
                dbContext.SaveChanges();
            }
        }

        public void AddStadium(Stadium stadium)
        {
            using (var dbContext = new FootballDBContext())
            {
                dbContext.Stadiums.Add(stadium);
                dbContext.SaveChanges();
            }
        }

        public void AddMatch(int homeTeamId, int guestTeamId, int stadiumId, DateTime matchDate)
        {
            using (var dbContext = new FootballDBContext())
            {
                var teams = dbContext.Teams.ToList();

                var homeTeam = teams.Find(t => t.Id == homeTeamId);

                var guestTeam = teams.Find(t => t.Id == guestTeamId);

                var stadiums = dbContext.Stadiums.ToList();

                var stadium = stadiums.Find(s => s.Id == stadiumId);

                Match match = new Match()
                {
                    HomeTeam = homeTeam,
                    GuestTeam = guestTeam,
                    Stadium = stadium,
                    Status = MatchStatus.Scheduled,
                    MatchDate = matchDate
                };

                dbContext.Matches.Add(match);
                dbContext.SaveChanges();
            }
        }

        #endregion

        #region DeleteEntityById

        public void DeleteFootballerById(int id)
        {
            using (var dbContext = new FootballDBContext())
            {
                var footballers = dbContext.Players.ToList();
                var teams = dbContext.Teams.ToList();

                var playerToDelete = footballers.Find(f => f.Id == id);

                if (playerToDelete == null)
                    throw new ArgumentException("Can't find player with such id");

                if (playerToDelete.Team != null)
                    throw new ArgumentException("You can only delete free agents. Firstly remove player from a team");

                dbContext.Players.Remove(playerToDelete);
                dbContext.SaveChanges();
            }
        }

        public void DeleteStadiumById(int id)
        {
            using (var dbContext = new FootballDBContext())
            {
                var stadiums = dbContext.Stadiums.ToList();
                var matches = dbContext.Matches.ToList();

                var stadiumToDelete = stadiums.Find(s => s.Id == id);

                if (stadiumToDelete == null)
                    throw new ArgumentException("Can't find stadium with such id");

                if (stadiumToDelete.Matches.Count > 0)
                    throw new ArgumentException("There are ");

                dbContext.Stadiums.Remove(stadiumToDelete);
                dbContext.SaveChanges();
            }
        }

        public void DeleteMatchById(int id)
        {
            using (var dbContext = new FootballDBContext())
            {
                var matches = dbContext.Matches.ToList();

                var matchToDelete = matches.Find(m => m.Id == id);

                if (matchToDelete == null)
                    throw new ArgumentException("Can't find match with such id");

                dbContext.Matches.Remove(matchToDelete);
                dbContext.SaveChanges();
            }
        }

        #endregion

        #region ChangeEntity

        public void ChangePlayersFirstName(int id, string FirstName)
        {
            using (var dbContext = new FootballDBContext())
            {
                var players = dbContext.Players.ToList();

                var playerToChange = players.Find(p => p.Id == id);

                if (playerToChange == null)
                    throw new ArgumentException("Can't find player with such id");

                playerToChange.FirstName = FirstName;

                dbContext.SaveChanges();
            }
        }

        public void ChangePlayersLastName(int id, string LastName)
        {
            using (var dbContext = new FootballDBContext())
            {
                var players = dbContext.Players.ToList();

                var playerToChange = players.Find(p => p.Id == id);

                if (playerToChange == null)
                    throw new ArgumentException("Can't find player with such id");

                playerToChange.LastName = LastName;

                dbContext.SaveChanges();
            }
        }

        public void ChangePlayersBirthDate(int id, DateTime birthDate)
        {
            using (var dbContext = new FootballDBContext())
            {
                var players = dbContext.Players.ToList();

                var playerToChange = players.Find(p => p.Id == id);

                if (playerToChange == null)
                    throw new ArgumentException("Can't find player with such id");

                playerToChange.BirthDate = birthDate;

                dbContext.SaveChanges();
            }
        }

        public void ChangePlayersPosition(int id, Position position)
        {
            using (var dbContext = new FootballDBContext())
            {
                var players = dbContext.Players.ToList();

                var playerToChange = players.Find(p => p.Id == id);

                if (playerToChange == null)
                    throw new ArgumentException("Can't find player with such id");

                playerToChange.Position = position;

                dbContext.SaveChanges();
            }
        }

        public void ChangePlayersHealthStatus(int id, HealthStatus status)
        {
            using (var dbContext = new FootballDBContext())
            {
                var players = dbContext.Players.ToList();

                var playerToChange = players.Find(p => p.Id == id);

                if (playerToChange == null)
                    throw new ArgumentException("Can't find player with such id");

                playerToChange.HealthStatus = status;

                dbContext.SaveChanges();
            }
        }

        public void ChangePlayersSalary(int id, decimal salary)
        {
            using (var dbContext = new FootballDBContext())
            {
                var players = dbContext.Players.ToList();

                var playerToChange = players.Find(p => p.Id == id);

                if (playerToChange == null)
                    throw new ArgumentException("Can't find player with such id");

                playerToChange.Salary = salary;

                dbContext.SaveChanges();
            }
        }

        public void AddPlayerToTeam(int playerId, int teamId)
        {
            using (var dbContext = new FootballDBContext())
            {
                var teams = dbContext.Teams.ToList();

                var players = dbContext.Players.ToList();

                var team = teams.Find(t => t.Id == teamId);

                var player = players.Find(p => p.Id == playerId);

                if (team == null)
                    throw new ArgumentException("Can't find team with such id");

                if (player == null)
                    throw new ArgumentException("Can't find player with such id");

                if (player.Team != null)
                    throw new Exception("Player already have a team. Firstly remove him from his previous team.");

                team.Players.Add(player);

                dbContext.SaveChanges();
            }
        }

        public void RemovePlayerFromTeam(int id)
        {
            using (var dbContext = new FootballDBContext())
            {
                var teams = dbContext.Teams.ToList();

                var players = dbContext.Players.ToList();

                var player = players.Find(p => p.Id == id);

                if (player == null)
                    throw new ArgumentException("Can't find player with such id");

                if (player.Team == null)
                    throw new ArgumentException("Player is already a free agent");

                player.Team = null;

                dbContext.SaveChanges();
            }
        }

        public void ChangeMatchData(int id, DateTime data)
        {
            using (var dbContext = new FootballDBContext())
            {
                var matches = dbContext.Matches.ToList();

                var matchToChange = matches.Find(m => m.Id == id);

                if (matchToChange == null)
                    throw new ArgumentException("Can't find match with such id");

                matchToChange.MatchDate = data;

                dbContext.SaveChanges();
            }
        }

        public void ChangeMatchStadium(int matchId, int stadiumId)
        {
            using (var dbContext = new FootballDBContext())
            {
                var matches = dbContext.Matches.ToList();

                var matchToChange = matches.Find(m => m.Id == matchId);

                var stadiums = dbContext.Stadiums.ToList();

                var stadium = stadiums.Find(s => s.Id == stadiumId);

                if (matchToChange == null)
                    throw new ArgumentException("Can't find match with such id");

                matchToChange.Stadium = stadium;

                dbContext.SaveChanges();
            }
        }

        public void EnterMatchResult(int id, int homeTeamGoals, int guestTeamGoals)
        {
            using (var dbContext = new FootballDBContext())
            {
                var matches = dbContext.Matches.ToList();

                var matchToChange = matches.Find(m => m.Id == id);

                if (matchToChange == null)
                    throw new ArgumentException("Can't find match with such id");

                matchToChange.HomeTeamGoals = homeTeamGoals;
                matchToChange.GuestTeamGoals = guestTeamGoals;
                matchToChange.Status = MatchStatus.Finished;

                dbContext.SaveChanges();
            }
        }

        public void ChangeStadiumCapacity(int id, int capacity)
        {
            using (var dbContext = new FootballDBContext())
            {
                var stadiums = dbContext.Stadiums.ToList();

                var stadiumToChange = stadiums.Find(s => s.Id == id);

                if (stadiumToChange == null)
                    throw new ArgumentException("Can't find stadium with such id");

                stadiumToChange.MaxCapacity = capacity;

                dbContext.SaveChanges();
            }
        }


        #endregion

        #region GetEntityById

        public Team GetTeamById(int id)
        {
            using (var dbContext = new FootballDBContext())
            {
                var teams = dbContext.Teams.ToList();

                var players = dbContext.Players.ToList();

                var team = teams.Find(t => t.Id == id);

                if (team == null)
                    throw new ArgumentException("Can't find team with such id");

                return team;
            }
        }

        public Footballer GetFootballerById(int id)
        {
            using (var dbContext = new FootballDBContext())
            {
                var footballers = dbContext.Players.ToList();

                var teams = dbContext.Teams.ToList();

                var footballer = footballers.Find(f => f.Id == id);

                if (footballer == null)
                    throw new ArgumentException("Can't find footballer with such id");

                return footballer;
            }
        }

        public Stadium GetStadiumById(int id)
        {
            using (var dbContext = new FootballDBContext())
            {
                var stadiums = dbContext.Stadiums.ToList();

                var matches = dbContext.Matches.ToList();

                var teams = dbContext.Teams.ToList();

                var stadium = stadiums.Find(s => s.Id == id);

                if (stadium == null)
                    throw new ArgumentException("Can't find stadium with such id");

                return stadium;
            }
        }

        public Match GetMatchById(int id)
        {
            using (var dbContext = new FootballDBContext())
            {
                var stadiums = dbContext.Stadiums.ToList();

                var teams = dbContext.Teams.ToList();

                var matches = dbContext.Matches.ToList();

                var match = matches.Find(m => m.Id == id);

                if (match == null)
                    throw new ArgumentException("Can't find match with such id");

                return match;
            }
        }

        #endregion

        #region GetListsOfEntities

        public List<Team> GetTeamsList()
        {
            using (var dbContext = new FootballDBContext())
            {
                var players = dbContext.Players.ToList();
                var matches = dbContext.Matches.ToList();
                var stadiums = dbContext.Stadiums.ToList();
                return dbContext.Teams.ToList();
            }
        }

        public List<Footballer> GetFootballersList()
        {
            using (var dbContext = new FootballDBContext())
            {
                var matches = dbContext.Matches.ToList();
                var teams = dbContext.Teams.ToList();
                var stadiums = dbContext.Stadiums.ToList();
                return dbContext.Players.ToList();
            }
        }

        public List<Stadium> GetStadiumsList()
        {
            using (var dbContext = new FootballDBContext())
            {
                var matches = dbContext.Matches.ToList();
                var teams = dbContext.Teams.ToList();
                var players = dbContext.Players.ToList();
                return dbContext.Stadiums.ToList();
            }
        }

        public List<Match> GetMatchesList()
        {
            using (var dbContext = new FootballDBContext())
            {
                var stadiums = dbContext.Stadiums.ToList();
                var teams = dbContext.Teams.ToList();
                var players = dbContext.Players.ToList();
                return dbContext.Matches.ToList();
            }
        }

        #endregion

    }
}
