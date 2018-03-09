using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter17_ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        // GET: Example
        public ViewResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Date = TempData["Date"];
            return View("Homepage");
        }

        public ViewResult Index_Model()
        {
            var date = DateTime.Now;
            return View(date);
        }

        public ViewResult Index_ViewBag() {
            ViewBag.Message = "Hello";
            ViewBag.Date    = DateTime.Now;

            return View();
        }

        public RedirectResult Redirect() {
            return Redirect("/Example/Index");
            // return RedirectPermanent("/Example/Index");
        }

        public RedirectToRouteResult Redirect_Route()
        {
            return RedirectToRoute(new { controller = "Example", action = "Index", ID = "MyID" });
        }

        public RedirectToRouteResult Redirect_Action()
        {
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult RedirectToRoute()
        {
            TempData["Message"] = "Hello";
            TempData["Date"] = DateTime.Now;
            return RedirectToAction("Index_TempData");
        }

        public ViewResult Index_TempData()
        {
            DateTime time = (DateTime)TempData.Peek("Date");
            TempData.Keep("Date");

            ViewBag.Message = TempData["Message"];
            ViewBag.Date = TempData["Date"];

            return View();
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(404, "URL cannot be serviced");
        }

        public HttpStatusCodeResult StatusCode_NotFound()
        {
            return HttpNotFound();
        }

        public HttpStatusCodeResult StatusCode_Unauthorized()
        {
            return new HttpUnauthorizedResult();
        }
    }
}