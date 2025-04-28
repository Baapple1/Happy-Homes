using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Homes
{
    public class Booking
    {
        public int CustomerID { get; set; }
        public string Date { get; set; }
        public string Time {  get; set; }
        public string Property {  get; set; }
        public int StaffID { get; set; }

        // Constructor
        public Booking(int customerID, string date, string time, string property, int staffID) 
        { 
            CustomerID = customerID;
            Date = date;
            Time = time;
            Property = property;
            StaffID = staffID;
        }

        // Methods
    }
}
