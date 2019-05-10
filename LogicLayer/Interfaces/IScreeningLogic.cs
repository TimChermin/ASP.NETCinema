using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IScreeningLogic
    {
        List<ScreeningModel> GetScreenings();
        void AddScreening(ScreeningModel screening);
        ScreeningModel GetScreeningById(int id);
        void EditScreening(ScreeningModel screening);
        void DeleteScreening(int id);
        bool IsThisDateAndTimeAvailable(int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening, int movieId, int screeningId);
    }
}
