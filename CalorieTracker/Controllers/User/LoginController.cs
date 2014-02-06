using System.Web.Mvc;

namespace CalorieTracker.Controllers.User
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        /// <summary>
        ///     Login User View
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Login User Post Back
        /// </summary>
        /// <param name="formCollection">User Login Form</param>
        /// <returns>Login View</returns>
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            return View();
        }
    }
}