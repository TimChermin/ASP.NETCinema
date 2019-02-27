using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCinema.Models
{
    public class UserModel
    {
        public UserModel(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }


        public UserModel()
        {
        }



        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "You Need to provide a longer password.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool Administrator { get; set; }
        public List<ScreeningModel> Tickets { get; set; }




    }
}
