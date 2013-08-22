using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogModel
    {
        public tbl_user User { get; set; }
        public LogActivityModel logActivity { get; set; }
        public LogFoodModel logFood { get; set; }

        public LogModel(List<tbl_activity> activityList, List<tbl_food> foodList)
        {
            logActivity = new LogActivityModel(activityList);
            logFood = new LogFoodModel(foodList);
        }
    }
}