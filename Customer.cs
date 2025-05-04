using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static System.Net.Mime.MediaTypeNames;

namespace Happy_Homes
{
    public class Customer
    {
        // Attributes
        private static int IncrementID = 1; // Sets Instance ID, shared across instances
        public int CustomerID { get; private set; } // Stores the ID to unique instance, private set prevents overwriting
        public string CustomerForename { get; set; }
        public string CustomerSurname { get; set; }
        private string Email { get; set; }
        private string Postal { get; set; }
        private int Phone { get; set; }
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
        public static bool ValidateCustomer(int customerID)
        {
            return customers.Any(customer => customer.CustomerID == customerID && customer.Score != 3); // Blocks Booking if score == 3
        }
        public static void FilterCustomer(int requestedCustomer)
        {
            bool found = false;
            foreach (var customer in customers)
            {
                if (customer.CustomerID == requestedCustomer)
                {
                    Console.Clear();
                    Console.WriteLine($@"Customer ID: {customer.CustomerID}
Forename: {customer.CustomerForename}
Surname: {customer.CustomerSurname}
Email: {customer.Email}
Postal: {customer.Postal}
Phone: {customer.Phone}
Score: {customer.Score}
-------------------------------

Press any key to continue");
                    found = true;
                }

            }
            if (!found)
            {
                Console.Clear();
                Console.WriteLine("Not Found");
            }
        }
        public static void AddCustomer(string forename, string surname, string email, string postal, int phone)
        {
            Customer newCustomer = new Customer(forename, surname, email, postal, phone, 0);
        }
        public static void AmendCustomer()
        {

        }
        public static void DeleteCustomer(int customerID)
        {

        }

        //Filter Customer (Name)
        //Score Increment
        //Block Booking
    }
}
