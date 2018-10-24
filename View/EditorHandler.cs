using Assignment1.Events;
using Assignment1.View.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1.View
{
    public class EditorHandler
    {
        PropertyInfo[] eventProperties;
        Dictionary<string, string> ControlMapping;
        Event referenceEvent;
        Control.ControlCollection formcontrols;
        Form callingform;

        bool editable;
        public EditorHandler(bool isNew)
        {
            editable = isNew;
        }

        public void CallingFormReference(Form form)
        {
            callingform = form;
        }

        public void GenerateControls(Event referenceEvent, Control.ControlCollection controls)
        {
            this.referenceEvent = referenceEvent;
            formcontrols = controls;
            ControlMapping = new Dictionary<string, string>();
            Type objType = this.referenceEvent.GetType();
            eventProperties = objType.GetProperties();
            ControlFactory factory = new ControlFactory();
            IControl control;
            foreach (var eventprop in eventProperties)
            {
                if (eventprop.GetCustomAttribute(typeof(Field)) != null)
                {
                    control = factory.GenerateControls(eventprop.GetCustomAttribute(typeof(Field)));
                    control.SetEditable(editable);
                    control.SetHandler(this);
                    control.SetLabelText(((EventLabel)eventprop.GetCustomAttribute(typeof(EventLabel))).Label);
                    control.SetData(eventprop.GetValue(this.referenceEvent));
                    control.SetField(eventprop.Name);
                    controls.Add((UserControl)control);
                }
            }

            control = new EditSaveControl();
            control.SetEditable(editable);
            control.SetHandler(this);
            controls.Add((UserControl)control);
        }



        public void Save()
        {
            if (editable)
            {
                editable = false;
                foreach (Control ctrl in formcontrols)
                {
                    if (ctrl is IControl)
                    {
                        ((IControl)ctrl).SetEditable(false);
                    }
                }
            }
        }

        public void Delete()
        {
            Map.removedEvent(referenceEvent);
            EventData.Instance.Delete(referenceEvent);
            if (callingform != null)
                callingform.Close();
        }

        public void Edit()
        {
            if (!editable)
            {
                editable = true;
                foreach (Control ctrl in formcontrols)
                {
                    if(ctrl is IControl)
                    {
                        ((IControl)ctrl).SetEditable(true);
                    }
                }
            }

        }

        public void DataChanged(string field, object value)
        {
            foreach(var prop in eventProperties)
            {
                if (prop.Name == field)
                {
                    prop.SetValue(referenceEvent, value);
                }
            }
        }

        public void GPXDataChanged()
        {
            if (referenceEvent is Tracklog)
                Map.gpxSegmentAdded((Tracklog)referenceEvent);
        }

        public void CloseCallingForm()
        {
            if (callingform != null)
                callingform.Close();
        }

    }
}
