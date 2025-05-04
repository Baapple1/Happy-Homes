

using Happy_Homes;
using System.ComponentModel.Design;
using System.Numerics;
using System.Security.Cryptography;
using System.Transactions;


// Populate Classes:
Property.AddProperty(PropertyType.Detached, "Test Address");

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
[2] Add Property
[3] Amend Property
[4] Remove Property");
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
            else
            {
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
            }
            // Semi-Detached
            else if (keyInput.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.SemiDetached, address);
            }

            // Bungalow
            else if (keyInput.Key == ConsoleKey.D3)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Bungalow, address);
            }

            // Flat
            else if (keyInput.Key == ConsoleKey.D4)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Flat, address);
            }

            // Terrace
            else if (keyInput.Key == ConsoleKey.D5)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Terrace, address);
            }

            // Enterprise
            else if (keyInput.Key == ConsoleKey.D6)
            {
                Console.WriteLine("Enter the Property Address:");
                string address = Console.ReadLine();
                Property.AddProperty(PropertyType.Enterprise, address);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input");
            }
        }
    }


    // Bookings Menu
    else if (keyInput.Key == ConsoleKey.D2)
    {
        Console.WriteLine(@"[1] View Bookings
[2] Add Booking");
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
            Console.WriteLine("Enter Customer ID");
            string sCustomerID = Console.ReadLine();
            if (int.TryParse(sCustomerID, out int customerID))
            {
                if (Customer.ValidateCustomer(customerID))   // Validate customerID && score != 3
                {
                    // Date
                    Console.Clear();
                    Console.WriteLine("Enter Date of Viewing");
                    string sDate = Console.ReadLine();
                    if (DateOnly.TryParse(sDate, out DateOnly date))
                    {
                        // Time
                        Console.Clear();
                        Console.WriteLine("Enter Time of Viewing");
                        string sTime = Console.ReadLine();
                        if (TimeOnly.TryParse(sTime, out TimeOnly time))
                        {
                            // Property (address)
                            Console.Clear();
                            Console.WriteLine("Enter the Address of Viewing");
                            string address = Console.ReadLine();
                            if (Property.ValidateProperty(address))   // Validate address
                            {
                                //  Staff ID
                                Console.Clear();
                                Console.WriteLine("Enter Staff ID");
                                string sStaffID = Console.ReadLine();
                                if (int.TryParse(sStaffID, out int staffID))
                                {
                                    if (Staff.ValidateStaff(staffID))   // Validate StaffID && check Availability
                                    {
                                        Console.Clear();
                                        var booking = new Booking(customerID, date, time, address, BookingStatus.Booked, staffID);
                                        Console.WriteLine($"New booking Created: \n{booking}");
                                        // Set Staff to Unavailable
                                        var staffStatus = Staff.staffList.First(staff => staff.StaffID == staffID); // Searches for first corresponding staffID in list
                                        staffStatus.Status = StaffStatus.Unavailable;   // Sets staff to Unavailable

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid Staff");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Input");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Address");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Input");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Customer ID");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid Input");
            }
        }
    }

    // Customers Menu
    else if (keyInput.Key == ConsoleKey.D3)
    {
        Console.Clear();
        Console.WriteLine(@"[1] View Bookings
[2] Add Booking");
        keyInput = Console.ReadKey();
        Console.Clear();

        //View Customers:
        if (keyInput.Key == ConsoleKey.D1)
        {
            Console.WriteLine("Existing Customers:\n");
            Customer.ViewCustomer();
            Console.WriteLine("\nPush any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        // Add Customer:
        else if (keyInput.Key == ConsoleKey.D2)
        {
            // CustomerForename
            Console.WriteLine("Enter the Customer Forename:");
            string forename = Console.ReadLine();
            if (!string.IsNullOrEmpty(forename))
            {
                // CustomerSurname
                Console.WriteLine("Enter the Customer Surname");
                string surname = Console.ReadLine();
                if (!string.IsNullOrEmpty(surname))
                {
                    // Email
                    Console.WriteLine("Enter the Customer Email");
                    string email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(email))
                    {
                        // Postal
                        Console.WriteLine("Enter the Customer Postal Address");
                        string postal = Console.ReadLine();
                        if (!string.IsNullOrEmpty(postal))
                        {
                            // Phone
                            Console.WriteLine("Enter the Customer Phone Number");
                            string sPhone = Console.ReadLine();
                            if (int.TryParse(sPhone, out int phone))
                            {
                                Console.WriteLine("Customer Added");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
    }

    // Staff menu
    else if (keyInput.Key == ConsoleKey.D4)
    {
        // View Staff:
        Console.WriteLine("Existing Properties");
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