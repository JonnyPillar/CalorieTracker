using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Utils.Weka.ARFF;

namespace CalorieTracker.Controllers.Dashboard
{
    public class SummaryController : Controller
    {
        //
        // GET: /Summary/
        /// <summary>
        ///     Summary Choice View
        /// </summary>
        /// <returns>Summary Choice View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            var db = new CalorieTrackerEntities();
            var arffGenerator = new ARFFGenerator("User Data", db.Users.ToList());
            arffGenerator.GenerateFile();
            return View();
        }

        /// <summary>
        ///     User Defiencies
        /// </summary>
        /// <returns>User Defiencies View</returns>
        [HttpGet]
        public ActionResult Deficiencies()
        {
            return View();
        }

        /// <summary>
        ///     User Overloads
        /// </summary>
        /// <returns>User Overloads View</returns>
        [HttpGet]
        public ActionResult Overloads()
        {
            return View();
        }

        /// <summary>
        ///     User Health Issues
        /// </summary>
        /// <returns>Health Isses View</returns>
        [HttpGet]
        public ActionResult HealthIssues()
        {
            return View();
        }
    }
}