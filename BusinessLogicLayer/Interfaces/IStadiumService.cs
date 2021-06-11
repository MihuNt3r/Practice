using System.Collections.Generic;
using BusinessEntities;

namespace BusinessLogicLayer.Interfaces
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
