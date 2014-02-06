using System.Web.Mvc;

namespace CalorieTracker.Controllers.Dashboard
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        /// <summary>
        ///     View Users Info
        /// </summary>
        /// <returns>Dashboard View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            //Check Logged In
            return View();
        }

        ///// <summary>
        /////     View Users Info
        ///// </summary>
        ///// <returns>Dashboard View</returns>
        //[HttpGet]
        //public ActionResult Index(int newUserID)
        //{
        //    //Check Logged In
        //    return View();
        //}
    }
}