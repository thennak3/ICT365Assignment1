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
using WMPLib;

namespace Assignment1.View.Controls
{
    public partial class VideoControl : UserControl, IControl
    {
        EditorHandler handler;
        string fieldname;

        string videoFile;
        public VideoControl()
        {
            InitializeComponent();
        }

        public void SetData(object data)
        {
            videoFile = (string)data;
            if (videoFile != "")
            {
                if (File.Exists(videoFile))
                {
                    mediaControl.URL = videoFile;
                }
                else
                    mediaControl.close();
            }
            else
                mediaControl.close();
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

            string formats = "All Videos Files |*.dat; *.wmv; *.3g2; *.3gp; *.3gp2; *.3gpp; *.amv; *.asf;  *.avi; *.bin; *.cue; *.divx; *.dv; *.flv; *.gxf; *.iso; *.m1v; *.m2v; *.m2t; *.m2ts; *.m4v; " +
          " *.mkv; *.mov; *.mp2; *.mp2v; *.mp4; *.mp4v; *.mpa; *.mpe; *.mpeg; *.mpeg1; *.mpeg2; *.mpeg4; *.mpg; *.mpv2; *.mts; *.nsv; *.nuv; *.ogg; *.ogm; *.ogv; *.ogx; *.ps; *.rec; *.rm; *.rmvb; *.tod; *.ts; *.tts; *.vob; *.vro; *.webm";

            ofd.Filter = formats;
            DialogResult dr = ofd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                videoFile = ofd.FileName;
                SetData(videoFile);
                handler.DataChanged(fieldname, videoFile);
            }

        }
    }
}
