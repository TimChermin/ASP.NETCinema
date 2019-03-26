using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTests.Movie.Dtos;

namespace UnitTests.Movie.MockContext
{
    class MovieContextMock : IMovieContext
    {
        List<IMovie> movies = new List<IMovie>();
        List<IMovie> moviesTemp = new List<IMovie>();

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            movies.Clear();
            foreach (var movie in moviesTemp)
            {
                movies.Add(movie);
            }
            movies = AddMoviesInOrderBy(movies, orderBy);
            return movies;
        }

        public List<IMovie> AddMoviesInOrderBy(List<IMovie> movies, string orderBy)
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
            if (orderBy == "Name")
            {
                return movies.OrderBy(movie => movie.Name).ToList();
            }
            else if (orderBy == "ReleaseDate")
            {
                return movies.OrderBy(movie => movie.ReleaseDate).ToList();
            }
            else if (orderBy == "MovieType")
            {
                return movies.OrderBy(movie => movie.MovieType).ToList();
            }
            else if (orderBy == "MovieToday")
            {
                var moviesToday = new List<IMovie>();
                foreach (var movie in movies)
                {
                    if (movie.ReleaseDate == DateTime.Today)
                    {
                        moviesToday.Add(movie);
                    }
                }
                return moviesToday;
            }
            return movies;
        }

        public void AddMovie(IMovie movie)
        {
            moviesTemp.Add(new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                LastScreeningDate = movie.LastScreeningDate,
                MovieType = movie.MovieType,
                MovieLenght = movie.MovieLenght,
                ImageString = movie.ImageString
            });
        }

        public void EditMovie(IMovie movie)
        {
            foreach (var mov in GetMovies(null))
            {
                if (mov.Id == movie.Id)
                {
                    mov.Name = movie.Name;
                    mov.Description = movie.Description;
                    mov.ReleaseDate = movie.ReleaseDate;
                    mov.LastScreeningDate = movie.LastScreeningDate;
                    mov.MovieType = movie.MovieType;
                    mov.MovieLenght = movie.MovieLenght;
                    mov.ImageString = movie.ImageString;
                    moviesTemp.Add(mov);
                }
            }
        }

        public void DeleteMovie(int id)
        {
            foreach (var movie in GetMovies(null))
            {
                if (movie.Id == id)
                {
                    movie.Name = "Deleted";
                    moviesTemp.Add(movie);
                }
            }
        }

        public IMovie GetMovieById(int id)
        {
            foreach (var movie in GetMovies(null))
            {
                if (movie.Id == id)
                {
                    return movie;
                }
            }
            return null;
        }

        public IEnumerable<IScreening> GetScreeningsForMovie(int idMovie)
        {
            return null;
        }
    }
}
