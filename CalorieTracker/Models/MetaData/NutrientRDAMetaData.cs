using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class NutrientRDAMetaData
    {
        [ScaffoldColumn(false)]
        public int NutrientRdaID { get; set; }

        [Required]
        [Display(Name = "Nutrient")]
        public int NutrientID { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        [Display(Name = "Min Age")]
        public int AgeMin { get; set; }

        [Required]
        [Display(Name = "Max Age")]
        public int AgeMax { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        [Display(Name = "Unit Type")]
        public int UnitType { get; set; }
    }
}