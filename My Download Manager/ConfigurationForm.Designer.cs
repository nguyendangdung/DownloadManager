namespace My_Download_Manager
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.TabConfig = new System.Windows.Forms.TabControl();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnDefaultAutoDownload = new System.Windows.Forms.Button();
            this.txtAutoDownloadExtension = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cboAutostartsniffer = new System.Windows.Forms.CheckBox();
            this.ClbSniffer = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTemBrowser = new System.Windows.Forms.Button();
            this.txtTemporaryFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDefaultNoSniff = new System.Windows.Forms.Button();
            this.txtExtensionNoSniff = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CboNumberConnection = new System.Windows.Forms.ComboBox();
            this.CboBuffer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cboGoogleChromeRegister = new System.Windows.Forms.CheckBox();
            this.cboOperaRegister = new System.Windows.Forms.CheckBox();
            this.cboFirefoxRegister = new System.Windows.Forms.CheckBox();
            this.cboIERegister = new System.Windows.Forms.CheckBox();
            this.cboRunOnStart = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.TabConfig.SuspendLayout();
            this.TabGeneral.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.TabConfig);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 415);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(336, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(244, 386);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TabConfig
            // 
            this.TabConfig.Controls.Add(this.TabGeneral);
            this.TabConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabConfig.Location = new System.Drawing.Point(0, 0);
            this.TabConfig.Name = "TabConfig";
            this.TabConfig.SelectedIndex = 0;
            this.TabConfig.Size = new System.Drawing.Size(752, 380);
            this.TabConfig.TabIndex = 0;
            // 
            // TabGeneral
            // 
            this.TabGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.TabGeneral.Controls.Add(this.cboRunOnStart);
            this.TabGeneral.Controls.Add(this.groupBox6);
            this.TabGeneral.Controls.Add(this.groupBox5);
            this.TabGeneral.Controls.Add(this.groupBox3);
            this.TabGeneral.Controls.Add(this.groupBox1);
            this.TabGeneral.Controls.Add(this.groupBox2);
            this.TabGeneral.Controls.Add(this.groupBox4);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(744, 354);
            this.TabGeneral.TabIndex = 0;
            this.TabGeneral.Text = "General";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnDefaultAutoDownload);
            this.groupBox6.Controls.Add(this.txtAutoDownloadExtension);
            this.groupBox6.Location = new System.Drawing.Point(6, 136);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(433, 145);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Auto download with this extension";
            // 
            // btnDefaultAutoDownload
            // 
            this.btnDefaultAutoDownload.Location = new System.Drawing.Point(352, 117);
            this.btnDefaultAutoDownload.Name = "btnDefaultAutoDownload";
            this.btnDefaultAutoDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDefaultAutoDownload.TabIndex = 1;
            this.btnDefaultAutoDownload.Text = "Default";
            this.btnDefaultAutoDownload.UseVisualStyleBackColor = true;
            this.btnDefaultAutoDownload.Click += new System.EventHandler(this.btnDefaultAutoDownload_Click);
            // 
            // txtAutoDownloadExtension
            // 
            this.txtAutoDownloadExtension.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoDownloadExtension.Location = new System.Drawing.Point(6, 19);
            this.txtAutoDownloadExtension.Multiline = true;
            this.txtAutoDownloadExtension.Name = "txtAutoDownloadExtension";
            this.txtAutoDownloadExtension.Size = new System.Drawing.Size(421, 95);
            this.txtAutoDownloadExtension.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cboAutostartsniffer);
            this.groupBox5.Controls.Add(this.ClbSniffer);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(445, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(293, 175);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Content Sniff";
            // 
            // cboAutostartsniffer
            // 
            this.cboAutostartsniffer.AutoSize = true;
            this.cboAutostartsniffer.Location = new System.Drawing.Point(6, 151);
            this.cboAutostartsniffer.Name = "cboAutostartsniffer";
            this.cboAutostartsniffer.Size = new System.Drawing.Size(276, 17);
            this.cboAutostartsniffer.TabIndex = 1;
            this.cboAutostartsniffer.Text = "Auto start sniffer when My Download Manager start";
            this.cboAutostartsniffer.UseVisualStyleBackColor = true;
            // 
            // ClbSniffer
            // 
            this.ClbSniffer.CheckOnClick = true;
            this.ClbSniffer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClbSniffer.FormattingEnabled = true;
            this.ClbSniffer.Items.AddRange(new object[] {
            "video (flv,mp4,wmv,3pg...)",
            "audio (mp3,wma...)",
            "application (swf,exe...)",
            "image (jpg,bmp,gif...)",
            "text (txt,htm,html,xml...)"});
            this.ClbSniffer.Location = new System.Drawing.Point(6, 18);
            this.ClbSniffer.Name = "ClbSniffer";
            this.ClbSniffer.Size = new System.Drawing.Size(281, 123);
            this.ClbSniffer.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTemBrowser);
            this.groupBox3.Controls.Add(this.txtTemporaryFolder);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(433, 62);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Temporary";
            // 
            // btnTemBrowser
            // 
            this.btnTemBrowser.Location = new System.Drawing.Point(371, 22);
            this.btnTemBrowser.Name = "btnTemBrowser";
            this.btnTemBrowser.Size = new System.Drawing.Size(53, 23);
            this.btnTemBrowser.TabIndex = 2;
            this.btnTemBrowser.Text = "...";
            this.btnTemBrowser.UseVisualStyleBackColor = true;
            this.btnTemBrowser.Click += new System.EventHandler(this.btnTemBrowser_Click);
            // 
            // txtTemporaryFolder
            // 
            this.txtTemporaryFolder.Location = new System.Drawing.Point(121, 23);
            this.txtTemporaryFolder.Name = "txtTemporaryFolder";
            this.txtTemporaryFolder.Size = new System.Drawing.Size(247, 21);
            this.txtTemporaryFolder.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Temporary directory :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDefaultNoSniff);
            this.groupBox1.Controls.Add(this.txtExtensionNoSniff);
            this.groupBox1.Location = new System.Drawing.Point(445, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extension no sniff";
            // 
            // btnDefaultNoSniff
            // 
            this.btnDefaultNoSniff.Location = new System.Drawing.Point(218, 132);
            this.btnDefaultNoSniff.Name = "btnDefaultNoSniff";
            this.btnDefaultNoSniff.Size = new System.Drawing.Size(75, 23);
            this.btnDefaultNoSniff.TabIndex = 1;
            this.btnDefaultNoSniff.Text = "Default";
            this.btnDefaultNoSniff.UseVisualStyleBackColor = true;
            this.btnDefaultNoSniff.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // txtExtensionNoSniff
            // 
            this.txtExtensionNoSniff.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtensionNoSniff.Location = new System.Drawing.Point(6, 20);
            this.txtExtensionNoSniff.Multiline = true;
            this.txtExtensionNoSniff.Name = "txtExtensionNoSniff";
            this.txtExtensionNoSniff.Size = new System.Drawing.Size(287, 106);
            this.txtExtensionNoSniff.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.CboNumberConnection);
            this.groupBox2.Controls.Add(this.CboBuffer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(185, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 89);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max connection :";
            // 
            // CboNumberConnection
            // 
            this.CboNumberConnection.FormattingEnabled = true;
            this.CboNumberConnection.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16"});
            this.CboNumberConnection.Location = new System.Drawing.Point(104, 50);
            this.CboNumberConnection.Name = "CboNumberConnection";
            this.CboNumberConnection.Size = new System.Drawing.Size(133, 21);
            this.CboNumberConnection.TabIndex = 1;
            // 
            // CboBuffer
            // 
            this.CboBuffer.FormattingEnabled = true;
            this.CboBuffer.Items.AddRange(new object[] {
            "4 Kb",
            "8 Kb",
            "16 Kb",
            "32 Kb",
            "56 Kb",
            "64 Kb",
            "96 Kb",
            "128 Kb",
            "256 Kb",
            "512 Kb",
            "1 Mb",
            "2 Mb",
            "4 Mb"});
            this.CboBuffer.Location = new System.Drawing.Point(104, 23);
            this.CboBuffer.Name = "CboBuffer";
            this.CboBuffer.Size = new System.Drawing.Size(133, 21);
            this.CboBuffer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect speed :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cboGoogleChromeRegister);
            this.groupBox4.Controls.Add(this.cboOperaRegister);
            this.groupBox4.Controls.Add(this.cboFirefoxRegister);
            this.groupBox4.Controls.Add(this.cboIERegister);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 125);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Integrate with browser";
            // 
            // cboGoogleChromeRegister
            // 
            this.cboGoogleChromeRegister.AutoSize = true;
            this.cboGoogleChromeRegister.Location = new System.Drawing.Point(13, 95);
            this.cboGoogleChromeRegister.Name = "cboGoogleChromeRegister";
            this.cboGoogleChromeRegister.Size = new System.Drawing.Size(99, 17);
            this.cboGoogleChromeRegister.TabIndex = 0;
            this.cboGoogleChromeRegister.Text = "Google Chrome";
            this.cboGoogleChromeRegister.UseVisualStyleBackColor = true;
            // 
            // cboOperaRegister
            // 
            this.cboOperaRegister.AutoSize = true;
            this.cboOperaRegister.Location = new System.Drawing.Point(13, 72);
            this.cboOperaRegister.Name = "cboOperaRegister";
            this.cboOperaRegister.Size = new System.Drawing.Size(56, 17);
            this.cboOperaRegister.TabIndex = 0;
            this.cboOperaRegister.Text = "Opera";
            this.cboOperaRegister.UseVisualStyleBackColor = true;
            // 
            // cboFirefoxRegister
            // 
            this.cboFirefoxRegister.AutoSize = true;
            this.cboFirefoxRegister.Location = new System.Drawing.Point(13, 49);
            this.cboFirefoxRegister.Name = "cboFirefoxRegister";
            this.cboFirefoxRegister.Size = new System.Drawing.Size(94, 17);
            this.cboFirefoxRegister.TabIndex = 0;
            this.cboFirefoxRegister.Text = "Mozilla Firefox";
            this.cboFirefoxRegister.UseVisualStyleBackColor = true;
            // 
            // cboIERegister
            // 
            this.cboIERegister.AutoSize = true;
            this.cboIERegister.Location = new System.Drawing.Point(13, 26);
            this.cboIERegister.Name = "cboIERegister";
            this.cboIERegister.Size = new System.Drawing.Size(109, 17);
            this.cboIERegister.TabIndex = 0;
            this.cboIERegister.Text = "Internet Explorer";
            this.cboIERegister.UseVisualStyleBackColor = true;
            // 
            // cboRunOnStart
            // 
            this.cboRunOnStart.AutoSize = true;
            this.cboRunOnStart.Location = new System.Drawing.Point(187, 108);
            this.cboRunOnStart.Name = "cboRunOnStart";
            this.cboRunOnStart.Size = new System.Drawing.Size(209, 17);
            this.cboRunOnStart.TabIndex = 3;
            this.cboRunOnStart.Text = "Run My download manager on startup";
            this.cboRunOnStart.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(776, 439);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.panel1.ResumeLayout(false);
            this.TabConfig.ResumeLayout(false);
            this.TabGeneral.ResumeLayout(false);
            this.TabGeneral.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl TabConfig;
        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTemBrowser;
        private System.Windows.Forms.TextBox txtTemporaryFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDefaultNoSniff;
        private System.Windows.Forms.TextBox txtExtensionNoSniff;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboNumberConnection;
        private System.Windows.Forms.ComboBox CboBuffer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cboGoogleChromeRegister;
        private System.Windows.Forms.CheckBox cboOperaRegister;
        private System.Windows.Forms.CheckBox cboFirefoxRegister;
        private System.Windows.Forms.CheckBox cboIERegister;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox ClbSniffer;
        private System.Windows.Forms.CheckBox cboAutostartsniffer;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnDefaultAutoDownload;
        private System.Windows.Forms.TextBox txtAutoDownloadExtension;
        private System.Windows.Forms.CheckBox cboRunOnStart;
    }
}