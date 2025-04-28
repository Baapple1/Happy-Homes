using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Homes
{
    public class Customer 
    {
        public int CustomerID { get; set; }
        public string CustomerForename {  get; set; }
        public string CustomerSurname { get; set; }
        private string Email { get; set; }
        private string Postal { get; set; }
        private string Phone {  get; set; }

        // Constructor
        public Customer(int customerID, string customerForename, string customerSurname, string email, string postal, string phone)
        {
            CustomerID = customerID;
            CustomerForename = customerForename;
            CustomerSurname = customerSurname;
            Email = email;
            Postal = postal;
            Phone = phone;
        }

        // Methods
    }
}
