//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nutrient
    {
        public Nutrient()
        {
            this.FoodNutritionLogs = new HashSet<FoodNutritionLogs>();
            this.tbl_nutrient_rda = new HashSet<NutrientRDA>();
        }
    
        public int NutrientID { get; set; }
        public int SourceID { get; set; }
        public int UnitType { get; set; }
        public string Name { get; set; }
        public int DecimalRounding { get; set; }
    
        public virtual ICollection<FoodNutritionLogs> FoodNutritionLogs { get; set; }
        public virtual ICollection<NutrientRDA> tbl_nutrient_rda { get; set; }
    }
}
