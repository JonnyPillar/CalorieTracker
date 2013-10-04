using System;
using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;
using System.Data;

namespace CalorieTracker.Collections
{
    public class DashboardHistoryList
    {
        public Dictionary<DateTime, List<DashboardHistoryListItem>> HistoryList;
        private DateTime RecordedDate;
        
        /// <summary>
        /// New Dashboard History List
        /// </summary>
        public DashboardHistoryList()
        {
            HistoryList = new Dictionary<DateTime, List<DashboardHistoryListItem>>();
        }

        /// <summary>
        /// Add Food Item To History List
        /// </summary>
        /// <param name="item">Food Log Item</param>
        public void Add(tbl_food_log item)
        {
            InsertItem(new DashboardHistoryListItem(item));
        }

        /// <summary>
        /// Add Activity To History List
        /// </summary>
        /// <param name="item">Activity Log</param>
        public void Add(tbl_activity_log item)
        {
            InsertItem(new DashboardHistoryListItem(item));
        }

        /// <summary>
        /// Add User Information To History List
        /// </summary>
        /// <param name="item">User Information</param>
        public void Add(tbl_user_metric_log item)
        {
            InsertItem(new DashboardHistoryListItem(item));
        }

        /// <summary>
        /// Insert List Item
        /// </summary>
        /// <param name="item">Dashboard History Item</param>
        private void InsertItem(DashboardHistoryListItem item)
        {
            if (HistoryList.ContainsKey(item.Date)) HistoryList[item.Date].Add(item);
            else HistoryList.Add(item.Date, new List<DashboardHistoryListItem>() { item }); //Create new List
        }

        /// <summary>
        /// Order Dictionary To Date Order
        /// </summary>
        public void OrderDate()
        {
            HistoryList = HistoryList.OrderByDescending(i => i.Key).ToDictionary(x => x.Key, x => x.Value); // TODO make more efficent
        }

        /// <summary>
        /// Crop History Set To Required Set
        /// </summary>
        /// <param name="number">Required Set Size</param>
        public void CropSet(int number)
        {
            HistoryList = HistoryList.Take(number).ToDictionary(item => item.Key, item => item.Value); 
        }
    }
}