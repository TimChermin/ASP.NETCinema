using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MovieTests
{
    public class GettingMoviesTest
    {
        MovieLogic movieLogic = new MovieLogic();
        MovieController movieController = new MovieController();
        List<MovieModel> movies = new List<MovieModel>();
        List<MovieModel> movies2 = new List<MovieModel>();
        ThingEqualityComparer comparer = new ThingEqualityComparer();


        [Fact]
        public void Should_ReturnAListOfMoviesOrderedByName_WhenLoadingMoviesByName()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy("Name");
            movies2 = movieLogic.GetMoviesAndOrderBy("Name");

            bool found = false;
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
                    Assert.True(false);
                }
                movieNr++;
            }
        }

        [Fact]
        public void Should_ReturnAListOfMoviesOrderedByNull_WhenLoadingMoviesByNull()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy(null);
            movies2 = movieLogic.GetMoviesAndOrderBy(null);

            bool found = false;
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
                    Assert.True(false);
                }
                movieNr++;
            }
        }


        [Fact]
        public void Should_ReturnAListOfMoviesOrderedByToday_WhenLoadingMoviesByToday()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy("MoviesToday");
            movies2 = movieLogic.GetMoviesAndOrderBy("MoviesToday");

            bool found = false;
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
                    Assert.True(false);
                }
                movieNr++;
            }
        }

        [Fact]
        public void Should_ReturnAListOfMoviesOrderedByReleaseAndName_WhenLoadingMoviesByReleaseAndName()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy("ReleaseDate");
            movies2 = movieLogic.GetMoviesAndOrderBy("Name");

            bool found = false;
            bool diffOrder = false;
            int movieNr = 0;
            int movie2Nr = 0;
            foreach (var movie in movies)
            {
                movie2Nr = 0;
                found = false;
                foreach (var movie2 in movies2)
                {
                    if (comparer.Equals(movie, movie2) && movieNr == movie2Nr && diffOrder == false && movies.Count > 4)
                    {
                        Assert.False(comparer.Equals(movie, movie2) == diffOrder);
                        found = true;
                    }
                    else if (comparer.Equals(movie, movie2))
                    {
                        Assert.True(comparer.Equals(movie, movie2));
                        found = true;
                        diffOrder = true;
                    }
                    movie2Nr++;
                }

                if (found == false)
                {
                    Assert.True(false);
                }
                movieNr++;
            }
        }



        class ThingEqualityComparer : IEqualityComparer<MovieModel>
        {
            public bool Equals(MovieModel x, MovieModel y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Name == y.Name && x.Description == y.Description && x.ReleaseDate == y.ReleaseDate
                    && x.LastScreeningDate == y.LastScreeningDate && x.MovieType == y.MovieType && x.MovieLenght == y.MovieLenght
                    && x.ImageString == y.ImageString);
            }

            public int GetHashCode(MovieModel obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
