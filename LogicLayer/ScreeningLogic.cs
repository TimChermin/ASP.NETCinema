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
        List<IScreening> Screenings = new List<IScreening>();

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
            var screenings = new List<IScreening>();
            if (Repository.GetScreeningById(id) == null)
            {
                return null;
            }
            screenings.Add(Repository.GetScreeningById(id));
            screenings = GetAndAddMovieToScreenings(screenings);
            screenings = GetAndAddHallToScreenings(screenings);
            return screenings[0];
        }


        public List<IScreening> GetAndAddMovieToScreenings(List<IScreening> screenings)
        {
            var screeningsWithMovies = new List<IScreening>();
            foreach (var screening in screenings)
            {
                screening.Movie = Repository.GetMovie(screening.MovieId);
                screeningsWithMovies.Add(screening);
            }
            return screeningsWithMovies;
        }

        public List<IScreening> GetAndAddHallToScreenings(List<IScreening> screenings)
        {
            var screeningsWithHalls = new List<IScreening>();
            foreach (var screening in screenings)
            {
                screening.Hall = Repository.GetHall(screening.HallId);
                screeningsWithHalls.Add(screening);
            }
            return screeningsWithHalls;
        }

        public IEnumerable<IScreening> GetScreenings()
        {
            var screenings = new List<IScreening>();
            screenings = Repository.GetScreenings().ToList();
            screenings = GetAndAddMovieToScreenings(screenings);
            screenings = GetAndAddHallToScreenings(screenings);
            return screenings;
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
