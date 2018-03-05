using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.WebUI.Controllers;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    /// <summary>
    /// Summary description for ImageTests
    /// </summary>
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            // Arrange - create a Product with image data
            var prod = new Product { ProductID = 2,
                ImageData = new byte[] { 0, 1, 1, 0 },
                ImageMimeType = "image/png"
            };

            // Arrange - setup mock products
            mock.Setup(p => p.Products)
                .Returns(new Product[] {
                    new Product {ProductID = 1, Name = "P1"},
                     prod,
                     new Product {ProductID = 3, Name = "P3"}
                });

            // Arrage - create the controller
            var controller = new ProductController(mock.Object);

            // Act - call the GetImage action method
            var result = controller.GetImage(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual("image/png", result.ContentType);
            var expectedBinaryArray = new byte[] { 0, 1, 1, 0 };
            for (int i = 0; i < expectedBinaryArray.Length; i++)
            {
                Assert.AreEqual(expectedBinaryArray[i], result.FileContents[i]);
            }
        }

        [TestMethod]
        public void Cannot_Retrieve_Image_Data_For_Invalid_ID()
        {
            // Arrange - create the mock repository
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();

            // Arrange - setup mock products
            mock.Setup(p => p.Products)
                .Returns(new Product[] {
                    new Product {ProductID = 1, Name = "P1"},
                     new Product {ProductID = 2, Name = "P2"}
                });

            // Arrage - create the controller
            var controller = new ProductController(mock.Object);

            // Act - call the GetImage action method
            var result = controller.GetImage(3);

            // Assert
            Assert.IsNull(result);
        }
    }
}
