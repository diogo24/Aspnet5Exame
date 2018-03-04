using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository _productRepository;

        public AdminController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Admin
        public ViewResult Index()
        {
            return View(_productRepository.Products);
        }

        public ViewResult Edit(int productId) {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);

            //if (product == null) {

            //}

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product) {

            if (ModelState.IsValid) {
                _productRepository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }

            // there is something wrong with the data values
            return View(product);
        }
    }
}