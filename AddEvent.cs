using Assignment1.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class AddEvent : Form
    {
        public double lat;
        public double _long;
        public AddEvent(double lat, double _long)
        {
            InitializeComponent();
            this.lat = lat;
            this._long = _long;
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            Button theSender = (Button)sender;
            EventView eventView = new EventView(true);


            Event @event;
            @event = EventData.Instance.AddNew(theSender.Tag.ToString(), lat, _long);
            Map.addedEvent(@event);
            eventView.SetEvent(@event);
            eventView.Show();
            this.Close();
            
        }
    }
}
