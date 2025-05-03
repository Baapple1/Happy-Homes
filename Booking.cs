using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Homes
{
    public class Booking
    {
        // Attributes
        public int CustomerID { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string Property { get; set; }
        public BookingStatus Status { get; set; }
        public int StaffID { get; set; }
        
        public static List<Booking> bookings = new();

        // Constructor
        public Booking(int customerID, DateOnly date, TimeOnly time, string property, BookingStatus status, int staffID)
        {
            CustomerID = customerID;
            Date = date;
            Time = time;
            Property = property;
            Status = status;
            StaffID = staffID;

            bookings.Add(this); // Adds this instance to the list automatically
        }

        // Methods
            // Pull CustomerID
            // Pull StaffID
            // Set Date
            // Set Time
            // Pull Status
            // Pull Property

        public static void ViewBooking()
        {
            foreach (var booking in bookings) 
            {
                Console.WriteLine(@$"Customer ID: {booking.CustomerID}
Date: {booking.Date}
Time: {booking.Time}
Property: {booking.Property}
Status: {booking.Status}
Staff ID: {booking.StaffID}
-------------------------------");
            }
        }
    }
}
