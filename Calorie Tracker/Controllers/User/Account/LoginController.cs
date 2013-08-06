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
        /// Get Login View
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public ActionResult Index()
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
        public ActionResult Index(DAL.tbl_user user)
        {
            tbl_user existingUser = db.tbl_user.FirstOrDefault(tbl_user => tbl_user.user_email == user.user_email);
            if (existingUser != null)
            {
                if (PasswordHasher.IsPasswordValid(existingUser.user_password_hash, existingUser.user_password_salt, user.user_password))
                {
                    //Password Valid
                    FormsAuthentication.SetAuthCookie(existingUser.user_email, true);
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
