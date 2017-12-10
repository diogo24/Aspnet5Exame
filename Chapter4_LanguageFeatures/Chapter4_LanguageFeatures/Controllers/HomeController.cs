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

        public ViewResult CreateProduct() {
            //// create a new Product object
            //Product myProduct = new Product();

            //// set the property values
            //myProduct.ProductID   = 100;
            //myProduct.Name        = "Kayak";
            //myProduct.Description = "A boat for one person";
            //myProduct.Price       = 275M;
            //myProduct.Category    = "Watersports";

            // create and populate a new Product object
            Product myProduct = new Product
            {
                ProductID   = 100,
                Name        = "Kayak",
                Description = "A boat for one person",
                Price       = 275M,
                Category    = "Watersports"
            };

            return View("Result", (object)string.Format("Category: {0}", myProduct.Category));
        }

        public ViewResult CreateCollection()
        {
            string[] stringArray = { "apple", "orange", "plum" };

            List<int> intList = new List<int> { 10, 20, 30, 40 };

            Dictionary<string, int> myDict = new Dictionary<string, int> {
                { "apple", 10 }, { "orange", 20  }, { "plam", 30 }
            };

            return View("Result", (object)stringArray[1]);
        }
    }
}