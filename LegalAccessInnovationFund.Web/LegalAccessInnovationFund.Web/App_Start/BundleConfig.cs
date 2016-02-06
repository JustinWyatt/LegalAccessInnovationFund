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
                      "~/Scripts/jquery.slitslider.js",
                      "~/Scripts/jquery.easing.min.js",
                      "~/Scripts/jquery.isotope.min.js",
                      "~/Scripts/main.js",
                      "~/Scripts/imagesloaded.pkgd.min.js",
                      "~/Scripts/jquery.ba-cond.min.js",
                      "~/Scripts/wow.min.js",
                      "~/Scripts/modernizr.custom.79639.js",
                      "~/Scripts/owl.carousel.js",
                      "~/Scripts/scrollupto.js",
                      "~/Scripts/skillset.js",
                      "~/Scripts/jquery.nicescroll.js",
                      "~/Scripts/jquery.mixitup.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/animate.min.css",
                      "~/Content/skillset.css",
                      "~/Content/owl.theme.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/owl.transition.css",
                      "~/Content/responsive.css",
                      "~/Content/bootstrap.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/style.css"
                      ));
        }
    }
}
