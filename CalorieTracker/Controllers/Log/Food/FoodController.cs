using System.Web.Mvc;

namespace CalorieTracker.Controllers.Log.Food
{
    public class FoodController : Controller
    {
        //
        // GET: /Food/
        /// <summary>
        ///     Get All Foods
        /// </summary>
        /// <returns>Food View List</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Food/Details/5
        /// <summary>
        ///     Get Details of a Food Item
        /// </summary>
        /// <param name="id">Food Item ID</param>
        /// <returns>Food Info View</returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Food/Create
        /// <summary>
        ///     Add New Food
        /// </summary>
        /// <returns>New Food View</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Food/Create
        /// <summary>
        ///     Add New Food From Form
        /// </summary>
        /// <param name="collection">Create Food Form</param>
        /// <returns>Food Info View</returns>
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
        // GET: /Food/Edit/5
        /// <summary>
        ///     Edit Food
        /// </summary>
        /// <param name="id">Food ID</param>
        /// <returns>Edit Food View</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Food/Edit/5
        /// <summary>
        ///     Edit Food Post
        /// </summary>
        /// <param name="id">Food ID</param>
        /// <param name="collection">Edit Food Form</param>
        /// <returns>Food Infomation View</returns>
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
        // GET: /Food/Delete/5

        /// <summary>
        ///     Delete Food Confirmation View
        /// </summary>
        /// <param name="id">Food ID</param>
        /// <returns>Food Confirmation View</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Food/Delete/5
        /// <summary>
        ///     Delete Food Post Back
        /// </summary>
        /// <param name="id">Food ID</param>
        /// <param name="collection">Food Delete Form</param>
        /// <returns>Food Index</returns>
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