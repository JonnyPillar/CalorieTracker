using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calorie_Tracker.DAL;
using Calorie_Tracker.Utilities;
using System.Web.Security;

namespace Calorie_Tracker.Controllers
{ 
    public class UserController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(db.tbl_user.ToList());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(string id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            return View(tbl_user);
        }

        /// <summary>
        /// User Log In
        /// </summary>
        /// <param name="email">Entered Email Address</param>
        /// <param name="password">Entered Password</param>
        /// <returns></returns>
        public ActionResult Details(string email, string password)
        {
            tbl_user existingUser = db.tbl_user.FirstOrDefault(tbl_user => tbl_user.user_email == email);
            if (existingUser != null)
            {
                if (PasswordHasher.IsPasswordValid(existingUser.user_password_hash, existingUser.user_password_salt, password))
                {
                    //Password Valid
                    FormsAuthentication.SetAuthCookie(email, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "User Name Or Password is incorrect!");
            return View();
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
                PasswordHasher hasher = new PasswordHasher(tbl_user.user_password);
                tbl_user.user_password_hash = hasher.PasswordHash;
                tbl_user.user_password_salt = hasher.PasswordSalt;
                tbl_user.user_creation_date = DateTime.Now.ToString("ddMMyyyyHHmmss");
                db.tbl_user.Add(tbl_user);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(tbl_user.user_email, true); //TODO Does it need to be true?
            }
            else ModelState.AddModelError("", "Login data is incorrect Model!");
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