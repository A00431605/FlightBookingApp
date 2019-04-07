using FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightBookingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Search sd = new Search();
            FlightBookingEntity db = new FlightBookingEntity();
            List<airline> ob = db.airlines.ToList();

            return View(sd);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult signUp()
        {
            return View();
        }

      
        

    }
}