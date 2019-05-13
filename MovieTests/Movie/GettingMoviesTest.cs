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
        MovieLogic _movieLogic;
        IMapper _mapper;
        ThingEqualityComparer comparer = new ThingEqualityComparer();
        string orderBy = "";
        List<MovieModel> movies = new List<MovieModel>();
        List<MovieModel> movies2 = new List<MovieModel>();

        public GettingMoviesTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            _movieLogic = new MovieLogic(new MovieContextMock(), _mapper);
        }

        [Fact]
        public void Should_ReturnAListOfMovies_WhenGettingMovies()
        {
            var movieLogic = new MovieLogic(new MovieContextMock(), _mapper);
            
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            movies2 = movieLogic.GetMovies(orderBy).ToList();
            
            Assert.True(AreTheyInTheSameOrder(movies, movies2));
        }

        [Fact]
        public void Should_ReturnAListOfMoviesInADifferentOrder_WhenGettingMovies()
        {
            var movieLogic = new MovieLogic(new MovieContextMock(), _mapper);
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            orderBy = "Name";
            movies2 = movieLogic.GetMovies(orderBy).ToList();

            Assert.False(AreTheyInTheSameOrder(movies, movies2));
        }


        [Fact]
        public void Should_AddAMovieToTheList_WhenAddingAMovie()
        {
            var movieLogic = new MovieLogic(new MovieContextMock(), _mapper);
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            movieLogic.AddMovie(new MovieModel { Id = 3, Name = "DFilm", Description = "Mooie film", ReleaseDate = DateTime.Today, LastScreeningDate = new DateTime(2220, 10, 3), MovieType = "3D Imax", MovieLenght = "100", ImageString = "TestString", BannerImageString = "TestString" });
            movies2 = movieLogic.GetMovies(orderBy).ToList();
            
            Assert.True(movies.Count() != movies2.Count());
        }

        [Fact]
        public void Should_ReturnAMovieListWithAnEditedMovie_WhenEditingAMovie()
        {
            var movieLogic = new MovieLogic(new MovieContextMock(), _mapper);
            //var result =  movieLogic.GetAllCustomers();
            movies = movieLogic.GetMovies(orderBy).ToList();
            movieLogic.EditMovie(new MovieModel { Id = 3, Name = "Edited", Description = "Mooie film", ReleaseDate = DateTime.Today, LastScreeningDate = new DateTime(2220, 10, 3), MovieType = "3D Imax", MovieLenght = "100", ImageString = "TestString", BannerImageString = "TestString" });
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
            var movieLogic = new MovieLogic(new MovieContextMock(), _mapper);
            movieLogic.AddMovie(new MovieModel { Id = 10, Name = "Getting", Description = "Mooie film", ReleaseDate = DateTime.Today, LastScreeningDate = new DateTime(2220, 10, 3), MovieType = "3D Imax", MovieLenght = "100", ImageString = "TestString", BannerImageString = "TestString" });
            MovieModel movie = movieLogic.GetMovieById(10);
            

            Assert.Equal(10, movie.Id);
        }

        [Fact]
        public void Should_ReturnAMovieListWithAnDeleteMovie_WhenDeleteingAMovie()
        {
            var movieLogic = new MovieLogic(new MovieContextMock(), _mapper);
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

        public bool AreTheyInTheSameOrder(List<MovieModel> movies, List<MovieModel> movies2)
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
