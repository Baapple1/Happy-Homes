using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Homes
{
    public class Staff
    {
        // Attributes
        private static int IncrementID = 1; // Sets Instance ID, shared across instances
        public int StaffID { get; private set; }    // Stores the ID to unique instance, private set prevents overwriting
        public string StaffForename { get; set; }
        public string StaffSurname { get; set; }
        public StaffStatus Status { get; set; }

        public static List<Staff> staff = new();

        // Constructor
        public Staff(int staffID, string staffForename, string staffSurname, StaffStatus status)
        {
            StaffID = IncrementID++;    // Sets the Instance ID, then Increments
            StaffForename = staffForename;
            StaffSurname = staffSurname;
            Status = status;

            staff.Add(this);    // Adds this instance to the list automatically
        }

        // Methods
        public static void ViewStaff()
        {
            foreach (var staff in staff)
            {
                Console.WriteLine(@$"Staff ID: {staff.StaffID}
Forename: {staff.StaffForename}
Surname: {staff.StaffSurname}
Status: {staff.Status}
-------------------------------");
            }
        }
    }
}
