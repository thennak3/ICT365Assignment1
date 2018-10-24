using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Assignment1.View;

namespace Assignment1
{
    public partial class EventView : Form
    {

        Event referenceEvent;
        EditorHandler editorHandler;
        bool newEevent;

        public EventView(bool isNew)
        {
            InitializeComponent();
            editorHandler = new EditorHandler(isNew);
            editorHandler.CallingFormReference(this);
        }




        public void SetEvent(Event @event)
        {
            EventGuiData eventGuiData = new EventGuiData();
            this.Text = eventGuiData.FriendlyName(@event);
            flwPanel.Visible = false;
            while (flwPanel.Controls.Count > 0)
            {
                flwPanel.Controls[0].Dispose();
            }

            flwPanel.Visible = true;

            referenceEvent = @event;
            editorHandler.GenerateControls(referenceEvent,flwPanel.Controls);
            
        }

        public void CloseForm()
        {
            Close();
        }

   
   
    }
}
