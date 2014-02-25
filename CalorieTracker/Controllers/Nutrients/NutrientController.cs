using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using CalorieTracker.Models;
using CalorieTracker.Models.ViewModels;
using CalorieTracker.Utils.Account;
using CalorieTracker.Utils.Chart;
using CalorieTracker.Utils.RDA.Breakdown;

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
            ChartUtil chartUtil = null;
            if (User.Identity.IsAuthenticated)
            {
                int userID = IdentityUtil.GetUserIDFromCookie(User);
                User user = db.Users.Find(userID);
                var breakdownUtil = new RDABreakdownUtil(nutrient, user, new TimeSpan(30, 0, 0, 0),
                    new TimeSpan(1, 0, 0, 0));

                decimal nutrientBaseLevel = breakdownUtil.NutrientRDAObject.Value;

                decimal maxChartValue = breakdownUtil.MaxValue;
                decimal minChartValue = breakdownUtil.MinValue;

                if (nutrientBaseLevel > maxChartValue) maxChartValue = nutrientBaseLevel;
                if (nutrientBaseLevel < minChartValue) minChartValue = nutrientBaseLevel;

                var labelString = new StringBuilder();
                var dataString = new StringBuilder();
                var nutrientBaseString = new StringBuilder();
                for (int i = 0; i < breakdownUtil.RDABreakdownItems.Count; i++)
                {
                    labelString.AppendFormat("\"Day {0}\"", breakdownUtil.RDABreakdownItems[i].ItemID);
                    dataString.Append(breakdownUtil.RDABreakdownItems[i].ItemValue);
                    nutrientBaseString.AppendFormat(nutrientBaseLevel.ToString());

                    if (i != breakdownUtil.RDABreakdownItems.Count - 1)
                    {
                        labelString.Append(",");
                        dataString.Append(",");
                        nutrientBaseString.Append(",");
                    }
                }
                chartUtil = new ChartUtil(labelString.ToString());
                chartUtil.AddDataSet(new ChartDataSet(dataString.ToString())); //User RDA Data

                var nutrientBaseDataSet = new ChartDataSet(nutrientBaseString.ToString());
                nutrientBaseDataSet.FillColor = "rgba(255, 0, 0, 0.5)";
                nutrientBaseDataSet.StrokeColor = "rgba(255, 0, 0, 1)";
                nutrientBaseDataSet.PointColor = "rgba(255, 0, 0, 1)";
                chartUtil.AddDataSet(nutrientBaseDataSet); //Nutrient RDA Data
                chartUtil.SetChartMinMaxValues(maxChartValue, minChartValue);
            }
            var nutrientModel = new NutrientModel(nutrient, chartUtil);
            return View(nutrientModel);
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