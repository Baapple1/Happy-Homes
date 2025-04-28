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
        public int StaffID;
        public string StaffForename { get; set; }
        public string StaffSurname { get; set; }
        private StaffRole Role { get; set; }

        // Constructor
        public Staff(int staffID, string staffForename, string staffSurname, StaffRole role)
        {
            StaffID = staffID;
            StaffForename = staffForename;
            StaffSurname = staffSurname;
            Role = role;
        }

        // Method

    }
}
