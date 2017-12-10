using Chapter4_LanguageFeatures.Models;
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

        public ViewResult AutoProperty() {
            //create a new Product object
            Product myProduct = new Product();

            // set the property value
            myProduct.Name = "Kayak";

            // get the property name
            string productName = myProduct.Name;

            // generate the view
            return View("Result", (object)string.Format("Product name: {0}", productName));
        }
    }
}