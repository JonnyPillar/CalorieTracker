using System;
using System.Web;
using System.Web.Mvc;

namespace CalorieTracker.Models.ModelBinders
{
    public class FoodLogModelBinder : DefaultModelBinder
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

            if (bindingContext.ModelType == typeof (FoodLog))
            {
                string rawfoodID = request.Form.Get("FoodID");
                string rawUserID = controllerContext.HttpContext.User.Identity.Name;
                string rawQuantity = request.Form.Get("Quantity");
                int foodID = 0;
                int userID = 0;
                decimal quantity = 0;
                try
                {
                    foodID = Convert.ToInt32(rawfoodID);
                    userID = Convert.ToInt32(rawUserID);
                    quantity = Convert.ToDecimal(rawQuantity);
                }
                catch (Exception)
                {
                    userID = 0; // TODO dont do this silly
                }

                return new FoodLog
                {
                    FoodID = foodID,
                    UserID = userID,
                    Quantity = quantity,
                    CreationTimestamp = DateTime.Now
                };
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
}