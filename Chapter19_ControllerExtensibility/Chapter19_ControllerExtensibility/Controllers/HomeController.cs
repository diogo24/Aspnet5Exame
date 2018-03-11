using Chapter19_ControllerExtensibility.Infrastructure;
using Chapter19_ControllerExtensibility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter19_ControllerExtensibility.Controllers
{
    public class HomeController : Controller
    {
           // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Local]
        [ActionName("Index")]
        public ActionResult LocalIndex()
        {
            return View("Result", new Result
            {
                ControllerName = "Home",
                ActionName = "LocalIndex"
            });
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write(string.Format("You requested the {0} action", actionName));
        }
    }
}