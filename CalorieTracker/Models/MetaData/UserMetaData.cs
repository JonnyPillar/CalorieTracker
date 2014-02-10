using System;
using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class UserMetaData
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