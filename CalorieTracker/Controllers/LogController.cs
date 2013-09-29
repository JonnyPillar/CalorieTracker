using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.ViewModels;
using CalorieTracker.Utilities;

namespace CalorieTracker.Controllers
{
    public class LogController : Controller
    {
        calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        private double todayCalorie = 0;
        //
        // GET: /Log/

        [HttpGet]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Logon", "Accounts");
            LogModel foodLogModel = new LogModel(db.tbl_activity.ToList(), GetUserFood(), db.tbl_user_metric.ToList(), todayCalorie, GetCalorieBurned());
            return View(foodLogModel);
        }

        [HttpPost]
        public ActionResult Food(LogSelectedFoodModel model)
        {
            model.UserID = User.Identity.Name;
            tbl_food_log newLog = new tbl_food_log(model);
            db.tbl_food_log.Add(newLog);
            db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }
        [HttpPost]
        public ActionResult Activity(LogActivityModel logModel)
        {
            logModel.UserID = User.Identity.Name;
            tbl_activity_log newLog = new tbl_activity_log(logModel);
            db.tbl_activity_log.Add(newLog);
            db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult Metric(LogUserInformationModel logModel)
        {
            logModel.UserID = User.Identity.Name;
            tbl_user_information newLog = new tbl_user_information(logModel);
            db.tbl_user_information.Add(newLog);
            db.SaveChanges();
            return RedirectToAction("Index", "Dashboard");
        }

        //
        // GET: /Log/History
        [HttpGet]
        public ActionResult History()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Logon", "Accounts");
            return View(LogUtil.GetUserHistory(db.tbl_user.Find(User.Identity.Name), -1));
        }



        /// <summary>
        /// Get Users Recent Foods
        /// </summary>
        /// <returns>List of Foods</returns>
        private List<tbl_food> GetUserFood()
        {
            //TODO you can food list from User Object
            Dictionary<string, tbl_food> usedFoodList = new Dictionary<string, tbl_food>();
            List<tbl_food_log> foodLog = db.tbl_food_log
                .Where(tbl_food_log => tbl_food_log.food_log_user_id == User.Identity.Name)
                .ToList();
            for (int i = 0; i < foodLog.Count; i++)
            {
                if (!usedFoodList.ContainsKey(foodLog[i].food_log_food_id)) usedFoodList.Add(foodLog[i].food_log_food_id, foodLog[i].tbl_food); //If we have not already added the food to the list
                if (DateTime.ParseExact(foodLog[i].food_log_date, "ddMMyyyyHHmmss", null).Date.CompareTo(DateTime.Now.Date) == 0)
                {
                    todayCalorie += (double)foodLog[i].tbl_food.food_calories * (double)foodLog[i].food_log_quantity;
                }
            }
            return usedFoodList.Values.ToList();
        }

        /// <summary>
        /// Get Users Calorie Burned
        /// </summary>
        /// <returns>Total Burned Today</returns>
        private double GetCalorieBurned()
        {
            double todayBurned = 0;
            List<tbl_activity_log> log = db.tbl_activity_log.Where(tbl_activity_log => tbl_activity_log.activity_log_user_id == User.Identity.Name).ToList();
            for (int i = 0; i < log.Count; i++)
            {
                if (DateTime.ParseExact(log[i].actvitity_log_date, "ddMMyyyyHHmmss", null).Date.CompareTo(DateTime.Now) == 0) todayBurned += (double)log[i].tbl_activity.activity_calorie_burn_rate * (double)log[i].activity_log_time;
            }
            return todayBurned;
        }
    }
}
