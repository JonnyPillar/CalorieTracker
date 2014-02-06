using System.Web.Mvc;

namespace CalorieTracker.Controllers.Dashboard
{
    public class ReviewController : Controller
    {
        //
        // GET: /Review/
        /// <summary>
        ///     Latest User Review Day
        /// </summary>
        /// <returns>Review Choice View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Day Review
        /// </summary>
        /// <returns>Day Review View</returns>
        public ActionResult Day()
        {
            return View();
        }

        /// <summary>
        ///     Dat Review
        /// </summary>
        /// <param name="dayNumber">Day Number of Year</param>
        /// <returns>Day Review View</returns>
        public ActionResult Day(int dayNumber)
        {
            return View();
        }

        /// <summary>
        ///     Weej Review
        /// </summary>
        /// <returns>Week Review View</returns>
        public ActionResult Week()
        {
            return View();
        }

        /// <summary>
        ///     Week Review
        /// </summary>
        /// <param name="weekNumber">Week Number</param>
        /// <returns>Week Review View</returns>
        public ActionResult Week(int weekNumber)
        {
            return View();
        }

        /// <summary>
        ///     Year Review
        /// </summary>
        /// <returns>Year Review View</returns>
        public ActionResult Year()
        {
            return View();
        }

        /// <summary>
        ///     Year Review
        /// </summary>
        /// <param name="yearNumber">Year</param>
        /// <returns>Year Review View</returns>
        public ActionResult Year(int yearNumber)
        {
            return View();
        }
    }
}