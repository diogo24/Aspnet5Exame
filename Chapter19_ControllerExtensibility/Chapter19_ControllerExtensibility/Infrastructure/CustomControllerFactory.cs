using Chapter19_ControllerExtensibility.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Chapter19_ControllerExtensibility.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type targetType = null;
            switch (controllerName)
            {
                case "Customer":
                    targetType = typeof(CustomerController);
                    break;

                case "Product":
                    targetType = typeof(ProductController);
                    break;

                default:
                    requestContext.RouteData.Values["controller"] = "Product";
                    targetType = typeof(ProductController);
                    break;
            }

            return targetType == null ? null
                : (IController)DependencyResolver.Current.GetService(targetType);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {

            switch (controllerName)
            {
                case "Home":
                    return SessionStateBehavior.ReadOnly;
                case "Product":
                    return SessionStateBehavior.Required;
                default:
                    return SessionStateBehavior.Default;
            }

            //return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable dispose = controller as IDisposable;
            if (dispose != null)
            {
                dispose.Dispose();
            }
        }
    }
}