using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models.Accounts;
using CalorieTracker.Utilities;
using System.Web.Security;
using CalorieTracker.Models;
using System.IO;
using System;

namespace CalorieTracker.Controllers
{
    public class AccountsController : Controller
    {
        calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        //
        // GET: /Accounts/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserContext.LoginModel loginModel)
        {
            // If we got this far, something failed, redisplay form
            if (ModelState.IsValid)
            {
                tbl_user existingUser = db.tbl_user.First(tbl_user => tbl_user.user_email == loginModel.user_email_address);
                if (existingUser != null)
                {
                    if (PasswordHasher.IsPasswordValid(existingUser.user_password_hash, existingUser.user_password_salt, loginModel.user_password))
                    {
                        //Password Valid
                        FormsAuthentication.SetAuthCookie(existingUser.user_id, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(loginModel);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserContext.RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                //Does user email already exist
                tbl_user existingUser = db.tbl_user.FirstOrDefault(tbl_user => tbl_user.user_email == registerModel.user_email);
                if (existingUser == null)
                {
                    tbl_user newUser = new tbl_user(registerModel);
                    if (string.IsNullOrWhiteSpace(newUser.user_profile_image))
                    {
                        string baseFolder = AppDomain.CurrentDomain.BaseDirectory + "/Uploads/User/Profile";
                        if (!Directory.Exists(baseFolder)) Directory.CreateDirectory(baseFolder);
                        newUser.user_profile_image = baseFolder + "default.jpeg";
                    }
                    db.tbl_user.Add(newUser);
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(newUser.user_id, true);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "This Email Address Has Been Used");
            }
            return View(registerModel);
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
