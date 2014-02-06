using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "User ID")]
        [Range(1, 999999)]
        public int UserID { get; set; }
        [Required]
        public string Password { get; set; }
    }
}