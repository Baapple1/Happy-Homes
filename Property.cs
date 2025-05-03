using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Happy_Homes
{
    public class Property
    {
        // Attributes
        public static Dictionary<PropertyType, string> properties { get; set; }

        // Methods
        public static void ViewProperties()
        {
            foreach (var property in properties)
            {
                Console.WriteLine(@$"{property.Value}: {property.Key}
-------------------------------");
            }    
        }
        public static void AddProperty(PropertyType type, string address)
        {
            // Add the Property to the Dictionary
            properties.Add(type, address);

        }
        public static bool ValidateProperty(string address)
        {
            return properties.Any(property => property.Value == address);   // Checks Properties Dictionary for matching address
        }
    }
}
