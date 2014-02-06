using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CalorieTracker.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth;
        [Required]
        public Boolean Gender;
        [DataType(DataType.Password)]
        [Required]
        public string Password;
    }
}