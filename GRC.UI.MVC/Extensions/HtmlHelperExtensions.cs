using System.Web.Mvc;

namespace GRC.UI.MVC.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string IfActive(this HtmlHelper helper, string controller)
        {
            string classValue = "";

            string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();

            if (currentController == controller)
            {
                classValue = "active";
            }

            return classValue;
        }
    }
}