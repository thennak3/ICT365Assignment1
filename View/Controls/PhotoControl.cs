using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment1.View.Controls
{
    public partial class PhotoControl : UserControl, IControl
    {
        string fieldname;
        EditorHandler handler;

        string filename;
        public PhotoControl()
        {
            InitializeComponent();
        }

        public void SetData(object data)
        {
            filename = (string)data;
            if(File.Exists(filename))
            {
                picture.Image = Image.FromFile(filename);
            }
        }

        public void SetEditable(bool isEditable)
        {
            if (isEditable)
                fileButton.Enabled = true;
            else
                fileButton.Enabled = false;
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
            fileButton.Text = text;
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Images| *.BMP; *.DIB; *.RLE; *.JPG; *.JPEG; *.JPE; *.JFIF; *.GIF; *.TIF; *.TIFF; *.PNG";

            DialogResult dr = ofd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                if(File.Exists(ofd.FileName))
                {
                    filename = ofd.FileName;
                    SetData(filename);
                    handler.DataChanged(fieldname, filename);
                }
            }
        }
    }
}
