using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Calorie_Tracker.DAL;
using Calorie_Tracker.Utilities;

namespace Calorie_Tracker.Controllers
{
    public class LoginController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /Login/

        /// <summary>
        /// Index View
        /// </summary>
        /// <returns>Index View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get Login View
        /// </summary>
        /// <returns>Return Register View</returns>
        [HttpGet]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View("~/Views/Login/Register.cshtml");
        }

        /// <summary>
        /// Post Register User
        /// </summary>
        /// <param name="user">Register User</param>
        /// <returns>Action</returns>
        [HttpPost]
        public ActionResult Register(DAL.tbl_user user)
        {
            tbl_user existingUser = db.tbl_user.FirstOrDefault(tbl_user => tbl_user.user_email == user.user_email);
            if (existingUser == null)
            {
                user.user_id = Guid.NewGuid().ToString(); // ID will be null
                PasswordHasher hasher = new PasswordHasher(user.user_password);
                user.user_password_hash = hasher.PasswordHash;
                user.user_password_salt = hasher.PasswordSalt;
                user.user_creation_date = DateTime.Now.ToString("ddMMyyyyHHmmss");
                db.tbl_user.Add(user);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(user.user_email, true); //TODO Does it need to be true?
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Login data is incorrect!");
            return View(user);
        }

        /// <summary>
        /// Get Login View
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        /// <summary>
        /// Post Login User
        /// </summary>
        /// <param name="user">User Details From View</param>
        /// <returns>Action</returns>
        [HttpPost]
        public ActionResult Login(DAL.tbl_user user)
        {
            tbl_user existingUser = db.tbl_user.FirstOrDefault(tbl_user => tbl_user.user_email == user.user_email);
            if (existingUser != null)
            {
                if(PasswordHasher.IsPasswordValid(existingUser.user_password_hash, existingUser.user_password_salt, user.user_password))
                {
                    //Password Valid
                    FormsAuthentication.SetAuthCookie(user.user_email, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "User Name Or Password is incorrect!");
            return View(user);
        }

        /// <summary>
        /// Logout User
        /// </summary>
        /// <returns>Actionn</returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
