using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using CalorieTracker.Models;
using CalorieTracker.Models.ViewModels;
using CalorieTracker.Utils.Account;

namespace CalorieTracker.Controllers.Users
{
    public class LoginController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();
        //
        // GET: /Login/

        /// <summary>
        ///     Login User View
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityUtil.AuthenticUser(User)) return RedirectToAction("Index", "Dashboard");
            return View();
        }

        /// <summary>
        ///     Login User Post Back
        /// </summary>
        /// <param name="loginModel">User Login Form</param>
        /// <returns>Login View</returns>
        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            if (SecurityUtil.AuthenticUser(User)) return RedirectToAction("Index", "Dashboard");
            if (ModelState.IsValid)
            {
                User existingUser = db.Users.First(user => user.UserID == loginModel.UserID);
                if (existingUser != null)
                {
                    if (SecurityUtil.IsPasswordValid(existingUser, loginModel.Password))
                    {
                        //Password Valid
                        FormsAuthentication.SetAuthCookie(existingUser.UserID.ToString(), true);
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View();
        }
    }
}