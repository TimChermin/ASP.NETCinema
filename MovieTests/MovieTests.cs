using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MovieTests
{
    public class MovieTests
    {
        MovieLogic movieLogic = new MovieLogic();
        MovieController movieController = new MovieController();
        List<MovieModel> movies = new List<MovieModel>();
        List<MovieModel> movies2 = new List<MovieModel>();

        ThingEqualityComparer comparer = new ThingEqualityComparer();


        [Fact]
        public void Should_ReturnAListOfMovies_WhenLoadingTheListMoviesViewName()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy("Name");
            movies2 = movieLogic.GetMoviesAndOrderBy("Name");
            
            bool found = false;
            foreach (var movie in movies)
            {
                found = false;
                foreach (var movie2 in movies2)
                {
                    if (movie.Id == movie2.Id)
                    {
                        Assert.True(comparer.Equals(movie, movie2));
                        found = true;
                    }
                }
                if (found == false)
                {
                    Assert.True(false);
                }
            }
        }

        [Fact]
        public void Should_ReturnAListOfMovies_WhenLoadingTheListMoviesView()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy(null);
            movies2 = movieLogic.GetMoviesAndOrderBy(null);

            bool found = false;
            foreach (var movie in movies)
            {
                found = false;
                foreach (var movie2 in movies2)
                {
                    if (movie.Id == movie2.Id)
                    {
                        Assert.True(comparer.Equals(movie, movie2));
                        found = true;
                    }
                }
                if (found == false)
                {
                    Assert.True(false);
                }
            }
        }


        [Fact]
        public void Should_ReturnAListOfMovies_WhenLoadingTheListMoviesViewMoviesToday()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            movies = movieLogic.GetMoviesAndOrderBy("MoviesToday");
            movies2 = movieLogic.GetMoviesAndOrderBy("MoviesToday");

            bool found = false;
            foreach (var movie in movies)
            {
                found = false;
                foreach (var movie2 in movies2)
                {
                    if (movie.Id == movie2.Id)
                    {
                        Assert.True(comparer.Equals(movie, movie2));
                        found = true;
                    }
                }
                if (found == false)
                {
                    Assert.True(false);
                }
            }
        }



        class ThingEqualityComparer : IEqualityComparer<MovieModel>
        {
            public bool Equals(MovieModel x, MovieModel y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Name == y.Name);
            }

            public int GetHashCode(MovieModel obj)
            {
                return obj.GetHashCode();
            }
        }

        /*
    <input name = "OrderBy" type="submit" id="submit" value="Name" />
    <input name = "OrderBy" type="submit" id="process" value="MovieType" />
    <input name = "OrderBy" type="submit" id="process" value="ReleaseDate" />
    <input name = "OrderBy" type="submit" id="process" value="MoviesToday" />*/

        /*[TestMethod()]
        public void Should_ReturnTrue_When_TheLocationWilNotBlockAValuable()
        {
            //Arrange
            shipArray = new Container[5, 4, 5];
            ship = new Ship(5, 4, 5, 1000, shipArray);
            shipArray[0, 0, 0] = cont = new Container(20, true, true);
            shipArray[1, 0, 0] = cont = new Container(20, true, false);
            cont2 = new Container(20, false, false);
            cont = new Container(20, true, false);

            //Act

            //Assert
            Assert.IsTrue(ship.DoesTheLocationHaveAnValuable(0, 0, 1, cont2, true) == true);
            Assert.IsTrue(ship.DoesTheLocationHaveAnValuable(1, 0, 1, cont, true) == false);
        }
        */
    }
}
