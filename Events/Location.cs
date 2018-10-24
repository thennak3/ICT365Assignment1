using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    public class Location
    {
        
        public double _lat { get; set; }

        public double _long {get; set;}

        public bool used { get; set; }

        public Location()
        {
            used = true;
        }

        public Location(double latitude, double longitude)
        {
            used = true;
            _lat = latitude;
            _long = longitude;
        }
    }
}
