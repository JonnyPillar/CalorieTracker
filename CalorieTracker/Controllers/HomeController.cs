using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models;
using WebGrease;

namespace CalorieTracker.Controllers
{
    public class HomeController : Controller
    {
        //private calo
        public ActionResult Index()
        {
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}