using System;
using CalorieTracker.Models;

namespace CalorieTracker.Collections
{
    public class DashboardHistoryListItem
    {
        public tbl_food_log FoodLog { get; set; }
        public tbl_activity_log ActivityLog { get; set; }
        public tbl_user_metric_log UserInformation { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Create Dashboard History Item
        /// </summary>
        public DashboardHistoryListItem()
        {
            FoodLog = new tbl_food_log();
            ActivityLog = new tbl_activity_log();
            UserInformation = new tbl_user_metric_log();
            Name = string.Empty;
            Date = new DateTime();
        }

        /// <summary>
        /// Create Dashboard History Item From Food Log
        /// </summary>
        /// <param name="item">Food Log</param>
        public DashboardHistoryListItem(tbl_food_log item)
        {
            FoodLog = item;
            Name = item.tbl_food.food_name;
            Date = item.food_log_timestamp;
        }

        /// <summary>
        /// Create Dashboard History Item From Activity Log
        /// </summary>
        /// <param name="item">Activity Log</param>
        public DashboardHistoryListItem(tbl_activity_log item)
        {
            ActivityLog = item;
            Name = item.tbl_activity.activity_name;
            Date = item.actvitity_log_timestamp;
        }

        /// <summary>
        /// Create Dashboard History Item From User Information
        /// </summary>
        /// <param name="item">User Information</param>
        public DashboardHistoryListItem(tbl_user_metric_log item)
        {
            UserInformation = item;
            Name = item.tbl_user_metric.user_metric_name;
            Date = item.user_metric_log_timestamp;
        }
    }
}