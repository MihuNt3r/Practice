using System.Collections.Generic;
using BusinessEntities;

namespace BusinessLogicLayer.Interfaces
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
