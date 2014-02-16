using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class FoodGroupMetaData
    {
        [ScaffoldColumn(false)]
        public int FoodGroupID { get; set; }

        [Required]
        [Display(Name = "Food Group Name")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public int SourceID { get; set; }
    }
}