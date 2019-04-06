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
using System.Collections.ObjectModel;

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
            String connetionString = System.Configuration.ConfigurationManager.AppSettings["h_wang_connectionString"];
            //var from = search.from.ToString();
            //var to = search.to.ToString();
            //var fromtime = search.fromtime.ToString();
            // var totime = search.fromtime.ToString();

            var people_count = Int32.Parse(search.people_count.ToString());
            var airline_choice = search.airline_choice.ToString();
            if (airline_choice == "-1")
            {
                // no airline select
                airline_choice = "airline_name";
            }
            else
            {
                airline_choice = String.Format("'{0}'", airline_choice);
            }
            var price_range = search.price_range.ToString();
            int start_price = 0;
            int end_price = 0;
            switch (price_range)
            {
                case "-1":
                    start_price = 0;
                    end_price = 2147483647;
                    break;
                case "0":
                    start_price = 0;
                    end_price = 300;
                    break;
                case "1":
                    start_price = 300;
                    end_price = 500;
                    break;
                case "2":
                    start_price = 500;
                    end_price = 2147483647;
                    break;
                default:
                    break;

            }
            System.Diagnostics.Debug.WriteLine("startPrice is ");
            System.Diagnostics.Debug.WriteLine(start_price);

            // TODO add exception handle about from->to wrong location
            // https://stackoverflow.com/questions/18098136/render-error-view-when-we-encounter-an-exception

            var from = "YHZ";
            var to = "YUL";
            var fromtime = "2019-04-03";
            var totime = "";
            try
            {
                totime = search.totime.ToString();

            }
            catch (NullReferenceException ex)
            {
                totime = fromtime;
            }

            totime = "2019-04-04";


            // Run native query directly

            SqlConnection connection = new SqlConnection(connetionString);

            String sqlPattern = @"select C.*,D.airline_name
from(SELECT A.* FROM flight as A 
where A.flight_from = '{0}' and A.flight_to = '{1}'
and
A.operating_date_from = '{2}' and A.operating_date_to='{3}'
) as C
join
airline as D
on C.airline_id=D.airline_id
where D.airline_name={4} and 
C.cost between {5} and {6}
and (C.total_seats-C.seats_booked>={7})
order by C.flight_timing_from;";
            String sqlSentence = String.Format(sqlPattern, from, to, fromtime, totime, airline_choice, start_price, end_price, people_count);
            System.Diagnostics.Debug.WriteLine(sqlSentence);

            Console.WriteLine(sqlSentence);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlSentence, connection);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<DataRow> searchResults = dt.AsEnumerable().ToList();

            foreach (DataRow dr in dt.Rows)
            {
                //System.Diagnostics.Debug.WriteLine(dr["flight_from"].ToString());
                //System.Diagnostics.Debug.WriteLine(dr.ItemArray.ToString());

            }


            System.Diagnostics.Debug.WriteLine(search.from);
            System.Diagnostics.Debug.WriteLine(search.to);
            System.Diagnostics.Debug.WriteLine(search.fromtime);


            return View("ShowSearchResult", dt);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
