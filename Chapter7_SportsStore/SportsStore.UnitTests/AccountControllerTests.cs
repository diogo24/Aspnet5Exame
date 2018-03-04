using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AccountControllerTests // AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credentials()
        {
            // Arrange - create a mock authentication provider
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();

            // Arrange - create the view model
            var model = new LoginViewModel { UserName = "UN1", Password = "P1" };

            // Arrange - Mock AUthenticate with credentials
            mock.Setup(m => m.Authenticate(model.UserName, model.Password)).Returns(true);

            // Arrange - create the controller
            AccountController target = new AccountController(mock.Object);

            // Act - authenticate using valid credentials
            ActionResult resultWithRedirect = target.Login(model, "/MyURL");
            ActionResult resultWithRedirectToAction = target.Login(model, null);

            // Assert
            mock.Verify(m => m.Authenticate("UN1", "P1"));
            Assert.IsInstanceOfType(resultWithRedirect, typeof(RedirectResult));
            Assert.AreEqual("/MyURL" , ((RedirectResult)resultWithRedirect).Url);

            Assert.IsInstanceOfType(resultWithRedirectToAction, typeof(RedirectToRouteResult));
            Assert.AreEqual("Index", ((RedirectToRouteResult)resultWithRedirectToAction).RouteValues["Action"]);
            Assert.AreEqual("Admin", ((RedirectToRouteResult)resultWithRedirectToAction).RouteValues["Controller"]);
        }

        [TestMethod]
        public void Cannot_Login_With_Invalid_Credentials()
        {
            // Arrange - create a mock authentication provider
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();

            // Arrange - create the view model
            var model = new LoginViewModel { UserName = "UN1", Password = "P1" };

            // Arrange - Mock AUthenticate with credentials fails
            mock.Setup(m => m.Authenticate(model.UserName, model.Password)).Returns(false);

            // Arrange - create the controller
            AccountController target = new AccountController(mock.Object);

            // Act - authenticate using invalid credentials
            ActionResult result = target.Login(model, null);

            // Assert
            mock.Verify(m => m.Authenticate("UN1", "P1"));
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
