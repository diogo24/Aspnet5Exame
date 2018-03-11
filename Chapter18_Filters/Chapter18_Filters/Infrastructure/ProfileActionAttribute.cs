using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter18_Filters.Infrastructure
{
    public class ProfileActionAttribute : FilterAttribute, IActionFilter
    {
        private Stopwatch timer;

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            timer.Stop();

            if (filterContext.Exception == null)
            {
                filterContext.HttpContext.Response.Write(
                    $"<div>Action method elapsed time: {timer.Elapsed.TotalSeconds.ToString("F6")}</div>"
                    );
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            timer = Stopwatch.StartNew();
        }
    }
}