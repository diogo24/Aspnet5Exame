using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter17_ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ViewResult Index()
        {
            return View("Homepage");
        }
    }
}