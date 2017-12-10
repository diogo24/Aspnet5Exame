using Chapter5_Razor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter5_Razor.Controllers
{
    public class HomeController : Controller
    {
        Product myProduct = new Product
        {
            ProductID   = 1,
            Name        = "Kayak",
            Description = "A boat for one person",
            Category    = "Watersports",
            Price       = 275M
        };

        // GET: Hom
        public ActionResult Index()
        {
            return View(myProduct);
        }
    }
}