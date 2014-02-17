using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Utils.Account;

namespace CalorieTracker.Controllers.Log
{
    public class LogController : Controller
    {
        private readonly CalorieTrackerEntities db = new CalorieTrackerEntities();

        //
        // GET: /Log/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            return View();
        }

        public ActionResult History()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");

            int userID = IdentityUtil.GetUserIDFromCookie(User);

            User user = db.Users.Find(userID);

            return View();
        }
    }
}