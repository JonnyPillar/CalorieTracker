using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calorie_Tracker.Controllers.User.Account
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Register(Models.User user)
        //{
        //    if (ModelState.IsValid)
        //    {

        //    }
        //}
    }
}
