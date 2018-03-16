using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Chapter26_ClientFeatures
{
    public class BundleConfig
    {
        public static void RegisterBundlers(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/content/*.css"));

            bundles.Add(new ScriptBundle("~/bundles/clientfeaturesscripts")
             .Include("~/Scripts/jquery-{version}.js",
             "~/Scripts/jquery.validate.js",
             "~/Scripts/jquery.validate.unobtrusive.js",
             "~/Scripts/jquery.unobtrusive-ajax.js"));
        }

    }
}