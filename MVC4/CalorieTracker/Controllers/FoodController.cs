using System;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.Controllers
{
    public class FoodController : Controller
    {
        calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        //
        // GET: /Food/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Food/Details/5

        public ActionResult Details(string id)
        {
            tbl_food_log log = db.tbl_food_log.Find(id);
            if (log != null)
            {
                return View(log);
            }
            return View(log);
        }

        //
        // GET: /Food/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Food/Create

        [HttpPost]
        public ActionResult Create(tbl_food newFood)
        {
            if (ModelState.IsValid)
            {
                if(string.IsNullOrEmpty(newFood.food_id)) newFood.food_id = Guid.NewGuid().ToString();
                db.tbl_food.Add(newFood); 
                //Create the New Food Log
                tbl_food_log foodLog = new tbl_food_log(newFood);
                foodLog.food_log_user_id = User.Identity.Name;
                db.tbl_food_log.Add(foodLog);
                //Save
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            else return View(newFood);
        }

        //
        // GET: /Food/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Food/Edit/5

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
        // GET: /Food/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Food/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
