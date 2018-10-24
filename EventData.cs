using Assignment1.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment1
{
    class EventData
    {

        private static EventData instance = null;

        private static readonly object padlock = new object();

        private bool ready = false;
        public static EventData Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (padlock)
                    {
                        if(instance == null)
                        {
                            instance = new EventData();
                        }
                    }
                }
                return instance;
            }
        }

        Dictionary<string, Event> events;
        public EventData()
        {
            ThreadStart work = LoadData;
            Thread thread = new Thread(work);
            thread.Start();
        }

        public void LoadData()
        {
            EventXMLAdapter eventXmlLoader = new EventXMLAdapter();
            events = eventXmlLoader.Load("events.xml");
            ready = true;
        }

        public void SaveData()
        {
            EventXMLAdapter eventXMLAdapter = new EventXMLAdapter();
            eventXMLAdapter.Save("events.xml", new List<Event>(events.Values));
            //lock up thread while saving so no new events can be made
        }

        public Event AddNew(string type,double lat, double lng)
        {
            EventFactory factory = new EventFactory();
            Random rand = new Random();
            Event @event = factory.EventFactoryModule(Guid.NewGuid().ToString(), type);
            @event.SetLocation(lat, lng);
            events.Add(@event.Eventid, @event);
            return @event;
        }

        public void Delete(Event @event)
        {
            if (events.ContainsKey(@event.Eventid))
                events.Remove(@event.Eventid);
        }

        public List<Event> Events()
        {
            return new List<Event>(events.Values);
        }

        public bool IsReady()
        {
            return ready;
        }
    }
}
