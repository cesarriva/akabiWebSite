using System.Web;
using System.Web.Optimization;

namespace AkaBIWebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/slicknav.css",
                      "~/Content/css/style.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/animate.css"));

            bundles.Add(new ScriptBundle("~/bundles/margoTemplate").Include(
                    "~/Scripts/jquery.fitvids.js",
                    "~/Scripts/owl.carousel.min.js",
                    "~/Scripts/nivo-lightbox.min.js",
                    "~/Scripts/jquery.isotope.min.js",
                    "~/Scripts/jquery.appear.js",
                    "~/Scripts/count-to.js",
                    "~/Scripts/jquery.textillate.js",
                    "~/Scripts/jquery.lettering.js",
                    "~/Scripts/jquery.nicescroll.min.js",
                    "~/Scripts/jquery.parallax.js",
                    "~/Scripts/mediaelement-and-player.js",
                    "~/Scripts/jquery.slicknav.js"
                ));
        }
    }
}

    
   