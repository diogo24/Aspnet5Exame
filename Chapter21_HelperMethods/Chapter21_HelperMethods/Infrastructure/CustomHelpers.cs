using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter21_HelperMethods.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper htmlHelper, string[] items) {
            TagBuilder tag = new TagBuilder("ul");
            foreach (var str in items)
            {
                var li = new TagBuilder("li");
                li.SetInnerText(str);
                tag.InnerHtml += li.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }

        //public static string DisplayMessage(this HtmlHelper htmlHelper, string msg) {
        //    var result = String.Format("This is the message: <p>{0}</p>", msg);
        //    //return new MvcHtmlString(result);
        //    return result; 
        //}

        public static MvcHtmlString DisplayMessage(this HtmlHelper htmlHelper, string msg)
        {
            var encoded = htmlHelper.Encode(msg);
            var result = String.Format("This is the message: <p>{0}</p>", encoded);
            return new MvcHtmlString(result);
        }
    }
}