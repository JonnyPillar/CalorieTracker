using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Utils.Account;

namespace CalorieTracker.Controllers.Log
{
    public class FoodLogController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();

        // GET: /FoodLog/
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            int currentUserID = IdentityUtil.GetUserIDFromCookie(User);
            IQueryable<FoodLog> foodlogs = db.FoodLogs.Include(f => f.Food).Include(f => f.User.UserID == currentUserID);
            return View(foodlogs.ToList());
        }

        // GET: /FoodLog/Details/5
        public ActionResult Details(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            FoodLog foodlog = db.FoodLogs.Find(id);
            if (foodlog == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(foodlog);
        }

        // GET: /FoodLog/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "PasswordHash");
            return View();
        }

        // POST: /FoodLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "FoodLogID,FoodID,UserID,Quantity,CreationTimestamp")] FoodLog foodlog)
        {
            if (ModelState.IsValid)
            {
                db.FoodLogs.Add(foodlog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name", foodlog.FoodID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "PasswordHash", foodlog.UserID);
            return View(foodlog);
        }

        // GET: /FoodLog/Edit/5
        public ActionResult Edit(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            FoodLog foodlog = db.FoodLogs.Find(id);
            if (foodlog == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name", foodlog.FoodID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "PasswordHash", foodlog.UserID);
            return View(foodlog);
        }

        // POST: /FoodLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodLogID,FoodID,UserID,Quantity,CreationTimestamp")] FoodLog foodlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodID = new SelectList(db.Foods, "FoodID", "Name", foodlog.FoodID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "PasswordHash", foodlog.UserID);
            return View(foodlog);
        }

        // GET: /FoodLog/Delete/5
        public ActionResult Delete(string id)
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            FoodLog foodlog = db.FoodLogs.Find(id);
            if (foodlog == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(foodlog);
        }

        // POST: /FoodLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FoodLog foodlog = db.FoodLogs.Find(id);
            db.FoodLogs.Remove(foodlog);
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