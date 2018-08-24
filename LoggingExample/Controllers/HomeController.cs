using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoggingExample.Models;
using Serilog;

namespace LoggingExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {




            return View();
        }

        public IActionResult About()
        {
            Employee e = new Employee() {
                EmployeeID = 1234324,
                LastName = "Sheley",
                FirstName = "Andrew",
                StreetAddress1 = "1234 Main St.",
                City = "Beverly Hills",
                State = "CA",
                ZipCode = "90210",
                PhoneNumber = "555-222-3333",
            };


            try
            {
                int x1 = 3;
                int x2 = 0;
                int x3 = x1 / x2;
            }
            catch (Exception exx)
            {
                Log.Error(exx, exx.StackTrace);


                Log.Fatal(exx.Message, exx, exx.StackTrace);
                throw;
            }

            Log.Information("Contact {@contactId} not found", e);
            

            Exception ex = new Exception("Oh my god something went wrong. . . . . . .");
            Log.Error(ex, ex.Message);

            Log.Fatal(ex.Message, ex, ex.Source, ex.ToString(), ex.StackTrace);
            Log.Error(ex.Message, ex, ex.Source, ex.ToString(), ex.StackTrace);



            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }



    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }

    }


}
