using System;
using CalorieTracker.Models;

namespace CalorieTracker.Collections
{
    public class DashboardHistoryListItem
    {
        public tbl_food_log FoodLog { get; set; }
        public tbl_activity_log ActivityLog { get; set; }
        public tbl_user_information UserInformation { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Create Dashboard History Item
        /// </summary>
        public DashboardHistoryListItem()
        {
            FoodLog = new tbl_food_log();
            ActivityLog = new tbl_activity_log();
            UserInformation = new tbl_user_information();
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
            Date = GetDate(item.food_log_date);
        }

        /// <summary>
        /// Create Dashboard History Item From Activity Log
        /// </summary>
        /// <param name="item">Activity Log</param>
        public DashboardHistoryListItem(tbl_activity_log item)
        {
            ActivityLog = item;
            Name = item.tbl_activity.activity_name;
            Date = GetDate(item.actvitity_log_date);
        }

        /// <summary>
        /// Create Dashboard History Item From User Information
        /// </summary>
        /// <param name="item">User Information</param>
        public DashboardHistoryListItem(tbl_user_information item)
        {
            UserInformation = item;
            Name = item.tbl_user_metric.user_metric_name;
            Date = GetDate(item.user_information_timestamp);
        }

        /// <summary>
        /// Parse Timestamp To Createed Date 
        /// </summary>
        /// <param name="date">Timestamp</param>
        /// <returns>Date DateTime</returns>
        private DateTime GetDate(string date)
        {
            DateTime loggedDate = DateTime.ParseExact(date, "ddMMyyyyHHmmss", null);
            return new DateTime(loggedDate.Year, loggedDate.Month, loggedDate.Day);
        }
    }
}