using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers
{
    public class UserInformationController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        //
        // GET: /UserInformation/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /UserInformation/Details/5

        public ActionResult Details(string id)
        {
            tbl_user_information log = db.tbl_user_information.Find(id);
            if (log != null)
            {
                return View(log);
            }
            return View(log);
        }

        //
        // GET: /UserInformation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserInformation/Create

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
        // GET: /UserInformation/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UserInformation/Edit/5

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
        // GET: /UserInformation/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UserInformation/Delete/5

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
