using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Test(tbl_user user)
        {
            return View("index");
        }

        public ActionResult htmlTest(tbl_user user)
        {
            return View("index");
        }
    }
}
