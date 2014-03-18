using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using ikvm.extensions;
using PagedList;

namespace CalorieTracker.Controllers.Foods
{
    public class FoodController : Controller
    {
        private readonly CalorieTrackerEntities db = new CalorieTrackerEntities();

        // GET: /Food/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.DescSortParm = sortOrder == "Description" ? "Description_desc" : "Description";
            ViewBag.FoodGroupSortParm = sortOrder == "FoodGroup" ? "FoodGroup_desc" : "FoodGroup";

            if (searchString != null)
            {
                page = 1;
                searchString = searchString.trim();
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            IQueryable<Food> foods = db.Foods.Include(f => f.FoodGroup);

            if (!string.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(
                    f =>
                        f.Name.ToUpper().Contains(searchString.ToUpper()) ||
                        f.Description.ToUpper().Contains(searchString.ToUpper()) ||
                        f.ManufactureName.ToUpper().Contains(searchString.ToUpper()));
            }

            if (string.IsNullOrEmpty(sortOrder))
            {
                foods = foods.OrderBy(f => f.Name);
            }
            else if (sortOrder.Equals("Name_desc"))
            {
                foods = foods.OrderByDescending(f => f.Name);
            }
            else if (sortOrder.Equals("Description"))
            {
                foods = foods.OrderBy(f => f.Description);
            }
            else if (sortOrder.Equals("Description_desc"))
            {
                foods = foods.OrderByDescending(f => f.Description);
            }
            else if (sortOrder.Equals("FoodGroup"))
            {
                foods = foods.OrderBy(f => f.FoodGroup.Name);
            }
            else if (sortOrder.Equals("FoodGroup_desc"))
            {
                foods = foods.OrderByDescending(f => f.FoodGroup.Name);
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(foods.ToPagedList(pageNumber, pageSize));
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