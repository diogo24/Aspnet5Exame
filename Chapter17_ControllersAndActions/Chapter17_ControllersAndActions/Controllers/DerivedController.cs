using Chapter17_ControllersAndActions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter17_ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        // GET: Derived
        public ActionResult Index()
        {
            ViewBag.Message = "Hello from the DerivedController Index method";
            return View("MyView");
        }

        public ActionResult ProduceOutput() {
            //if (Server.MachineName == "TINY")
            //{
            //    //Response.Redirect("/Basic/Index");
            //    return new CustomRedirectResult { Url = "/Basic/Index" };
            //}
            //else {
            //    Response.Write("Controller: Derived, Action: ProduceOutput");
            //    return null;
            //}
            return new RedirectResult("/Basic/Index");
        }

        public ActionResult ShowWeatherForecast()
        {
            string city = (string)RouteData.Values["city"];
            DateTime forDate = DateTime.Parse(Request.Form["forDate"]);
            // ... implement weather forecast here ...
            return View();
        }

        public ActionResult ShowWeatherForecast(string city, DateTime forDate)
        {
            // ... implement weather forecast here ...
            return View();
        }

        public ActionResult Search(string query = "all", int page = 1)
        {
            // ...process request...
            return View();
        }

    }
}