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
    public class UserTargerController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /UserTarger/

        public ViewResult Index()
        {
            var tbl_user_target = db.tbl_user_target.Include(t => t.tbl_user).Include(t => t.tbl_user_metric).Include(t => t.tbl_user_target2);
            return View(tbl_user_target.ToList());
        }

        //
        // GET: /UserTarger/Details/5

        public ViewResult Details(string id)
        {
            tbl_user_target tbl_user_target = db.tbl_user_target.Find(id);
            return View(tbl_user_target);
        }

        //
        // GET: /UserTarger/Create

        public ActionResult Create()
        {
            ViewBag.user_target_user_id = new SelectList(db.tbl_user, "user_id", "user_email");
            ViewBag.user_target_metric_id = new SelectList(db.tbl_user_metric, "user_metric_id", "user_metric_name");
            ViewBag.user_target_parent_id = new SelectList(db.tbl_user_target, "user_target_id", "user_target_user_id");
            return View();
        } 

        //
        // POST: /UserTarger/Create

        [HttpPost]
        public ActionResult Create(tbl_user_target tbl_user_target)
        {
            if (ModelState.IsValid)
            {
                db.tbl_user_target.Add(tbl_user_target);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.user_target_user_id = new SelectList(db.tbl_user, "user_id", "user_email", tbl_user_target.user_target_user_id);
            ViewBag.user_target_metric_id = new SelectList(db.tbl_user_metric, "user_metric_id", "user_metric_name", tbl_user_target.user_target_metric_id);
            ViewBag.user_target_parent_id = new SelectList(db.tbl_user_target, "user_target_id", "user_target_user_id", tbl_user_target.user_target_parent_id);
            return View(tbl_user_target);
        }
        
        //
        // GET: /UserTarger/Edit/5
 
        public ActionResult Edit(string id)
        {
            tbl_user_target tbl_user_target = db.tbl_user_target.Find(id);
            ViewBag.user_target_user_id = new SelectList(db.tbl_user, "user_id", "user_email", tbl_user_target.user_target_user_id);
            ViewBag.user_target_metric_id = new SelectList(db.tbl_user_metric, "user_metric_id", "user_metric_name", tbl_user_target.user_target_metric_id);
            ViewBag.user_target_parent_id = new SelectList(db.tbl_user_target, "user_target_id", "user_target_user_id", tbl_user_target.user_target_parent_id);
            return View(tbl_user_target);
        }

        //
        // POST: /UserTarger/Edit/5

        [HttpPost]
        public ActionResult Edit(tbl_user_target tbl_user_target)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user_target).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_target_user_id = new SelectList(db.tbl_user, "user_id", "user_email", tbl_user_target.user_target_user_id);
            ViewBag.user_target_metric_id = new SelectList(db.tbl_user_metric, "user_metric_id", "user_metric_name", tbl_user_target.user_target_metric_id);
            ViewBag.user_target_parent_id = new SelectList(db.tbl_user_target, "user_target_id", "user_target_user_id", tbl_user_target.user_target_parent_id);
            return View(tbl_user_target);
        }

        //
        // GET: /UserTarger/Delete/5
 
        public ActionResult Delete(string id)
        {
            tbl_user_target tbl_user_target = db.tbl_user_target.Find(id);
            return View(tbl_user_target);
        }

        //
        // POST: /UserTarger/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            tbl_user_target tbl_user_target = db.tbl_user_target.Find(id);
            db.tbl_user_target.Remove(tbl_user_target);
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