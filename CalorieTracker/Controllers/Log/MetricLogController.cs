using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Utils.Account;

namespace CalorieTracker.Controllers.Log
{
    public class MetricLogController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();

        // GET: /MetricLog/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            int currentUserID = IdentityUtil.GetUserIDFromCookie(User);
            IQueryable<MetricLog> metriclogs =
                db.MetricLogs.Include(m => m.Metric).Include(m => m.User).Where(m => m.User.UserID == currentUserID);
            return View(metriclogs.ToList());
        }

        // GET: /MetricLog/Details/5
        public ActionResult Details(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            if (id == null)
            {
                return RedirectToAction("Index", "Account");
            }
            MetricLog metriclog = db.MetricLogs.Find(id);
            if (metriclog == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View(metriclog);
        }

        // GET: /MetricLog/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            ViewBag.MetricID = new SelectList(db.Metrics, "MetricID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        // POST: /MetricLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "MetricLogID,UserID,MetricID,Value,CreationTimestamp")] MetricLog metriclog)
        {
            if (ModelState.IsValid)
            {
                metriclog.MetricLogID = Guid.NewGuid().ToString();
                db.MetricLogs.Add(metriclog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MetricID = new SelectList(db.Metrics, "MetricID", "Name", metriclog.MetricID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", metriclog.UserID);
            return View(metriclog);
        }

        // GET: /MetricLog/Edit/5
        public ActionResult Edit(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            if (id == null)
            {
                return RedirectToAction("Index", "Account");
            }
            MetricLog metriclog = db.MetricLogs.Find(id);
            if (metriclog == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.MetricID = new SelectList(db.Metrics, "MetricID", "Name", metriclog.MetricID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", metriclog.UserID);
            return View(metriclog);
        }

        // POST: /MetricLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "MetricLogID,UserID,MetricID,Value,CreationTimestamp")] MetricLog metriclog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metriclog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MetricID = new SelectList(db.Metrics, "MetricID", "Name", metriclog.MetricID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", metriclog.UserID);
            return View(metriclog);
        }

        // GET: /MetricLog/Delete/5
        public ActionResult Delete(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            if (id == null)
            {
                return RedirectToAction("Index", "Account");
            }
            MetricLog metriclog = db.MetricLogs.Find(id);
            if (metriclog == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View(metriclog);
        }

        // POST: /MetricLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MetricLog metriclog = db.MetricLogs.Find(id);
            db.MetricLogs.Remove(metriclog);
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