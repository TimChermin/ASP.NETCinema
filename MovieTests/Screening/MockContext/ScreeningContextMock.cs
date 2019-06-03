using ASPNETCinema.Models;
using DAL;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using MovieDto = DAL.Dtos.MovieDto;
using ScreeningDto = DAL.Dtos.ScreeningDto;

namespace UnitTests.Screening.MockContext
{
    class ScreeningContextMock : IScreeningContext
    {
        List<MovieDto> movies = new List<MovieDto>();
        List<ScreeningDto> screenings = new List<ScreeningDto>();
        List<ScreeningDto> screeningsTemp = new List<ScreeningDto>();
        List<ScreeningDto> screeningsTempDeleted = new List<ScreeningDto>();
        int delete = 0;
        int edit = 0;
        DateTime editDate = DateTime.Today;

        public List<ScreeningDto> GetScreenings()
        {
            screenings.Clear();
            SetScreenings();
            AddedScreenings();
            return screenings;
        }

        public void SetScreenings()
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

            WasSomethingDeleted();
            WasSomethingEdited();
        }

        public void WasSomethingDeleted()
        {
            if (delete != 0)
            {
                foreach (var screening in screenings)
                {
                    if (screening.Id == delete)
                    {
                        screenings.Remove(screening);
                        break;
                    }
                }
            }
        }

        public void WasSomethingEdited()
        {
            if (edit != 0)
            {
                foreach (var screening in screenings)
                {
                    if (screening.Id == edit && editDate != DateTime.Today)
                    {
                        screenings[0].DateOfScreening = editDate;
                        break;
                    }
                }
            }
        }

        public void AddScreening(ScreeningModel screening)
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

        private void AddedScreenings()
        {
            foreach (var screening in screeningsTemp)
            {
                screenings.Add(screening);
            }
        }

        public void EditScreening(ScreeningModel screening)
        {
            edit = screening.Id;
            editDate = screening.DateOfScreening;
        }

        public void DeleteScreening(int id)
        {
            delete = id;
        }

        public ScreeningDto GetScreeningById(int id)
        {
            foreach (var screening in screenings)
            {
                if (screening.Id == id)
                {
                    return screening;
                }
            }
            foreach (var screening in screeningsTemp)
            {
                if (screening.Id == id)
                {
                    return screening;
                }
            }
            return null;
        }

        public MovieDto GetMovie(int idMovie)
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

        public List<MovieDto> GetMovies()
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

        public List<HallDto> GetHalls()
        {
            return null;
        }

        public HallDto GetHall(int idHall)
        {
            return null;
        }
    }
}
