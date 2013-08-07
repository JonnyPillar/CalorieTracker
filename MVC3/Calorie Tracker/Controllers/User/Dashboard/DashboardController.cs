using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calorie_Tracker.DAL;

namespace Calorie_Tracker.Controllers.User.Dashboard
{
    public class DashboardController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            tbl_user user = db.tbl_user.First(tbl_user => tbl_user.user_email == User.Identity.Name);
            return View(user);
        }
    }
}
