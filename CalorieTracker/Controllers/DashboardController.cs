using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.ViewModels;

namespace CalorieTracker.Controllers
{
    public class DashboardController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        private  List<tbl_user_information> userInfoList = new List<tbl_user_information>();
        private  List<tbl_user_metric> metricList = new List<tbl_user_metric>();
        private tbl_user user = new tbl_user();

        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Accounts");
            //TODO Improve!!! and move SQL Excution out
            user = db.tbl_user.Find(User.Identity.Name);
            metricList = db.tbl_user_metric.ToList();
            foreach (tbl_user_metric item in metricList)
            {
                var query = "SELECT * FROM tbl_user_information WHERE user_information_metric_id = ? ORDER BY SUBSTR(user_information_timestamp,5,4) DESC, SUBSTR(user_information_timestamp,3,2) DESC, SUBSTR(user_information_timestamp,1,2) DESC, SUBSTR(user_information_timestamp,9,2) DESC, SUBSTR(user_information_timestamp,11,2) DESC";
                tbl_user_information temp = db.tbl_user_information.SqlQuery(query, item.user_metric_id).First();
                if (temp != null) userInfoList.Add(temp);
            }
            DashboardModel model = new DashboardModel(user, userInfoList, getUserHistory());
            return View(model);
        }

        /// <summary>
        /// Get all users history and merge into one feed ordered by Date
        /// </summary>
        /// <returns>Date Ordered Dictionary or User History</returns>
        private Dictionary<DateTime, List<object>> getUserHistory()
        {
            Dictionary<DateTime, List<object>> historyDictionary = new Dictionary<DateTime, List<object>>();
            foreach (tbl_food_log item in user.tbl_food_log) //Add all foods to history disctionn
            {
                DateTime loggedDate = DateTime.ParseExact(item.food_log_date, "ddMMyyyyHHmmss", null);
                DateTime recordedDate = new DateTime(loggedDate.Year, loggedDate.Month, loggedDate.Day);
                if (historyDictionary.ContainsKey(recordedDate)) historyDictionary[recordedDate].Add(item); //If exists add to existing list
                else historyDictionary.Add(recordedDate, new List<object>() { item }); //Create new List
            }
            foreach (tbl_activity_log item in user.tbl_activity_log) //Add all Activities to history dictionary
            {
                DateTime loggedDate = DateTime.ParseExact(item.actvitity_log_date, "ddMMyyyyHHmmss", null);
                DateTime recordedDate = new DateTime(loggedDate.Year, loggedDate.Month, loggedDate.Day);
                if (historyDictionary.ContainsKey(recordedDate)) historyDictionary[recordedDate].Add(item); //If exists add to existing list
                else historyDictionary.Add(recordedDate, new List<object>() { item }); //Create new List
            }
            foreach (tbl_user_information item in user.tbl_user_information)
            {
                DateTime loggedDate = DateTime.ParseExact(item.user_information_timestamp, "ddMMyyyyHHmmss", null);
                DateTime recordedDate = new DateTime(loggedDate.Year, loggedDate.Month, loggedDate.Day);
                if (historyDictionary.ContainsKey(recordedDate)) historyDictionary[recordedDate].Add(item); //If exists add to existing list
                else historyDictionary.Add(recordedDate, new List<object>() { item }); //Create new List
            }
            historyDictionary = historyDictionary.OrderByDescending(i => i.Key).ToDictionary(x => x.Key, x => x.Value); // TODO make more efficent
            return historyDictionary;
        }
    }
}
