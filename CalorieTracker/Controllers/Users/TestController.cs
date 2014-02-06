﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using CalorieTracker.Models;

//namespace CalorieTracker.Controllers.User
//{
//    public class TestController : Controller
//    {
//        private CTDBContainer db = new CTDBContainer();

//        // GET: /Test/
//        public ActionResult Index()
//        {
//            return View(db.Users.ToList());
//        }

//        // GET: /Test/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // GET: /Test/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: /Test/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include="user_id,user_dob,user_gender,user_password_hash,user_password_salt,user_admin,user_creation_timestamp,user_activity_level_type,user_personality_type")] User user)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Users.Add(user);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(user);
//        }

//        // GET: /Test/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: /Test/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include="user_id,user_dob,user_gender,user_password_hash,user_password_salt,user_admin,user_creation_timestamp,user_activity_level_type,user_personality_type")] User user)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(user).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(user);
//        }

//        // GET: /Test/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = db.Users.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: /Test/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            User user = db.Users.Find(id);
//            db.Users.Remove(user);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
