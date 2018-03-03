using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartControllerTests
    {
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            // Arrange - create the mock repository            
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(p => p.Products).Returns(new Product[] {
                new Product() { ProductID = 1, Name = "Product1" }
            });

            // Arrange - create a Cart            
            Cart cart = new Cart();

            // Arrange - create the controller            
            CartController target = new CartController(mock.Object);

            // Act
            target.AddToCart(cart, 1, null);

            // Assert
            Assert.AreEqual(1, cart.Lines.Count());
            Assert.AreEqual(1, cart.Lines.ToArray()[0].Product.ProductID);
        }

        [TestMethod]
        public void Can_Remove_From_Cart()
        {
            // Arrange - create the mock repository            
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
            mock.Setup(p => p.Products).Returns(new Product[] {
                p1,
                p2,
                p3
            });

            // Arrange - create a Cart            
            Cart cart = new Cart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 3);
            cart.AddItem(p3, 5);
            cart.AddItem(p2, 1);

            // Arrange - create the controller            
            CartController target = new CartController(mock.Object);

            // Act
            target.RemoveFromCart(cart, 2, null);

            // Assert
            Assert.AreEqual(0, cart.Lines.Where(c => c.Product == p2).Count());
            Assert.AreEqual(2, cart.Lines.Count());

        }

        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen()
        {
            // Arrange - create the mock repository            
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(p => p.Products).Returns(new Product[] {
                new Product() { ProductID = 1, Name = "Product1" }
            });

            // Arrange - create a Cart            
            Cart cart = new Cart();

            // Arrange - create the controller            
            CartController target = new CartController(mock.Object);

            // Act
            var result = target.AddToCart(cart, 1, "myUrl");

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("myUrl", result.RouteValues["returnUrl"]);
        }

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            // Arrange - create a Cart            
            Cart cart = new Cart();

            // Arrange - create the controller            
            CartController target = new CartController(null);

            // Act
            var result = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

            // Assert
            Assert.AreSame(cart, result.Cart);
            Assert.AreEqual("myUrl", result.ReturnUrl);

        }
    }
}
