using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightBookingApp.Controllers
{
    public class SearchController : Controller
    {
        // POST:search available flights
        [HttpPost]
        public ActionResult Index()
        {
            return View("SearchPage");
        }
    }
}