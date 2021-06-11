using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEntities;

namespace PracticeBL
{
    public interface IStadiumService
    {
        void AddStadium(Stadium stadium);
        void DeleteStadium(int id);
        void ChangeCapacity(int id, int capacity);
        void ChangeSitPrice(int id, decimal sitPrice);
        Stadium GetStadiumById(int id);
        List<Stadium> GetAllStadiumsFromDb();
    }
}
