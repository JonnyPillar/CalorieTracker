using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.ViewModels;
using System.Web.Helpers;

namespace CalorieTracker.Controllers
{
    public class DashboardController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        private  List<tbl_user_information> userInfoList = new List<tbl_user_information>();
        private  List<tbl_user_metric> metricList = new List<tbl_user_metric>();
        private  IEnumerable<tbl_activity_log> activityLogList;
        private tbl_user user = new tbl_user();
        ModelServices mobjModel = new ModelServices();

        //
        // GET: /Dashboard/

        public ActionResult Index(int page = 1, string sort = "food_name", string sortDir = "ASC")
        {
            if (!User.Identity.IsAuthenticated) RedirectToAction("Login", "Accounts");

            //TODO Improve!!! and move SQL Excution out
            activityLogList = user.tbl_activity_log.ToList();
            metricList = db.tbl_user_metric.ToList();
            foreach (tbl_user_metric item in metricList)
            {
                var query = "SELECT * FROM tbl_user_information WHERE user_information_metric_id = ? ORDER BY SUBSTR(user_information_timestamp,5,4) DESC, SUBSTR(user_information_timestamp,3,2) DESC, SUBSTR(user_information_timestamp,1,2) DESC, SUBSTR(user_information_timestamp,9,2) DESC, SUBSTR(user_information_timestamp,11,2) DESC";
                tbl_user_information temp = db.tbl_user_information.SqlQuery(query, item.user_metric_id).First();
                if (temp != null) userInfoList.Add(temp);
            }


            user = db.tbl_user.Find(User.Identity.Name);
            const int pageSize = 10;
            int totalRows = mobjModel.CountCustomer();
            bool dir = sortDir.Equals("desc", StringComparison.CurrentCultureIgnoreCase) ? true : false;
            IEnumerable<tbl_food_log> foodLogList = mobjModel.GetFoodLogPage(page, pageSize, sort, dir);
            var data = new PagedFoodList()
            {
                TotalRows = totalRows,
                PageSize = pageSize,
                Customer = foodLogList
            };
            DashboardModel model = new DashboardModel(user, userInfoList, data);
            return View(model);
        }

        public ActionResult Test(int page = 1, string sort = "food_name", string sortDir = "ASC")
        {
            user = db.tbl_user.Find(User.Identity.Name);
            const int pageSize = 10;
            int totalRows = mobjModel.CountCustomer();
            bool dir = sortDir.Equals("desc", StringComparison.CurrentCultureIgnoreCase) ? true : false;
            IEnumerable<tbl_food_log> foodLogList = mobjModel.GetFoodLogPage(page, pageSize, sort, dir);
            var data = new PagedFoodList()
            {
                TotalRows = totalRows,
                PageSize = pageSize,
                Customer = foodLogList
            };
            DashboardModel model = new DashboardModel(user, userInfoList, data); 
          if (Request.IsAjaxRequest())
            {
                return PartialView("_partialviewname", model.pagedList);
             }
          return View(model);

        }
    }
}
