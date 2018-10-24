using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    internal class Facebook : Event
    {

        [EventLabel(Label = "Facebook Update")]
        [TextField]
        public string text { get; set; }

        [IgnoreField]
        public DateTime timestamp { get; set; }

        [TextField]
        [EventLabel(Label = "Facebook Permalink")]
        public string FacebookURI { get; set; }

        public Facebook(string eventID) : base(eventID)
        {
            timestamp = DateTime.Now;
            FacebookURI = "";
            text = "";

        }


    }

    class FacebookDataHandler : EventDataHandler
    {
        public FacebookDataHandler()
        {
            eventName = "facebook-status-update";
        }
        public override void Load(Event _event, Dictionary<string, string> data)
        {
            Facebook facebook = (Facebook)_event;

            //Test
            if (ValueDoesExist(data, "text"))
                facebook.text = data["text"];
            else
                facebook.text = "";

            //Location
            double tempd;
            facebook.Location = new Location();
            if (ValueDoesExist(data, "location\\lat"))
            {
                if (Double.TryParse(data["location\\lat"], out tempd))
                    facebook.Location._lat = tempd;
                else
                    facebook.Location._lat = 0;
            }
            else
                facebook.Location._lat = 0;

            if (ValueDoesExist(data, "location\\long"))
            {
                if (Double.TryParse(data["location\\long"], out tempd))
                    facebook.Location._long = tempd;
                else
                    facebook.Location._long = 0;
            }
            else
                facebook.Location._long = 0;

            //Date time stamp
            if (ValueDoesExist(data, "datetimestamp"))
            {
                DateTime temp;
                if (DateTime.TryParse(data["datetimestamp"], out temp))
                    facebook.timestamp = temp;
                else
                    facebook.timestamp = DateTime.Now;
            }
            else
                facebook.timestamp = DateTime.Now;

            //Facebook uri
            if (ValueDoesExist(data, "facebookuri"))
            {
                facebook.FacebookURI = data["facebookuri"];
            }
            else
                facebook.FacebookURI = "";
        }

        public override Dictionary<string, string> Save(Event @event)
        {
            Facebook facebook = (Facebook)@event;
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("text", facebook.text);
            data = MergeDictionary(data, ProcessSaveLocation(facebook.Location));
            data.Add("datetimestamp", facebook.timestamp.ToString());
            data.Add("facebookuri", facebook.FacebookURI.ToString());

            return data;
        }
    }
}
