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
            DashboardModel model = new DashboardModel(user);
            return View(model);
        }
    }
}
