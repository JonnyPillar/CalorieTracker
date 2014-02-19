namespace CalorieTracker.Models.ViewModels
{
    public class UserNutrientRDAModel
    {
        public UserNutrientRDAModel(Nutrient nutrient, decimal nutrientRDAValue, decimal nutrientRDAPercentage)
        {
            UserNutrient1 = nutrient;
            NutrientRDAValue1 = nutrientRDAValue;
            NutrientRDAPercentage = nutrientRDAPercentage;
        }

        public Nutrient UserNutrient1 { get; set; }

        public decimal NutrientRDAValue1 { get; set; }

        public decimal NutrientRDAPercentage { get; set; }
    }
}