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

        [HttpPost]
        public ActionResult Index(Search search)
        {
            DataTable dt = new DataTable();
            String connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["FlightBookingEntity"].ConnectionString;
            SqlConnection connection = new SqlConnection(connetionString);
            // refer: https://stackoverflow.com/questions/137660/where-does-console-writeline-go-in-asp-net
            if (ModelState.IsValid)
            {

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

                // TODO add exception handle about from->to wrong location
                // https://stackoverflow.com/questions/18098136/render-error-view-when-we-encounter-an-exception

                var from = search.from.ToString();
                var to = search.to.ToString();
                var fromtime = search.fromtime.ToString();
                var totime = "";
                try
                {
                    totime = search.totime.ToString();

                }
                catch (NullReferenceException ex)
                {
                    totime = fromtime;
                }

                

                String sqlPattern = @"select C.*,D.airline_name from(SELECT A.* FROM flight as A  where A.flight_from = '{0}' and A.flight_to = '{1}'and A.operating_date_from = '{2}' and A.operating_date_to='{3}') as C join airline as D on C.airline_id=D.airline_id where D.airline_name={4} and C.cost between {5} and {6} and (C.total_seats-C.seats_booked>={7}) order by C.flight_timing_from;";
                String sqlSentence = String.Format(sqlPattern, from, to, fromtime, totime, airline_choice, start_price, end_price, people_count);

                connection.Open();
                SqlCommand command = new SqlCommand(sqlSentence, connection);

                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dt);
            }
            return View("SearchPage", dt);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}