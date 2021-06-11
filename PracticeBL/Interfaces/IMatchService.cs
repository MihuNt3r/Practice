using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEntities;

namespace PracticeBL.Interfaces
{
    public interface IMatchService
    {
        void AddMatch(int homeTeamId, int guestTeamId, int stadiumId, DateTime matchDate);
        void DeleteMatch(int id);
        void ChangeMatchDate(int id, DateTime data);
        void ChangeStadium(int matchId, int stadiumId);
        void ChangeSpectatorsCount(int id, int spectatorsCount);
        void EnterMatchResult(int id, int homeTeamGoals, int guestTeamGoals);
        Match GetMatchById(int id);
        List<Match> GetAllMatchesFromDb();
        List<Match> SortMatchesByData();
        List<Match> SortMatchesByResult();
    }
}
