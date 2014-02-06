using System.Web.Mvc;

namespace CalorieTracker.Controllers.Log.Metric
{
    public class MetricController : Controller
    {
        //
        // GET: /Metric/
        /// <summary>
        ///     View Metrics
        /// </summary>
        /// <returns>Metric View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Metric/Details/5
        /// <summary>
        ///     Metric Details
        /// </summary>
        /// <param name="id">Metric ID</param>
        /// <returns>Metric Detail View</returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Metric/Create
        /// <summary>
        ///     Create New Metric
        /// </summary>
        /// <returns>New Metric View</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Metric/Create
        /// <summary>
        ///     new Meetric Post Back
        /// </summary>
        /// <param name="collection">Metric Form</param>
        /// <returns>Metric Info</returns>
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
        // GET: /Metric/Edit/5
        /// <summary>
        ///     Edit Metric
        /// </summary>
        /// <param name="id">Metric ID</param>
        /// <returns>Metric Edit View</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Metric/Edit/5
        /// <summary>
        ///     Metric Edit Postback
        /// </summary>
        /// <param name="id">Metric ID</param>
        /// <param name="collection">Metric Form</param>
        /// <returns>Metric Info View</returns>
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
        // GET: /Metric/Delete/5
        /// <summary>
        ///     Delete Metric
        /// </summary>
        /// <param name="id">Metric ID</param>
        /// <returns>Delete Metric Confirmation View</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Metric/Delete/5
        /// <summary>
        ///     Delete Metric
        /// </summary>
        /// <param name="id">Metric ID</param>
        /// <param name="collection">Metric Delete Form</param>
        /// <returns></returns>
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