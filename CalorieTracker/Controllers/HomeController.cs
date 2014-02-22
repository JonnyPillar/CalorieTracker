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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}