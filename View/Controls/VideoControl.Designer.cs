namespace Assignment1.View.Controls
{
    partial class VideoControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoControl));
            this.fileButton = new System.Windows.Forms.Button();
            this.mediaControl = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.mediaControl)).BeginInit();
            this.SuspendLayout();
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(254, 212);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(127, 23);
            this.fileButton.TabIndex = 0;
            this.fileButton.Text = "button1";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // mediaControl
            // 
            this.mediaControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaControl.Enabled = true;
            this.mediaControl.Location = new System.Drawing.Point(0, 3);
            this.mediaControl.Name = "mediaControl";
            this.mediaControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaControl.OcxState")));
            this.mediaControl.Size = new System.Drawing.Size(381, 200);
            this.mediaControl.TabIndex = 1;
            // 
            // VideoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mediaControl);
            this.Controls.Add(this.fileButton);
            this.Name = "VideoControl";
            this.Size = new System.Drawing.Size(384, 238);
            ((System.ComponentModel.ISupportInitialize)(this.mediaControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fileButton;
        private AxWMPLib.AxWindowsMediaPlayer mediaControl;
    }
}
