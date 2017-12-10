using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Chapter4_LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength() {
            HttpClient client = new HttpClient();

            var httpTask = client.GetAsync("http://appress.com");

            // we could do other things here while we are waiting
            // for the HTTP request to complete

            return httpTask.ContinueWith((Task<HttpResponseMessage> antecedent) => {
                return antecedent.Result.Content.Headers.ContentLength;
            });
        }

        public static async Task<long?> GetPageLengthAsync()
        {
            HttpClient client = new HttpClient();

            var httpMessage = await client.GetAsync("http://appress.com");

             return httpMessage.Content.Headers.ContentLength;
        }
    }
}