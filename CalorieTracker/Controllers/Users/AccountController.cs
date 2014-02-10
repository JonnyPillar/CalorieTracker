using System.Data.Entity;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Utils.Account;

namespace CalorieTracker.Controllers.Users
{
    public class AccountController : Controller
    {
        private readonly CTDBContainer db = new CTDBContainer();

        // GET: /Account/
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                int userID = IdentityUtil.GetUserIDFromCookie(User);
                if (userID >= 0) // valid user ID
                {
                    User user = db.Users.Find(userID);
                    if (user != null)
                    {
                        return View("Details", user);
                    }
                }
            }
            return RedirectToAction("Index", "Account");
        }

        // GET: /Account/Details/5
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                User user = db.Users.Find(id);
                if (user != null)
                {
                    return View(user);
                }
            }
            return RedirectToAction("Index", "Account");
        }

        // GET: /Account/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Account");
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View(user);
        }

        // POST: /Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include =
                    "UserID,DOB,Gender,PasswordHash,PasswordSalt,Admin,CreationTimestamp,ActivityLevelType,Personality")
            ] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: /Account/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Account");
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View(user);
        }

        // POST: /Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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