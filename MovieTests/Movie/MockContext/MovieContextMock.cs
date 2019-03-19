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
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            var movies = new List<IMovie>();
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
                return movies.OrderByDescending(movie => movie.Name).ToList();
            }
            else if (orderBy == "ReleaseDate")
            {
                return movies.OrderByDescending(movie => movie.ReleaseDate).ToList();
            }
            else if (orderBy == "MovieType")
            {
                return movies.OrderByDescending(movie => movie.MovieType).ToList();
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
            throw new NotImplementedException();
        }

        public void EditMovie(IMovie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(IMovie movie)
        {
            throw new NotImplementedException();
        }

        public IMovie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
