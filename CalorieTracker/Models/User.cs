using System;
using System.Collections.Generic;

namespace CalorieTracker.Models
{
    public partial class User
    {
        public User()
        {
            UserActivityLogs = new HashSet<ActivityLog>();
            UserFoodLogs = new HashSet<FoodLog>();
            UserMetricLogs = new HashSet<MetricLog>();
        }

        public int UserID { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool Admin { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public int ActivityLevelType { get; set; }
        public int Personality { get; set; }

        public virtual ICollection<ActivityLog> UserActivityLogs { get; set; }
        public virtual ICollection<FoodLog> UserFoodLogs { get; set; }
        public virtual ICollection<MetricLog> UserMetricLogs { get; set; }
    }
}