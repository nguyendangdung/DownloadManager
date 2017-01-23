namespace My_Download_Manager
{
    partial class MediafireDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediafireDownload));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUncheckAll = new System.Windows.Forms.Button();
            this.btnAddtocategory = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtSaveTo = new System.Windows.Forms.TextBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStopGetLink = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCheckLink = new System.Windows.Forms.Button();
            this.btnGetLink = new System.Windows.Forms.Button();
            this.txtLinkMediafire = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GridFile = new System.Windows.Forms.DataGridView();
            this.FileSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new My_Download_Manager.CustomGridColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customGridColumn1 = new My_Download_Manager.CustomGridColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUncheckAll);
            this.panel1.Controls.Add(this.btnAddtocategory);
            this.panel1.Controls.Add(this.btnCheckAll);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 420);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 80);
            this.panel1.TabIndex = 2;
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.Location = new System.Drawing.Point(513, 46);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(81, 21);
            this.btnUncheckAll.TabIndex = 0;
            this.btnUncheckAll.Text = "Uncheck all";
            this.btnUncheckAll.UseVisualStyleBackColor = true;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnAddtocategory
            // 
            this.btnAddtocategory.Location = new System.Drawing.Point(601, 46);
            this.btnAddtocategory.Name = "btnAddtocategory";
            this.btnAddtocategory.Size = new System.Drawing.Size(114, 21);
            this.btnAddtocategory.TabIndex = 0;
            this.btnAddtocategory.Text = "Add to Category";
            this.btnAddtocategory.UseVisualStyleBackColor = true;
            this.btnAddtocategory.Click += new System.EventHandler(this.btnAddtocategory_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(513, 19);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(65, 21);
            this.btnCheckAll.TabIndex = 0;
            this.btnCheckAll.Text = "Check all";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowser);
            this.groupBox1.Controls.Add(this.txtSaveTo);
            this.groupBox1.Controls.Add(this.cboCategory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(461, 18);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(36, 21);
            this.btnBrowser.TabIndex = 3;
            this.btnBrowser.Text = "...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(71, 19);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.Size = new System.Drawing.Size(384, 21);
            this.txtSaveTo.TabIndex = 2;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(71, 44);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(198, 21);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Category :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save to :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStopGetLink);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnCheckLink);
            this.panel2.Controls.Add(this.btnGetLink);
            this.panel2.Controls.Add(this.txtLinkMediafire);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 107);
            this.panel2.TabIndex = 3;
            // 
            // btnStopGetLink
            // 
            this.btnStopGetLink.Location = new System.Drawing.Point(494, 74);
            this.btnStopGetLink.Name = "btnStopGetLink";
            this.btnStopGetLink.Size = new System.Drawing.Size(75, 23);
            this.btnStopGetLink.TabIndex = 9;
            this.btnStopGetLink.Text = "Stop";
            this.btnStopGetLink.UseVisualStyleBackColor = true;
            this.btnStopGetLink.Click += new System.EventHandler(this.btnStopGetLink_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoEllipsis = true;
            this.lblStatus.Location = new System.Drawing.Point(497, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(210, 23);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(577, 74);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCheckLink
            // 
            this.btnCheckLink.Location = new System.Drawing.Point(576, 42);
            this.btnCheckLink.Name = "btnCheckLink";
            this.btnCheckLink.Size = new System.Drawing.Size(70, 24);
            this.btnCheckLink.TabIndex = 6;
            this.btnCheckLink.Text = "Check Link";
            this.btnCheckLink.UseVisualStyleBackColor = true;
            this.btnCheckLink.Click += new System.EventHandler(this.btnCheckLink_Click);
            // 
            // btnGetLink
            // 
            this.btnGetLink.Location = new System.Drawing.Point(494, 42);
            this.btnGetLink.Name = "btnGetLink";
            this.btnGetLink.Size = new System.Drawing.Size(75, 24);
            this.btnGetLink.TabIndex = 6;
            this.btnGetLink.Text = "Get Link";
            this.btnGetLink.UseVisualStyleBackColor = true;
            this.btnGetLink.Click += new System.EventHandler(this.btnGetLink_Click);
            // 
            // txtLinkMediafire
            // 
            this.txtLinkMediafire.HideSelection = false;
            this.txtLinkMediafire.Location = new System.Drawing.Point(99, 3);
            this.txtLinkMediafire.Multiline = true;
            this.txtLinkMediafire.Name = "txtLinkMediafire";
            this.txtLinkMediafire.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLinkMediafire.Size = new System.Drawing.Size(389, 101);
            this.txtLinkMediafire.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Link Mediafire :";
            // 
            // GridFile
            // 
            this.GridFile.AllowUserToAddRows = false;
            this.GridFile.AllowUserToDeleteRows = false;
            this.GridFile.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GridFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileSelected,
            this.FileName,
            this.Size,
            this.Status,
            this.Reference,
            this.Link});
            this.GridFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GridFile.Location = new System.Drawing.Point(0, 112);
            this.GridFile.Name = "GridFile";
            this.GridFile.RowHeadersVisible = false;
            this.GridFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridFile.Size = new System.Drawing.Size(719, 308);
            this.GridFile.TabIndex = 4;
            // 
            // FileSelected
            // 
            this.FileSelected.FillWeight = 25F;
            this.FileSelected.HeaderText = "";
            this.FileSelected.Name = "FileSelected";
            this.FileSelected.Width = 25;
            // 
            // FileName
            // 
            this.FileName.FillWeight = 150F;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileName.Width = 150;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // Status
            // 
            this.Status.FillWeight = 80F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 80;
            // 
            // Reference
            // 
            this.Reference.FillWeight = 200F;
            this.Reference.HeaderText = "Reference";
            this.Reference.Name = "Reference";
            this.Reference.Width = 200;
            // 
            // Link
            // 
            this.Link.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Link.FillWeight = 300F;
            this.Link.HeaderText = "Link";
            this.Link.Name = "Link";
            // 
            // customGridColumn1
            // 
            this.customGridColumn1.FillWeight = 180F;
            this.customGridColumn1.HeaderText = "File Name";
            this.customGridColumn1.Name = "customGridColumn1";
            this.customGridColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.customGridColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Size";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Status";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Link";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Reference";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // MediafireDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 500);
            this.Controls.Add(this.GridFile);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MediafireDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mediafire Download";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView GridFile;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtSaveTo;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Button btnUncheckAll;
        private System.Windows.Forms.Button btnAddtocategory;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetLink;
        private System.Windows.Forms.TextBox txtLinkMediafire;
        private System.Windows.Forms.Button btnCheckLink;
        private CustomGridColumn customGridColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FileSelected;
        private CustomGridColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStopGetLink;
    }
}