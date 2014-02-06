using System.Web.Mvc;

namespace CalorieTracker.Controllers.User
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/

        /// <summary>
        ///     Register New User View
        /// </summary>
        /// <returns>Login View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///     Register New User Post Back
        /// </summary>
        /// <param name="formCollection">New User Form</param>
        /// <returns>Action</returns>
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            return View();
        }
    }
}