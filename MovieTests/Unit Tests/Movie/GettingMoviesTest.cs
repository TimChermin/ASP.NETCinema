using ASPNETCinema;
using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Movie.MockContext;
using Xunit;

namespace MovieTests
{
    public class GettingMoviesTest
    {
        MovieLogic movieLogic;
        IMapper _mapper;
        string orderBy = "";

        public GettingMoviesTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            movieLogic = new MovieLogic(new MovieContextMock(), _mapper);
        }
        
        
        [Fact]
        public void Should_AddAnMovie_WhenAddingAnMovie()
        {
            //Arrange
            MovieModel movie = new MovieModel { Id = 10, Name = "AddTest" };

            //Act
            movieLogic.AddMovie(movie);

            //Assert
            Assert.True(movieLogic.GetMovieById(10).Name == "AddTest");
        }

        [Fact]
        public void Should_EditAnMovie_WhenEditingAnMovie()
        {
            //Arrange
            MovieModel movie = new MovieModel { Id = 1, Name = "EditTest" };

            //Act
            movieLogic.EditMovie(movie);

            //Assert
            Assert.True(movieLogic.GetMovies(null)[0].Name == "EditTest");
        }

        [Fact]
        public void Should_ReturnAMovie_WhenGettingAMovieById()
        {
            //Arrange
            movieLogic.AddMovie(new MovieModel { Id = 5, Name = "GetByIdTest" });

            //Act
            MovieModel movie = movieLogic.GetMovieById(5);

            //Assert
            Assert.True(movie.Id == 5 && movie.Name == "GetByIdTest");
        }

        [Fact]
        public void Should_DeleteAnMovie_WhenDeleteingAnMovie()
        {
            //Arrange
            List<MovieModel> movies = new List<MovieModel>();
            movies = movieLogic.GetMovies(null);
            string name = movies[0].Name;

            //Act
            movieLogic.DeleteMovie(movies[0].Id);

            //Assert
            Assert.False(movies[0].Name != name);
        }

        [Fact]
        public void Should_GetMoviesFromTheList_WhenGettingMovies()
        {
            //Arrange
            MovieModel movie = new MovieModel { Id = 10, Name = "GetTest" };
            movieLogic.AddMovie(movie);
            bool found = false;

            //Act
            if (movieLogic.GetMovies(null)[4].Id == 10 && movieLogic.GetMovies(null)[4].Name == "GetTest")
            {
                found = true;
            }

            //Assert
            Assert.True(found);
        }
    }
}
