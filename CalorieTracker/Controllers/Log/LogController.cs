using System.Web.Mvc;

namespace CalorieTracker.Controllers.Log
{
    public class LogController : Controller
    {
        //
        // GET: /Log/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            return View();
        }

        public ActionResult Food()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            return View();
        }

        public ActionResult Activity()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            return View();
        }

        public ActionResult Metric()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            return View();
        }
    }
}