namespace Assignment1
{
    partial class Map
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mapControl = new GMap.NET.WindowsForms.GMapControl();
            this.lblLat = new System.Windows.Forms.Label();
            this.lblLong = new System.Windows.Forms.Label();
            this.lblZoom = new System.Windows.Forms.Label();
            this.contextMenuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapControl
            // 
            this.mapControl.AutoSize = true;
            this.mapControl.Bearing = 0F;
            this.mapControl.CanDragMap = true;
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl.GrayScaleMode = false;
            this.mapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl.LevelsKeepInMemmory = 5;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.MarkersEnabled = true;
            this.mapControl.MaxZoom = 2;
            this.mapControl.MinZoom = 2;
            this.mapControl.MouseWheelZoomEnabled = true;
            this.mapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl.Name = "mapControl";
            this.mapControl.NegativeMode = false;
            this.mapControl.PolygonsEnabled = true;
            this.mapControl.RetryLoadTile = 0;
            this.mapControl.RoutesEnabled = true;
            this.mapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapControl.ShowTileGridLines = false;
            this.mapControl.Size = new System.Drawing.Size(808, 517);
            this.mapControl.TabIndex = 0;
            this.mapControl.Zoom = 0D;
            this.mapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.mapControl_OnMarkerClick);
            this.mapControl.Paint += new System.Windows.Forms.PaintEventHandler(this.mapControl_Paint);
            this.mapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapControl_MouseDown);
            // 
            // lblLat
            // 
            this.lblLat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(683, 10);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(35, 13);
            this.lblLat.TabIndex = 1;
            this.lblLat.Text = "label1";
            // 
            // lblLong
            // 
            this.lblLong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLong.AutoSize = true;
            this.lblLong.Location = new System.Drawing.Point(683, 23);
            this.lblLong.Name = "lblLong";
            this.lblLong.Size = new System.Drawing.Size(35, 13);
            this.lblLong.TabIndex = 1;
            this.lblLong.Text = "label1";
            // 
            // lblZoom
            // 
            this.lblZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(683, 36);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(35, 13);
            this.lblZoom.TabIndex = 1;
            this.lblZoom.Text = "label1";
            // 
            // contextMenuRightClick
            // 
            this.contextMenuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEventToolStripMenuItem});
            this.contextMenuRightClick.Name = "contextMenuStrip1";
            this.contextMenuRightClick.Size = new System.Drawing.Size(129, 26);
            // 
            // addEventToolStripMenuItem
            // 
            this.addEventToolStripMenuItem.Name = "addEventToolStripMenuItem";
            this.addEventToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.addEventToolStripMenuItem.Text = "Add Event";
            this.addEventToolStripMenuItem.Click += new System.EventHandler(this.addEventToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::Assignment1.Properties.Resources.save;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(644, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 31);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveData);
            // 
            // Map
            // 
            this.ClientSize = new System.Drawing.Size(808, 517);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.lblLong);
            this.Controls.Add(this.lblLat);
            this.Controls.Add(this.mapControl);
            this.Name = "Map";
            this.contextMenuRightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl mapControl;
        private System.Windows.Forms.Label lblLat;
        private System.Windows.Forms.Label lblLong;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.ContextMenuStrip contextMenuRightClick;
        private System.Windows.Forms.ToolStripMenuItem addEventToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

