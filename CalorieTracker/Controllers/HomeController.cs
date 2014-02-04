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
            tbl_user temp = new tbl_user();
            temp.user_gender = 0;
            temp.user_creation_timestamp = DateTime.UtcNow;
            temp.user_admin = 0;
            temp.user_password_hash = "";
            temp.user_password_salt = "";

            //temp.

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