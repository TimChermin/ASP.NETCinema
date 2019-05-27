﻿using ASPNETCinema.Models;
using DAL;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieDto = DAL.Dtos.MovieDto;

namespace UnitTests.Movie.MockContext
{
    class MovieContextMock : IMovieContext
    {
        List<MovieDto> movies = new List<MovieDto>();
        List<MovieDto> moviesTemp = new List<MovieDto>();

        
        public List<MovieDto> GetMovies(string orderBy)
        {
            movies.Clear();
            foreach (var movie in moviesTemp)
            {
                movies.Add(movie);
            }
            movies = AddMoviesInOrderBy(movies, orderBy);
            return movies;
        }

        public List<MovieDto> AddMoviesInOrderBy(List<MovieDto> movies, string orderBy)
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
                var moviesToday = new List<MovieDto>();
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

        public void AddMovie(MovieModel movie)
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

        public void EditMovie(MovieModel movie)
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

        public MovieDto GetMovieById(int id)
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

        public List<ScreeningDto> GetScreeningsForMovie(int idMovie)
        {
            return null;
        }

        public MovieDto GetMovieByName(string name)
        {
            return null;
        }
    }
}
