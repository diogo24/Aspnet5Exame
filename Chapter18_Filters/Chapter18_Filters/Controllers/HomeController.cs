using Chapter18_Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter18_Filters.Controllers
{
    public class HomeController : Controller
    {
        private Stopwatch timer;

        [CustomAuth(true)]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        [Authorize(Users = "admin")]
        public string Index_AuthorizeAttribute()
        {
            return "This is the Index action on the Home controller";
        }

        [RangeException]
        public string RangeTest(int id)
        {
            if (id > 100)
            {
                return string.Format("The id value is : {0}", id);
            }
            else {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }


        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError_BuiltIn")]
        public string RangeTest_BuiltInExceptionFilter(int id)
        {
            if (id > 100)
            {
                return string.Format("The id value is : {0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }

        [CustomAction]
        public string ActionFilterTest()
        {
            return "This is the FilterTest action";
        }

        [ProfileAction]
        [ProfileResult]
        [ProfileAll]
        public string ActionFilterTest_Timer()
        {
            return "This is the FilterTest action";
        }


        public string FilterTest()
        {
            return "This is the FilterTest action";
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            timer.Stop();
            filterContext.HttpContext.Response.Write(
                string.Format("<div>Total Controller elapsed time: {0}</div>",
                timer.Elapsed.TotalSeconds));
        }
    }
}