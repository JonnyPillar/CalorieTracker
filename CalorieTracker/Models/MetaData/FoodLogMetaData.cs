using System;
using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Models.MetaData
{
    public class FoodLogMetaData
    {
        [ScaffoldColumn(false)]
        public string FoodLogID { get; set; }
        [Required]
        public int FoodID { get; set; }

        [ScaffoldColumn(false)]
        public int UserID { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Quantity { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreationTimestamp { get; set; }
    }
}