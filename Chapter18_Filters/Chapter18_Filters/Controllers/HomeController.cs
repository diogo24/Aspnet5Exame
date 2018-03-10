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
    }
}