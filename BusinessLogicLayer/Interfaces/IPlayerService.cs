using System;
using System.Collections.Generic;
using BusinessEntities;

namespace BusinessLogicLayer.Interfaces
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
