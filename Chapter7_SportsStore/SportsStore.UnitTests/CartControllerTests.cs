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
            CartController target = new CartController(mock.Object, null);

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
            CartController target = new CartController(mock.Object, null);

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
            CartController target = new CartController(mock.Object, null);

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
            CartController target = new CartController(null, null);

            // Act
            var result = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

            // Assert
            Assert.AreSame(cart, result.Cart);
            Assert.AreEqual("myUrl", result.ReturnUrl);

        }

        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {
            // Arrange - create a mock order processor    
            Mock<IOrderProcessor> orderMock = new Mock<IOrderProcessor>();

            // Arrange - create an empty cart    
            Cart cart = new Cart();
            
            // Arrange - create shipping details    
            ShippingDetails shippingDetails = new ShippingDetails();

            // Arrange - create an instance of the controller    
            CartController target = new CartController(null, orderMock.Object);

            // Act
            var result = target.Checkout(cart, shippingDetails);

            // Assert - check that the order hasn't been passed on to the processor 
            orderMock.Verify(o => o.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never);

            // Assert - check that the method is returning the default view    
            Assert.AreEqual("", result.ViewName);    

            // Assert - check that I am passing an invalid model to the view 
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            // Arrange - create a mock order processor    
            Mock<IOrderProcessor> orderMock = new Mock<IOrderProcessor>();

            // Arrange - create a cart with an item    
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            // Arrange - create shipping details    
            ShippingDetails shippingDetails = new ShippingDetails();

            // Arrange - create an instance of the controller    
            CartController target = new CartController(null, orderMock.Object);

            // Arrange - add an error to the model    
            target.ModelState.AddModelError("error", "error");

            // Act
            var result = target.Checkout(cart, shippingDetails);

            // Assert - check that the order hasn't been passed on to the processor 
            orderMock.Verify(o => o.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never);

            // Assert - check that the method is returning the default view    
            Assert.AreEqual("", result.ViewName);

            // Assert - check that I am passing an invalid model to the view 
            Assert.IsFalse(result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void Can_Checkout_And_Submit_Order()
        {
            // Arrange - create a mock order processor    
            Mock<IOrderProcessor> orderMock = new Mock<IOrderProcessor>();

            // Arrange - create a cart with an item   
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            // Arrange - create shipping details    
            ShippingDetails shippingDetails = new ShippingDetails();

            // Arrange - create an instance of the controller    
            CartController target = new CartController(null, orderMock.Object);

            // Act
            var result = target.Checkout(cart, shippingDetails);

            // Assert - check that the order has been passed on to the processor 
            orderMock.Verify(o => o.ProcessOrder(cart, shippingDetails), Times.Once);

            // Assert - check that the method is returning the completed view    
            Assert.AreEqual("Completed", result.ViewName);

            // Assert - check that I am passing an valid model to the view 
            Assert.IsTrue(result.ViewData.ModelState.IsValid);

            // Assert
            Assert.AreEqual(0, cart.Lines.Count());
        }
    }
}
