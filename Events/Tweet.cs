using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    class Tweet : Event
    {
        [EventLabel(Label = "Tweet Text")]
        [TextField]
        public string text { get; set; }

        [IgnoreField]
        public DateTime timestamp { get; set; }

        public Tweet(string eventID) : base(eventID)
        {
            timestamp = DateTime.Now;

        }
       

    }

    class TweetDataHandler : EventDataHandler
    {

        public TweetDataHandler()
        {
            eventName = "tweet";
        }

        public override void Load(Event _event, Dictionary<string, string> data)
        {
            Tweet tweet = (Tweet)_event;

            if (ValueDoesExist(data, "text"))
                tweet.text = data["text"];
            else
                tweet.text = "";

            tweet.Location = ProcessLoadLocation(data);           

            if (ValueDoesExist(data, "datetimestamp"))
            {
                DateTime temp;
                if (DateTime.TryParse(data["datetimestamp"], out temp))
                    tweet.timestamp = temp;
                else
                    tweet.timestamp = DateTime.Now;
            }
            else
                tweet.timestamp = DateTime.Now;
        }

        public override Dictionary<string, string> Save(Event @event)
        {
            Tweet tweet = (Tweet)@event;
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("text", tweet.text);
            data = MergeDictionary(data, ProcessSaveLocation(tweet.Location));
            data.Add("datetimestamp", tweet.timestamp.ToString());

            return data;
        }
    }

}
