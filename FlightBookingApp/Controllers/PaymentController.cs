using FlightBookingApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightBookingApp.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            Hashtable orderdetails = new Hashtable();
            orderdetails.Add("flight_id", 1);
            orderdetails.Add("airline_name", "WestJet Airlines");
            orderdetails.Add("flight_no", "WS 3452");
            orderdetails.Add("flight_from", "YHZ");
            orderdetails.Add("flight_to", "YUL");
            orderdetails.Add("operating_date_from", "2019-04-03");
            orderdetails.Add("operating_date_to", "2019-04-03");
            orderdetails.Add("flight_timing_from", "12:00");
            orderdetails.Add("flight_timing_to", "14:00");
            orderdetails.Add("class_type", "economy"); // or first
            orderdetails.Add("cost", 300);
            orderdetails.Add("qty", 2);
            orderdetails.Add("Totalcost", 300*2);

            //orderdetails.Add("firstclass_cost","600");

            /*
            Hashtable orderdetails1 = new Hashtable();
            orderdetails1 = new Hashtable();
            orderdetails1.Add("flight_id", "1");
            orderdetails1.Add("airline_name", "WestJet Airlines");
            orderdetails1.Add("flight_no", "WS 3452");
            orderdetails1.Add("flight_from", "YHZ");
            orderdetails1.Add("flight_to", "YUL");
            orderdetails1.Add("operating_date_from", "2019-04-03");
            orderdetails1.Add("operating_date_to", "2019-04-03");
            orderdetails1.Add("flight_timing_from", "12:00");
            orderdetails1.Add("flight_timing_to", "14:00");
            orderdetails1.Add("class_type", "first"); // or first
            //orderdetails1.Add("eco_cost", "300");
            orderdetails1.Add("cost",600*1); //firstclass_cost
            orderdetails1.Add("qty", "1");
            */

            List<Hashtable> orders = new List<Hashtable>();
            orders.Add(orderdetails);
            //orders.Add(orderdetails1);
            TempData["flight_details"] =  orders;
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(flight f)
        {
            Hashtable orderdetails = new Hashtable();
            // add flight_name
            orderdetails.Add("flight_id", f.flight_id);
            orderdetails.Add("airline_name", f.flight_name);
            orderdetails.Add("flight_no", "WS 3452");
            orderdetails.Add("flight_from", "YHZ");
            orderdetails.Add("flight_to", "YUL");
            orderdetails.Add("operating_date_from", "2019-04-03");
            orderdetails.Add("operating_date_to", "2019-04-03");
            orderdetails.Add("flight_timing_from", "12:00");
            orderdetails.Add("flight_timing_to", "14:00");
            orderdetails.Add("class_type", "economy"); // or first
            orderdetails.Add("cost", 300);
            orderdetails.Add("qty", 2);
            orderdetails.Add("Totalcost", 300 * 2);
            List<Hashtable> orders = new List<Hashtable>();
            orders.Add(orderdetails);
            //orders.Add(orderdetails1);
            TempData["flight_details"] = orders;

            return View();
        }

        [HttpPost]
        public ActionResult PaymentConfirmation(booking_details bd)
        {
            if (ModelState.IsValid)
            {
                // Reference : https://docs.microsoft.com/en-us/visualstudio/data-tools/insert-new-records-into-a-database?view=vs-2019
                //bd.cc.ToString();
                //bd.NameOnCC.ToString();
                //bd.cardType.ToString();
                //bd.expDate.ToString();
                String connetionString = System.Configuration.ConfigurationManager.AppSettings["fazal_connectionString"];
                //connetionString = "data source = DESKTOP - 5TD9BOD; initial catalog = FlightBookingApp; integrated security = True; MultipleActiveResultSets = True; App = EntityFramework";

                //System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connetionString);
                SqlConnection sqlConnection1 = new SqlConnection(connetionString);
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                string sqlPattern = "INSERT into booking_details (customer_id, flight_id, payment, qty, status) VALUES ({0},{1},{2},{3},{4})";
                cmd.CommandText = String.Format(sqlPattern, bd.customer_id, bd.flight_id, bd.payment, bd.qty, bd.status);
                cmd.Connection = sqlConnection1;
                System.Diagnostics.Debug.WriteLine(cmd.CommandText);
                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
            }
            return View(bd);
        }
    }
}