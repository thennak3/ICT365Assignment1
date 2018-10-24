using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Events
{
    class Photo : Event
    {

        [EventLabel(Label = "Select File")]
        [ImageField]
        public string filePath { get; set; }

        public Photo(string eventID) : base(eventID)
        {

        }
    }

    class PhotoDataHandler : EventDataHandler
    {

        public PhotoDataHandler()
        {
            eventName = "photo";
        }
        public override void Load(Event _event, Dictionary<string, string> data)
        {
            Photo photo = (Photo)_event;

            //Filepath

            if (ValueDoesExist(data, "filepath"))
                photo.filePath = data["filepath"];
            
            //Location

            
            photo.Location = ProcessLoadLocation(data);
            

        }

        public override Dictionary<string, string> Save(Event @event)
        {
            Photo photo = (Photo)@event;
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("filepath", photo.filePath.ToString());
            data = MergeDictionary(data, ProcessSaveLocation(photo.Location));

            return data;
        }
    }
}
