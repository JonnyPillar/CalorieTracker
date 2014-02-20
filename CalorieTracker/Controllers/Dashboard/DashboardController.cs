using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using CalorieTracker.Models;
using CalorieTracker.Models.ViewModels;
using CalorieTracker.Utils.Account;
using CalorieTracker.Utils.RDA;

namespace CalorieTracker.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        private readonly CalorieTrackerEntities db = new CalorieTrackerEntities();
        //
        // GET: /Dashboard/

        /// <summary>
        ///     View Users Info
        /// </summary>
        /// <returns>Dashboard View</returns>
        [HttpGet]
        public ActionResult Index(string id)
        {
            //Check Logged In
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            int userID = IdentityUtil.GetUserIDFromCookie(User);
            User dashboardUser = db.Users.FirstOrDefault(user => user.UserID == userID);

            if (dashboardUser == null)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }

            List<Nutrient> nutrientEnumerable = db.Nutrients.ToList();

            List<UserNutrientRDAModel> userNutrientRDAModels = new List<UserNutrientRDAModel>();
            

            foreach (var nutrient in nutrientEnumerable)
            {
                RDAUtil rdaUtil = new RDAUtil(dashboardUser, nutrient, new TimeSpan(30, 00, 00 ,00));
                UserNutrientRDAModel nutrientRDAModel =  new UserNutrientRDAModel(rdaUtil);
                if (nutrientRDAModel.UserNutrientRDA != null)
                {
                    userNutrientRDAModels.Add(nutrientRDAModel);
                }
                
            }


            var dashboardModel = new DashboardModel(!string.IsNullOrEmpty(id), dashboardUser, userNutrientRDAModels);
            return View(dashboardModel);
        }
    }
}