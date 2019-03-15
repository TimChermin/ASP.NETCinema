using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCinema.Models
{
    public class MovieModel
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

        
        //[Range(100000, 999999, ErrorMessage = "This ID isn't good")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        //[Range(DateTime.Today, DateTime.Today, ErrorMessage = "This ID isn't good")]
        [Display(Name = "Release date")]
        [Required(ErrorMessage = "The Release Date field is required.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Last Screening Date")]
        [Required(ErrorMessage = "The Last Screening Date field is required.")]
        [DataType(DataType.Date)]
        public DateTime LastScreeningDate { get; set; }

        [Display(Name = "Movie Type")]
        [Required(ErrorMessage = "The Movie Type field is required.")]
        public string MovieType { get; set; }

        [Display(Name = "Movie Lenght")]
        [Required(ErrorMessage = "You need to fill in the movie lenght")]
        public string MovieLenght { get; set; }

        [Display(Name = "Link To Movie Image")]
        [Required(ErrorMessage = "You need to add an image")]
        public string ImageString { get; set; }

    }
}
