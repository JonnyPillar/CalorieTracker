using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Utils.Account;

namespace CalorieTracker.Controllers.Nutrients
{
    public class NutrientController : Controller
    {
        private readonly CalorieTrackerEntities db = new CalorieTrackerEntities();

        // GET: /Nutrient/
        public ActionResult Index()
        {
            return View(db.Nutrients.ToList());
        }

        // GET: /Nutrient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nutrient nutrient = db.Nutrients.Find(id);
            if (nutrient == null)
            {
                return HttpNotFound();
            }
            if (User.Identity.IsAuthenticated)
            {
                int userID = IdentityUtil.GetUserIDFromCookie(User);
                User user = db.Users.Find(userID);
            }
            return View(nutrient);
        }

        // GET: /Nutrient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Nutrient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "NutrientID,SourceID,UnitType,Name,DecimalRounding")] Nutrient nutrient)
        {
            if (ModelState.IsValid)
            {
                db.Nutrients.Add(nutrient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nutrient);
        }

        // GET: /Nutrient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nutrient nutrient = db.Nutrients.Find(id);
            if (nutrient == null)
            {
                return HttpNotFound();
            }
            return View(nutrient);
        }

        // POST: /Nutrient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NutrientID,SourceID,UnitType,Name,DecimalRounding")] Nutrient nutrient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nutrient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nutrient);
        }

        // GET: /Nutrient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nutrient nutrient = db.Nutrients.Find(id);
            if (nutrient == null)
            {
                return HttpNotFound();
            }
            return View(nutrient);
        }

        // POST: /Nutrient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nutrient nutrient = db.Nutrients.Find(id);
            db.Nutrients.Remove(nutrient);
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