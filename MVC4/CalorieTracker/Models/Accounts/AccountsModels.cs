using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace CalorieTracker.Models.Accounts
{
    public class UserContext : DbContext
    {
        public UserContext() : base("calorie_tracker_v1Entities")
        {
        }

        public DbSet<tbl_user> UserProfiles { get; set; }

        public class LoginModel
        {
            [Required]
            [Display(Name = "Email Address")]
            public string user_email_address { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string user_password { get; set; }

            [Display(Name = "Remember me?")]
            public bool user_remember_me { get; set; }
        }

        public class RegisterModel : tbl_user
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
    }
}