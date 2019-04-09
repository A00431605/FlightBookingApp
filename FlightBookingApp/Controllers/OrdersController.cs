using FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightBookingApp.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        // GET: Orders
       
        public ActionResult Index()
        {
            String connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["FlightBookingEntity"].ConnectionString;
            SqlConnection connection = new SqlConnection(connetionString);
            DataTable dt = new DataTable();
            if (Session["username"] == null)
            {
                Response.Redirect("~/Home/Login");
            }
            else
            {
                String sqlPattern = @"select bd.booking_id,fl.flight_no,flight_from,fl.flight_to,flight_timing_from,flight_timing_to,payment,status from booking_details bd join flight fl on fl.flight_id = bd.flight_id where bd.customer_id =" + Session["userid"].ToString();
                String sqlSentence = String.Format(sqlPattern);

                connection.Open();
                SqlCommand command = new SqlCommand(sqlSentence, connection);
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dt);
            }
            return View("Index", dt);

        }
       
        public ActionResult OrderCancel()
        {
            
            return View();
        }
        public JsonResult updateCancel(string bookingid)
        {
            String connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["FlightBookingEntity"].ConnectionString;
            SqlConnection connection = new SqlConnection(connetionString);

            String sqlPattern = @"Update dbo.booking_details set status = 'Cancelled' where booking_id = " + bookingid;
            String sqlSentence = String.Format(sqlPattern);

            connection.Open();
            SqlCommand command = new SqlCommand(sqlSentence, connection);
            int com = 0;
            com = command.ExecuteNonQuery();
            var redirectUrl = new UrlHelper(Request.RequestContext).Action( "Orders", "OrderCancel");
            return Json(new { Url = redirectUrl });

        }

    }
}