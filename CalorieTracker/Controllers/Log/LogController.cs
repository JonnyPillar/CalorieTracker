using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Utils.Account;
using CalorieTracker.Utils.History;
using PagedList;

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
            return View();
        }

        [HttpGet]
        public ActionResult GetUserHistory(int? id)
        {
            int userID = IdentityUtil.GetUserIDFromCookie(User);
            User user = db.Users.Find(userID);
            var historyGenerator = new HistoryGeneratorUtil(user);
            int pageSize = 20;
            int pageNumber = (id ?? 1);
            return PartialView("Partial/_HistoryView", historyGenerator.Test.ToPagedList(pageNumber, pageSize));
        }
    }
}