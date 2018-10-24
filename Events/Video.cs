using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    class Video : Event
    {

        [EventLabel(Label = "Select A File")]
        [VideoField]
        public string Filepath { get; set; }

        [DateField]
        [EventLabel(Label = "Start Date & Time")]
        public DateTime Starttime { get; set; }

        [DateField]
        [EventLabel(Label = "End Date & Time")]
        public DateTime Endtime { get; set; }
        public Video(string eventID) : base(eventID)
        {
            Starttime = DateTime.Now;
            Endtime = DateTime.Now;

        }
    }

    class VideoDataHandler : EventDataHandler
    {

        public VideoDataHandler()
        {
            eventName = "video";
        }
        public override void Load(Event _event, Dictionary<string, string> data)
        {
            Video video = (Video)_event;

            //Filepath

            if (ValueDoesExist(data, "filepath"))
                video.Filepath = data["filepath"];

            //Location
            
            video.Location = ProcessLoadLocation(data);

            //Start and end Date timestamps
            DateTime tempdt;
            if (ValueDoesExist(data, "start-time\\datetimestamp"))
            {
                if (DateTime.TryParse(data["start-time\\datetimestamp"], out tempdt))
                    video.Starttime = tempdt;
                else
                    video.Starttime = DateTime.Now;
            }
            else
                video.Starttime = DateTime.Now;

            if (ValueDoesExist(data, "end-time\\datetimestamp"))
            {
                if (DateTime.TryParse(data["end-time\\datetimestamp"], out tempdt))
                    video.Endtime = tempdt;
                else
                    video.Endtime = DateTime.Now;
            }
            else
                video.Endtime = DateTime.Now;
        }

        public override Dictionary<string, string> Save(Event @event)
        {
            Video video = (Video)@event;
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("filepath", video.Filepath);
            data = MergeDictionary(data, ProcessSaveLocation(video.Location));
            data.Add("start-time\\datetimestamp", video.Starttime.ToString());
            data.Add("end-time\\datetimestamp", video.Endtime.ToString());

            return data;
        }
    }
}
