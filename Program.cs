

using Happy_Homes;
using System.Numerics;
using System.Security.Cryptography;

while (true){

    // Login Sequence - Verify Staff & Determine Role

    // Staff
    // IF statement (StaffRole == Employee)
    if (/*StaffRole.Employee*/ true)
    {
        Console.WriteLine(@"[1] Properties
[2] Bookings
[3] Customers
[4] Logout");
        string sInput = Console.ReadLine();
        Console.Clear();
        bool success = int.TryParse(sInput, out int input);
        if (success && input >= 1 && input <= 4)
        {

            // Properties Menu
            if (input == 1)
            {
                Console.WriteLine(@"[1] View Properties
[2] Add Property");
                sInput = Console.ReadLine();
                Console.Clear();
                success = int.TryParse(sInput, out input);
                if (success)
                {
                    //View properties:
                    if (input == 1)
                    {
                        Console.WriteLine("Existing Properties:\n");
                        // Pull from Properties Class
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
                        success = int.TryParse(sInput, out input);
                        if (success && input >= 1 && input <= 6)
                        {
                            // Detached
                            if (input == 1)
                            {
                                Console.WriteLine("Enter the Property Address:");
                                string address = Console.ReadLine();
                                Property.AddProperty("Detached", address);
                            }
                            // Semi-Detached
                            else if (input == 2)
                            {
                                Console.WriteLine("Enter the Property Address:");
                                string address = Console.ReadLine();
                                Property.AddProperty("Semi-Detached", address);
                            }

                            // Bungalow
                            else if (input == 3)
                            {
                                Console.WriteLine("Enter the Property Address:");
                                string address = Console.ReadLine();
                                Property.AddProperty("Bungalow", address);
                            }

                            // Flat
                            else if (input == 4)
                            {
                                Console.WriteLine("Enter the Property Address:");
                                string address = Console.ReadLine();
                                Property.AddProperty("Flat", address);
                            }

                            // Terrace
                            else if (input == 5)
                            {
                                Console.WriteLine("Enter the Property Address:");
                                string address = Console.ReadLine();
                                Property.AddProperty("Terrace", address);
                            }

                            // Enterprise
                            else if (input == 6)
                            {
                                Console.WriteLine("Enter the Property Address:");
                                string address = Console.ReadLine();
                                Property.AddProperty("Enterprise", address);
                            }
                        }
                    }
                }
            }

            // Bookings Menu
            else if (input == 2)
            {
                Console.WriteLine(@"[1] View Bookings
[2] Add Booking");
                sInput = Console.ReadLine();
                Console.Clear();
                success = int.TryParse(sInput, out input);
                if (success)
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

                        // Date

                        // Time

                        // Property (address)

                        // Staff ID
                        Console.WriteLine("[2]"); // Test
                        Console.ReadKey();
                        Console.Clear();
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
                success = int.TryParse(sInput, out input);
                if (success)
                {
                    //View Customers:
                    if (input == 1)
                    {
                        Console.WriteLine("Existing Customers:\n");
                        // Pull from Customer Class
                        Console.WriteLine("\nPush Key to Leave");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    // Add Customer:
                    else if (input == 2)
                    {
                        // CustomerID

                        // CustomerForename

                        // CustomerSurname

                        // Email

                        // Postal

                        // Phone

                        Console.WriteLine("[2]"); // Test
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }


            // Logout
            else if (input == 4)
            {
                Console.WriteLine("[4]");  // Test
                Console.ReadKey();
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine("Invalid Entry\n");
        }
    }

    // Manager
    // ELSE IF statement (StaffRole == Manager)
    /*
    if (StaffRole.Manager)
            {
            Console.WriteLine(@"[1] Properties
    [2] Bookings
    [3] Customers
    [4] Staff
    [5] Logout");

            string sInput = Console.ReadLine();
            Console.Clear();
            bool success = int.TryParse(sInput, out int input);
            if (success && input >= 1 && input <= 5)
            {
                // Properties Menu
                if (input == 1)
                {
                    Console.WriteLine("1"); // Test
                }

                // Bookings Menu
                else if (input == 2)
                {
                    Console.WriteLine("2"); // Test
                }

                 // Customers Menu
                else if (input == 3)
                {
                    Console.WriteLine("3"); // Test
                }

                // Staff Menu
                else if (input == 4)
                {
                    Console.WriteLine("4"); // Test
                }

                // Logout
                else if (input == 5)
                {
                    Console.WriteLine("5"); // Test
                }
            }
        }*/

}
