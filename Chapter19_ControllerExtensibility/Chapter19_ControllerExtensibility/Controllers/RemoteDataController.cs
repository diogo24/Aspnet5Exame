using Chapter19_ControllerExtensibility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Chapter19_ControllerExtensibility.Controllers
{
    public class RemoteDataController : Controller
    {
        // GET: RemoteData
        public ActionResult Data()
        {
            RemoteService service = new RemoteService();
            string data = service.GetRemoteData();
            return View((object)data);
        }

        public async Task<ActionResult> Data_Asynchronous()
        {
            RemoteService service = new RemoteService();
            string data = await service.GetRemoteDataAsync();
            return View("Data", (object)data);
        }
    }
}