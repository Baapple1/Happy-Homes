using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Happy_Homes
{
    public class Property
    {
        public string Detached {  get; set; }
        public string SemiDetatched { get; set; }
        public string Bungalow { get; set; }
        public string Flat {  get; set; }
        public string Terrace {  get; set; }
        public string Enterprise { get; set; }

        // Constructor
        public Property(string detached, string semiDetatched, string bungalow, string flat, string terrace, string enterprise)
        {
            Detached = detached;
            SemiDetatched = semiDetatched;
            Bungalow = bungalow;
            Flat = flat;
            Terrace = terrace;
            Enterprise = enterprise;
        }

        // Methods
    }
}
