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
    public partial class GPXControl : UserControl, IControl
    {

        EditorHandler handler;
        string fieldname;
        public GPXControl()
        {
            InitializeComponent();
        }

        public void SetData(object data)
        {
            lblfilename.Text = (string)data;
        }

        public void SetEditable(bool isEditable)
        {
            pickfile.Enabled = isEditable;
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
            pickfile.Text = text;
        }

        private void pickfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Gpx Files *.gpx | *.gpx";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                SetData(ofd.FileName);
                handler.DataChanged(fieldname, ofd.FileName);
                handler.GPXDataChanged();
            }
            
        }
    }
}
