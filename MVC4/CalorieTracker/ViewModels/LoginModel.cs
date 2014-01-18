using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace CalorieTracker.ViewModels
{
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
}