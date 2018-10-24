using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class GPXParser
    {
        public GMapOverlay ParseGPX(string file)
        {
            if (!File.Exists(file))
                return null;
            //GMapControl gmap = new GMapControl();
            string gpx = File.ReadAllText(file);
            GMaps gmap = GMaps.Instance;
            gpxType gpxType = gmap.DeserializeGPX(gpx);
            GMapOverlay routeOverlay = new GMapOverlay(file);
            if (gpxType == null)
                return null;
            if (gpxType.trk.Length == 0)
                return null;
            foreach(var trk in gpxType.trk)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach(var seg in trk.trkseg)
                {
                    foreach(var point in seg.trkpt)
                    {
                        points.Add(new PointLatLng((double)point.lat, (double)point.lon));
                    }
                }
                GMapRoute route = new GMapRoute(points, string.Empty);
                routeOverlay.Routes.Add(route);
            }

            return routeOverlay;

            
        }
        
    }
}
