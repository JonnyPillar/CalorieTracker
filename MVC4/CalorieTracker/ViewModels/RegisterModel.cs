using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class RegisterModel
    {
        [HiddenInput(DisplayValue = false)]
        public tbl_user newUser { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public RegisterModel()
        {
            newUser = new tbl_user();
        }
    }
}