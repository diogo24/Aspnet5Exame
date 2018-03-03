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

        public ActionResult Index(string returnUrl)
        {
            var model = new CartIndexViewModel() {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
    }
}