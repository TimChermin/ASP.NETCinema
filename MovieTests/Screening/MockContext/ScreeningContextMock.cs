using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.Movie.Dtos;
using UnitTests.Screening.Dtos;

namespace UnitTests.Screening.MockContext
{
    class ScreeningContextMock : IScreeningContext
    {
        List<IScreening> screenings = new List<IScreening>();
        List<IScreening> screeningsTemp = new List<IScreening>();
        List<IMovie> movies = new List<IMovie>();

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        public IEnumerable<IScreening> GetScreenings()
        {
            screenings.Clear();
            foreach (var screening in screeningsTemp)
            {
                screenings.Add(screening);
            }
            screenings = AddScreeningsInOrderBy(screenings);
            return screenings;
        }

        public List<IScreening> AddScreeningsInOrderBy(List<IScreening> screenings)
        {
            screenings.Add(new ScreeningDto
            {
                Id = 1,
                MovieId = 1,
                HallId = 1,
                DateOfScreening = new DateTime(2020, 1, 1),
                TimeOfScreening = new TimeSpan(1, 0, 0)
            });

            screenings.Add(new ScreeningDto
            {
                Id = 5,
                MovieId = 5,
                HallId = 5,
                DateOfScreening = new DateTime(2020, 10, 10),
                TimeOfScreening = new TimeSpan(2, 0, 0)
            });

            screenings.Add(new ScreeningDto
            {
                Id = 3,
                MovieId = 5,
                HallId = 1,
                DateOfScreening = new DateTime(2020, 10, 10),
                TimeOfScreening = new TimeSpan(10, 30, 0)
            });

            screenings.Add(new ScreeningDto
            {
                Id = 9,
                MovieId = 3,
                HallId = 3,
                DateOfScreening = new DateTime(2020, 10, 10),
                TimeOfScreening = new TimeSpan(2, 0, 0)
            });
            return screenings;
        }

        public void DeleteScreening(int id)
        {

        }

        public void EditScreening(IScreening screening)
        {

        }

        public IHall GetHall(int idHall)
        {
            return null;
        }

        public IMovie GetMovie(int idMovie)
        {
            foreach (var movie in GetMovies())
            {
                if (movie.Id == idMovie)
                {
                    return movie;
                }
            }
            return null;
        }

        public IEnumerable<IMovie> GetMovies()
        {
            movies.Add(new MovieDto
            {
                Id = 1,
                Name = "AFilm",
                Description = "Mooie film",
                ReleaseDate = new DateTime(2000, 10, 3),
                LastScreeningDate = new DateTime(2020, 10, 3),
                MovieType = "3D",
                MovieLenght = "120",
                ImageString = "TestString"
            });

            movies.Add(new MovieDto
            {
                Id = 5,
                Name = "CFilms",
                Description = "Mooie films",
                ReleaseDate = new DateTime(2020, 10, 3),
                LastScreeningDate = new DateTime(2030, 10, 3),
                MovieType = "Normal",
                MovieLenght = "125",
                ImageString = "TestString"
            });

            movies.Add(new MovieDto
            {
                Id = 2,
                Name = "BFilmpie",
                Description = "Mooie film",
                ReleaseDate = new DateTime(2000, 10, 3),
                LastScreeningDate = new DateTime(2020, 10, 3),
                MovieType = "2D",
                MovieLenght = "80",
                ImageString = "TestString"
            });

            movies.Add(new MovieDto
            {
                Id = 3,
                Name = "DFilm",
                Description = "Mooie film",
                ReleaseDate = DateTime.Today,
                LastScreeningDate = new DateTime(2220, 10, 3),
                MovieType = "3D IMAX",
                MovieLenght = "100",
                ImageString = "TestString"
            });
            return movies;
        }

        public IScreening GetScreeningById(int id)
        {
            foreach (var screening in GetScreenings())
            {
                if (screening.Id == id)
                {
                    return screening;
                }
            }
            return null;
        }

        public void AddScreening(IScreening screening)
        {
            screeningsTemp.Add(new ScreeningDto
            {
                Id = screening.Id,
                MovieId = screening.MovieId,
                HallId = screening.HallId,
                DateOfScreening = screening.DateOfScreening,
                TimeOfScreening = screening.TimeOfScreening
            });
        }

        public IEnumerable<IHall> GetHalls()
        {
            return null;
        }
    }
}
