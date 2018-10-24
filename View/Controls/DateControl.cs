using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1.View.Controls
{
    public partial class DateControl : UserControl, IControl
    {
        string fieldname;
        EditorHandler handler;
        public DateControl()
        {
            InitializeComponent();
        }

        public void SetData(object data)
        {
            dateTimePicker.Value = (DateTime)data;
        }

        public void SetEditable(bool isEditable)
        {
            if (isEditable)
                dateTimePicker.Enabled = true;
            else
                dateTimePicker.Enabled = false;
        }

        public void SetField(string fieldname)
        {
            this.fieldname = fieldname;
        }

        public void SetHandler(EditorHandler handler)
        {
            this.handler = handler;
        }

        public void SetLabelText(string text)
        {
            lblLabel.Text = text;
        }
    }
}
