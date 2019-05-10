using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IScreeningLogic
    {
        IEnumerable<IScreening> GetScreenings();
        void AddScreening(int id, int movieId, int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening);
        IScreening GetScreeningById(int id);
        void EditScreening(int id, int movieId, int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening);
        void DeleteScreening(int id);
        bool IsThisDateAndTimeAvailable(int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening, int movieId, int screeningId);
    }
}
