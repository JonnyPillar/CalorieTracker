using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using PagedList;

namespace CalorieTracker.Controllers.Activitys
{
    public class ActivityController : Controller
    {
        private readonly CalorieTrackerEntities db = new CalorieTrackerEntities();

        // GET: /Activity/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Account");
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

            if (searchString != null)  page = 1;
            else searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            IQueryable<Activity> activities = from a in db.Activities select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                activities = activities.Where(
                    a =>
                        a.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            if (string.IsNullOrEmpty(sortOrder))
            {
                activities = activities.OrderBy(a => a.Name);
            }
            else if (sortOrder.Equals("Name_desc"))
            {
                activities = activities.OrderByDescending(a => a.Name);
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(activities.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Activity/Details/5
        public ActionResult Details(int? id)
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
        public ActionResult Edit(int? id)
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
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int? id)
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