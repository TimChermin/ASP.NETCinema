using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using AutoMapper;
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
        private ScreeningRepository Repository { get; }
        List<ScreeningModel> Screenings = new List<ScreeningModel>();
        private IMapper _mapper;

        public ScreeningLogic(IScreeningContext context, IMapper mapper)
        {
            Repository = new ScreeningRepository(context);
            _mapper = mapper;
        }

        public ScreeningModel GetScreeningById(int id)
        {
            var screenings = new List<ScreeningModel>();
            if (Repository.GetScreeningById(id) == null)
            {
                return null;
            }
            screenings.Add(_mapper.Map<ScreeningModel>(Repository.GetScreeningById(id)));
            screenings = GetAndAddMoviesToScreenings(screenings);
            screenings = GetAndAddHallsToScreenings(screenings);
            return screenings[0];
        }


        public List<ScreeningModel> GetAndAddMoviesToScreenings(List<ScreeningModel> screenings)
        {
            var screeningsWithMovies = new List<ScreeningModel>();
            foreach (var screening in screenings)
            {
                screening.Movie = _mapper.Map<MovieModel>(Repository.GetMovie(screening.MovieId));
                screening.Movies = _mapper.Map<List<MovieModel>>(Repository.GetMovies());
                screeningsWithMovies.Add(screening);
            }
            return screeningsWithMovies;
        }

        public List<ScreeningModel> GetAndAddHallsToScreenings(List<ScreeningModel> screenings)
        {
            var screeningsWithHalls = new List<ScreeningModel>();
            foreach (var screening in screenings)
            {
                screening.Hall = _mapper.Map<HallModel>(Repository.GetHall(screening.HallId));
                screening.Halls = _mapper.Map<List<HallModel>>(Repository.GetHalls());
                screeningsWithHalls.Add(screening);
            }
            return screeningsWithHalls;
        }

        public List<ScreeningModel> GetScreenings()
        {
            var screenings = new List<ScreeningModel>();
            screenings = _mapper.Map<List<ScreeningModel>>(Repository.GetScreenings().ToList());
            screenings = GetAndAddMoviesToScreenings(screenings);
            screenings = GetAndAddHallsToScreenings(screenings);
            return screenings;
        }
        

        public void AddScreening(ScreeningModel screening)
        {
            Repository.AddScreening(screening);
        }

        public void EditScreening(ScreeningModel screening)
        {
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
                    if (IsItAfterOrBeforeTheScreening(timeOfScreening, movieId, screeningDatabase) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public bool IsItAfterOrBeforeTheScreening(TimeSpan timeOfScreening, int movieId, ScreeningModel screeningDatabase)
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
