using System.Collections.Generic;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogModel
    {
        [HiddenInput(DisplayValue = false)]
        public LogActivityModel logActivity { get; set; }
        [HiddenInput(DisplayValue = false)]
        public LogFoodModel logFood { get; set; }
        [HiddenInput(DisplayValue = false)]
        public LogUserInformationModel logMetric { get; set; }
        [HiddenInput(DisplayValue = false)]
        public LogStatModel logStat { get; set; }

        /// <summary>
        /// Log Model Constructor
        /// </summary>
        /// <param name="activityList">List of Activities</param>
        /// <param name="foodList">List of Foods</param>
        /// <param name="metricList">List of Metrics</param>
        public LogModel(List<tbl_activity> activityList, List<tbl_food> foodList, List<tbl_user_metric> metricList, double todayEaten, double todayBurned)
        {
            logActivity = new LogActivityModel(activityList);
            logFood = new LogFoodModel(foodList);
            logMetric = new LogUserInformationModel(metricList);
            logStat = new LogStatModel(todayBurned, todayEaten);
        }
    }
}