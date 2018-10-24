using Assignment1.Events;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    public abstract class Event
    {
        
        private string _eventid;

        [IgnoreField]
        public Location Location { get; set; }

        public void SetLocation(double lat, double _long)
        {
            Location = new Location(lat, _long);
        }




        public Event(string eventID)
        {
            _eventid = eventID;
        }

        [IgnoreField]
        public string Eventid {
            get { return _eventid; }
            protected set { Eventid = value; }
        }





    }


}
