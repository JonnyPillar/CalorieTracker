//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CTDataGenerator.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Food
    {
        public Food()
        {
            this.FoodLogs = new HashSet<FoodLog>();
            this.FoodNutrients = new HashSet<FoodNutrientLog>();
        }
    
        public int FoodID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Name { get; set; }
        public int SourceID { get; set; }
        public int GroupID { get; set; }
        public string Description { get; set; }
        public string ManufacturerName { get; set; }
    
        public virtual ICollection<FoodLog> FoodLogs { get; set; }
        public virtual FoodGroup FoodGroup { get; set; }
        public virtual ICollection<FoodNutrientLog> FoodNutrients { get; set; }
    }
}
