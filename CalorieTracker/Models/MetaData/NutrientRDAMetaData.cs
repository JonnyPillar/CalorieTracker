using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class NutrientRDAMetaData
    {
        [ScaffoldColumn(false)]
        public int NutrientRdaID { get; set; }

        [ScaffoldColumn(false)]
        public int NutrientID { get; set; }

        public bool Gender { get; set; }

        [Display(Name = "Min Age")]
        public int AgeMin { get; set; }

        [Display(Name = "Max Age")]
        public int AgeMax { get; set; }

        public decimal Value { get; set; }

        [Display(Name = "Unit Type")]
        public int UnitType { get; set; }
    }
}