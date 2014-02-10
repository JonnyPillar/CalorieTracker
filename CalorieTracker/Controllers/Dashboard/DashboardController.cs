using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using CalorieTracker.Models;
using CalorieTracker.Models.ViewModels;
using CalorieTracker.Utils.Account;
using Microsoft.Ajax.Utilities;

namespace CalorieTracker.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();
        //
        // GET: /Dashboard/

        /// <summary>
        ///     View Users Info
        /// </summary>
        /// <returns>Dashboard View</returns>
        [HttpGet]
        public ActionResult Index(string id)
        {
            //Check Logged In
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            int userID = IdentityUtil.GetUserIDFromCookie(User);
            User dashboardUser = db.Users.FirstOrDefault(user => user.UserID == userID);

            if (dashboardUser == null)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            var dashboardModel = new DashboardModel(id.IsNullOrWhiteSpace(), dashboardUser);
            return View(dashboardModel);
        }
    }
}