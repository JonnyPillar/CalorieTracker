using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.ViewModels;
using CTDataGenerator.Utils;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (UserMetadata))]
    public partial class User
    {
        public User(RegisterModel registerModel)
        {
            DOB = registerModel.DateOfBirth;
            Gender = registerModel.Gender;
            var passwordHasher = new PasswordHasher(registerModel.Password);
            PasswordHash = passwordHasher.PasswordHash;
            PasswordSalt = passwordHasher.PasswordSalt;
            Admin = false;
            CreationTimestamp = DateTime.Now;
            ActivityLevelType = 0;
            Personality = 0;

            ActivityLogs = new HashSet<ActivityLog>();
            FoodLogs = new HashSet<FoodLog>();
            MetricLogs = new HashSet<MetricLog>();
        }
    }

    public class UserMetadata
    {
        [ScaffoldColumn(false)]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public bool Gender { get; set; }

        [ScaffoldColumn(false)]
        public string PasswordHash { get; set; }

        [ScaffoldColumn(false)]
        public string PasswordSalt { get; set; }

        [ScaffoldColumn(false)]
        public bool Admin { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationTimestamp { get; set; }

        [ScaffoldColumn(false)]
        public int ActivityLevelType { get; set; }

        [ScaffoldColumn(false)]
        public int Personality { get; set; }
    }
}