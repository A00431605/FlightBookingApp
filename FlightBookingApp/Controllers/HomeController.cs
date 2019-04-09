

﻿using FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

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

       
        [HttpPost]
        public ActionResult Login(customer_book customerModel)
        {
            using (FlightBookingEntity db = new FlightBookingEntity())
            {
                var obj = db.customer_book.Where(x => x.customer_emailaddress == customerModel.customer_emailaddress && x.customer_password == customerModel.customer_password).FirstOrDefault();
                if (obj == null)
                {
                    customerModel.LoginErrorMessage = "Please enter valid Username or Password";
                    return View("Login",customerModel); 
                }


                Session["username"] = obj.customer_name;
                Session["userId"] = obj.customer_id;
        
                return RedirectToAction("Index");

            }
        }

 public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult AboutUS()
        {
            return View();
        }


        [HttpGet]

        public ActionResult ForgotPasswordView()
        {
            //using (FlightBookingEntity db = new FlightBookingEntity())
            //{
            //    return View(db.customer_book.Where(x => x.customer_emailaddress == customerModel.customer_emailaddress).FirstOrDefault());
            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPasswordView(customer_book customerModel)
        {
            String connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["FlightBookingEntity"].ConnectionString;
            SqlConnection connection = new SqlConnection(connetionString);

            FlightBookingEntity db = new FlightBookingEntity();
            var customerid = db.customer_book.Where(x => x.customer_emailaddress == customerModel.customer_emailaddress).Select(x => x.customer_id).FirstOrDefault();
            String sqlPattern = @"update customer_book set customer_password="+customerModel.customer_password +"where customer_id="+customerid;
            String sqlSentence = String.Format(sqlPattern);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlSentence, connection);
            command.ExecuteNonQuery();
            ViewData["message"] = "Password updated successfully.Go to Login Page!!!";
            return View();
        }

        [HttpGet]
        public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult signUp(customer_book customerModel1)
        {
                using (FlightBookingEntity db = new FlightBookingEntity())
                {
                    db.customer_book.Add(customerModel1);
                    db.SaveChanges();

                }
                ModelState.Clear();
                ViewData["message"] = "Successfully signed up.Go to Login Page!";
                customerModel1 = null;
           
         
                return View("signUp",new customer_book());
        } 

        public ActionResult signout()
        {
            Session["username"] = null;
            return RedirectToAction("Index");
        }


    } 

}