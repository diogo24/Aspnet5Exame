using System;
using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Chapter15_UrlsAndRoutes.Tests
{
    [TestClass]
    public class RouteTests_Chapter14
    {
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET") {
            // create the mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // create the mock context, using the request and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            return mockContext.Object;
        }

        private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "Get") {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object routeProperties)
        {
            Func<object, object, bool> compare = (object a, object b) => { return StringComparer.InvariantCultureIgnoreCase.Compare(a, b) == 0; };

            var result = compare(controller, routeResult.Values["controller"]);

            result = result && compare(action, routeResult.Values["action"]);

            if (routeProperties != null) {            
                var properties = routeProperties.GetType().GetProperties();
                foreach (var item in properties)
                {
                    if (!routeResult.Values.ContainsKey(item.Name)
                        || !compare(item.GetValue(routeProperties, null), routeResult.Values[item.Name])
                        )
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        private void TestRouteFail(string url) {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            // Assert
            Assert.IsTrue(result == null || result.Route == null);
        }

        //[TestMethod]
        //public void TestIncomingRoutes_Example2()
        //{
        //    // check for the URL that is hoped for
        //    TestRouteMatch("~/Admin/Index", "Admin", "Index");
        //    // check that the values are being obtained from the segments
        //    TestRouteMatch("~/one/Two", "one", "two");

        //    // ensure that too many or too few segments fails to match
        //    TestRouteFail("~/Admin");
        //    TestRouteFail("~/Admin/Index/Segment");
        //}

        //[TestMethod]
        //public void TestIncomingRoutes_Example4()
        //{
        //    // check for the URL that is hoped for
        //    TestRouteMatch("~/Admin/Index", "Admin", "Index");
        //    // check that the values are being obtained from the segments
        //    TestRouteMatch("~/one/Two", "one", "two");

        //    TestRouteMatch("~/Admin", "Admin", "Index");
        //    TestRouteMatch("~/", "Home", "Index");

        //    // ensure that too many or too few segments fails to match

        //    TestRouteFail("~/Admin/Index/Segment");
        //}

        //[TestMethod]
        //public void TestIncomingRoutes_Example7()
        //{
        //    // check for the URL that is hoped for
        //    TestRouteMatch("~/Admin/Index", "Admin", "Index");
        //    // check that the values are being obtained from the segments
        //    TestRouteMatch("~/one/Two", "one", "two");

        //    TestRouteMatch("~/Admin", "Admin", "Index");
        //    TestRouteMatch("~/", "Home", "Index");

        //    TestRouteMatch("~/Shop/Index", "Home", "Index");

        //    // ensure that too many or too few segments fails to match

        //    TestRouteFail("~/Admin/Index/Segment");
        //}

        //[TestMethod]
        //public void TestIncomingRoutes_Example9()
        //{
        //    TestRouteMatch("~/", "Home", "Index", new { id = "DefaultId" });
        //    TestRouteMatch("~/Customer", "Customer", "index", new { id = "DefaultId" });
        //    TestRouteMatch("~/Customer/List", "Customer", "List", new { id = "DefaultId" });
        //    TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
        //    TestRouteFail("~/Customer/List/All/Delete");
        //}

        //[TestMethod]
        //public void TestIncomingRoutes_Example10()
        //{
        //    TestRouteMatch("~/", "Home", "Index");
        //    TestRouteMatch("~/Customer", "Customer", "index");
        //    TestRouteMatch("~/Customer/List", "Customer", "List");
        //    TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
        //    TestRouteFail("~/Customer/List/All/Delete");
        //}

        //[TestMethod]
        //public void TestIncomingRoutes_Example11()
        //{
        //    TestRouteMatch("~/", "Home", "Index");
        //    TestRouteMatch("~/Customer", "Customer", "Index");
        //    TestRouteMatch("~/Customer/List", "Customer", "List");
        //    TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });
        //    TestRouteMatch("~/Customer/List/All/Delete", "Customer", "List", new { id = "All", catchall = "Delete" });
        //    TestRouteMatch("~/Customer/List/All/Delete/Perm", "Customer", "List", new { id = "All", catchall = "Delete/Perm" });
        //}

        //[TestMethod]
        //public void TestIncomingRoutes_Example17()
        //{
        //    TestRouteMatch("~/", "Home", "Index");
        //    TestRouteMatch("~/Home", "Home", "Index");
        //    TestRouteMatch("~/Home/Index", "Home", "Index");
        //    TestRouteMatch("~/Home/About", "Home", "About");
        //    TestRouteMatch("~/Home/About/MyId", "Home", "About", new { id = "MyId" });
        //    TestRouteMatch("~/Home/About/MyId/More/Segments", "Home", "About",
        //    new
        //    {
        //        id = "MyId",
        //        catchall = "More/Segments"
        //    });
        //    TestRouteFail("~/Home/OtherAction");
        //    TestRouteFail("~/Account/Index");
        //    TestRouteFail("~/Account/About");
        //}
    }
}
