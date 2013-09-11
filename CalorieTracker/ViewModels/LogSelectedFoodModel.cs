using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.ViewModels
{
    public class LogSelectedFoodModel
    {
        [Display(Name = "Food")]
        public tbl_food Food { get; set; }

        [HiddenInput]
        public string SelectedFood { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Please Provide A Valid Quantity")]
        [Range(0, 10000, ErrorMessage = "Value must be between 0 and 10000")]
        public double Quantity { get; set; }

        [HiddenInput]
        public string UserID { get; set; }

        public LogSelectedFoodModel()
        {
        }

        public LogSelectedFoodModel(tbl_food food)
        {
            Food = food;
            SelectedFood = food.food_id;
        }
    }
}