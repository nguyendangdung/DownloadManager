namespace My_Download_Manager
{
    partial class AddUrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUrl));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLinkFile = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaveto = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnDownloadLater = new System.Windows.Forms.Button();
            this.btnStartDownload = new System.Windows.Forms.Button();
            this.btnCancelDownload = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboRemember = new System.Windows.Forms.CheckBox();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.picIconFile = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconFile)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Link File :";
            // 
            // txtLinkFile
            // 
            this.txtLinkFile.Location = new System.Drawing.Point(91, 12);
            this.txtLinkFile.Name = "txtLinkFile";
            this.txtLinkFile.Size = new System.Drawing.Size(399, 21);
            this.txtLinkFile.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(212, 45);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(293, 45);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtLinkFile);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 78);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Save to :";
            // 
            // txtSaveto
            // 
            this.txtSaveto.Location = new System.Drawing.Point(88, 23);
            this.txtSaveto.Name = "txtSaveto";
            this.txtSaveto.Size = new System.Drawing.Size(311, 21);
            this.txtSaveto.TabIndex = 1;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(405, 22);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(61, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnDownloadLater
            // 
            this.btnDownloadLater.Location = new System.Drawing.Point(113, 77);
            this.btnDownloadLater.Name = "btnDownloadLater";
            this.btnDownloadLater.Size = new System.Drawing.Size(99, 23);
            this.btnDownloadLater.TabIndex = 4;
            this.btnDownloadLater.Text = "Download later";
            this.btnDownloadLater.UseVisualStyleBackColor = true;
            this.btnDownloadLater.Click += new System.EventHandler(this.btnDownloadLater_Click);
            // 
            // btnStartDownload
            // 
            this.btnStartDownload.Location = new System.Drawing.Point(227, 77);
            this.btnStartDownload.Name = "btnStartDownload";
            this.btnStartDownload.Size = new System.Drawing.Size(99, 23);
            this.btnStartDownload.TabIndex = 4;
            this.btnStartDownload.Text = "Start download";
            this.btnStartDownload.UseVisualStyleBackColor = true;
            this.btnStartDownload.Click += new System.EventHandler(this.btnStartDownload_Click);
            // 
            // btnCancelDownload
            // 
            this.btnCancelDownload.Location = new System.Drawing.Point(345, 77);
            this.btnCancelDownload.Name = "btnCancelDownload";
            this.btnCancelDownload.Size = new System.Drawing.Size(99, 23);
            this.btnCancelDownload.TabIndex = 4;
            this.btnCancelDownload.Text = "Cancel";
            this.btnCancelDownload.UseVisualStyleBackColor = true;
            this.btnCancelDownload.Click += new System.EventHandler(this.btnCancelDownload_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboRemember);
            this.panel2.Controls.Add(this.lblFileSize);
            this.panel2.Controls.Add(this.picIconFile);
            this.panel2.Controls.Add(this.btnBrowser);
            this.panel2.Controls.Add(this.btnCancelDownload);
            this.panel2.Controls.Add(this.txtSaveto);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnStartDownload);
            this.panel2.Controls.Add(this.btnDownloadLater);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 111);
            this.panel2.TabIndex = 5;
            // 
            // cboRemember
            // 
            this.cboRemember.AutoSize = true;
            this.cboRemember.Location = new System.Drawing.Point(88, 53);
            this.cboRemember.Name = "cboRemember";
            this.cboRemember.Size = new System.Drawing.Size(122, 17);
            this.cboRemember.TabIndex = 7;
            this.cboRemember.Text = "Remember this path";
            this.cboRemember.UseVisualStyleBackColor = true;
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoEllipsis = true;
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(476, 59);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(0, 13);
            this.lblFileSize.TabIndex = 6;
            this.lblFileSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picIconFile
            // 
            this.picIconFile.Location = new System.Drawing.Point(472, 12);
            this.picIconFile.Name = "picIconFile";
            this.picIconFile.Size = new System.Drawing.Size(50, 40);
            this.picIconFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picIconFile.TabIndex = 5;
            this.picIconFile.TabStop = false;
            // 
            // AddUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(557, 195);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddUrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Url";
            this.Load += new System.EventHandler(this.AddUrl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLinkFile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtSaveto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelDownload;
        private System.Windows.Forms.Button btnStartDownload;
        private System.Windows.Forms.Button btnDownloadLater;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cboRemember;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.PictureBox picIconFile;
    }
}