using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models.ViewModels;
using CTDataGenerator.Utils;

namespace CalorieTracker.Models
{
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
}