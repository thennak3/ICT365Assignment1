using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    internal class MetFriend : Event
    {

        [EventLabel(Label = "Friend")]
        [TextField]
        public string friend { get; set; }

        [IgnoreField]
        public DateTime timestamp { get; set; }

        public MetFriend(string eventID) : base(eventID)
        {
            timestamp = DateTime.Now;
            friend = "";

        }


    }

    class MetFriendDataHandler : EventDataHandler
    {
        public MetFriendDataHandler()
        {
            eventName = "friendmeeting";
        }
        public override void Load(Event _event, Dictionary<string, string> data)
        {
            MetFriend MetFriend = (MetFriend)_event;

            //Test
            if (ValueDoesExist(data, "text"))
                MetFriend.friend = data["text"];
            else
                MetFriend.friend = "";

            //Location
            double tempd;
            MetFriend.Location = new Location();
            if (ValueDoesExist(data, "location\\lat"))
            {
                if (Double.TryParse(data["location\\lat"], out tempd))
                    MetFriend.Location._lat = tempd;
                else
                    MetFriend.Location._lat = 0;
            }
            else
                MetFriend.Location._lat = 0;

            if (ValueDoesExist(data, "location\\long"))
            {
                if (Double.TryParse(data["location\\long"], out tempd))
                    MetFriend.Location._long = tempd;
                else
                    MetFriend.Location._long = 0;
            }
            else
                MetFriend.Location._long = 0;

            //Date time stamp
            if (ValueDoesExist(data, "datetimestamp"))
            {
                DateTime temp;
                if (DateTime.TryParse(data["datetimestamp"], out temp))
                    MetFriend.timestamp = temp;
                else
                    MetFriend.timestamp = DateTime.Now;
            }
            else
                MetFriend.timestamp = DateTime.Now;
        }

        public override Dictionary<string, string> Save(Event @event)
        {
            MetFriend MetFriend = (MetFriend)@event;
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("text", MetFriend.friend);
            data = MergeDictionary(data, ProcessSaveLocation(MetFriend.Location));
            data.Add("datetimestamp", MetFriend.timestamp.ToString());

            return data;
        }
    }
}
