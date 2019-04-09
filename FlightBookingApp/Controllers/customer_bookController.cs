using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightBookingApp.Models;

namespace FlightBookingApp.Controllers
{
    public class customer_bookController : Controller
    {
        private FlightBookingEntity db = new FlightBookingEntity();

        // GET: customer_book
        public async Task<ActionResult> Index()
        {
            return View(await db.customer_book.ToListAsync());
        }

        // GET: customer_book/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_book customer_book = await db.customer_book.FindAsync(id);
            if (customer_book == null)
            {
                return HttpNotFound();
            }
            return View(customer_book);
        }

        // GET: customer_book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: customer_book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "customer_id,country,Gender,customer_name,birth_Date,customer_address,customer_phonenumber,customer_emailaddress,customer_postalcode,customer_password")] customer_book customer_book)
        {
            if (ModelState.IsValid)
            {
                db.customer_book.Add(customer_book);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer_book);
        }

        // GET: customer_book/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_book customer_book = await db.customer_book.FindAsync(id);
            if (customer_book == null)
            {
                return HttpNotFound();
            }
            return View(customer_book);
        }

        // POST: customer_book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "customer_id,country,Gender,customer_name,birth_Date,customer_address,customer_phonenumber,customer_emailaddress,customer_postalcode,customer_password")] customer_book customer_book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_book).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer_book);
        }

        // GET: customer_book/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_book customer_book = await db.customer_book.FindAsync(id);
            if (customer_book == null)
            {
                return HttpNotFound();
            }
            return View(customer_book);
        }

        // POST: customer_book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            customer_book customer_book = await db.customer_book.FindAsync(id);
            db.customer_book.Remove(customer_book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
