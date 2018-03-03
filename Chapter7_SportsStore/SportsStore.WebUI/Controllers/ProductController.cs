using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
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
        private IProductsRepository _productsRepository;
        public int PageSize = 4;

        public ProductController(IProductsRepository productsRepositoryParam)
        {
            _productsRepository = productsRepositoryParam;
        }

        //// GET: Product
        //public ViewResult List(string category, int page = 1)
        //{
        //    ProductsListViewModel model = new ProductsListViewModel
        //    {
        //        Products = _productsRepository.Products
        //        .Where(FilterProductsCategory(category))
        //        .OrderBy(p => p.ProductID)
        //        .Skip((page - 1) * PageSize)
        //        .Take(PageSize),
        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage  = page,
        //            ItemsPerPage = PageSize,
        //            TotalItems   = _productsRepository.Products.Count(FilterProductsCategory(category))
        //        },
        //        CurrentCategory = category
        //    };
        //    return View(model);
        //}

        //private static Func<Product, bool> FilterProductsCategory(string category)
        //{
        //    return p => category == null || p.Category == category;
        //}

        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = GetProductsByCategory(category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage  = page,
                    ItemsPerPage = PageSize,
                    TotalItems   = GetProductsByCategory(category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        private IEnumerable<Product> GetProductsByCategory(string category)
        {
            return category == null ?
                _productsRepository.Products :
                _productsRepository.Products.Where(p => p.Category == category);
        }
    }
}