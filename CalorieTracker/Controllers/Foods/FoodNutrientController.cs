using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers.Foods
{
    public class FoodNutrientController : Controller
    {
        private CalorieTrackerEntities db = new CalorieTrackerEntities();

        // GET: /FoodNutrient/
        public ActionResult Index()
        {
            var foodnutritionlogs = db.FoodNutritionLogs.Include(f => f.Food).Include(f => f.Nutrient);
            return View(foodnutritionlogs.ToList());
        }

        // GET: /FoodNutrient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodNutritionLogs foodnutritionlogs = db.FoodNutritionLogs.Find(id);
            if (foodnutritionlogs == null)
            {
                return HttpNotFound();
            }
            return View(foodnutritionlogs);
        }

        // GET: /FoodNutrient/Create
        public ActionResult Create()
        {
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name");
            ViewBag.NurtientID = new SelectList(db.Nutrients, "NutrientID", "Name");
            return View();
        }

        // POST: /FoodNutrient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="NurtientLogID,FoodID,NurtientID,Value")] FoodNutritionLogs foodnutritionlogs)
        {
            if (ModelState.IsValid)
            {
                db.FoodNutritionLogs.Add(foodnutritionlogs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name", foodnutritionlogs.FoodID);
            ViewBag.NurtientID = new SelectList(db.Nutrients, "NutrientID", "Name", foodnutritionlogs.NurtientID);
            return View(foodnutritionlogs);
        }

        // GET: /FoodNutrient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodNutritionLogs foodnutritionlogs = db.FoodNutritionLogs.Find(id);
            if (foodnutritionlogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name", foodnutritionlogs.FoodID);
            ViewBag.NurtientID = new SelectList(db.Nutrients, "NutrientID", "Name", foodnutritionlogs.NurtientID);
            return View(foodnutritionlogs);
        }

        // POST: /FoodNutrient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NurtientLogID,FoodID,NurtientID,Value")] FoodNutritionLogs foodnutritionlogs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodnutritionlogs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name", foodnutritionlogs.FoodID);
            ViewBag.NurtientID = new SelectList(db.Nutrients, "NutrientID", "Name", foodnutritionlogs.NurtientID);
            return View(foodnutritionlogs);
        }

        // GET: /FoodNutrient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodNutritionLogs foodnutritionlogs = db.FoodNutritionLogs.Find(id);
            if (foodnutritionlogs == null)
            {
                return HttpNotFound();
            }
            return View(foodnutritionlogs);
        }

        // POST: /FoodNutrient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodNutritionLogs foodnutritionlogs = db.FoodNutritionLogs.Find(id);
            db.FoodNutritionLogs.Remove(foodnutritionlogs);
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
