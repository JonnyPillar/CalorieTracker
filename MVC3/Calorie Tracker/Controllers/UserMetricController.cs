using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calorie_Tracker.DAL;

namespace Calorie_Tracker.Controllers
{ 
    public class UserMetricController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /UserMetric/

        public ViewResult Index()
        {
            return View(db.tbl_user_metric.ToList());
        }

        //
        // GET: /UserMetric/Details/5

        public ViewResult Details(string id)
        {
            tbl_user_metric tbl_user_metric = db.tbl_user_metric.Find(id);
            return View(tbl_user_metric);
        }

        //
        // GET: /UserMetric/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /UserMetric/Create

        [HttpPost]
        public ActionResult Create(tbl_user_metric tbl_user_metric)
        {
            if (ModelState.IsValid)
            {
                tbl_user_metric.user_metric_id = Guid.NewGuid().ToString();
                db.tbl_user_metric.Add(tbl_user_metric);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tbl_user_metric);
        }
        
        //
        // GET: /UserMetric/Edit/5
 
        public ActionResult Edit(string id)
        {
            tbl_user_metric tbl_user_metric = db.tbl_user_metric.Find(id);
            return View(tbl_user_metric);
        }

        //
        // POST: /UserMetric/Edit/5

        [HttpPost]
        public ActionResult Edit(tbl_user_metric tbl_user_metric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user_metric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_user_metric);
        }

        //
        // GET: /UserMetric/Delete/5
 
        public ActionResult Delete(string id)
        {
            tbl_user_metric tbl_user_metric = db.tbl_user_metric.Find(id);
            return View(tbl_user_metric);
        }

        //
        // POST: /UserMetric/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            tbl_user_metric tbl_user_metric = db.tbl_user_metric.Find(id);
            db.tbl_user_metric.Remove(tbl_user_metric);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}