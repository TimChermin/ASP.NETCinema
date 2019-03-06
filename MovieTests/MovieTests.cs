using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace MovieTests
{
    public class MovieTests
    {
        MovieLogic movieLogic = new MovieLogic();
        MovieController movieController = new MovieController();

        [Fact]
        public void Should_ReturnAListOfMovies_WhenLoadingTheListMoviesView()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            List<MovieModel> movies = movieLogic.GetMoviesAndOrderBy("MoviesToday");
            List<MovieModel> movies2 = movieLogic.GetMoviesAndOrderBy("MoviesToday");



            //Assert
            //Assert.Same(movies, movies2);
            //Assert.Equal(movies, movies2);
           // Assert.True(movies.Equals(movies2));
     
            //Assert.Equal(movies, movies2);
            //Assert.NotEqual(movies, movies2);

            //Assert.Equal(movies2, actual: movies);



            //Assert.Equal("[MovieModel { Description = WATAAAAAAAAAAR, ID = 13, ImageString = https://www.movieposters4u.com/images/a/AquamanAdv..., LastScreeningDate = 2019-03-02T00:00:00.0000000, MovieLenght = 70, ... }, MovieModel { Description = TestEdit, ID = 1, ImageString = https://www.movieposters4u.com/images/b/BladeRunne..., LastScreeningDate = 2020-10-05T00:00:00.0000000, MovieLenght = 144, ... }, MovieModel { Description = PIKA, ID = 15, ImageString = https://m.media-amazon.com/images/M/MV5BMTk1MjgwNj..., LastScreeningDate = 2019-02-28T00:00:00.0000000, MovieLenght = 136, ... }, MovieModel { Description = About a dude, ID = 14, ImageString = https://www.movieposter.com/posters/archive/main/3..., LastScreeningDate = 2019-03-10T00:00:00.0000000, MovieLenght = 154, ... }, MovieModel { Description = Gaat over Jader, ID = 6, ImageString = https://images-na.ssl-images-amazon.com/images/I/5..., LastScreeningDate = 2019-02-04T00:00:00.0000000, MovieLenght = 122, ... }, ...]", "[MovieModel { Description = WATAAAAAAAAAAR, ID = 13, ImageString = https://www.movieposters4u.com/images/a/AquamanAdv..., LastScreeningDate = 2019-03-02T00:00:00.0000000, MovieLenght = 70, ... }, MovieModel { Description = TestEdit, ID = 1, ImageString = https://www.movieposters4u.com/images/b/BladeRunne..., LastScreeningDate = 2020-10-05T00:00:00.0000000, MovieLenght = 144, ... }, MovieModel { Description = PIKA, ID = 15, ImageString = https://m.media-amazon.com/images/M/MV5BMTk1MjgwNj..., LastScreeningDate = 2019-02-28T00:00:00.0000000, MovieLenght = 136, ... }, MovieModel { Description = About a dude, ID = 14, ImageString = https://www.movieposter.com/posters/archive/main/3..., LastScreeningDate = 2019-03-10T00:00:00.0000000, MovieLenght = 154, ... }, MovieModel { Description = Gaat over Jader, ID = 6, ImageString = https://images-na.ssl-images-amazon.com/images/I/5..., LastScreeningDate = 2019-02-04T00:00:00.0000000, MovieLenght = 122, ... }, ...]");
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
