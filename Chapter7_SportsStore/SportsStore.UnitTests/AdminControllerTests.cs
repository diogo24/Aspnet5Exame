using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void Index_Contains_All_Products()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            var products = new Product[] {
                 new Product {ProductID = 1, Name = "P1"},
                 new Product {ProductID = 2, Name = "P2"},
                 new Product {ProductID = 3, Name = "P3"}
            };
            mock.Setup(p => p.Products).Returns(products);

            // Arrange - create controller
            var controller = new AdminController(mock.Object);

            // Act
            var result = ((IEnumerable<Product>)controller.Index().Model).ToArray();

            // Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("P1", result[0].Name);
            Assert.AreEqual("P2", result[1].Name);
            Assert.AreEqual("P3", result[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            var products = new Product[] {
                 new Product {ProductID = 1, Name = "P1"},
                 new Product {ProductID = 2, Name = "P2"},
                 new Product {ProductID = 3, Name = "P3"}
            };
            mock.Setup(p => p.Products).Returns(products);

            // Arrange - create controller
            var controller = new AdminController(mock.Object);

            // Act
            Product p1 = controller.Edit(1).ViewData.Model as Product;
            Product p2 = controller.Edit(2).ViewData.Model as Product;
            Product p3 = controller.Edit(3).ViewData.Model as Product;

            // Assert
            Assert.AreSame(products[0], p1);
            Assert.AreSame(products[1], p2);
            Assert.AreSame(products[2], p3);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Product()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            var products = new Product[] {
                 new Product {ProductID = 1, Name = "P1"},
                 new Product {ProductID = 2, Name = "P2"},
                 new Product {ProductID = 3, Name = "P3"}
            };
            mock.Setup(p => p.Products).Returns(products);

            // Arrange - create controller
            var controller = new AdminController(mock.Object);

            // Act
            Product p4 = controller.Edit(4).ViewData.Model as Product;

            // Assert
            Assert.IsNull(p4);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            // Arrange - create controller
            var controller = new AdminController(mock.Object);

            // Arrange - create a product
            Product product = new Product { Name = "Test" };

            // Act - try to save the product
            ActionResult result = controller.Edit(product);

            // Assert - check that the repository was called
            mock.Verify(p => p.SaveProduct(product));

            // Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

            // Assert - check message
            Assert.AreEqual("Test has been saved", controller.TempData["message"]);
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            // Arrange - create controller
            var controller = new AdminController(mock.Object);

            // Arrange - Add error to ModelState
            controller.ModelState.AddModelError("Error", "Error");

            // Arrange - create a product
            Product product = new Product { };

            // Act - try to save the product
            ActionResult result = controller.Edit(product);

            // Assert - check that the repository was not called
            mock.Verify(p => p.SaveProduct(It.IsAny<Product>()), Times.Never);

            // Assert - check the method result type
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            // Assert - check no message added to TempData
            Assert.IsNull(controller.TempData["message"]);
        }

        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            var p2 = new Product { ProductID = 2, Name = "P2" };
            var products = new Product[] {
                 new Product {ProductID = 1, Name = "P1"},
                p2,
                 new Product {ProductID = 3, Name = "P3"}
            };
            mock.Setup(p => p.Products).Returns(products);
            mock.Setup(p => p.DeleteProduct(2)).Returns(p2);

            // Arrange - create controller
            var controller = new AdminController(mock.Object);

            // Act
            var result = controller.Delete(2);

            // Assert
            mock.Verify(m => m.DeleteProduct(2), Times.Once);
            Assert.AreEqual("P2 was deleted", controller.TempData["message"]);
        }

        [TestMethod]
        public void Can_Delete_Valid_Products2()
        {
            // Arrange - create a Product
            Product prod = new Product { ProductID = 2, Name = "Test" };
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
 new Product {ProductID = 1, Name = "P1"},
 prod,
 new Product {ProductID = 3, Name = "P3"},
 });
            // Arrange - create the controller
            AdminController target = new AdminController(mock.Object);
            // Act - delete the product
            target.Delete(prod.ProductID);
            // Assert - ensure that the repository delete method was
            // called with the correct Product
            mock.Verify(m => m.DeleteProduct(prod.ProductID));

        }
    }
}
