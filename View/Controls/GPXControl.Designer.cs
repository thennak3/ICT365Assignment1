namespace Assignment1.View.Controls
{
    partial class GPXControl
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
            this.lblfilename = new System.Windows.Forms.Label();
            this.pickfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblfilename
            // 
            this.lblfilename.AutoSize = true;
            this.lblfilename.Location = new System.Drawing.Point(3, 16);
            this.lblfilename.Name = "lblfilename";
            this.lblfilename.Size = new System.Drawing.Size(76, 13);
            this.lblfilename.TabIndex = 0;
            this.lblfilename.Text = "fffffffffffffffffffffff";
            // 
            // pickfile
            // 
            this.pickfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickfile.Location = new System.Drawing.Point(371, 11);
            this.pickfile.Name = "pickfile";
            this.pickfile.Size = new System.Drawing.Size(75, 23);
            this.pickfile.TabIndex = 1;
            this.pickfile.Text = "button1";
            this.pickfile.UseVisualStyleBackColor = true;
            this.pickfile.Click += new System.EventHandler(this.pickfile_Click);
            // 
            // GPXControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pickfile);
            this.Controls.Add(this.lblfilename);
            this.Name = "GPXControl";
            this.Size = new System.Drawing.Size(449, 41);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblfilename;
        private System.Windows.Forms.Button pickfile;
    }
}
