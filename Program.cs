

using Happy_Homes;
using System.ComponentModel.Design;
using System.Numerics;
using System.Security.Cryptography;
using System.Transactions;

while (true)
{
    Console.WriteLine(@"[1] Properties
[2] Bookings
[3] Customers
[4] Staff
[4] Logout");
    string sInput = Console.ReadLine();
    Console.Clear();
    if (int.TryParse(sInput, out int input) && input >= 1 && input <= 5)
    {

        // Properties Menu
        if (input == 1)
        {
            Console.WriteLine(@"[1] View Properties
[2] Add Property
[3] Amend Property
[4] Remove Property");
            sInput = Console.ReadLine();
            Console.Clear();
            if (int.TryParse(sInput, out input))
            {
                //View properties:
                if (input == 1)
                {
                    Console.WriteLine("Existing Properties");
                    Property.ViewProperties();  // Pulls from Properties Dictionary
                    Console.WriteLine("\nPush Key to Leave");
                    Console.ReadKey();
                    Console.Clear();
                }
                // Add property:
                else if (input == 2)
                {
                    // Selecting property type:
                    Console.WriteLine(@"Select Property Type:
[1] Detached
[2] Semi-Detatched
[3] Bungalow
[4] Flat
[5] Terrace
[6] Enterprise");
                    sInput = Console.ReadLine();
                    Console.Clear();
                    if (int.TryParse(sInput, out input))
                    {
                        // Detached
                        if (input == 1)
                        {
                            Console.WriteLine("Enter the Property Address:");
                            string address = Console.ReadLine();
                            Property.AddProperty(PropertyType.Detached, address);
                        }
                        // Semi-Detached
                        else if (input == 2)
                        {
                            Console.WriteLine("Enter the Property Address:");
                            string address = Console.ReadLine();
                            Property.AddProperty(PropertyType.SemiDetached, address);
                        }

                        // Bungalow
                        else if (input == 3)
                        {
                            Console.WriteLine("Enter the Property Address:");
                            string address = Console.ReadLine();
                            Property.AddProperty(PropertyType.Bungalow, address);
                        }

                        // Flat
                        else if (input == 4)
                        {
                            Console.WriteLine("Enter the Property Address:");
                            string address = Console.ReadLine();
                            Property.AddProperty(PropertyType.Flat, address);
                        }

                        // Terrace
                        else if (input == 5)
                        {
                            Console.WriteLine("Enter the Property Address:");
                            string address = Console.ReadLine();
                            Property.AddProperty(PropertyType.Terrace, address);
                        }

                        // Enterprise
                        else if (input == 6)
                        {
                            Console.WriteLine("Enter the Property Address:");
                            string address = Console.ReadLine();
                            Property.AddProperty(PropertyType.Enterprise, address);
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input");
                    }
                }
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid Input");
        }
    }

    // Bookings Menu
    else if (input == 2)
    {
        Console.WriteLine(@"[1] View Bookings
[2] Add Booking");
        sInput = Console.ReadLine();
        Console.Clear();
        if (int.TryParse(sInput, out input))
        {
            //View Bookings:
            if (input == 1)
            {
                Console.WriteLine("Existing Bookings:\n");
                // Pull from Bookings Class
                Console.WriteLine("\nPush Key to Leave");
                Console.ReadKey();
                Console.Clear();
            }
            // Add Booking:
            else if (input == 2)
            {
                // Customer ID
                Console.WriteLine("Enter Customer ID");
                string sCustomerID = Console.ReadLine();
                if (int.TryParse(sCustomerID, out int customerID))
                {
                    if ()   //  If Customer ID matches && score != 3
                    {
                        // Date
                        Console.Clear();
                        Console.WriteLine("Enter Date of Viewing");
                        string sDate = Console.ReadLine();
                        if (DateOnly.TryParse(sDate, out DateOnly date))
                        {
                            // Time
                            Console.WriteLine("Enter Time of Viewing");
                            string sTime = Console.ReadLine();
                            if (TimeOnly.TryParse(sTime, out TimeOnly time))
                            {
                                // Property (address)
                                Console.WriteLine("Enter the Address of Viewing");
                                string address = Console.ReadLine();
                                if ()   // Valid Address 
                                {
                                    //  Staff ID
                                    Console.WriteLine("Enter Staff ID");
                                    string sStaffID = Console.ReadLine();
                                    if (int.TryParse(sStaffID, out int staffID))
                                    {
                                        if ()   // Valid StaffID && Available
                                        {
                                            var booking = new Booking(customerID, date, time, address, BookingStatus.Booked, staffID);
                                            Console.WriteLine($"New booking Created: \n{booking}");
                                            // Set Staff to Unavailable
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

    }

    // Customers Menu
    else if (input == 3)
    {
        Console.WriteLine(@"[1] View Bookings
[2] Add Booking");
        sInput = Console.ReadLine();
        Console.Clear();
        if (int.TryParse(sInput, out input))
        {
            //View Customers:
            if (input == 1)
            {
                Console.WriteLine("Existing Customers:\n");
                Customer.ViewCustomer();
                Console.WriteLine("\nPush Key to Leave");
                Console.ReadKey();
                Console.Clear();
            }
            // Add Customer:
            else if (input == 2)
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
        //Staff menu
        else if (input == 4)
        {
            Console.WriteLine("Existing Properties");
            Staff.ViewStaff();  // Pulls from Staff List
            Console.WriteLine("\nPush Key to Leave");
            Console.ReadKey();
            Console.Clear();
        }

        // Logout
        else if (input == 5)
        {
            Environment.Exit(0);
        }

        else
        {
            Console.WriteLine("Invalid Input\n");
        }
    }
}