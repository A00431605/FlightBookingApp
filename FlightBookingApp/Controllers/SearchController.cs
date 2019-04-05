using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightBookingApp.Models;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;


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
            // refer: https://stackoverflow.com/questions/137660/where-does-console-writeline-go-in-asp-net

            System.Diagnostics.Debug.WriteLine("----------------");
            var from = search.from.ToString();
            var to = search.to.ToString();
            var fromtime = search.fromtime.ToString();

            // Run native query directly
            String connectionString = 
            SqlConnection connection = new SqlConnection(connetionString);

           String  sqlSentence = "select * from " + table + ";";
            Console.Write(sqlSentence);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlSentence, connection);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr.toString());
            }


                System.Diagnostics.Debug.WriteLine(search.from);
            System.Diagnostics.Debug.WriteLine(search.to);
            System.Diagnostics.Debug.WriteLine(search.fromtime);


            return View();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}