using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogFoodModel
    {
        [Display(Name = "Food")]
        public IEnumerable<tbl_food> FoodList { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public string SelectedFood { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserID { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Please Provide A Valid Quantity")]
        [Range(0, 10000, ErrorMessage = "Value must be between 0 and 10000")]
        public string Quantity { get; set; }

        /// <summary>
        /// Log Food Model Constructor
        /// </summary>
        public LogFoodModel()
        {

        }

        /// <summary>
        /// Log Food Model Constructor
        /// </summary>
        /// <param name="foodList">List of Foods</param>
        public LogFoodModel(List<tbl_food> foodList)
        {
            FoodList = foodList;
        }
    }
}