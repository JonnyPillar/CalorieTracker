using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalorieTracker.Controllers.Log.Metric
{
    public class MetricController : Controller
    {
        //
        // GET: /Metric/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Metric/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Metric/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Metric/Create
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Metric/Edit/5
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Metric/Delete/5
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
