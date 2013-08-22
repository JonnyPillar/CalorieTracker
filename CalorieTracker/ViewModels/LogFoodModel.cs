using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogFoodModel
    {
        public IEnumerable<tbl_food> FoodList { get; set; }
        public string selectedFood { get; set; }

        public LogFoodModel( List<tbl_food> foodList)
        {
            FoodList = foodList;
        }
    }
}