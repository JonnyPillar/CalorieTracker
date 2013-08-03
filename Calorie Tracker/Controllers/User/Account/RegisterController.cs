using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Calorie_Tracker.DAL;
using Calorie_Tracker.Utilities;

namespace Calorie_Tracker.Controllers.User.Account
{
    public class RegisterController : Controller
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /Register/

        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(DAL.tbl_user user)
        {
            tbl_user existingUser = db.tbl_user.FirstOrDefault(tbl_user => tbl_user.user_email == user.user_email);
            if (existingUser == null)
            {
                user.user_id = Guid.NewGuid().ToString(); // ID will be null
                PasswordHasher hasher = new PasswordHasher(user.user_password);
                user.user_password_hash = hasher.PasswordHash;
                user.user_password_salt = hasher.PasswordSalt;
                user.user_creation_date = DateTime.Now.ToString("ddMMyyyyHHmmss");
                db.tbl_user.Add(user);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(user.user_email, true); //TODO Does it need to be true?
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Login data is incorrect!");
            return View(user);
        }
    }
}
