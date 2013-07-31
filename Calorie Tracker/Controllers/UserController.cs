using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calorie_Tracker.DAL;
using Calorie_Tracker.Utilities;

namespace Calorie_Tracker.Controllers
{ 
    public class UserController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /User/

        public ViewResult Index()
        {
            List<tbl_user> userList = new List<tbl_user>();
            foreach(tbl_user user in db.tbl_user.ToList()) //TODO find a more efficent method of doing this!
            {
                user.user_creation_date = DateDisplay.parseDate(user.user_creation_date);
                user.user_dob = DateDisplay.parseDOB(user.user_dob);
                userList.Add(user);
            }
            return View(userList);
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(string id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            return View(tbl_user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(tbl_user.user_id)) tbl_user.user_id = Guid.NewGuid().ToString();
                tbl_user.user_password_hash = string.Empty;
                db.tbl_user.Add(tbl_user);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tbl_user);
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(string id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            return View(tbl_user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_user);
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(string id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            return View(tbl_user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {            
            tbl_user tbl_user = db.tbl_user.Find(id);
            db.tbl_user.Remove(tbl_user);
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