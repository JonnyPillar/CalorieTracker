using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Calorie_Tracker.DAL;
using Calorie_Tracker.Utilities;

namespace Calorie_Tracker.Controllers.User.Account
{
    public class RegisterController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /Register/

        /// <summary>
        /// Get Login View
        /// </summary>
        /// <returns>Return Register View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        /// <summary>
        /// Post Register User
        /// </summary>
        /// <param name="user">Register User</param>
        /// <returns>Action</returns>
        [HttpPost]
        public ActionResult Index(DAL.tbl_user user)
        {
            if (ModelState.IsValid)
            {
                tbl_user existingUser = db.tbl_user.FirstOrDefault(tbl_user => tbl_user.user_email == user.user_email);
                if (existingUser == null)
                {
                    UserController uController = new UserController();
                    uController.Create(user);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "This Email Address Has Been Used");
            }
            else ModelState.AddModelError("", "Login data is incorrect!");
            return View(user);
        }
    }
}
