using Chapter19_ControllerExtensibility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter19_ControllerExtensibility.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName     = "Index"
            });
        }
        public ViewResult List()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName     = "List"
            });
        }
    }
}