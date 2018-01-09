using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
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
        public int PageSize = 4;

        public ProductController(IProductsRepository productsRepositoryParam)
        {
            productsRepository = productsRepositoryParam;
        }

        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = productsRepository.Products
                .Where(FilterProductsCategory(category))
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage  = page,
                    ItemsPerPage = PageSize,
                    TotalItems   = productsRepository.Products.Count(FilterProductsCategory(category))
                },
                CurrentCategory = category
            };
            return View(model);
        }

        private static Func<Domain.Entities.Product, bool> FilterProductsCategory(string category)
        {
            return p => category == null || p.Category == category;
        }
    }
}