using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.ViewModels;
namespace CalorieTracker.Controllers
{
    public class LogController : Controller
    {
        calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        //
        // GET: /Log/

        [HttpGet]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) RedirectToAction("Logon", "Accounts");

            LogModel foodLogModel = new LogModel(db.tbl_activity.ToList(), GetUserFood());
            //foodLogModel.CurrentUser = db.tbl_user.Find(User.Identity.Name);
            return View(foodLogModel);
        }

        [HttpPost]
        public ActionResult Food(LogFoodModel logModel)
        {
            logModel.UserID = User.Identity.Name;
            tbl_food_log newLog = new tbl_food_log(logModel);
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

        private List<tbl_food> GetUserFood()
        {
            List<tbl_food> foodList = db.tbl_food.ToList();
            Dictionary<string, tbl_food> usedFoodList = new Dictionary<string, tbl_food>();
            List<tbl_food_log> foodLog = db.tbl_food_log
                .Where(tbl_food_log => tbl_food_log.food_log_user_id == User.Identity.Name)
                .ToList();
            for (int i = 0; i < foodLog.Count; i++) //TODO Improve this
            {
                if (!usedFoodList.ContainsKey(foodLog[i].food_log_food_id))
                {
                    for (int j = 0; j < foodList.Count; j++)
                    {
                        if (foodLog[i].food_log_food_id.Equals(foodList[j].food_id))
                        {
                            usedFoodList.Add(foodList[j].food_id, foodList[j]);
                            break;
                        }
                    }
                }
            }
            return usedFoodList.Values.ToList();
        }
    }
}
