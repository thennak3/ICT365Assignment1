using Assignment1.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Assignment1
{
    class EventXMLAdapter
    {
        public EventXMLAdapter()
        {

        }

        public Dictionary<string,Event> Load(string file)
        {
            Dictionary<string,Event> data = new Dictionary<string, Event>();
            XElement xelement = XElement.Load(file);
            //Eat first two soap elements..
            if (xelement.Name.LocalName.ToLower() == "envelope")
                xelement = (XElement)xelement.FirstNode;

            IEnumerable<XElement> events = xelement.Elements("Event");
            XElement dataElement;

            EventFactory factory = new EventFactory();
            Event @event;
            EventDataHandler dataHandler;
            foreach (var _event in events)
            {
                string eventid = (string)_event.Element("eventid");
                dataElement = (XElement)_event.LastNode;
                Dictionary<string, string> list = new Dictionary<string, string>();
                ParseDictionary(list, dataElement, "");
                //    = dataElement.Elements().ToDictionary(item => item.Name.LocalName, item => item.Value);
                @event = factory.EventFactoryModule(eventid, dataElement.Name.LocalName);
                dataHandler = factory.EventDataHandlerFactory(@event);
                dataHandler.Load(@event, list);
                data.Add(eventid, @event);
            }
            
            return data;
        }

        public void ParseDictionary(Dictionary<string,string> list, XElement root,string parent)
        {
            foreach(XElement element in root.Elements())
            {
                if(element.HasElements)
                {
                    ParseDictionary(list, element, element.Name.LocalName);
                }
                else
                {
                    
                    list.Add((parent == "" ? "" : parent + "\\") + element.Name.LocalName, element.Value);
                }
            }
        }

        public bool Save(string file, List<Event> events)
        {
            //Build soap container

            var EventsXML = new XDocument(new XDeclaration("1.0", "utf-8", string.Empty));
            
            XNamespace soapenv = "http://www.w3.org/2001/12/soap-envelope";

            XElement root = new XElement( soapenv + "Envelope", new XAttribute(XNamespace.Xmlns+"SOAP-ENV",soapenv), new XAttribute(soapenv + "encodingStyle", "http://www.w3.org/2001/12/soap-encoding"), new XElement(soapenv + "Body"));
            EventsXML.Add(root);
            XElement body = (XElement)root.FirstNode;
            Dictionary<string, string> eventdata;
            EventFactory factory = new EventFactory();
            EventDataHandler eventDataHandler;
            XElement xmlevent;
            
            foreach (Event @event in events)
            {
                xmlevent = new XElement("Event");
                eventDataHandler = factory.EventDataHandlerFactory(@event);
                eventdata = eventDataHandler.Save(@event);
                xmlevent.Add(new XElement("eventid", @event.Eventid));

                XElement xmlEventData = new XElement(eventDataHandler.eventName);
                ProcessSaveEventData(eventdata, xmlEventData);
                xmlevent.Add(xmlEventData);
                body.Add(xmlevent);
            }
            EventsXML.Save(file);
            return true;
        }

        private void ProcessSaveEventData(Dictionary<string,string> data, XElement eventdata)
        {
            Dictionary<string, XElement> addedElements = new Dictionary<string, XElement>();
            XElement keyEvent;
            List<string> keys = new List<string>(data.Keys);
            string key = "";
            for (int i = 0; i < keys.Count; i++)
            {
                key = keys[i];
                //Check if contains delimiter
                //Split on first delimiter, check if addedElements contains value
                //If split, handle by creating parent first and adding, if not proceed as normal
                if (key.Contains("\\"))
                    key = key.Split('\\')[0];
                if (addedElements.ContainsKey(key))
                    keyEvent = addedElements[key];
                else
                    keyEvent = new XElement(key);

                key = keys[i];
                if (key.Contains("\\"))
                {
                    XElement tElement = new XElement(key.Split('\\')[1]);
                    tElement.Value = data[key];
                    keyEvent.Add(tElement);
                    if (!addedElements.ContainsKey(key.Split('\\')[0]))
                    {
                        eventdata.Add(keyEvent);
                        addedElements.Add(key.Split('\\')[0], keyEvent);
                    }
                }
                else
                {
                    keyEvent.Value = data[key];
                    addedElements.Add(key, keyEvent);
                    eventdata.Add(keyEvent);
                }
                
            }
        }
    }

}
