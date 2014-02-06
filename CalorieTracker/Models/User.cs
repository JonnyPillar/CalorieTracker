//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.ActivityLogs = new HashSet<ActivityLog>();
            this.FoodLogs = new HashSet<FoodLog>();
            this.MetricLogs = new HashSet<MetricLog>();
        }
    
        public int UserID { get; set; }
        public System.DateTime DOB { get; set; }
        public bool Gender { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool Admin { get; set; }
        public System.DateTime CreationTimestamp { get; set; }
        public int ActivityLevelType { get; set; }
        public int Personality { get; set; }
    
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<FoodLog> FoodLogs { get; set; }
        public virtual ICollection<MetricLog> MetricLogs { get; set; }
    }
}