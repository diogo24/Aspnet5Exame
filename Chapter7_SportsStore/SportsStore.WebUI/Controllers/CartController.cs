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
    public class CartController : Controller
    {
        private IProductsRepository _productRepository;

        public CartController(IProductsRepository productsRepository)
        {
            _productRepository = productsRepository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            var model = new CartIndexViewModel() {
                Cart = cart,
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        //private Cart GetCart()
        //{
        //    var cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }

        //    return cart;
        //}

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}