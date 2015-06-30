using System.Web;
using System.Web.Optimization;

namespace TulaTreeMvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                      "~/Scripts/jquery.bxslider.js",
                      "~/Scripts/jquery.flexslider.js",
                      "~/Scripts/jquery.slicknav.js",
                      "~/Scripts/jquery-ui.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/style.css",
                      "~/Content/jquery.bxslider.css",
                      "~/Content/flexslider.css",
                      "~/Content/slicknav.css",
                      "~/App_Themes/Default/css/oiioStyle.css",
                       "~/App_Themes/Default/Admin%20CSS/css/oiioAdminStyle.css",
                       "~/App_Themes/Default/AdminMenu/css/nav.css",
                       "~/Content/PagedList.css"));

            ////adminpanel
            //bundles.Add(new ScriptBundle("~/bundles/jquery/Adminjs").Include(
            //    "~/Scripts/jquery.js",
            //    "~/Scripts/jquery-ui.js",
            //    "~/App_Themes/Default/Admin CSS/js/bootstrap.min.js",
            //    "~/Scripts/modernizr.js",
            //    ""));
            //bundles.Add(new StyleBundle("~/Content/css/Admincss").Include(
            //    "~/App_Themes/Default/Admin CSS/css/bootstrap.css",
            //    "~/App_Themes/Default/Admin CSS/css/bootstrap-theme.min.css",
            //    "~/App_Themes/Default/css/oiioStyle.css",
            //    "~/App_Themes/Default/Admin%20CSS/css/oiioAdminStyle.css",
            //    "~/App_Themes/Default/AdminMenu/css/nav.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
