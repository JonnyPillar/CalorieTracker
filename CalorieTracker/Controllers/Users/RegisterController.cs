using System.Web.Mvc;
using System.Web.Security;
using CalorieTracker.Models;
using CalorieTracker.Models.ViewModels;
using CalorieTracker.Utils.Account;

namespace CalorieTracker.Controllers.Users
{
    public class RegisterController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();
        //
        // GET: /Register/

        /// <summary>
        ///     Register New User View
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityUtil.AuthenticUser(User)) return RedirectToAction("Index", "Dashboard");
            return View();
        }

        /// <summary>
        ///     Register New User Post Back
        /// </summary>
        /// <param name="registerModel">New User Form</param>
        /// <returns>Action</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterModel registerModel)
        {
            if (SecurityUtil.AuthenticUser(User)) return RedirectToAction("Index", "Dashboard");
            if (ModelState.IsValid)
            {
                var user = new User(registerModel);
                db.Users.Add(user);
                db.SaveChanges();

                //Password Valid
                FormsAuthentication.SetAuthCookie(user.UserID.ToString(), true);
                return RedirectToAction("Index", "Dashboard", new {id = user.UserID});
                    //TODO Updatedashboard to react to this id being passed
            }
            return View(registerModel);
        }
    }
}