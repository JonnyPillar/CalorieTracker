using System.Web.Mvc;

namespace CalorieTracker.Controllers.Log.Activity
{
    public class ActivityController : Controller
    {
        //
        // GET: /Activity/
        /// <summary>
        ///     All activities view
        /// </summary>
        /// <returns>Activity List View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Activity/Details/5

        /// <summary>
        ///     View Details of Activity
        /// </summary>
        /// <param name="id">Activity ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Activity/Create
        /// <summary>
        ///     Add New Activity
        /// </summary>
        /// <returns>Add Activity View</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Activity/Create
        /// <summary>
        ///     Create New Activity Post Back
        /// </summary>
        /// <param name="collection">Activity Form</param>
        /// <returns>Activity Information View</returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Activity/Edit/5
        /// <summary>
        ///     Edit Activity
        /// </summary>
        /// <param name="id">Activity ID</param>
        /// <returns>Activity Edit View</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Activity/Edit/5
        /// <summary>
        ///     Edit Activity Post Back
        /// </summary>
        /// <param name="id">Activity ID</param>
        /// <param name="collection">Activity Edit Form</param>
        /// <returns>Activity Info Page</returns>
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Activity/Delete/5

        /// <summary>
        ///     Delete Activity Confirmation Page
        /// </summary>
        /// <param name="id">Activity ID</param>
        /// <returns>Delete Activity Confirmation Page</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Activity/Delete/5
        /// <summary>
        ///     Delete Activity Post Back
        /// </summary>
        /// <param name="id">Activity ID</param>
        /// <param name="collection">Activity Form</param>
        /// <returns>Activity List View</returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}