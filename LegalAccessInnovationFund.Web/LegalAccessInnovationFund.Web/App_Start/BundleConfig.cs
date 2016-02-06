using System.Web;
using System.Web.Optimization;

namespace LegalAccessInnovationFund.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/html5shiv.js",
                      "~/Scripts/jquery.inview.min.js",
                      "~/Scripts/countTo.js",
                      "~/Scripts/lightbox.min.js",
                      "~/Scripts/main.js",
                      "~/Scripts/mousescroll.js",
                      "~/Scripts/smoothscroll.js",
                      "~/Scripts/wow.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/animate.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/lightbox.css",
                      "~/Content/bootstrap.css",
                      "~/Content/main.css",
                      "~/Content/responsive.css",
                      "~/Content/bootstrap.css",
                      "~/Content/preset1.css"
                      ));
        }
    }
}
