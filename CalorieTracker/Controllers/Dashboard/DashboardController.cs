﻿using System.Web.Mvc;

namespace CalorieTracker.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        /// <summary>
        ///     View Users Info
        /// </summary>
        /// <returns>Dashboard View</returns>
        public ActionResult Index()
        {
            //Check Logged In
            return View();
        }
    }
}