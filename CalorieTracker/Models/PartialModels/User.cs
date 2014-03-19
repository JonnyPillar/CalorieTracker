using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.Enum;
using CalorieTracker.Models.MetaData;
using CalorieTracker.Models.ViewModels;
using CTDataGenerator.Utils;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (UserMetaData))]
    public partial class User
    {
        public Gender GenderEnum
        {
            get { return (Gender) Convert.ToInt32(Gender); }
            set { Gender = Convert.ToBoolean(value); }
        }

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

            UserActivityLogs = new HashSet<ActivityLog>();
            UserFoodLogs = new HashSet<FoodLog>();
            UserMetricLogs = new HashSet<MetricLog>();
        }
    }
}