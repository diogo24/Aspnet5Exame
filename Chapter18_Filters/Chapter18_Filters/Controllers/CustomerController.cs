using Chapter18_Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter18_Filters.Controllers
{
    [SimpleMessage(Message = "C")]
    public class CustomerController : Controller
    {
        public string Index()
        {
            return "This is the Customer controller";
        }

        [SimpleMessage(Message = "A", Order = 1)]
        [SimpleMessage(Message = "B", Order = 2)]
        public string Index_MultipleAttributes()
        {
            return "This is the Customer controller";
        }

        [SimpleMessage(Message = "D")]
        public string OtherAction()
        {
            return "This is the Other Action in the Customer controller";
        }

        [CustomOverrideActionFilters()]
        [SimpleMessage(Message = "E")]
        public string OtherAction_CustomOverrideActionFilters()
        {
            return "This is the Other Action in the Customer controller, OtherAction_CustomOverrideActionFilters";
        }
    }
}