using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter15_UrlsAndRoutes.Controllers
{
    public class LegacyController : Controller
    {
        public ActionResult GetLegacyURL(string legacyURL)
        {
            return View((object)legacyURL);
        }
    }
}