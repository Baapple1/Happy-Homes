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
        public static Dictionary<PropertyType, List<string>> properties { get; set; } = new();

        // Methods
        public static void ViewProperties()
        {
            foreach (var property in properties)
            {
                foreach (var address in property.Value)
                {
                    Console.WriteLine(@$"{address}: {property.Key}
-------------------------------");
                }
            }
        }
        public static void AddProperty(PropertyType type, string address)
        {
            if (!properties.ContainsKey(type))
            {
                properties[type] = new List<string>();
            }

            properties[type].Add(address);
        }
        public static bool ValidateProperty(string address)
        {
            return properties.Any(property => property.Value.Contains(address));
        }
        public static void FilterProperties(string requestedAddress)
        {
            bool found = false;
            foreach (var property in properties)
            {
                foreach (var address in property.Value)
                {
                    if (address == requestedAddress)
                    {
                        Console.Clear();
                        Console.WriteLine($@"{address}: {property.Key}

Press any key to continue");
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.Clear();
                Console.WriteLine("Not Found");
            }
        }
    }
}
