using System;
using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Collections;
using CalorieTracker.Models;

namespace CalorieTracker.Utilities
{
    public class LogUtil
    {
        /// <summary>
        /// Get users history and merge into one feed ordered by Date
        /// </summary>
        /// <param name="user">User to Retreive</param>
        /// <param name="dayAmount">Amount of Days to Show. -1 Equals All</param>
        /// <returns>Date Ordered Dictionary or User History</returns>
        public static DashboardHistoryList GetUserHistory(tbl_user user, int dayAmount)
        {
            DashboardHistoryList historyDictionary = new DashboardHistoryList();
            foreach (tbl_food_log item in user.tbl_food_log) //Add all foods to history disctionn
            {
                historyDictionary.Add(item);
            }
            foreach (tbl_activity_log item in user.tbl_activity_log) //Add all Activities to history dictionary
            {
                historyDictionary.Add(item);
            }
            foreach (tbl_user_information item in user.tbl_user_information)
            {
                historyDictionary.Add(item);
            }
            historyDictionary.OrderDate();
            if (dayAmount == -1) return historyDictionary;
            else
            {
                historyDictionary.CropSet(dayAmount); //Return the set amount of days
                return historyDictionary;
            }
        }

        /// <summary>
        /// Get users history and merge into one feed ordered by Date
        /// </summary>
        /// <param name="user">User to Retreive</param>
        /// <param name="dayAmount">Amount of Days to Show. -1 Equals All</param>
        /// <returns>Date Ordered Dictionary or User History</returns>
        //public static Dictionary<DateTime, List<object>> getUserHistory(tbl_user user, int dayAmount)
        //{
        //    Dictionary<DateTime, List<object>> historyDictionary = new Dictionary<DateTime, List<object>>();
        //    foreach (tbl_food_log item in user.tbl_food_log) //Add all foods to history disctionn
        //    {
        //        DateTime loggedDate = DateTime.ParseExact(item.food_log_date, "ddMMyyyyHHmmss", null);
        //        DateTime recordedDate = new DateTime(loggedDate.Year, loggedDate.Month, loggedDate.Day);
        //        if (historyDictionary.ContainsKey(recordedDate)) historyDictionary[recordedDate].Add(item); //If exists add to existing list
        //        else historyDictionary.Add(recordedDate, new List<object>() { item }); //Create new List
        //    }
        //    foreach (tbl_activity_log item in user.tbl_activity_log) //Add all Activities to history dictionary
        //    {
        //        DateTime loggedDate = DateTime.ParseExact(item.actvitity_log_date, "ddMMyyyyHHmmss", null);
        //        DateTime recordedDate = new DateTime(loggedDate.Year, loggedDate.Month, loggedDate.Day);
        //        if (historyDictionary.ContainsKey(recordedDate)) historyDictionary[recordedDate].Add(item); //If exists add to existing list
        //        else historyDictionary.Add(recordedDate, new List<object>() { item }); //Create new List
        //    }
        //    foreach (tbl_user_information item in user.tbl_user_information)
        //    {
        //        DateTime loggedDate = DateTime.ParseExact(item.user_information_timestamp, "ddMMyyyyHHmmss", null);
        //        DateTime recordedDate = new DateTime(loggedDate.Year, loggedDate.Month, loggedDate.Day);
        //        if (historyDictionary.ContainsKey(recordedDate)) historyDictionary[recordedDate].Add(item); //If exists add to existing list
        //        else historyDictionary.Add(recordedDate, new List<object>() { item }); //Create new List
        //    }
        //    historyDictionary = historyDictionary.OrderByDescending(i => i.Key).ToDictionary(x => x.Key, x => x.Value); // TODO make more efficent
        //    if (dayAmount == -1) return historyDictionary;
        //    else return historyDictionary.Take(dayAmount).ToDictionary(item => item.Key, item => item.Value); //Return the set amount of days
        //}
    }
}