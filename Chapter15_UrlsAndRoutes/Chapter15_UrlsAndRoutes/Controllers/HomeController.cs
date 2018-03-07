using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter15_UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Controller = "Home";
            ViewBag.Action     = "Index";
            return View("ActionName");
        }

        public ActionResult CustomVariable()
        {
            ViewBag.Controller     = "Home";
            ViewBag.Action         = "CustomVariable";
            ViewBag.CustomVariable = RouteData.Values["id"];
            return View();
        }

        public ActionResult CustomVariableParameters(string id)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id;
            return View("CustomVariable");
        }

        public ActionResult CustomVariableOptional(string id)
        {
            ViewBag.Controller = "Home";
            ViewBag.Action = "CustomVariable";
            ViewBag.CustomVariable = id ?? "<no value>";
            return View("CustomVariable");
        }

        public ActionResult CustomVariableOptional_ActionDefaultValue(string id = "DefaultId")
        {
            ViewBag.Controller     = "Home";
            ViewBag.Action         = "CustomVariable";
            ViewBag.CustomVariable = id;
            return View("CustomVariable");
        }
    }
}