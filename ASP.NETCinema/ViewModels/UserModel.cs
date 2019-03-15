using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ASPNETCinema.Models;

namespace ASPNETCinema.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string name, string password, int administrator)
        {
            Id = id;
            Name = name;
            Password = password;
            Administrator = administrator;
        }

        public UserViewModel(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

        public UserViewModel()
        {
        }



        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You must have a Name")]
        public string Name { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "You Need to provide a longer password.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required")]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }

        [Range(0, 2, ErrorMessage = "Can only be between 0 and 2: 0 = Normal - 1 = Admin - 2 = Employee")]
        [Required(ErrorMessage = "This field is required")]
        public int Administrator { get; set; }
        
        public List<ScreeningModel> Tickets { get; set; }




    }
}
