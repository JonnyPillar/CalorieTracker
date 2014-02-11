using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User ID")]
        public int UserID { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}