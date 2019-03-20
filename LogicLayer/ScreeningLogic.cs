using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL;
using DAL.Repository;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class ScreeningLogic
    {
        //List<IScreening> screeningsWithMovies;
        private ScreeningRepository Repository { get; }

        public ScreeningLogic(IScreeningContext context)
        {
            Repository = new ScreeningRepository(context);
        }
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public IScreening GetScreeningById(int id)
        {
            return Repository.GetScreeningById(id);
        }

        public List<ScreeningModel> AddTheMovieToTheScreenings(List<IScreening> screenings)
        {
            /*screeningsWithMovies = new List<IScreening>();
            foreach (var screening in screenings)
            {
                screeningsWithMovies.Add(AddTheMovieToTheScreening(screening));
            }
            return screeningsWithMovies;
            */
            return null;
        }
        

        public ScreeningModel AddTheMovieToTheScreening(ScreeningModel screening)
        {
            /*foreach (MovieModel movie in databaseMovie.GetMovies())
            {
                if (screening.MovieId == movie.Id)
                {
                    screening.Movie = movie;
                }
            }
            */
            //return screening;
            return null;
        }

        public IEnumerable<IScreening> GetScreenings()
        {
            return Repository.GetScreenings();
        }

        public void AddScreening(int id, int movieId, int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening)
        {
            var screening = new ScreeningModel
            {
                Id = id,
                MovieId = movieId,
                HallId = hallId,
                DateOfScreening = dateOfScreening,
                TimeOfScreening = timeOfScreening
            };
            Repository.AddScreening(screening);
        }

        public void EditScreening(int id, int movieId, int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening)
        {
            var screening = new ScreeningModel
            {
                Id = id,
                MovieId = movieId,
                HallId = hallId,
                DateOfScreening = dateOfScreening,
                TimeOfScreening = timeOfScreening
            };
            Repository.EditScreening(screening);
        }

        public void DeleteScreening(int id)
        {
            Repository.DeleteScreening(id);
        }


        public bool IsThisDateAndTimeAvailable(int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening)
        {
            foreach (var screeningDatabase in GetScreenings())
            {
                if (screeningDatabase.HallId == hallId && screeningDatabase.DateOfScreening == dateOfScreening)
                {
                    if (screeningDatabase.TimeOfScreening == timeOfScreening)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
