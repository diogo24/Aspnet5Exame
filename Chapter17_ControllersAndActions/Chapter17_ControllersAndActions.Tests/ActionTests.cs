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

        [TestMethod]
        public void ViewSelectionTest()
        {
            // Arrange  - create the controller
            var controller = new ExampleController();

            // Act  - call the action method
            ViewResult result = controller.Index_Model();

            // Assert
            Assert.AreEqual(string.Empty, result.ViewName);
            Assert.IsInstanceOfType(result.Model, typeof(DateTime));
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(DateTime));
        }

        [TestMethod]
        public void ControllerTest_ViewBag()
        {
            // Arrange  - create the controller
            var controller = new ExampleController();

            // Act  - call the action method
            ViewResult result = controller.Index_ViewBag();

            // Assert
            Assert.AreEqual(string.Empty, result.ViewName);
            Assert.AreEqual("Hello", result.ViewBag.Message);
            Assert.IsInstanceOfType(result.ViewBag.Date, typeof(DateTime));
        }

        [TestMethod]
        public void ControllerTest_RedirectLiteral()
        {
            // Arrange  - create the controller
            var controller = new ExampleController();

            // Act  - call the action method
            RedirectResult result = controller.Redirect();

            // Assert
            Assert.AreEqual("/Example/Index", result.Url);
            Assert.IsFalse(result.Permanent);
        }

        [TestMethod]
        public void ControllerTest_RedirectRoute()
        {
            // Arrange  - create the controller
            var controller = new ExampleController();

            // Act  - call the action method
            RedirectToRouteResult result = controller.Redirect_Route();

            // Assert
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual(string.Empty, result.RouteName);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyID", result.RouteValues["ID"]);
        }

        [TestMethod]
        public void ControllerTest_()
        {
            // Arrange  - create the controller
            var controller = new ExampleController();

            // Act  - call the action method
            HttpStatusCodeResult result = controller.StatusCode_Unauthorized();

            // Assert
            Assert.AreEqual(401, result.StatusCode);
        }
    }
}
