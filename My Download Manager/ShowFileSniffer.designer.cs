namespace My_Download_Manager
{
    partial class ShowFileSniffer
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
            this.LinkDownloadAll = new System.Windows.Forms.LinkLabel();
            this.btnBrowser = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // LinkDownloadAll
            // 
            this.LinkDownloadAll.AutoSize = true;
            this.LinkDownloadAll.Location = new System.Drawing.Point(5, 3);
            this.LinkDownloadAll.Name = "LinkDownloadAll";
            this.LinkDownloadAll.Size = new System.Drawing.Size(68, 13);
            this.LinkDownloadAll.TabIndex = 0;
            this.LinkDownloadAll.TabStop = true;
            this.LinkDownloadAll.Text = "Download All";
            this.LinkDownloadAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkDownloadAll_LinkClicked);
            // 
            // btnBrowser
            // 
            this.btnBrowser.AutoSize = true;
            this.btnBrowser.Location = new System.Drawing.Point(79, 3);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(46, 13);
            this.btnBrowser.TabIndex = 0;
            this.btnBrowser.TabStop = true;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnBrowser_LinkClicked);
            // 
            // ShowFileSniffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(299, 19);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.LinkDownloadAll);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ShowFileSniffer";
            this.ShowInTaskbar = false;
            this.Text = ".: My Download Manager :.";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ShowFileSniffer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LinkDownloadAll;
        private System.Windows.Forms.LinkLabel btnBrowser;




    }
}