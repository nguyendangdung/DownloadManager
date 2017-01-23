namespace My_Download_Manager
{
    partial class ControlSniffFile
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
            this.lblFileName = new System.Windows.Forms.Label();
            this.picIconFile = new System.Windows.Forms.PictureBox();
            this.btnDownload = new System.Windows.Forms.PictureBox();
            this.btnDeleteFile = new System.Windows.Forms.PictureBox();
            this.lblSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIconFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteFile)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoEllipsis = true;
            this.lblFileName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.Blue;
            this.lblFileName.Location = new System.Drawing.Point(38, 4);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(165, 24);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "controlsniffer.flv";
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFileName.MouseLeave += new System.EventHandler(this.ControlSniffFile_MouseLeave);
            this.lblFileName.Click += new System.EventHandler(this.lblFileName_Click);
            this.lblFileName.MouseHover += new System.EventHandler(this.ControlSniffFile_MouseHover);
            // 
            // picIconFile
            // 
            this.picIconFile.Location = new System.Drawing.Point(3, 0);
            this.picIconFile.Margin = new System.Windows.Forms.Padding(0);
            this.picIconFile.Name = "picIconFile";
            this.picIconFile.Size = new System.Drawing.Size(32, 32);
            this.picIconFile.TabIndex = 1;
            this.picIconFile.TabStop = false;
            this.picIconFile.MouseLeave += new System.EventHandler(this.ControlSniffFile_MouseLeave);
            this.picIconFile.MouseHover += new System.EventHandler(this.ControlSniffFile_MouseHover);
            // 
            // btnDownload
            // 
            this.btnDownload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDownload.Image = global::My_Download_Manager.Properties.Resources.download;
            this.btnDownload.Location = new System.Drawing.Point(252, 4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(24, 24);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.TabStop = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDeleteFile.Image = global::My_Download_Manager.Properties.Resources.delete;
            this.btnDeleteFile.Location = new System.Drawing.Point(276, 4);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteFile.TabIndex = 2;
            this.btnDeleteFile.TabStop = false;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(203, 11);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(35, 13);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "label1";
            // 
            // ControlSniffFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.picIconFile);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ControlSniffFile";
            this.Size = new System.Drawing.Size(300, 32);
            this.MouseLeave += new System.EventHandler(this.ControlSniffFile_MouseLeave);
            this.MouseHover += new System.EventHandler(this.ControlSniffFile_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.picIconFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.PictureBox picIconFile;
        private System.Windows.Forms.PictureBox btnDownload;
        private System.Windows.Forms.PictureBox btnDeleteFile;
        private System.Windows.Forms.Label lblSize;
    }
}
