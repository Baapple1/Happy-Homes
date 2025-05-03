using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Homes
{
    public class Customer 
    {
        // Attributes
        private static int IncrementID = 1; // Sets Instance ID, shared across instances
        public int CustomerID { get; private set; } // Stores the ID to unique instance, private set prevents overwriting
        public string CustomerForename {  get; set; }
        public string CustomerSurname { get; set; }
        private string Email { get; set; }
        private string Postal { get; set; }
        private int Phone {  get; set; }
        public int Score { get; set; }
        
        public static List<Customer> customers = new();
        // Constructor
        public Customer(string customerForename, string customerSurname, string email, string postal, int phone, int score)
        {
            CustomerID = IncrementID++; // Sets the Instance ID, then Increments
            CustomerForename = customerForename;
            CustomerSurname = customerSurname;
            Email = email;
            Postal = postal;
            Phone = phone;
            Score = score;

            customers.Add(this);    // Adds this instance to the list automatically
        }

        // Methods
        //Ammend
        //Remove
        //View Customers
        public static void ViewCustomer()
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(@$"Customer ID: {customer.CustomerID}
Forename: {customer.CustomerForename}
Surname: {customer.CustomerSurname}
Email: {customer.Email}
Postal: {customer.Postal}
Phone: {customer.Phone}
Score: {customer.Score}
-------------------------------");
            }
        }
        //Filter Customer (Name)
        //Score Increment
        //Block Booking
    }
}
