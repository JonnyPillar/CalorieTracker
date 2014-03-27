using System.Web.Mvc;

namespace CalorieTracker.Controllers
{
    public class HomeController : Controller
    {
        //private calo
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Dashboard");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}