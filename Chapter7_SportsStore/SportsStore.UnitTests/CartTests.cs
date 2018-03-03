using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            var quantity = 2;

            // Arrange - create a new cart
            var cart = new Cart();

            // Act
            cart.AddItem(p1, quantity);
            cart.AddItem(p2, quantity);
            CartLine[] results = cart.Lines.ToArray();

            //Assert
            Assert.AreEqual(2, results.Length);
            Assert.AreSame(p1, results[0].Product);
            Assert.AreSame(p2, results[1].Product);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            var quantity = 2;

            // Arrange - create a new cart with products
            var cart = new Cart() ;
            cart.AddItem(p1, quantity);
            cart.AddItem(p2, quantity);

            // Act
            var newQuantity = 5;
            cart.AddItem(p1, newQuantity);
            CartLine[] results = cart.Lines.OrderBy(c => c.Product.ProductID).ToArray();

            //Assert
            Assert.AreEqual(2, results.Length);
            Assert.AreSame(p1, results[0].Product);
            Assert.AreEqual(quantity + newQuantity, results[0].Quantity);
            Assert.AreSame(p2, results[1].Product);
            Assert.AreEqual(quantity, results[1].Quantity);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            // Arrange - create a new cart with products
            var cart = new Cart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 3);
            cart.AddItem(p3, 5);
            cart.AddItem(p2, 1);


            // Act
            cart.RemoveLine(p2);

            //Assert
            Assert.AreEqual(2, cart.Lines.Count());
            Assert.AreEqual(0, cart.Lines.Where(c => c.Product == p2).Count());
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Arrange - create a new cart with products
            var cart = new Cart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 3);
            cart.AddItem(p1, 1);

            // Act
            var result = cart.ComputeTotalValue();

            // Assert
            Assert.AreEqual(350M, result);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {
            // Arrange - create some test products
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

            // Arrange - create a new cart with products
            var cart = new Cart();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 3);
            cart.AddItem(p1, 1);

            // Act
            cart.Clear();

            //Assert
            Assert.AreEqual(0, cart.Lines.Count());
        }
    }
}
