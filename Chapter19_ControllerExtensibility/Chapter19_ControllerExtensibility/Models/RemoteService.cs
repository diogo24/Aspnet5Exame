using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Chapter19_ControllerExtensibility.Models
{
    public class RemoteService
    {
        internal string GetRemoteData()
        {
            Thread.Sleep(3000);
            return "Hello from the other side of the world";
        }

        internal async Task<string> GetRemoteDataAsync()
        {
            return await Task<string>.Factory.StartNew(() => {
                Thread.Sleep(3000);
                return "Hello from the other side of the world async";
            }) ;
        }
    }
}