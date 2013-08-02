using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Calorie_Tracker.DAL;

namespace Calorie_Tracker.Controllers.User.Account
{
    public class RegisterController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

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

        [HttpPost]
        public ActionResult Register(DAL.tbl_user user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.user_password))
                {
                    if (string.IsNullOrEmpty(user.user_id)) user.user_id = Guid.NewGuid().ToString();
                    user.user_password_hash = string.Empty;
                    db.tbl_user.Add(user);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(user.user_email, true); //TODO Does it need to be true?
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(user);
        }
    }
}
