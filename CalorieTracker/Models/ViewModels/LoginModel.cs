using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User ID")]
        [Range(1, 999999)]
        public int UserID;
        [Required]
        public string Password;
    }
}