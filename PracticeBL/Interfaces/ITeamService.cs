using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEntities;

namespace PracticeBL.Interfaces
{
    public interface ITeamService
    {
        void AddTeam(Team team);
        void AddPlayerToTeam(int playerId, int teamId);
        void RemovePlayerFromTeam(int playerId);
        Team GetTeamById(int id);
        List<Team> GetAllTeamsFromDb();
    }
}
