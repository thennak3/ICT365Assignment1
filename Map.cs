using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Threading;
using GMap;
using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Assignment1.View;
using Assignment1.Events;

namespace Assignment1
{
    public partial class Map : Form
    {


        public delegate void EventAdded(Event @event);
        public delegate void EventRemoved(Event @event);
        public delegate void AddGPXSegment(Tracklog @event);

        Point lastClicked;
        PointLatLng lastRightClickSpot;
        Dictionary<string, GMapOverlay> gpxOverlays;
        AddEvent addEventForm;
        public static EventAdded addedEvent;
        public static AddGPXSegment gpxSegmentAdded;
        public static EventRemoved removedEvent;

        Dictionary<string, BaseMarker> mapMarkers;

        public Map()
        {
            InitializeComponent();
            gpxOverlays = new Dictionary<string, GMapOverlay>();
            mapMarkers = new Dictionary<string, BaseMarker>();
            EventData.Instance.IsReady();
            ThreadStart work = FillMapGraphics;
            Thread thread = new Thread(work);
            thread.Start();
            InitializeMap();

        }

        void InitializeMap()
        {
            mapControl.MapProvider = GMapProviders.BingMap;
            mapControl.Position = new GMap.NET.PointLatLng(-31.9505, 115.8605);
            mapControl.DragButton = MouseButtons.Left;
            mapControl.MinZoom = 2;
            mapControl.MaxZoom = 22;
            mapControl.Zoom = 10;
            addedEvent += AddMarker;
            removedEvent += RemoveMarker;
            gpxSegmentAdded += GPXSegmentAdd;
            
        }
        GMapOverlay gMapOverlay;
        void FillMapGraphics()
        {
            
            while(!EventData.Instance.IsReady())
            {
                Thread.Sleep(50);
            }

            gMapOverlay = new GMapOverlay("markers");
            
            foreach (Event @event in EventData.Instance.Events())
            {
                AddMarker(@event);
            }

            mapControl.Overlays.Add(gMapOverlay);
            //Data is loaded...
        }


        void AddMarker(Event @event)
        {
            PointLatLng point;
            BaseMarker gMapMarker;
            Bitmap markerGraphic;
            point = new PointLatLng(@event.Location._lat, @event.Location._long);
            markerGraphic = EventIcon(@event);
            if (markerGraphic != null)
                gMapMarker = new BaseMarker(point, markerGraphic, @event);
            else
                gMapMarker = new BaseMarker(point, GMarkerGoogleType.red_pushpin, @event);
            gMapOverlay.Markers.Add(gMapMarker);
            mapMarkers.Add(@event.Eventid, gMapMarker);
            if(@event is Tracklog)
            {
                GPXSegmentAdd((Tracklog)@event);
            }
            
        }

        void RemoveMarker(Event @event)
        {
            if(mapMarkers.ContainsKey(@event.Eventid))
            {
                gMapOverlay.Markers.Remove(mapMarkers[@event.Eventid]);
                mapMarkers.Remove(@event.Eventid);
            }
        }

        void GPXSegmentAdd(Tracklog @event)
        {
            if(gpxOverlays.ContainsKey(@event.Eventid))
            {
                mapControl.Overlays.Remove(gpxOverlays[@event.Eventid]);
                gpxOverlays.Remove(@event.Eventid);
            }
            GPXParser parser = new GPXParser();
            GMapOverlay gMapOverlay = parser.ParseGPX(@event.Filepath);
            if(gMapOverlay != null)
            {
                mapControl.Overlays.Add(gMapOverlay);
                gpxOverlays.Add(@event.Eventid, gMapOverlay);
            }
        }

        Bitmap EventIcon(Event @event)
        {
            EventGuiData emarker = new EventGuiData();
            return emarker.GetMarkerIcon(@event);
        }
            
        

        private void mapControl_Paint(object sender, PaintEventArgs e)
        {
            lblLat.Text = "Latitutde " + mapControl.Position.Lat.ToString();
            lblLong.Text = "Longitude " + mapControl.Position.Lng.ToString();
            lblZoom.Text = "Zoom Level " + mapControl.Zoom.ToString();
        }

        private void mapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                lastClicked = Cursor.Position;
                //e.X, e.Y
                lastRightClickSpot = mapControl.FromLocalToLatLng(e.X, e.Y);
                contextMenuRightClick.Show(Cursor.Position);
            }
        }

        private void mapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            BaseMarker marker = (BaseMarker)item;
            EventView viewSubWindow = new EventView(false);
            viewSubWindow.SetEvent(marker.referenceEvent);
            viewSubWindow.Show();
        }

        private void SaveData(object sender, EventArgs e)
        {
            if (EventData.Instance.IsReady())//no point trying to save if the data hasn't loaded yet
                EventData.Instance.SaveData();
        }

        private void addEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addEventForm != null && !addEventForm.IsDisposed)
            {
                addEventForm.lat = lastRightClickSpot.Lat;
                addEventForm._long = lastRightClickSpot.Lng;
                addEventForm.Show();
                    
            }
            else
            {
                addEventForm = new AddEvent(lastRightClickSpot.Lat, lastRightClickSpot.Lng);
                addEventForm.Show();
            }
        }
    }
}
