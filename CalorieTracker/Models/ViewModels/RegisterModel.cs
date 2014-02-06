using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CalorieTracker.Models.ViewModels
{
    [Bind(Exclude = "IDNumber")]
    public class RegisterModel
    {
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth;
        public Boolean Gender;
        [DataType(DataType.Password)]
        public string Password;
    }
}