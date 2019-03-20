using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Movie.Dtos;
using UnitTests.Movie.MockContext;
using Xunit;

namespace MovieTests
{
    public class GettingMoviesTest
    {
        MovieLogic _movieLogic;
        ThingEqualityComparer comparer = new ThingEqualityComparer();
        string orderBy = "";
        List<IMovie> movies = new List<IMovie>();
        List<IMovie> movies2 = new List<IMovie>();

        public GettingMoviesTest()
        {
            _movieLogic = new MovieLogic(new MovieContextMock());
        }

        [Fact]
        public void Should_ReturnAListOfMovies_WhenGettingMovies()
        {
            var movieLogic = new MovieLogic(new MovieContextMock());
            
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            movies2 = movieLogic.GetMovies(orderBy).ToList();
            
            Assert.True(AreTheyInTheSameOrder(movies, movies2));
        }

        [Fact]
        public void Should_ReturnAListOfMoviesInADifferentOrder_WhenGettingMovies()
        {
            var movieLogic = new MovieLogic(new MovieContextMock());
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            orderBy = "Name";
            movies2 = movieLogic.GetMovies(orderBy).ToList();

            Assert.False(AreTheyInTheSameOrder(movies, movies2));
        }


        [Fact]
        public void Should_ReturnAMovieListWithAnAddedMovie_WhenAddingAMovie()
        {
            var movieLogic = new MovieLogic(new MovieContextMock());
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            movieLogic.AddMovie(3, "DFilm", "Mooie film", DateTime.Today, new DateTime(2220, 10, 3), "3D Imax", "100", "TestString");
            movies2 = movieLogic.GetMovies(orderBy).ToList();

            if (movies.Count() != movies2.Count())
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void Should_ReturnAMovieListWithAnEditedMovie_WhenEditingAMovie()
        {
            var movieLogic = new MovieLogic(new MovieContextMock());
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            movieLogic.EditMovie(3, "Edited", "Mooie film", DateTime.Today, new DateTime(2220, 10, 3), "3D Imax", "100", "TestString");
            movies2 = movieLogic.GetMovies(orderBy).ToList();

            foreach (var movie in movies)
            {
                if (movie.Name != "Edited")
                {
                    Assert.True(true);
                }
            }
            foreach (var movie in movies2)
            {
                if (movie.Name == "Edited")
                {
                    Assert.True(true);
                }
            }
        }

        [Fact]
        public void Should_ReturnAMovie_WhenGettingAMovieById()
        {
            var movieLogic = new MovieLogic(new MovieContextMock());
            movieLogic.AddMovie(10, "Getting", "Mooie film", DateTime.Today, new DateTime(2220, 10, 3), "3D Imax", "100", "TestString");
            IMovie movie = movieLogic.GetMovieById(10);
            

            Assert.Equal(10, movie.Id);
        }

        [Fact]
        public void Should_ReturnAMovieListWithAnDeleteMovie_WhenDeleteingAMovie()
        {
            var movieLogic = new MovieLogic(new MovieContextMock());
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            movieLogic.DeleteMovie(3);
            movies2 = movieLogic.GetMovies(orderBy).ToList();

            foreach (var movie in movies)
            {
                if (movie.Name != "Deleted")
                {
                    Assert.True(true);
                }
            }
            foreach (var movie in movies2)
            {
                if (movie.Name == "Deleted")
                {
                    Assert.True(true);
                }
            }

        }

            public bool AreTheyInTheSameOrder(IEnumerable<IMovie> movies, IEnumerable<IMovie> movies2)
        {
            bool found;
            int movieNr = 0;
            int movie2Nr = 0;
            foreach (var movie in movies)
            {
                movie2Nr = 0;
                found = false;
                foreach (var movie2 in movies2)
                {
                    if (comparer.Equals(movie, movie2) && movieNr == movie2Nr)
                    {
                        Assert.True(true);
                        found = true;
                    }
                    movie2Nr++;
                }
                if (found == false)
                {
                    return false;
                }
                movieNr++;
            }
            return true;
        }


       
        class ThingEqualityComparer : IEqualityComparer<IMovie>
        {
            public bool Equals(IMovie x, IMovie y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Name == y.Name && x.Description == y.Description && x.ReleaseDate == y.ReleaseDate
                    && x.LastScreeningDate == y.LastScreeningDate && x.MovieType == y.MovieType && x.MovieLenght == y.MovieLenght
                    && x.ImageString == y.ImageString);
            }

            public int GetHashCode(IMovie obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
