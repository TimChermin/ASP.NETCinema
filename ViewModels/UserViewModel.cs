using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using static aMVCLayer.Enums.UserType;

namespace ASPNETCinema.ViewModels
{
    public class UserViewModel
    {
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
        
        public List<ScreeningViewModel> Tickets { get; set; }

        [Display(Name = "User Role")]
        [Required(ErrorMessage = "The User Roile field is required.")]
        public List<UserTypes> UserTypes { get; set; }

        [Display(Name = "User Role")]
        [Required(ErrorMessage = "The User Role field is required.")]
        public string Role { get; set; }




    }
}
