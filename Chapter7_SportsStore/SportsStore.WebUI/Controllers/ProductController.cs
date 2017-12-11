using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepositoryParam)
        {
            productsRepository = productsRepositoryParam;
        }

        // GET: Product
        public ViewResult List()
        {
            return View(productsRepository.Products);
        }
    }
}