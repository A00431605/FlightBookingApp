namespace FlightBookingApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FlightBookingEntity : DbContext
    {
        public FlightBookingEntity()
            : base("name=FlightBookingEntity")
        {
        }

        public virtual DbSet<customer_book> customer_book { get; set; }
        public virtual DbSet<passenger> passengers { get; set; }
        public virtual DbSet<airline> airlines { get; set; }
        public virtual DbSet<airport> airports { get; set; }
        public virtual DbSet<booking_details> booking_details { get; set; }
        public virtual DbSet<flight> flights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer_book>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<customer_book>()
                .Property(e => e.customer_emailaddress)
                .IsUnicode(false);

            modelBuilder.Entity<customer_book>()
                .Property(e => e.customer_password)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.passport_number)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.passenger_address)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.passenger_postalCode)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.passenger_Country)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.passenger_phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.passenger_emailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<passenger>()
                .Property(e => e.passenger_gender)
                .IsUnicode(false);

            modelBuilder.Entity<airline>()
                .Property(e => e.airline_name)
                .IsUnicode(false);

            modelBuilder.Entity<airport>()
                .Property(e => e.airport_name)
                .IsUnicode(false);

            modelBuilder.Entity<airport>()
                .Property(e => e.airport_short_code)
                .IsUnicode(false);

            modelBuilder.Entity<airport>()
                .Property(e => e.airport_country)
                .IsUnicode(false);

            modelBuilder.Entity<airport>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<booking_details>()
                .Property(e => e.payment)
                .IsUnicode(false);

            modelBuilder.Entity<booking_details>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<flight>()
                .Property(e => e.flight_no)
                .IsUnicode(false);

            modelBuilder.Entity<flight>()
                .Property(e => e.flight_from)
                .IsUnicode(false);

            modelBuilder.Entity<flight>()
                .Property(e => e.flight_to)
                .IsUnicode(false);

            modelBuilder.Entity<flight>()
                .Property(e => e.flight_timing_from)
                .IsUnicode(false);

            modelBuilder.Entity<flight>()
                .Property(e => e.flight_timing_to)
                .IsUnicode(false);
        }
    }
}
