using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.ViewModels;

namespace CalorieTracker.Controllers
{
    public class DashboardController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Accounts");
            tbl_user user = db.tbl_user.Find(User.Identity.Name);
            //TODO Improve!!! and move SQL Excution out
            List<tbl_user_information> userInfoList = new List<tbl_user_information>();
            List<tbl_user_metric> metricList = db.tbl_user_metric.ToList();
            foreach (tbl_user_metric item in metricList)
            {
                var query = "SELECT * FROM tbl_user_information WHERE user_information_metric_id = ? ORDER BY SUBSTR(user_information_timestamp,5,4) DESC, SUBSTR(user_information_timestamp,3,2) DESC, SUBSTR(user_information_timestamp,1,2) DESC, SUBSTR(user_information_timestamp,9,2) DESC, SUBSTR(user_information_timestamp,11,2) DESC";
                tbl_user_information temp = db.tbl_user_information.SqlQuery(query, item.user_metric_id).First();
                if (temp != null) userInfoList.Add(temp);
            }
            DashboardModel model = new DashboardModel(user, userInfoList);
            return View(model);
        }
    }
}
