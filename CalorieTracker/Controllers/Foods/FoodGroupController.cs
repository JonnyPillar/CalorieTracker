using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers.Foods
{
    public class FoodGroupController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();

        // GET: /FoodGroup/
        public ActionResult Index()
        {
            return View(db.FoodGroups.ToList());
        }

        // GET: /FoodGroup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            FoodGroup foodgroup = db.FoodGroups.Find(id);
            if (foodgroup == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(foodgroup);
        }

        // GET: /FoodGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FoodGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodGroupID,Name,SourceID")] FoodGroup foodgroup)
        {
            if (ModelState.IsValid)
            {
                db.FoodGroups.Add(foodgroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodgroup);
        }

        // GET: /FoodGroup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            FoodGroup foodgroup = db.FoodGroups.Find(id);
            if (foodgroup == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(foodgroup);
        }

        // POST: /FoodGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodGroupID,Name,SourceID")] FoodGroup foodgroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodgroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodgroup);
        }

        // GET: /FoodGroup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            FoodGroup foodgroup = db.FoodGroups.Find(id);
            if (foodgroup == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(foodgroup);
        }

        // POST: /FoodGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodGroup foodgroup = db.FoodGroups.Find(id);
            db.FoodGroups.Remove(foodgroup);
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