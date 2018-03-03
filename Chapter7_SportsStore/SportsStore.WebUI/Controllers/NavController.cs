using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductsRepository _productRepository;

        public NavController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Nav
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            //return "Hello from NavController";
            var categoriesList = _productRepository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c);

            return PartialView(categoriesList);
        }
    }
}