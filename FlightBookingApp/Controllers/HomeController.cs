
﻿using FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
                    customerModel.LoginErrorMessage = "Please enter valid Username and Password";
                    return View("Login",customerModel);
                }
                Session["username"] = obj.customer_name;
                Session["userId"] = obj.customer_id;
                
                return RedirectToAction("Index");

            }
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
                ViewBag.SuccessMessage = "Registration Successful.";
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