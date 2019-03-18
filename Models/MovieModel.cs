using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Interfaces;

namespace ASPNETCinema.Models
{
    public class MovieModel : IMovie
    {
        public MovieModel(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString)
        {
            Name = name;
            Description = description;
            ReleaseDate = releaseDate;
            LastScreeningDate = lastScreeningDate;
            MovieType = movieType;
            MovieLenght = movieLenght;
            ImageString = imageString;
        }

        public MovieModel(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString)
        {
            Id = id;
            Name = name;
            Description = description;
            ReleaseDate = releaseDate;
            LastScreeningDate = lastScreeningDate;
            MovieType = movieType;
            MovieLenght = movieLenght;
            ImageString = imageString;
        }

        public MovieModel()
        {

        }

        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastScreeningDate { get; set; }
        public string MovieType { get; set; }
        public string MovieLenght { get; set; }
        public string ImageString { get; set; }

    }
}
