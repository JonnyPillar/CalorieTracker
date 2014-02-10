using System;
using System.Web;
using System.Web.Mvc;

namespace CalorieTracker.Models.ModelBinders
{
    public class ActivityLogModelBinder : DefaultModelBinder
    {
        /// <summary>
        ///     Override the binding for Models when passed to Controller
        /// </summary>
        /// <param name="controllerContext">Controller Context</param>
        /// <param name="bindingContext">Binding Context</param>
        /// <returns>New Bound Object</returns>
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            if (bindingContext.ModelType == typeof (ActivityLog))
            {
                string activityLogID = Guid.NewGuid().ToString();
                string activityID = request.Form.Get("ActivityID");
                int userID = Convert.ToInt32(controllerContext.HttpContext.User.Identity.Name);
                DateTime startDate = DateTime.ParseExact(request.Form.Get("StartDate"), "dd:MM:yyyy hh:mm:ss", null);
                //TimeSpan duration = TimeSpan.ParseExact(request.Form.Get("Duration"), "hh:mm:ss", null);
                TimeSpan duration = new TimeSpan();
                decimal distance = Convert.ToDecimal(request.Form.Get("Distance"));
                string title = request.Form.Get("Title");
                decimal accent = Convert.ToDecimal(request.Form.Get("Accent"));
                int heartRate = Convert.ToInt32(request.Form.Get("HeartRate"));
                string notes = request.Form.Get("Notes");
                string fileURL = request.Form.Get("FileURL");

                return new ActivityLog
                {
                    ActivityLogID = activityLogID,
                    ActivityID = activityID,
                    UserID = userID,
                    StartDate = startDate,
                    Duration = duration,
                    Distance = distance,
                    Title = title,
                    Accent = accent,
                    HeartRate = heartRate,
                    Notes = notes,
                    FileURL = fileURL
                };
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
}