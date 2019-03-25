using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IScreeningContext
    {
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        IEnumerable<IScreening> GetScreenings();
        void AddScreening(IScreening screening);
        IScreening GetScreeningById(int id);
        void EditScreening(IScreening screening);
        void DeleteScreening(int id);

        IHall GetHall(int idHall);
        IMovie GetMovie(int idMovie);
    }
}
