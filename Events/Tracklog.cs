using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    public class Tracklog : Event
    {
        [EventLabel(Label = "GPX File")]
        [GPXField]
        public string Filepath { get; set; }

        [EventLabel(Label = "GPS Data")]
        [TextField]
        public string Data { get; set; }

        [EventLabel(Label = "Start Date & Time")]
        [DateField]
        public DateTime Starttime { get; set; }

        [EventLabel(Label = "End Date & Time")]
        [DateField]
        public DateTime Endtime { get; set; }
        public Tracklog(string eventID) : base(eventID)
        {
            Starttime = DateTime.Now;
            Endtime = DateTime.Now;

        }
    }

    class TracklogDataHandler : EventDataHandler
    {

        public TracklogDataHandler()
        {
            eventName = "tracklog";
        }
        public override void Load(Event _event, Dictionary<string, string> data)
        {
            Tracklog tracklog = (Tracklog)_event;

            //Data tbd

            if (ValueDoesExist(data, "data"))
                tracklog.Data = data["data"];
            else
                tracklog.Data = "";

            if (ValueDoesExist(data, "filepath"))
                tracklog.Filepath = data["filepath"];
            else
                tracklog.Filepath = "";

            tracklog.Location = ProcessLoadLocation(data);

            //Start and end Date timestamps
            DateTime tempdt;
            if (ValueDoesExist(data, "start-time\\datetimestamp"))
            {
                if (DateTime.TryParse(data["start-time\\datetimestamp"], out tempdt))
                    tracklog.Starttime = tempdt;
                else
                    tracklog.Starttime = DateTime.Now;
            }
            else
                tracklog.Starttime = DateTime.Now;

            if (ValueDoesExist(data, "end-time\\datetimestamp"))
            {
                if (DateTime.TryParse(data["end-time\\datetimestamp"], out tempdt))
                    tracklog.Endtime = tempdt;
                else
                    tracklog.Endtime = DateTime.Now;
            }
            else
                tracklog.Endtime = DateTime.Now;
        }

        public override Dictionary<string, string> Save(Event @event)
        {
            Tracklog tracklog = (Tracklog)@event;
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("data", tracklog.Data);
            data.Add("filepath", tracklog.Filepath);
            data.Add("start-time\\datetimestamp", tracklog.Starttime.ToString());
            data.Add("end-time\\datetimestamp", tracklog.Endtime.ToString());
            data = MergeDictionary(data, ProcessSaveLocation(tracklog.Location));
            return data;
        }
    }
}
