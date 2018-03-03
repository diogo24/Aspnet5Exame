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

namespace SportsStore.UnitTests
{
    [TestClass]
    public class NavControllerTests
    {
        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange    
            // - create the mock repository    
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                new Product {ProductID = 4, Name = "P4", Category = "Oranges"},
            });

            // Arrange - create the controller    
            NavController target = new NavController(mock.Object);

            // Act = get the set of categories    
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

            // Assert    
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Arrange    
            // - create the mock repository    
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] { });

            // Arrange - create the controller    
            NavController target = new NavController(mock.Object);

            // Arrange - define the category to selected    
            string categoryToSelect = "Apples";

            // Act = get the set of categories    
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;
            
            // Assert    
            Assert.AreEqual(categoryToSelect, result);
        }
    }
}
