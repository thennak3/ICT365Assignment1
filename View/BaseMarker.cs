using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.View
{
    class BaseMarker : GMarkerGoogle
    {
        public Event referenceEvent;

        public BaseMarker(PointLatLng p, GMarkerGoogleType type, Event @event) : base(p, type)
        {
            referenceEvent = @event;
        }

        public BaseMarker(PointLatLng p, Bitmap Bitmap, Event @event) : base(p, Bitmap)
        {
            referenceEvent = @event;
        }

        public BaseMarker(SerializationInfo info, StreamingContext context, Event @event) : base(info, context)
        {
            referenceEvent = @event;
        }


        public override void OnRender(Graphics g)
        {
            base.OnRender(g);
            
        }
    }
}
