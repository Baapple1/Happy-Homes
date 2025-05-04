

using Happy_Homes;
using System.ComponentModel.Design;
using System.Numerics;
using System.Security.Cryptography;
using System.Transactions;


// Populate Classes:
Property.AddProperty(PropertyType.Detached, "Test Address");
Customer.AddCustomer("TestForename", "TestSurname", "test@email.com", "T3ST P0S7", "0174777362");
Staff testStaff1 = new Staff("TestForename1", "TestSurname1", StaffStatus.Available);
Staff testStaff2 = new Staff("TestForename2", "TestSurname2", StaffStatus.Available);

while (true)
{
    Console.WriteLine(@"[1] Properties
[2] Bookings
[3] Customers
[4] Staff
[5] Logout");
    var keyInput = Console.ReadKey();
    Console.Clear();

    // Properties Menu
    if (keyInput.Key == ConsoleKey.D1)
    {
        Console.WriteLine(@"[1] View Properties
[2] Add Property");
        keyInput = Console.ReadKey();
        Console.Clear();

        //View properties:
        if (keyInput.Key == ConsoleKey.D1)
        {
            Console.WriteLine("Existing Properties");
            Property.ViewProperties();  // Pulls from Properties Dictionary
            Console.WriteLine("[1] Filter by Address \nPush Key to Leave");
            keyInput = Console.ReadKey();
            Console.Clear();
            if (keyInput.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Enter the Address");
                string requestedAddress = Console.ReadLine();
                Property.FilterProperties(requestedAddress);
                Console.WriteLine("\nPush any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Add property:
        else if (keyInput.Key == ConsoleKey.D2)
        {
            // Selecting property type:
            Console.WriteLine(@"Select Property Type:
[1] Detached
[2] Semi-Detatched
[3] Bungalow
[4] Flat
[5] Terrace
[6] Enterprise");
            keyInput = Console.ReadKey();
            Console.Clear();

            // Detached
            if (keyInput.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Detached, address);
                Console.Clear();
                Console.WriteLine("Property Added\n");
            }
            // Semi-Detached
            else if (keyInput.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.SemiDetached, address);
                Console.Clear();
                Console.WriteLine("Property Added\n");
            }

            // Bungalow
            else if (keyInput.Key == ConsoleKey.D3)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Bungalow, address);
                Console.Clear();
                Console.WriteLine("Property Added\n");
            }

            // Flat
            else if (keyInput.Key == ConsoleKey.D4)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Flat, address);
                Console.Clear();
                Console.WriteLine("Property Added\n");
            }

            // Terrace
            else if (keyInput.Key == ConsoleKey.D5)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Terrace, address);
                Console.Clear();
                Console.WriteLine("Property Added\n");
            }

            // Enterprise
            else if (keyInput.Key == ConsoleKey.D6)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Enterprise, address);
                Console.Clear();
                Console.WriteLine("Property Added\n");
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input\n");
            }
        }
    }


    // Bookings Menu
    else if (keyInput.Key == ConsoleKey.D2)
    {
        Console.WriteLine(@"[1] View Bookings
[2] Add Booking
[3] Amend Status");
        keyInput = Console.ReadKey();
        Console.Clear();

        //View Bookings:
        if (keyInput.Key == ConsoleKey.D1)
        {
            Console.WriteLine("Existing Bookings:\n");
            Booking.ViewBooking();
            Console.WriteLine("\nPush any Key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        // Add Booking:
        else if (keyInput.Key == ConsoleKey.D2)
        {
            // Customer ID
            Console.WriteLine("Enter Customer ID:");
            string sCustomerID = Console.ReadLine();
            Console.Clear();
            if (int.TryParse(sCustomerID, out int customerID))
            {
                if (Customer.ValidateCustomer(customerID))   // Validate customerID && score != 3
                {
                    // Date
                    Console.WriteLine(@"Enter Date of Viewing:
DD/MM/YYYY");
                    string sDate = Console.ReadLine();
                    Console.Clear();
                    if (DateOnly.TryParse(sDate, out DateOnly date))
                    {
                        // Time
                        Console.WriteLine(@"Enter Time of Viewing:
HH:MM");
                        string sTime = Console.ReadLine();
                        Console.Clear();
                        if (TimeOnly.TryParse(sTime, out TimeOnly time))
                        {
                            // Property (address)
                            Console.WriteLine("Enter the Address of Viewing:");
                            string address = Console.ReadLine();
                            Console.Clear();
                            if (Property.ValidateProperty(address))   // Validate address
                            {
                                //  Staff ID
                                Console.WriteLine("Enter Staff ID:");
                                string sStaffID = Console.ReadLine();
                                Console.Clear();
                                if (int.TryParse(sStaffID, out int staffID))
                                {
                                    if (Staff.ValidateStaff(staffID))   // Validate StaffID && check Availability
                                    {

                                        var booking = new Booking(customerID, date, time, address, BookingStatus.Booked, staffID);
                                        Console.WriteLine($"New booking Created\n");
                                        // Set Staff to Unavailable
                                        var staffStatus = Staff.staffList.First(staff => staff.StaffID == staffID); // Searches for first corresponding staffID in list
                                        staffStatus.Status = StaffStatus.Unavailable;   // Sets staff to Unavailable
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid Staff\n");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Input\n");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Address\n");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input\n");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input\n");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Customer ID\n");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input\n");
            }
        }

        // Amend Booking:
        else if (keyInput.Key == ConsoleKey.D3)
        {
            Console.WriteLine("Enter Booking ID:");
            Console.Clear();
            if (int.TryParse(Console.ReadLine(), out int bookingID))
            {
                Console.WriteLine(@"Amend the Following:
[1] Booked
[2] Attended
[3] Missed
[4] Cancelled");

                keyInput = Console.ReadKey();
                if (keyInput.Key == ConsoleKey.D1)
                {
                    Booking.AmendBooking(bookingID, BookingStatus.Booked);
                }
                else if (keyInput.Key == ConsoleKey.D2)
                {
                    Booking.AmendBooking(bookingID, BookingStatus.Attended);
                }
                else if (keyInput.Key == ConsoleKey.D3)
                {
                    Booking.AmendBooking(bookingID, BookingStatus.Missed);
                }
                else if (keyInput.Key == ConsoleKey.D4)
                {
                    Booking.AmendBooking(bookingID, BookingStatus.Cancelled);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input\n");
            }
        }
    }

    // Customers Menu
    else if (keyInput.Key == ConsoleKey.D3)
    {
        Console.Clear();
        Console.WriteLine(@"[1] View Customers
[2] Add Customer
[3] Amend Customer
[4] Remove Customer");
        keyInput = Console.ReadKey();
        Console.Clear();

        //View Customers:
        if (keyInput.Key == ConsoleKey.D1)
        {
            Console.WriteLine("Existing Customers:\n");
            Customer.ViewCustomer();
            Console.WriteLine("[1] Filter by ID \nPush any key to continue");
            keyInput = Console.ReadKey();
            Console.Clear();
            if (keyInput.Key == ConsoleKey.D1)
            {
                Console.WriteLine("Enter the CustomerID:");
                string sRequestedCustomer = Console.ReadLine();
                int requestedCustomer = Convert.ToInt32(sRequestedCustomer);
                Customer.FilterCustomer(requestedCustomer);
                Console.WriteLine("\nPush any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Add Customer:
        else if (keyInput.Key == ConsoleKey.D2)
        {
            // CustomerForename
            Console.Clear();
            Console.WriteLine("Enter the Customer Forename:");
            string forename = Console.ReadLine();
            if (!string.IsNullOrEmpty(forename))
            {
                // CustomerSurname
                Console.Clear();
                Console.WriteLine("Enter the Customer Surname:");
                string surname = Console.ReadLine();
                if (!string.IsNullOrEmpty(surname))
                {
                    // Email
                    Console.Clear();
                    Console.WriteLine("Enter the Customer Email:");
                    string email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(email))
                    {
                        // Postal
                        Console.Clear();
                        Console.WriteLine("Enter the Customer Postal Address:");
                        string postal = Console.ReadLine();
                        if (!string.IsNullOrEmpty(postal))
                        {
                            // Phone
                            Console.Clear();
                            Console.WriteLine("Enter the Customer Phone Number:");
                            string phone = Console.ReadLine();
                            Console.Clear();
                            Customer.AddCustomer(forename, surname, email, postal, phone);
                            Console.WriteLine($"Customer Added: \n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input\n");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input\n");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Input\n");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input\n");
            }
        }
    }

    // Staff menu
    else if (keyInput.Key == ConsoleKey.D4)
    {
        // View Staff:
        Console.WriteLine("Existing Staff:");
        Staff.ViewStaff();  // Pulls from Staff List
        Console.WriteLine("\nPush Key to Leave");
        Console.ReadKey();
        Console.Clear();
    }

    // Logout
    else if (keyInput.Key == ConsoleKey.D5)
    {
        Environment.Exit(0);
    }

    else
    {
        Console.WriteLine("Invalid Input\n");
    }

}