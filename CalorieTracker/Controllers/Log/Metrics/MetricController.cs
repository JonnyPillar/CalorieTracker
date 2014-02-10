using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers.Log.Metrics
{
    public class MetricController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();

        // GET: /Metric/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            return View(db.Metrics.ToList());
        }

        // GET: /Metric/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // GET: /Metric/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Metric/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MetricID,Name,Type")] Metric metric)
        {
            if (ModelState.IsValid)
            {
                db.Metrics.Add(metric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metric);
        }

        // GET: /Metric/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // POST: /Metric/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MetricID,Name,Type")] Metric metric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // GET: /Metric/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // POST: /Metric/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Metric metric = db.Metrics.Find(id);
            db.Metrics.Remove(metric);
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