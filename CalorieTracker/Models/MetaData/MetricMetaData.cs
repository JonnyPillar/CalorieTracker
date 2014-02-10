using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class MetricMetaData
    {
        [ScaffoldColumn(false)]
        public string MetricID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Metric Type")]
        public int Type { get; set; }
    }
}