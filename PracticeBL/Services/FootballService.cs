using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using FootballEntities;
using PracticeBL.Exceptions;
using PracticeBL.Interfaces;

namespace PracticeBL.Services
{
    public class FootballService : IFootballService
    {
        private FootballDataStore _dataStore;

        public FootballService(FootballDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        #region AddEntity

        public void AddTeam(Team team)
        {
            var teams = _dataStore.GetTeamsList();

            var duplicate = teams.Find(t => t.Name == team.Name && t.City == team.City);

            if (duplicate != null)
                throw new DuplicateException("Team with such name and city already exists");

            _dataStore.AddTeam(team);
        }

        public void AddFootballer(Footballer player)
        {
            var players = _dataStore.GetFootballersList();

            var duplicate = players.Find(p => p.FirstName == player.FirstName &&
                                              p.LastName == player.LastName);
            if (duplicate != null)
                throw new DuplicateException("Footballer with such name and surname already exists");

            _dataStore.AddFootballer(player);
        }

        public void AddStadium(Stadium stadium)
        {
            var stadiums = _dataStore.GetStadiumsList();

            var duplicate = stadiums.Find(s => s.Name == stadium.Name && s.City == stadium.City);

            if (duplicate != null)
                throw new DuplicateException("Stadium with such name and city already exists");

            _dataStore.AddStadium(stadium);
        }

        public void AddMatch(int homeTeamId, int guestTeamId, int stadiumId, DateTime matchDate)
        {
            Team homeTeam = _dataStore.GetTeamById(homeTeamId);

            Team guestTeam = _dataStore.GetTeamById(guestTeamId);

            if (homeTeam.Equals(guestTeam))
                throw new MatchCreationException("Team can't play with itself");

            Stadium stadium = _dataStore.GetStadiumById(stadiumId);

            var matches = _dataStore.GetMatchesList();

            var duplicate1 = matches.Find(m => m.HomeTeam.Equals(homeTeam) && m.MatchDate == matchDate);
            var duplicate2 = matches.Find(m => m.HomeTeam.Equals(guestTeam) && m.MatchDate == matchDate);
            var duplicate3 = matches.Find(m => m.GuestTeam.Equals(homeTeam) && m.MatchDate == matchDate);
            var duplicate4 = matches.Find(m => m.GuestTeam.Equals(guestTeam) && m.MatchDate == matchDate);

            if (duplicate1 != null || duplicate2 != null || duplicate3 != null ||
                duplicate4 != null)
                throw new MatchCreationException("Team can't have two matches in one day");

            var stadiums = _dataStore.GetStadiumsList();

            int healthyPlayersHomeTeam = 0, healthyGoalkeepersHomeTeam = 0;

            foreach (var p in homeTeam.Players)
            {
                if (p.HealthStatus == HealthStatus.Healthy)
                    healthyPlayersHomeTeam++;
                if (p.HealthStatus == HealthStatus.Healthy &&
                    p.Position == Position.Goalkeeper)
                    healthyGoalkeepersHomeTeam++;
            }

            if (healthyPlayersHomeTeam < 11 || healthyGoalkeepersHomeTeam < 1)
                throw new MatchCreationException("Team must have at least 11 healthy players and at least one healthy goalkeeper");

            int healthyPlayersGuestTeam = 0, healthyGoalkeepersGuestTeam = 0;

            foreach (var p in guestTeam.Players)
            {
                if (p.HealthStatus == HealthStatus.Healthy)
                    healthyPlayersGuestTeam++;
                if (p.HealthStatus == HealthStatus.Healthy &&
                    p.Position == Position.Goalkeeper)
                    healthyGoalkeepersGuestTeam++;
            }

            if (healthyPlayersGuestTeam < 11 || healthyGoalkeepersGuestTeam < 1)
                throw new MatchCreationException("Team must have at least 11 healthy players and at least one healthy goalkeeper");


            var duplicateStadium = matches.Find(m => m.Stadium == stadium && m.MatchDate == matchDate);

            if (duplicateStadium != null)
                throw new MatchCreationException("Can't play two matches at one stadium in one day");

            _dataStore.AddMatch(homeTeamId, guestTeamId, stadiumId, matchDate);
        }

        #endregion

        #region DeleteEntityById

        public void DeleteFootballer(int id)
        {
            _dataStore.DeleteFootballerById(id);
        }

        public void DeleteStadium(int id)
        {
            _dataStore.DeleteStadiumById(id);
        }

        public void DeleteMatch(int id)
        {
            _dataStore.DeleteMatchById(id);
        }

        #endregion

        #region ChangeEntity

        public void ChangeFirstName(int id, string firstName)
        {
            _dataStore.ChangePlayersFirstName(id, firstName);
        }

        public void ChangeLastName(int id, string lastName)
        {
            _dataStore.ChangePlayersFirstName(id, lastName);
        }

        public void ChangeBirthDate(int id, DateTime birthDate)
        {
            _dataStore.ChangePlayersBirthDate(id, birthDate);
        }

        public void ChangePosition(int id, Position position)
        {
            _dataStore.ChangePlayersPosition(id, position);
        }

        public void ChangeHealthStatus(int id, HealthStatus healthStatus)
        {
            _dataStore.ChangePlayersHealthStatus(id, healthStatus);
        }

        public void ChangeSalary(int id, decimal salary)
        {
            _dataStore.ChangePlayersSalary(id, salary);
        }

        public void AddPlayerToTeam(int playerId, int teamId)
        {
            _dataStore.AddPlayerToTeam(playerId, teamId);
        }

        public void RemovePlayerFromTeam(int playerId)
        {
            _dataStore.RemovePlayerFromTeam(playerId);
        }

        public void ChangeCapacity(int id, int newCapacity)
        {
            _dataStore.ChangeStadiumCapacity(id, newCapacity);
        }

        public void ChangeSitPrice(int id, decimal sitPrice)
        {
            throw new NotImplementedException();
        }

        public void ChangeMatchDate(int id, DateTime data)
        {
            _dataStore.ChangeMatchData(id, data);
        }

        public void ChangeStadium(int matchId, int stadiumId)
        {
            _dataStore.ChangeMatchStadium(matchId, stadiumId);
        }

        public void ChangeSpectatorsCount(int matchId, int newSpectatorsCount)
        {
            throw new NotImplementedException();
        }

        public void EnterMatchResult(int id, int homeTeamGoals, int guestTeamGoals)
        {
            var matches = _dataStore.GetMatchesList();

            var match = matches.Find(m => m.Id == id);

            if (match == null)
                throw new ArgumentException("Can't find match with such id");

            if (match.HomeTeamGoals != null && match.GuestTeamGoals != null)
                throw new EnteringResultException("Match already have a result");

            _dataStore.EnterMatchResult(id, homeTeamGoals, guestTeamGoals);
        }

        #endregion

        #region GetEntityById

        public Team GetTeamById(int id)
        {
            return _dataStore.GetTeamById(id);
        }

        public Footballer GetFootballerById(int id)
        {
            return _dataStore.GetFootballerById(id);
        }

        public Stadium GetStadiumById(int id)
        {
            return _dataStore.GetStadiumById(id);
        }

        public Match GetMatchById(int id)
        {
            return _dataStore.GetMatchById(id);
        }

        #endregion

        #region GetListOfEntities

        public List<Team> GetAllTeamsFromDb()
        {
            return _dataStore.GetTeamsList();
        }

        public List<Footballer> GetAllFootballersFromDb()
        {
            return _dataStore.GetFootballersList();
        }

        public List<Stadium> GetAllStadiumsFromDb()
        {
            return _dataStore.GetStadiumsList();
        }

        public List<Match> GetAllMatchesFromDb()
        {
            return _dataStore.GetMatchesList();
        }

        public List<Match> SortMatchesByData()
        {
            throw new NotImplementedException();
        }

        public List<Match> SortMatchesByResult()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
