using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers
{
    public class ActivityController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();
        //
        // GET: /Activity/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Activity/Details/5

        public ActionResult Details(string id)
        {
            tbl_food_log log = db.tbl_food_log.Find(id);
            if (log != null)
            {
                return View(log);
            }
            return View(log);
        }

        //
        // GET: /Activity/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Activity/Create

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

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Activity/Edit/5

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

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Activity/Delete/5

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
