using System.Collections.Generic;
using CalorieTracker.Utils.Chart;

namespace CalorieTracker.Models.ViewModels
{
    public class NutrientModel
    {
        public NutrientModel(Nutrient nutrient, ChartUtil nutrientRDADataList)
        {
            ChartName = "_" + nutrient.Name + "Chart";
            Nutrient = nutrient;
            NutrientRDAChartUtil = nutrientRDADataList;
        }

        public string ChartName { get; set; }

        public Nutrient Nutrient { get; set; }

        public ChartUtil NutrientRDAChartUtil { get; set; }
    }
}