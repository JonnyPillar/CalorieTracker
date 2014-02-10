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
    }
}