using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL;
using DAL.Repository;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class ScreeningLogic : IScreeningLogic
    {
        //List<IScreening> screeningsWithMovies;
        private ScreeningRepository Repository { get; }
        List<ScreeningModel> Screenings = new List<ScreeningModel>();

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

        public ScreeningModel GetScreeningById(int id)
        {
            var screenings = new List<ScreeningModel>();
            if (Repository.GetScreeningById(id) == null)
            {
                return null;
            }
            screenings.Add(Repository.GetScreeningById(id));
            screenings = GetAndAddMoviesToScreenings(screenings);
            screenings = GetAndAddHallsToScreenings(screenings);
            return screenings[0];
        }


        public List<ScreeningModel> GetAndAddMoviesToScreenings(List<ScreeningModel> screenings)
        {
            var screeningsWithMovies = new List<ScreeningModel>();
            foreach (var screening in screenings)
            {
                screening.Movie = Repository.GetMovie(screening.MovieId);
                screening.Movies = Repository.GetMovies();
                screeningsWithMovies.Add(screening);
            }
            return screeningsWithMovies;
        }

        public List<ScreeningModel> GetAndAddHallsToScreenings(List<ScreeningModel> screenings)
        {
            var screeningsWithHalls = new List<ScreeningModel>();
            foreach (var screening in screenings)
            {
                screening.Hall = Repository.GetHall(screening.HallId);
                screening.Halls = Repository.GetHalls();
                screeningsWithHalls.Add(screening);
            }
            return screeningsWithHalls;
        }

        public IEnumerable<ScreeningModel> GetScreenings()
        {
            var screenings = new List<ScreeningModel>();
            screenings = Repository.GetScreenings().ToList();
            screenings = GetAndAddMoviesToScreenings(screenings);
            screenings = GetAndAddHallsToScreenings(screenings);
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
        
        public bool IsThisDateAndTimeAvailable(int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening, int movieId, int screeningId)
        {
            foreach (var screeningDatabase in GetScreenings())
            {
                if (screeningDatabase.HallId == hallId && screeningDatabase.DateOfScreening == dateOfScreening && screeningDatabase.Id != screeningId)
                {
                    if (IsItAfterOrBeforeTheScreening(hallId, dateOfScreening, timeOfScreening, movieId, screeningDatabase) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public bool IsItAfterOrBeforeTheScreening(int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening, int movieId, IScreening screeningDatabase)
        {
            foreach (var movieAlreadyScreening in Repository.GetMovies())
            {
                if (movieAlreadyScreening.Id == screeningDatabase.MovieId)
                {
                    TimeSpan lenghtScreening = new TimeSpan(0, Int32.Parse(movieAlreadyScreening.MovieLenght), 0);
                    TimeSpan lenghtMovie = new TimeSpan(0, Int32.Parse(Repository.GetMovie(movieId).MovieLenght), 0);

                    if ((timeOfScreening > screeningDatabase.TimeOfScreening && timeOfScreening > screeningDatabase.TimeOfScreening.Add(lenghtScreening)) 
                        || (timeOfScreening < screeningDatabase.TimeOfScreening && timeOfScreening.Add(lenghtMovie) < screeningDatabase.TimeOfScreening))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return true;
        }

    }
}
