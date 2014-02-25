﻿using System;
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
        public ActionResult Index(string id, int? timeSpan)
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
<<<<<<< HEAD
            List<Nutrient> nutrientEnumerable = db.Nutrients.ToList(); //Get List of all nutrients
            var rdaList = new List<NutrientRDA>();
=======
>>>>>>> b5d70df00a32dfe3b1e1300e323d364f084db9c8

            int timespanInt = 0;
            if (timeSpan != null)
            {
                timespanInt = timeSpan.GetValueOrDefault();
            }
            else timespanInt = 30;
            var dashboardModel = new DashboardModel(!string.IsNullOrEmpty(id), dashboardUser);
            dashboardModel.NutritionTimespan = timespanInt;

            return View(dashboardModel);
        }

        [HttpGet]
        public ActionResult GetUserRDAChart(int? id)
        {
            var userNutrientRDAModels = new List<UserNutrientRDAModel>();
            int timespanInt = 30;
            if (id != null) timespanInt = id.GetValueOrDefault();

<<<<<<< HEAD
=======
            
            var dashboardModel = new DashboardModel(!string.IsNullOrEmpty(id), dashboardUser);
            dashboardModel.NutritionTimespan = timespanInt;

            return View(dashboardModel);
        }

        
        public ActionResult GetUserRDAChart(int? timespan)
        {
            var userNutrientRDAModels = new List<UserNutrientRDAModel>();
            int timespanInt = 30;
            if (timespan != null) timespanInt = timespan.GetValueOrDefault();

>>>>>>> b5d70df00a32dfe3b1e1300e323d364f084db9c8
            int userID = IdentityUtil.GetUserIDFromCookie(User);
            if (userID != -1)
            {
                User user = db.Users.Find(userID);
                if (user != null)
                {
                    List<Nutrient> nutrientEnumerable = db.Nutrients.ToList(); //Get List of all nutrients
<<<<<<< HEAD
                    //List of all the Nutrients RDA's
=======
                     //List of all the Nutrients RDA's
>>>>>>> b5d70df00a32dfe3b1e1300e323d364f084db9c8
                    foreach (Nutrient nutrient in nutrientEnumerable)
                    {
                        RDAUtil rdaUtil = null;
                        rdaUtil = new RDAUtil(user, nutrient, new TimeSpan(timespanInt, 00, 00, 00));
                        var nutrientRDAModel = new UserNutrientRDAModel(rdaUtil);
                        if (nutrientRDAModel.UserNutrientRDA != null)
                        {
                            userNutrientRDAModels.Add(nutrientRDAModel);
                        }
                    }
                }
            }
            return PartialView("PartialViews/_UserNutrition", userNutrientRDAModels);
        }
    }
}