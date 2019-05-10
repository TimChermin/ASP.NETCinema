
using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IScreeningContext
    {
        List<ScreeningDto> GetScreenings();
        void AddScreening(ScreeningModel screening);
        ScreeningDto GetScreeningById(int id);
        void EditScreening(ScreeningModel screening);
        void DeleteScreening(int id);

        HallDto GetHall(int idHall);
        MovieDto GetMovie(int idMovie);
        List<MovieDto> GetMovies();
        List<HallDto> GetHalls();
    }
}
