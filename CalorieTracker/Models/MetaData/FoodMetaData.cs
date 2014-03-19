using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class FoodMetaData
    {
        //[ScaffoldColumn(false)]
        public int FoodID { get; set; }

        [ScaffoldColumn(false)]
        public int SourceID { get; set; }

        [ScaffoldColumn(false)]
        public int? ParentID { get; set; }

        //[ScaffoldColumn(false)]
        public int GroupID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Manufacturer Name")]
        public string ManufactureName { get; set; }
    }
}