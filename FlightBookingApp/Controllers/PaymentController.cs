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
        public JsonResult Index1(flight f)
        {
            if (Session["username"] == null)
            {
                return Json(new { status = false });
            }
            else
            {
                Session["flight_id"] = f.flight_id;
                Hashtable orderdetails = new Hashtable();
                orderdetails.Add("flight_id", f.flight_id);
                orderdetails.Add("airline_name", f.airline_id);
                orderdetails.Add("flight_no", f.flight_no);
                orderdetails.Add("flight_from", f.flight_timing_from);
                orderdetails.Add("flight_to", f.flight_timing_to);
                orderdetails.Add("operating_date_from", f.operating_date_from);
                orderdetails.Add("operating_date_to", f.operating_date_to);
                orderdetails.Add("flight_timing_from", f.flight_timing_from);
                orderdetails.Add("flight_timing_to", f.flight_timing_to);
                orderdetails.Add("class_type", "economy"); // or first
                orderdetails.Add("cost", f.cost);
                //System.Diagnostics.Debug.WriteLine("qty is ");
                //System.Diagnostics.Debug.WriteLine(Session["qty"]);
                orderdetails.Add("qty", (int)Session["qty"]);
                // orderdetails.Add("Totalcost", f.cost * ((int)Session["qty"]));
                orderdetails.Add("Totalcost", f.cost * (int)Session["qty"]);



                List<Hashtable> orders = new List<Hashtable>();
                orders.Add(orderdetails);
                //orders.Add(orderdetails1);
                TempData["flight_details"] = orders;

                return Json(new { status = true });
            }
            //return View("Index");
        }

        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public JsonResult PassengerInsert(passenger p)
        {
            //p.passenger_id = (int)Session["username"];
            p.passenger_id = (int)Session["userId"];
            System.Diagnostics.Debug.WriteLine("passenger id is " + p.passenger_id);
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
                //cmd.ExecuteNonQuery();
                //int id = (int)cmd.ExecuteScalar();
                //System.Diagnostics.Debug.WriteLine(cmd.ExecuteScalar());
                JsonResult a = Json(new { status = true, pass_id = cmd.ExecuteScalar() });

                sqlConnection1.Close();
                return a;
            }
            catch (Exception e)
            {
                sqlConnection1.Close();
                System.Diagnostics.Debug.WriteLine(e.Message);
                return Json(new { status = false });
            }
        }


        [HttpPost]
        public ActionResult PaymentConfirmation(booking_details bd)
        {
            // Reference : https://docs.microsoft.com/en-us/visualstudio/data-tools/insert-new-records-into-a-database?view=vs-2019
            //connetionString = "data source = DESKTOP - 5TD9BOD; initial catalog = FlightBookingApp; integrated security = True; MultipleActiveResultSets = True; App = EntityFramework";

            //System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connetionString);
            SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;

            string sqlPattern = "INSERT into booking_details (customer_id, flight_id, payment, qty, status, passenger_id) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}'); SELECT SCOPE_IDENTITY()";
            cmd.CommandText = String.Format(sqlPattern, (int)Session["userId"], Session["flight_id"], bd.payment, bd.qty, "SUCCESS", bd.passenger_id);
            cmd.Connection = sqlConnection1;
            System.Diagnostics.Debug.WriteLine(cmd.CommandText);
            sqlConnection1.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                sqlConnection1.Close();
                return Json(new { status = true });
            }
            else
            {
                return Json(new { status = false });
            }
        }
    }
}