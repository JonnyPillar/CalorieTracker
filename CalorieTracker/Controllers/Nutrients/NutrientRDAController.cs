using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers.Nutrients
{
    public class NutrientRDAController : Controller
    {
        private CalorieTrackerEntities db = new CalorieTrackerEntities();

        // GET: /NutrientRDA/
        public ActionResult Index()
        {
            var nutrientrdas = db.NutrientRDAs.Include(n => n.Nutrient);
            return View(nutrientrdas.ToList());
        }

        // GET: /NutrientRDA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutrientRDA nutrientrda = db.NutrientRDAs.Find(id);
            if (nutrientrda == null)
            {
                return HttpNotFound();
            }
            return View(nutrientrda);
        }

        // GET: /NutrientRDA/Create
        public ActionResult Create()
        {
            ViewBag.NutrientID = new SelectList(db.Nutrients, "NutrientID", "Name");
            return View();
        }

        // POST: /NutrientRDA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="NutrientRdaID,NutrientID,Gender,AgeMax,AgeMin,Value,UnitType")] NutrientRDA nutrientrda)
        {
            if (ModelState.IsValid)
            {
                db.NutrientRDAs.Add(nutrientrda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NutrientID = new SelectList(db.Nutrients, "NutrientID", "Name", nutrientrda.NutrientID);
            return View(nutrientrda);
        }

        // GET: /NutrientRDA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutrientRDA nutrientrda = db.NutrientRDAs.Find(id);
            if (nutrientrda == null)
            {
                return HttpNotFound();
            }
            ViewBag.NutrientID = new SelectList(db.Nutrients, "NutrientID", "Name", nutrientrda.NutrientID);
            return View(nutrientrda);
        }

        // POST: /NutrientRDA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="NutrientRdaID,NutrientID,Gender,AgeMax,AgeMin,Value,UnitType")] NutrientRDA nutrientrda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nutrientrda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NutrientID = new SelectList(db.Nutrients, "NutrientID", "Name", nutrientrda.NutrientID);
            return View(nutrientrda);
        }

        // GET: /NutrientRDA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NutrientRDA nutrientrda = db.NutrientRDAs.Find(id);
            if (nutrientrda == null)
            {
                return HttpNotFound();
            }
            return View(nutrientrda);
        }

        // POST: /NutrientRDA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NutrientRDA nutrientrda = db.NutrientRDAs.Find(id);
            db.NutrientRDAs.Remove(nutrientrda);
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
