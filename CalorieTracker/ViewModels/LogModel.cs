using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogModel
    {
        public LogActivityModel logActivity { get; set; }
        public LogFoodModel logFood { get; set; }
        public LogUserInformationModel logMetric { get; set; }

        public LogModel(List<tbl_activity> activityList, List<tbl_food> foodList, List<tbl_user_metric> metricList)
        {
            logActivity = new LogActivityModel(activityList);
            logFood = new LogFoodModel(foodList);
            logMetric = new LogUserInformationModel(metricList);
        }
    }
}