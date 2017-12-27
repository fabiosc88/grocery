using System.Web;
using System.Web.Optimization;

namespace GRC.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Product Page - JS
            bundles.Add(new ScriptBundle("~/bundles/general").Include(
                      "~/Scripts/comum/general.js"));

            //Jquery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //Jquery validate
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //Jquery UI
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.12.1.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            //Toastr - JS
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                    "~/Scripts/toastr.js"
            ));

            //Materialize - JS
            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize/materialize.js"));

            //Product Page - JS
            bundles.Add(new ScriptBundle("~/bundles/productpage").Include(
                      "~/Scripts/pages/productpage.js"));

            // InputMask
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                        "~/Scripts/inputmask/inputmask.js",
                        "~/Scripts/inputmask/jquery.inputmask.js",
                        "~/Scripts/inputmask/inputmask.extensions.js",
                        "~/Scripts/inputmask/inputmask.numeric.extensions.js",
                        "~/Scripts/inputmask/inputmask.regex.extensions.js"));

            //Toastr - CSS
            bundles.Add(new StyleBundle("~/Content/toastr").Include(
                "~/Content/toastr.css"
            ));

            //Jquery UI
            bundles.Add(new ScriptBundle("~/Content/jqueryui").Include(
                        "~/Content/themes/base/jquery-ui.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize/css/materialize.css",
                      "~/Content/site.css"));
        }
    }
}
