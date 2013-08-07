using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calorie_Tracker.DAL;
using Calorie_Tracker.Connection;

namespace Calorie_Tracker.Controllers
{ 
    public class UserInformationController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /UserInformationn/

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home"); //Return if user is not logged in
            tbl_user existingUser = db.tbl_user.First(tbl_user => tbl_user.user_email == User.Identity.Name); //Get Logged In User ID
            var tbl_user_information = db.tbl_user_information.Include(t => t.tbl_user).Where(t => t.tbl_user.user_id == existingUser.user_id).Include(t => t.tbl_user_metric); //Get Info and Metrics based on User ID
            return View(tbl_user_information.ToList());
        }

        //
        // GET: /UserInformation/Details/5

        public ViewResult Details(string id)
        {
            tbl_user_information tbl_user_information = db.tbl_user_information.Find(id);
            return View(tbl_user_information);
        }

        //
        // GET: /UserInformation/Create

        public ActionResult Create()
        {
            //ViewBag.user_information_user_id = new SelectList(db.tbl_user, "user_id", "user_email");
            ViewBag.user_information_metric_id = new SelectList(db.tbl_user_metric, "user_metric_id", "user_metric_name");
            return View();
        } 

        //
        // POST: /UserInformation/Create

        [HttpPost]
        public ActionResult Create(tbl_user_information tbl_user_information)
        {
            if (ModelState.IsValid)
            {
                db.tbl_user_information.Add(tbl_user_information);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.user_information_user_id = new SelectList(db.tbl_user, "user_id", "user_email", tbl_user_information.user_information_user_id);
            ViewBag.user_information_metric_id = new SelectList(db.tbl_user_metric, "user_metric_id", "user_metric_name", tbl_user_information.user_information_metric_id);
            return View(tbl_user_information);
        }
        
        //
        // GET: /UserInformation/Edit/5
 
        public ActionResult Edit(string id)
        {
            tbl_user_information tbl_user_information = db.tbl_user_information.Find(id);
            ViewBag.user_information_user_id = new SelectList(db.tbl_user, "user_id", "user_email", tbl_user_information.user_information_user_id);
            ViewBag.user_information_metric_id = new SelectList(db.tbl_user_metric, "user_metric_id", "user_metric_name", tbl_user_information.user_information_metric_id);
            return View(tbl_user_information);
        }

        //
        // POST: /UserInformation/Edit/5

        [HttpPost]
        public ActionResult Edit(tbl_user_information tbl_user_information)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user_information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_information_user_id = new SelectList(db.tbl_user, "user_id", "user_email", tbl_user_information.user_information_user_id);
            ViewBag.user_information_metric_id = new SelectList(db.tbl_user_metric, "user_metric_id", "user_metric_name", tbl_user_information.user_information_metric_id);
            return View(tbl_user_information);
        }

        //
        // GET: /UserInformation/Delete/5
 
        public ActionResult Delete(string id)
        {
            tbl_user_information tbl_user_information = db.tbl_user_information.Find(id);
            return View(tbl_user_information);
        }

        //
        // POST: /UserInformation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            tbl_user_information tbl_user_information = db.tbl_user_information.Find(id);
            db.tbl_user_information.Remove(tbl_user_information);
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