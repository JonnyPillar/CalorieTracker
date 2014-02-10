using System;
using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class MetricLogMetaData
    {
        [ScaffoldColumn(false)]
        public string MetricLogID { get; set; }

        [ScaffoldColumn(false)]
        public int? UserID { get; set; }

        [Required]
        [Display(Name = "Metric")]
        public string MetricID { get; set; }

        [Required]
        public decimal Value { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationTimestamp { get; set; }
    }
}