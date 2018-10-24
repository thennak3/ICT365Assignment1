using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    abstract class EventDataHandler
    {
        protected bool ValueDoesExist(Dictionary<string, string> dictionary, string value)
        {
            if (dictionary.ContainsKey(value))
                return true;
            return false;
        }

        protected Location ProcessLoadLocation(Dictionary<string,string> data)
        {
            Location loc = new Location();
            double tempd;
            if (ValueDoesExist(data, "location\\lat"))
            {
                if (Double.TryParse(data["location\\lat"], out tempd))
                    loc._lat = tempd;
                else
                    loc._lat = 0;
            }
            else
                loc._lat = 0;

            if (ValueDoesExist(data, "location\\long"))
            {
                if (Double.TryParse(data["location\\long"], out tempd))
                    loc._long = tempd;
                else
                    loc._long = 0;
            }
            else
                loc._long = 0;
            return loc;
        }

        protected Dictionary<string,string> MergeDictionary(Dictionary<string,string> dictionary1,Dictionary<string,string> dictionary2)
        {
            return dictionary1.Concat(dictionary2).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        protected Dictionary<string,string> ProcessSaveLocation(Location location)
        {
            Dictionary<string, string> locdata = new Dictionary<string, string>();

            locdata.Add("location\\long", location._long.ToString());
            locdata.Add("location\\lat", location._lat.ToString());


            return locdata;
        }

        public string eventName;

        public abstract void Load(Event _event, Dictionary<string,string> data);
        public abstract Dictionary<string, string> Save(Event @event);
    }
}
