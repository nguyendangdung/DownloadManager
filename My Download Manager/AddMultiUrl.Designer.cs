namespace My_Download_Manager
{
    partial class AddMultiUrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddMultiUrl));
            this.FilterFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnCheckLink = new System.Windows.Forms.Button();
            this.GridLink = new System.Windows.Forms.DataGridView();
            this.ChooseFile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new My_Download_Manager.CustomGridColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtSaveto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customGridColumn1 = new My_Download_Manager.CustomGridColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtURLs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddLinks = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FilterFlowLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridLink)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilterFlowLayout
            // 
            this.FilterFlowLayout.Controls.Add(this.btnCheckAll);
            this.FilterFlowLayout.Controls.Add(this.btnCheckLink);
            this.FilterFlowLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.FilterFlowLayout.Name = "FilterFlowLayout";
            this.FilterFlowLayout.Size = new System.Drawing.Size(752, 27);
            this.FilterFlowLayout.TabIndex = 2;
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(3, 3);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(96, 23);
            this.btnCheckAll.TabIndex = 0;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnCheckLink
            // 
            this.btnCheckLink.Location = new System.Drawing.Point(105, 3);
            this.btnCheckLink.Name = "btnCheckLink";
            this.btnCheckLink.Size = new System.Drawing.Size(128, 23);
            this.btnCheckLink.TabIndex = 1;
            this.btnCheckLink.Text = "Check link";
            this.btnCheckLink.UseVisualStyleBackColor = true;
            this.btnCheckLink.Click += new System.EventHandler(this.btnCheckLink_Click);
            // 
            // GridLink
            // 
            this.GridLink.AllowUserToAddRows = false;
            this.GridLink.AllowUserToDeleteRows = false;
            this.GridLink.AllowUserToOrderColumns = true;
            this.GridLink.AllowUserToResizeRows = false;
            this.GridLink.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridLink.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChooseFile,
            this.FileName,
            this.Size,
            this.Link});
            this.GridLink.Dock = System.Windows.Forms.DockStyle.Top;
            this.GridLink.Location = new System.Drawing.Point(0, 27);
            this.GridLink.Name = "GridLink";
            this.GridLink.RowHeadersVisible = false;
            this.GridLink.Size = new System.Drawing.Size(752, 374);
            this.GridLink.TabIndex = 3;
            // 
            // ChooseFile
            // 
            this.ChooseFile.FillWeight = 25F;
            this.ChooseFile.HeaderText = "";
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Width = 25;
            // 
            // FileName
            // 
            this.FileName.FillWeight = 250F;
            this.FileName.HeaderText = "File name";
            this.FileName.Name = "FileName";
            this.FileName.Width = 250;
            // 
            // Size
            // 
            this.Size.FillWeight = 80F;
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.Width = 80;
            // 
            // Link
            // 
            this.Link.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Link.HeaderText = "Link";
            this.Link.Name = "Link";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.btnBrowser);
            this.groupBox1.Controls.Add(this.txtSaveto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 533);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save to";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(64, 50);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(198, 21);
            this.cboCategory.TabIndex = 5;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Category :";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(581, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(662, 42);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(487, 21);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtSaveto
            // 
            this.txtSaveto.Location = new System.Drawing.Point(64, 22);
            this.txtSaveto.Name = "txtSaveto";
            this.txtSaveto.Size = new System.Drawing.Size(411, 21);
            this.txtSaveto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save to :";
            // 
            // customGridColumn1
            // 
            this.customGridColumn1.FillWeight = 250F;
            this.customGridColumn1.HeaderText = "File name";
            this.customGridColumn1.Name = "customGridColumn1";
            this.customGridColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 80F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Size";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Link";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // txtURLs
            // 
            this.txtURLs.Location = new System.Drawing.Point(50, 20);
            this.txtURLs.Multiline = true;
            this.txtURLs.Name = "txtURLs";
            this.txtURLs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtURLs.Size = new System.Drawing.Size(558, 94);
            this.txtURLs.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Link :";
            // 
            // btnAddLinks
            // 
            this.btnAddLinks.Location = new System.Drawing.Point(614, 53);
            this.btnAddLinks.Name = "btnAddLinks";
            this.btnAddLinks.Size = new System.Drawing.Size(75, 23);
            this.btnAddLinks.TabIndex = 7;
            this.btnAddLinks.Text = "Add link";
            this.btnAddLinks.UseVisualStyleBackColor = true;
            this.btnAddLinks.Click += new System.EventHandler(this.btnAddLinks_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtURLs);
            this.groupBox2.Controls.Add(this.btnAddLinks);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 407);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 120);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Analyst link from text";
            // 
            // AddMultiUrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(752, 616);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GridLink);
            this.Controls.Add(this.FilterFlowLayout);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddMultiUrl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMultiUrl";
            this.Load += new System.EventHandler(this.AddMultiUrl_Load);
            this.FilterFlowLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridLink)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FilterFlowLayout;
        private System.Windows.Forms.DataGridView GridLink;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtSaveto;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ChooseFile;
        private CustomGridColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.Button btnCheckLink;
        private CustomGridColumn customGridColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox txtURLs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddLinks;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}