using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter4_LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        //// GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}