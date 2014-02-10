using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CalorieTracker.Models.ViewModels;
using CTDataGenerator.Utils;

namespace CalorieTracker.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public User(RegisterModel registerModel)
        {
            this.DOB = registerModel.DateOfBirth;
            this.Gender = registerModel.Gender;
            PasswordHasher passwordHasher = new PasswordHasher(registerModel.Password);
            this.PasswordHash = passwordHasher.PasswordHash;
            this.PasswordSalt = passwordHasher.PasswordSalt;
            this.Admin = false;
            this.CreationTimestamp = DateTime.Now;
            this.ActivityLevelType = 0;
            this.Personality = 0;

            this.ActivityLogs = new HashSet<ActivityLog>();
            this.FoodLogs = new HashSet<FoodLog>();
            this.MetricLogs = new HashSet<MetricLog>();
        }
    }

    public class UserMetadata
    {
        [ScaffoldColumn(false)] 
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public System.DateTime DOB { get; set; }
        [Required]
        public bool Gender { get; set; }
        [ScaffoldColumn(false)] 
        public string PasswordHash { get; set; }
        [ScaffoldColumn(false)] 
        public string PasswordSalt { get; set; }
        [ScaffoldColumn(false)] 
        public bool Admin { get; set; }
        [ScaffoldColumn(false)] 
        public System.DateTime CreationTimestamp { get; set; }
        [ScaffoldColumn(false)] 
        public int ActivityLevelType { get; set; }
        [ScaffoldColumn(false)] 
        public int Personality { get; set; }

    }


}