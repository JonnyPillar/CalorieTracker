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
        public string SelectedFood { get; set; }
        public string UserID { get; set; }
        public string Quantity { get; set; }

        public LogFoodModel()
        {

        }

        public LogFoodModel(List<tbl_food> foodList)
        {
            FoodList = foodList;
        }
    }
}