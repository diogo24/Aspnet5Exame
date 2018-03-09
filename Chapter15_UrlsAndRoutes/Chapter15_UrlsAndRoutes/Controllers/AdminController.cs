using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter15_UrlsAndRoutes.Controllers
{
    [RouteArea("Services")]
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult Index()
        {
            ViewBag.Controller = "Admin";
            ViewBag.Action = "Index";
            return View("ActionName");
        }

        [Route("Add/{user}/{id:int}", Name = "AddRoute")]
        public string Create(string user, int id)
        {
            return string.Format("User: {0}, ID: {1}", user, id);
        }

        [Route("Add/{user}/{password:alpha:length(6)}")]
        public string ChangePass(string user, string password)
        {
            return string.Format("ChangePass Method - User: {0}, Pass: {1}",
            user, password);
        }

        [Route("~/List")]
        public ActionResult About()
        {
            ViewBag.Controller = "Admin";
            ViewBag.Action = "About";
            return View("ActionName");
        }
    }
}