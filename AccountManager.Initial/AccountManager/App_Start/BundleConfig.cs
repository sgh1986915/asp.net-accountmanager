using System.Web;
using System.Web.Optimization;

namespace AccountManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Bundles/Core").Include(
                "~/Content/Avant/js/jquery-1.10.2.min.js",
                "~/Content/Avant/js/jqueryui-1.10.3.min.js",
                "~/Content/Avant/js/bootstrap.min.js",
                "~/Content/Avant/js/enquire.js",
                "~/Content/Avant/js/jquery.cookie.js",
                "~/Content/Avant/js/jquery.nicescroll.min.js",
                "~/Content/Avant/js/application.js"

                ));
/*
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            */

            bundles.Add(new StyleBundle("~/Bundles/Css").Include(
                         "~/Content/Avant/css/styles.css",
                         "~/Content/Avant/js/jqueryui.css",
                         "~/Content/Agritec/Agritec.css"

                         ));


            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
