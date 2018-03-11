using Chapter18_Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter18_Filters.Controllers
{
    public class HomeController : Controller
    {
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
    }
}