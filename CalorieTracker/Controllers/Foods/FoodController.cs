using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers.Foods
{
    public class FoodController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();

        // GET: /Food/
        public ActionResult Index()
        {
            IQueryable<Food> foods = db.Foods.Include(f => f.FoodGroup);
            return View(foods.ToList());
        }

        // GET: /Food/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // GET: /Food/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name");
            return View();
        }

        // POST: /Food/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "FoodID,SourceID,ParentID,GroupID,Name,Description,ManufactureName")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.GroupID);
            return View(food);
        }

        // GET: /Food/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.GroupID);
            return View(food);
        }

        // POST: /Food/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "FoodID,SourceID,ParentID,GroupID,Name,Description,ManufactureName")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.FoodGroups, "FoodGroupID", "Name", food.GroupID);
            return View(food);
        }

        // GET: /Food/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        // POST: /Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
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