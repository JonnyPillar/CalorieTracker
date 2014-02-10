using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class FoodGroupMetaData
    {
        [ScaffoldColumn(false)]
        public int FoodGroupID { get; set; }

        [Required]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public int SourceID { get; set; }
    }
}