using FlightBookingApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace FlightBookingApp.Controllers
{ 
    public class PaymentController : Controller
    {
        public String connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FlightBookingEntity"].ConnectionString;

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
            orderdetails.Add("airline_name", f.flight_id);
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
        public JsonResult PassengerInsert(passenger p)
        {
            //p.passenger_id = (int)Session["username"];
            p.passenger_id = 1;
            System.Diagnostics.Debug.WriteLine("passenger id is "+p.passenger_id);
            System.Diagnostics.Debug.WriteLine(p.GetType());
             SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;

                string sqlPattern = "INSERT into passenger ([passport_number], [passenger_address], [passenger_postalCode], [passenger_Country]," +
                    "[passenger_phoneNumber],[passenger_emailAddress],[passenger_DOB],[passenger_gender],[passenger_name],[passport_expiry])" +
                    " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'); SELECT SCOPE_IDENTITY()";
                cmd.CommandText = String.Format(sqlPattern, p.passport_number, p.passenger_address, p.passenger_postalCode, p.passenger_Country,
                    p.passenger_phoneNumber, p.passenger_emailAddress, p.passenger_DOB, p.passenger_gender, p.passenger_name, p.passenger_expiry);
                cmd.Connection = sqlConnection1;
                System.Diagnostics.Debug.WriteLine(cmd.CommandText);
                sqlConnection1.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        //int id = (int)cmd.ExecuteScalar();
                        System.Diagnostics.Debug.WriteLine(cmd.ExecuteScalar());
                        return Json( new {status = true, pass_id = cmd.ExecuteScalar() });
                    }
                    catch(Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                        return Json( new {status = false});
                    }
                sqlConnection1.Close();
        }


        [HttpPost]
        public ActionResult PaymentConfirmation(booking_details bd)
        {
            if (ModelState.IsValid)
            {
                // Reference : https://docs.microsoft.com/en-us/visualstudio/data-tools/insert-new-records-into-a-database?view=vs-2019
                //connetionString = "data source = DESKTOP - 5TD9BOD; initial catalog = FlightBookingApp; integrated security = True; MultipleActiveResultSets = True; App = EntityFramework";

                //System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connetionString);
                SqlConnection sqlConnection1 = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
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