namespace My_Download_Manager
{
    partial class Sniffer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sniffer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUnCheckAll = new System.Windows.Forms.Button();
            this.btnCheckAll = new System.Windows.Forms.Button();
            this.btnDownloadlater = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtPathSave = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TreeTypeSniffer = new System.Windows.Forms.TreeView();
            this.GridFile = new System.Windows.Forms.DataGridView();
            this.FileSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new My_Download_Manager.CustomGridColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customGridColumn1 = new My_Download_Manager.CustomGridColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridFile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnUnCheckAll);
            this.panel1.Controls.Add(this.btnCheckAll);
            this.panel1.Controls.Add(this.btnDownloadlater);
            this.panel1.Controls.Add(this.btnDownload);
            this.panel1.Controls.Add(this.btnBrowser);
            this.panel1.Controls.Add(this.txtPathSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 44);
            this.panel1.TabIndex = 0;
            // 
            // btnUnCheckAll
            // 
            this.btnUnCheckAll.Location = new System.Drawing.Point(171, 11);
            this.btnUnCheckAll.Name = "btnUnCheckAll";
            this.btnUnCheckAll.Size = new System.Drawing.Size(80, 23);
            this.btnUnCheckAll.TabIndex = 3;
            this.btnUnCheckAll.Text = "UnCheck all";
            this.btnUnCheckAll.UseVisualStyleBackColor = true;
            this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.Location = new System.Drawing.Point(105, 11);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(60, 23);
            this.btnCheckAll.TabIndex = 3;
            this.btnCheckAll.Text = "Check all";
            this.btnCheckAll.UseVisualStyleBackColor = true;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnDownloadlater
            // 
            this.btnDownloadlater.Location = new System.Drawing.Point(667, 11);
            this.btnDownloadlater.Name = "btnDownloadlater";
            this.btnDownloadlater.Size = new System.Drawing.Size(93, 23);
            this.btnDownloadlater.TabIndex = 2;
            this.btnDownloadlater.Text = "Download later";
            this.btnDownloadlater.UseVisualStyleBackColor = true;
            this.btnDownloadlater.Click += new System.EventHandler(this.btnDownloadlater_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(596, 11);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(69, 23);
            this.btnDownload.TabIndex = 2;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(565, 11);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(28, 23);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtPathSave
            // 
            this.txtPathSave.Location = new System.Drawing.Point(329, 12);
            this.txtPathSave.Name = "txtPathSave";
            this.txtPathSave.Size = new System.Drawing.Size(231, 21);
            this.txtPathSave.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::My_Download_Manager.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(257, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 44);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TreeTypeSniffer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GridFile);
            this.splitContainer1.Size = new System.Drawing.Size(864, 462);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 2;
            // 
            // TreeTypeSniffer
            // 
            this.TreeTypeSniffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeTypeSniffer.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeTypeSniffer.ItemHeight = 18;
            this.TreeTypeSniffer.Location = new System.Drawing.Point(0, 0);
            this.TreeTypeSniffer.Name = "TreeTypeSniffer";
            this.TreeTypeSniffer.Size = new System.Drawing.Size(209, 462);
            this.TreeTypeSniffer.TabIndex = 0;
            this.TreeTypeSniffer.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeTypeSniffer_BeforeSelect);
            // 
            // GridFile
            // 
            this.GridFile.AllowUserToAddRows = false;
            this.GridFile.AllowUserToDeleteRows = false;
            this.GridFile.AllowUserToOrderColumns = true;
            this.GridFile.AllowUserToResizeRows = false;
            this.GridFile.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GridFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileSelected,
            this.FileName,
            this.Size,
            this.Link});
            this.GridFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridFile.Location = new System.Drawing.Point(0, 0);
            this.GridFile.Name = "GridFile";
            this.GridFile.RowHeadersVisible = false;
            this.GridFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridFile.Size = new System.Drawing.Size(651, 462);
            this.GridFile.TabIndex = 0;
            // 
            // FileSelected
            // 
            this.FileSelected.FillWeight = 30F;
            this.FileSelected.HeaderText = "";
            this.FileSelected.Name = "FileSelected";
            this.FileSelected.Width = 30;
            // 
            // FileName
            // 
            this.FileName.FillWeight = 180F;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileName.Width = 180;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            // 
            // Link
            // 
            this.Link.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            this.dataGridViewTextBoxColumn1.FillWeight = 180F;
            this.dataGridViewTextBoxColumn1.HeaderText = "File Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Size";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Link";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Sniffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 506);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sniffer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sniffer";
            this.Load += new System.EventHandler(this.Sniffer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView TreeTypeSniffer;
        private System.Windows.Forms.DataGridView GridFile;
        private System.Windows.Forms.Button btnDownloadlater;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtPathSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnUnCheckAll;
        private System.Windows.Forms.Button btnCheckAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FileSelected;
        private CustomGridColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private CustomGridColumn customGridColumn1;

    }
}