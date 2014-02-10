using System;
using System.Web.Mvc;

namespace CalorieTracker.Controllers.Users
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        /// <summary>
        ///     View User Account
        /// </summary>
        /// <returns>Account View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string id = User.Identity.Name;
                try
                {
                    int userID = Convert.ToInt32(id);
                }
                catch (Exception)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }

        //
        // GET: /Account/Details/5
        /// <summary>
        ///     Get details of a user. Admin Only
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Details View</returns>
        [HttpGet]
        public ActionResult Details(int id)
        {
            //Check Admin
            return View();
        }

        //
        // GET: /Account/Edit/5
        /// <summary>
        ///     Edit User Info
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Edit View</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Account/Edit/5
        /// <summary>
        ///     Edit User Post Back
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="collection">User Edit Form</param>
        /// <returns>View Info View</returns>
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Delete/5

        /// <summary>
        ///     Delete User
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>Delete Confirmation View</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Account/Delete/5
        /// <summary>
        ///     Delete A User After Confirmation
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="collection">Delete User Form</param>
        /// <returns>Return To Homepage</returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                //Ensure User logged out!
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}