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
        private int IncrementID = 1;
        public int BookingID { get; private set; }
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
            BookingID = IncrementID++; // Sets the Instance ID, then Increments
            CustomerID = customerID;
            Date = date;
            Time = time;
            Property = property;
            Status = status;
            StaffID = staffID;

            bookings.Add(this); // Adds this instance to the list automatically
        }

        // Methods

        public static void ViewBooking()
        {
            foreach (var booking in bookings) 
            {
                Console.WriteLine(@$"Booking ID: {booking.BookingID}
Customer ID: {booking.CustomerID}
Date: {booking.Date}
Time: {booking.Time}
Property: {booking.Property}
Status: {booking.Status}
Staff ID: {booking.StaffID}
-------------------------------");
            }
        }
        public static bool ValidateBooking(int bookingID)
        {
            return bookings.Any(booking => booking.BookingID == bookingID);
        }
        public static void AddBooking(int customerID, DateOnly date, TimeOnly time, string address, int staffID)
        {
            Booking newBooking = new Booking(customerID, date, time, address, BookingStatus.Booked, staffID);
        }
        public static void AmendBooking(int bookingID, BookingStatus newStatus)
        {
            bool found = false;
            foreach (var booking in bookings)
            {
                if (booking.BookingID == bookingID)
                {
                    booking.Status = newStatus;
                    
                    // Increase Customer Score if Missed
                    if (newStatus == BookingStatus.Missed)
                    {
                        var customer = Customer.customers.FirstOrDefault(customer => customer.CustomerID == booking.CustomerID);
                        if (customer != null)
                        {
                            customer.Score++;
                        }
                    }

                        Console.Clear();
                    Console.WriteLine("Booking status updated.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.Clear();
                Console.WriteLine("Booking ID not found.");
            }
        }
    }
}
