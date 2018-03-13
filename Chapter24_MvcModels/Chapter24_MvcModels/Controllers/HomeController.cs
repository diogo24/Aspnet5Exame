using Chapter24_MvcModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter24_MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] _personData = {
             new Person {PersonId = 1, FirstName = "Adam", LastName = "Freeman",
             Role = Role.Admin},
             new Person {PersonId = 2, FirstName = "Jacqui", LastName = "Griffyth",
             Role = Role.User},
             new Person {PersonId = 3, FirstName = "John", LastName = "Smith",
             Role = Role.User},
             new Person {PersonId = 4, FirstName = "Anne", LastName = "Jones",
             Role = Role.Guest}
         };

        // GET: Home
        //public ActionResult Index(int id)
        //{
        //    Person person = _personData.Where(p => p.PersonId == id).First();
        //    return View(person);
        //}

        //public ActionResult Index(int? id)
        //{
        //    Person person = _personData.Where(p => p.PersonId == id).First();
        //    return View(person);
        //}

        public ActionResult Index(int id = 1)
        {
            Person person = _personData.Where(p => p.PersonId == id).First();
            return View(person);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            return View("Index", person);
        }

        public ActionResult DisplaySummary([Bind(Prefix = nameof(Person.HomeAddress), Exclude = nameof(AddressSummary.Country))]AddressSummary addressSummary)
        {
            return View(addressSummary);
        }

        public ActionResult Names(string[] names)
        {
            names = names ?? new string[0];
            return View(names);
        }

        public ActionResult Names_Collection(IList<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }

        public ActionResult Address(IList<AddressSummary> addresses)
        {
            addresses = addresses ?? new List<AddressSummary>();

            return View(addresses);
        }


        //public ActionResult Address_ManuallyInvokingModelBinding()
        //{
        //    IList<AddressSummary> addresses = new List<AddressSummary>();

        //    //UpdateModel(addresses);
        //    UpdateModel(addresses, new FormValueProvider(ControllerContext));

        //    return View(addresses);
        //}

        //public ActionResult Address_ManuallyInvokingModelBinding(FormCollection provider)
        //{
        //    IList<AddressSummary> addresses = new List<AddressSummary>();

        //    //UpdateModel(addresses);
        //    UpdateModel(addresses, provider);

        //    return View(addresses);
        //}

        //public ActionResult Address_ManuallyInvokingModelBinding(FormCollection formData)
        //{
        //    IList<AddressSummary> addresses = new List<AddressSummary>();

        //    //UpdateModel(addresses);
        //    //try
        //    //{
        //    //    UpdateModel(addresses, formData);
        //    //}
        //    //catch (InvalidOperationException)
        //    //{
        //    //    //throw;
        //    //    // provide feedback to user
        //    //}

        //    if (TryUpdateModel(addresses, formData))
        //    {
        //        // proceed as normal
        //    }
        //    else
        //    {
        //        // provide feedback to user
        //    }

        //    return View(addresses);
        //}

        public ActionResult Address_ManuallyInvokingModelBinding()
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();

            UpdateModel(addresses);
            //pdateModel(addresses, new FormValueProvider(ControllerContext));

            return View(addresses);
        }
    }
}