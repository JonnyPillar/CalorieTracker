using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers.Log.Activitys
{
    public class ActivityController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();

        // GET: /Activity/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            return View(db.Activities.ToList());
        }

        // GET: /Activity/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: /Activity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Activity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityID,Name,CalorieBurnRate,ImageUrl")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        // GET: /Activity/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // POST: /Activity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityID,Name,CalorieBurnRate,ImageUrl")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // GET: /Activity/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        // POST: /Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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