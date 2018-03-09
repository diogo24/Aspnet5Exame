using System;
using System.Web.Mvc;
using Chapter17_ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chapter17_ControllersAndActions.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            // Arrange  - create the controller
            var controller = new ExampleController();

            // Act  - call the action method
            ViewResult result = controller.Index();

            // Assert
            Assert.AreEqual("Homepage", result.ViewName);
        }
    }
}
