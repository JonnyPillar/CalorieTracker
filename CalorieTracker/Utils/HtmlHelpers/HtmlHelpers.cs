using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CalorieTracker.Utils.HtmlHelpers
{
    public static class HtmlHelpers
    {
        /// <summary>
        ///     Create a Navigation menu item which responds to being the active page
        /// </summary>
        /// <param name="htmlHelper">HTML Helper</param>
        /// <param name="linkText">Link Text</param>
        /// <param name="actionName">Action to Invoke</param>
        /// <param name="controllerName">Controller to Invoke</param>
        /// <returns>Menu Item li</returns>
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName,
            string controllerName)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            var builder = new TagBuilder("li")
            {
                InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName).ToHtmlString()
            };
            if (controllerName == currentController && actionName == currentAction) builder.AddCssClass("active");
            return new MvcHtmlString(builder.ToString());
        }
    }
}