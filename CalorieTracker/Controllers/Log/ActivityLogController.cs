using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Models.ModelBinders;
using CalorieTracker.Utils.Account;

namespace CalorieTracker.Controllers.Log
{
    public class ActivityLogController : Controller
    {
        private readonly CalorieTrackerEntities db = new CalorieTrackerEntities();

        // GET: /ActivityLog/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            int currentUserID = IdentityUtil.GetUserIDFromCookie(User);
            IQueryable<ActivityLog> activitylogs =
                db.ActivityLogs.Include(a => a.Activity).Include(a => a.User).Where(a => a.User.UserID == currentUserID);
            return View(activitylogs.ToList());
        }

        // GET: /ActivityLog/Details/5
        public ActionResult Details(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            if (id == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ActivityLog activitylog = db.ActivityLogs.Find(id);
            if (activitylog == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View(activitylog);
        }

        // GET: /ActivityLog/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        // POST: /ActivityLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [ModelBinder(typeof(ActivityLogModelBinder))][Bind(
                Include =
                    "ActivityLogID,ActivityID,UserID,StartDate,Duration,Distance,Title,Accent,HeartRate,Notes,FileURL")] ActivityLog activitylog)
        {
            if (ModelState.IsValid)
            {
                db.ActivityLogs.Add(activitylog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "Name", activitylog.ActivityID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", activitylog.UserID);
            return View(activitylog);
        }

        // GET: /ActivityLog/Edit/5
        public ActionResult Edit(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            if (id == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ActivityLog activitylog = db.ActivityLogs.Find(id);
            if (activitylog == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "Name", activitylog.ActivityID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", activitylog.UserID);
            return View(activitylog);
        }

        // POST: /ActivityLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include =
                    "ActivityLogID,ActivityID,UserID,StartDate,Duration,Distance,Title,Accent,HeartRate,Notes,FileURL")] ActivityLog activitylog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activitylog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityID = new SelectList(db.Activities, "ActivityID", "Name", activitylog.ActivityID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", activitylog.UserID);
            return View(activitylog);
        }

        // GET: /ActivityLog/Delete/5
        public ActionResult Delete(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            if (id == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ActivityLog activitylog = db.ActivityLogs.Find(id);
            if (activitylog == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View(activitylog);
        }

        // POST: /ActivityLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ActivityLog activitylog = db.ActivityLogs.Find(id);
            db.ActivityLogs.Remove(activitylog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}