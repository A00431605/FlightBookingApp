using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightBookingApp.Models;
using System.Net;
using System.Net.Http;
using System.Web;


namespace FlightBookingApp.Controllers
{
    public class SearchController : Controller
    {
        // POST:search available flights
        
        /**public ActionResult Index(object form)
        {
            Console.WriteLine(form);
            return View();
        }**/

        [HttpPost]
        public ActionResult Index(Search search)
        {
            // Console.WriteLine("search is :");
            System.Diagnostics.Debug.WriteLine("----------------");
            System.Diagnostics.Debug.WriteLine(search.Status);


            return View();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}