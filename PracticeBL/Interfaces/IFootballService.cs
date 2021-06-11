using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEntities;

namespace PracticeBL.Interfaces
{
    public interface IFootballService : IMatchService, IPlayerService, IStadiumService, ITeamService
    {
    }
}
