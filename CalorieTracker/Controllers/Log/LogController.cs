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

        public ActionResult History(int? page)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");

            int userID = IdentityUtil.GetUserIDFromCookie(User);

            User user = db.Users.Find(userID);

            HistoryGeneratorUtil historyGenerator = new HistoryGeneratorUtil(user);
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(historyGenerator.Test.ToPagedList(pageNumber, pageSize));
        }
    }
}