using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballEntities;

namespace PracticeBL.Interfaces
{
    public interface IPlayerService
    {
        void AddFootballer(Footballer player);
        void DeleteFootballer(int id);
        void ChangeFirstName(int id, string newFirstName);
        void ChangeLastName(int id, string newLastName);
        void ChangeBirthDate(int id, DateTime newBirthDate);
        void ChangePosition(int id, Position newPosition);
        void ChangeHealthStatus(int id, HealthStatus newHealthStatus);
        void ChangeSalary(int id, decimal newSalary);
        Footballer GetFootballerById(int id);
        List<Footballer> GetAllFootballersFromDb();
    }
}
