using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using CalorieTracker.Models;
using CalorieTracker.Models.Accounts;
using CalorieTracker.Utilities;
using CalorieTracker.Models.Accounts;
namespace CalorieTracker.Controllers
{
    public class AccountsController : Controller
    {
        calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /Accounts/
        /// <summary>
        /// Account Get
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
            }
            return View("Login");
        }

        /// <summary>
        /// Login Get
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Login Post
        /// </summary>
        /// <param name="loginModel">Login Model</param>
        /// <returns>Result</returns>
        [HttpPost]
        public ActionResult Login(UserContext.LoginModel loginModel)
        {
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

        /// <summary>
        /// Register Get
        /// </summary>
        /// <returns>Register View</returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register Post
        /// </summary>
        /// <param name="registerModel">Register Model</param>
        /// <returns>Result</returns>
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
                    db.tbl_user.Add(newUser); //TODO Through inheritance can  just add here?
                    db.SaveChanges();
                    FormsAuthentication.SetAuthCookie(newUser.user_id, true);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "This Email Address Has Been Used");
            }
            return View(registerModel);
        }

        /// <summary>
        /// Logoff Action
        /// </summary>
        /// <returns>Redirect Routing</returns>
        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
