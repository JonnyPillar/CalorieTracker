using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class ActivityMetaData
    {
        [ScaffoldColumn(false)]
        public string ActivityID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Calorie Burn Rate (Per Sec)")]
        public decimal CalorieBurnRate { get; set; }

        [Required]
        [Display(Name = "Activity Image URL")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}