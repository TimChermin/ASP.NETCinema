using ASPNETCinema.Data;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class ScreeningLogic
    {
        DatabaseScreening database = new DatabaseScreening();
        DatabaseMovie databaseMovie = new DatabaseMovie();
        List<ScreeningModel> screeningsWithMovies;

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public ScreeningModel GetScreening(int? id)
        {
            foreach (ScreeningModel screening in database.GetScreenings())
            {
                if (id == screening.Id && id != null)
                {
                    return screening;
                }
            }
            return null;
        }

        public List<ScreeningModel> AddTheMovieToTheScreenings(List<ScreeningModel> screenings)
        {
            screeningsWithMovies = new List<ScreeningModel>();
            foreach (ScreeningModel screening in screenings)
            {
                screeningsWithMovies.Add(AddTheMovieToTheScreening(screening));
            }
            return screeningsWithMovies;
        }

        public ScreeningModel AddTheMovieToTheScreening(ScreeningModel screening)
        {
            foreach (MovieModel movie in databaseMovie.GetMovies())
            {
                if (screening.MovieId == movie.Id)
                {
                    screening.Movie = movie;
                }
            }
            return screening;
        }

        public List<ScreeningModel> GetScreenings()
        {
            List<ScreeningModel> screenings = null;
            screenings = database.GetScreenings();
            return AddTheMovieToTheScreenings(screenings);
        }

        public void AddScreening(ScreeningModel screening)
        {
            database.AddScreening(screening);
        }

        public void EditScreening(ScreeningModel screening)
        {
            database.EditScreening(screening);
        }

        public void DeleteScreening(ScreeningModel screening)
        {
            database.DeleteScreening(screening);
        }


        public bool IsThisDateAndTimeAvailable(ScreeningModel screening)
        {
            foreach (ScreeningModel screeningDatabase in database.GetScreenings())
            {
                if (screeningDatabase.HallId == screening.HallId && screeningDatabase.DateOfScreening == screening.DateOfScreening)
                {
                    if (screeningDatabase.TimeOfScreening == screening.TimeOfScreening)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
