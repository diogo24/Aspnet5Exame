﻿using Chapter21_HelperMethods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter21_HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] _personData = {
             new Person {FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
             new Person {FirstName = "Jacqui", LastName = "Griffyth", Role = Role.User},
             new Person {FirstName = "John", LastName = "Smith", Role = Role.User},
             new Person {FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
         };        
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetPeople()
        //{
        //    return View(_personData);
        //}

        //[HttpPost]
        //public ActionResult GetPeople(string selectedRole)
        //{
        //    if (string.IsNullOrEmpty(selectedRole) || selectedRole == "All")
        //    {
        //        return View(_personData);
        //    }
        //    else
        //    {
        //        Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
        //        var list = _personData.Where(p => p.Role == selected);
        //        return View(list);
        //    }
        //}

        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                var list = _personData.Where(p => p.Role == selected);
                return PartialView(list);
            }

            return PartialView(_personData);
        }

        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }
    }
}