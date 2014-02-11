using System;
using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class ActivityLogMetaData
    {
        [ScaffoldColumn(false)]
        public string ActivityLogID { get; set; }

        [Required]
        [Display(Name = "Activity")]
        public string ActivityID { get; set; }

        [ScaffoldColumn(false)]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "hh:MM:ss hh:mm:ss")]
        public DateTime StartDate { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public decimal Distance { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Accent { get; set; }

        [Required]
        [Display(Name = "Heart Rate")]
        public int HeartRate { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        [Display(Name = "File URL")]
        [DataType(DataType.Upload)]
        public string FileURL { get; set; }
    }
}