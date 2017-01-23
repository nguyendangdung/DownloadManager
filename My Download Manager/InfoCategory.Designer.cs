namespace My_Download_Manager
{
    partial class InfoCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoCategory));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSaveTo = new System.Windows.Forms.TextBox();
            this.NUDDownload = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cboChangeDirectory = new System.Windows.Forms.CheckBox();
            this.CboShutdownWhencomplete = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NUDDownload)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Download :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Save to :";
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(141, 126);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "Add";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(151, 21);
            this.txtName.TabIndex = 3;
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(79, 58);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.Size = new System.Drawing.Size(285, 21);
            this.txtSaveTo.TabIndex = 3;
            // 
            // NUDDownload
            // 
            this.NUDDownload.Location = new System.Drawing.Point(79, 32);
            this.NUDDownload.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NUDDownload.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDDownload.Name = "NUDDownload";
            this.NUDDownload.Size = new System.Drawing.Size(42, 21);
            this.NUDDownload.TabIndex = 4;
            this.NUDDownload.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "file at the same time.";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(370, 56);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(63, 23);
            this.btnBrowser.TabIndex = 6;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(222, 126);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cboChangeDirectory
            // 
            this.cboChangeDirectory.AutoSize = true;
            this.cboChangeDirectory.Location = new System.Drawing.Point(79, 86);
            this.cboChangeDirectory.Name = "cboChangeDirectory";
            this.cboChangeDirectory.Size = new System.Drawing.Size(295, 17);
            this.cboChangeDirectory.TabIndex = 7;
            this.cboChangeDirectory.Text = "Change directory for all file uncomplete in this category.";
            this.cboChangeDirectory.UseVisualStyleBackColor = true;
            // 
            // CboShutdownWhencomplete
            // 
            this.CboShutdownWhencomplete.AutoSize = true;
            this.CboShutdownWhencomplete.Location = new System.Drawing.Point(79, 105);
            this.CboShutdownWhencomplete.Name = "CboShutdownWhencomplete";
            this.CboShutdownWhencomplete.Size = new System.Drawing.Size(250, 17);
            this.CboShutdownWhencomplete.TabIndex = 7;
            this.CboShutdownWhencomplete.Text = "Shutdown computer when download complete.";
            this.CboShutdownWhencomplete.UseVisualStyleBackColor = true;
            // 
            // InfoCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(438, 152);
            this.Controls.Add(this.CboShutdownWhencomplete);
            this.Controls.Add(this.cboChangeDirectory);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NUDDownload);
            this.Controls.Add(this.txtSaveTo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoCategory";
            this.Text = "Category";
            this.Load += new System.EventHandler(this.InfoCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUDDownload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSaveTo;
        private System.Windows.Forms.NumericUpDown NUDDownload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox cboChangeDirectory;
        private System.Windows.Forms.CheckBox CboShutdownWhencomplete;
    }
}