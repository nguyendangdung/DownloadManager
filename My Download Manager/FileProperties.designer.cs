namespace My_Download_Manager
{
    partial class FileProperties
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileProperties));
            this.label1 = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSaveto = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblResumeAble = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProcessStatusMultiPart = new My_Download_Manager.CustomProcessBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDownloaded = new System.Windows.Forms.Label();
            this.lblMediafireLink = new System.Windows.Forms.TextBox();
            this.btnShowDetail = new System.Windows.Forms.Button();
            this.ProcessStatus = new My_Download_Manager.CustomProcessBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.lblTranferRate = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name :";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(95, 5);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(35, 13);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Size :";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(95, 26);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(35, 13);
            this.lblFileSize.TabIndex = 1;
            this.lblFileSize.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Save to :";
            // 
            // txtSaveto
            // 
            this.txtSaveto.Location = new System.Drawing.Point(95, 163);
            this.txtSaveto.Name = "txtSaveto";
            this.txtSaveto.Size = new System.Drawing.Size(375, 21);
            this.txtSaveto.TabIndex = 3;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(473, 162);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(64, 23);
            this.btnBrowser.TabIndex = 4;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Link :";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(95, 133);
            this.txtLink.Name = "txtLink";
            this.txtLink.ReadOnly = true;
            this.txtLink.Size = new System.Drawing.Size(375, 21);
            this.txtLink.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Resumeable :";
            // 
            // lblResumeAble
            // 
            this.lblResumeAble.AutoSize = true;
            this.lblResumeAble.Location = new System.Drawing.Point(95, 47);
            this.lblResumeAble.Name = "lblResumeAble";
            this.lblResumeAble.Size = new System.Drawing.Size(35, 13);
            this.lblResumeAble.TabIndex = 1;
            this.lblResumeAble.Text = "label2";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(196, 221);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(286, 221);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProcessStatusMultiPart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 35);
            this.panel1.TabIndex = 9;
            // 
            // ProcessStatusMultiPart
            // 
            this.ProcessStatusMultiPart.BackColor = System.Drawing.Color.Silver;
            this.ProcessStatusMultiPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcessStatusMultiPart.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ProcessStatusMultiPart.Location = new System.Drawing.Point(14, 6);
            this.ProcessStatusMultiPart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProcessStatusMultiPart.MaxValue = ((long)(100));
            this.ProcessStatusMultiPart.Name = "ProcessStatusMultiPart";
            this.ProcessStatusMultiPart.Size = new System.Drawing.Size(526, 22);
            this.ProcessStatusMultiPart.TabIndex = 10;
            this.ProcessStatusMultiPart.Value = ((long)(0));
            this.ProcessStatusMultiPart.ValueColor = System.Drawing.Color.SpringGreen;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblDownloaded);
            this.panel2.Controls.Add(this.lblMediafireLink);
            this.panel2.Controls.Add(this.btnShowDetail);
            this.panel2.Controls.Add(this.txtLink);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ProcessStatus);
            this.panel2.Controls.Add(this.lblFileName);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.lblFileSize);
            this.panel2.Controls.Add(this.btnBrowser);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblTimeLeft);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblTranferRate);
            this.panel2.Controls.Add(this.lblResumeAble);
            this.panel2.Controls.Add(this.txtSaveto);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 248);
            this.panel2.TabIndex = 10;
            // 
            // lblDownloaded
            // 
            this.lblDownloaded.AutoSize = true;
            this.lblDownloaded.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloaded.Location = new System.Drawing.Point(95, 114);
            this.lblDownloaded.Name = "lblDownloaded";
            this.lblDownloaded.Size = new System.Drawing.Size(0, 13);
            this.lblDownloaded.TabIndex = 13;
            // 
            // lblMediafireLink
            // 
            this.lblMediafireLink.BackColor = System.Drawing.SystemColors.Control;
            this.lblMediafireLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMediafireLink.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMediafireLink.ForeColor = System.Drawing.Color.Blue;
            this.lblMediafireLink.Location = new System.Drawing.Point(184, 25);
            this.lblMediafireLink.Name = "lblMediafireLink";
            this.lblMediafireLink.ReadOnly = true;
            this.lblMediafireLink.Size = new System.Drawing.Size(328, 14);
            this.lblMediafireLink.TabIndex = 12;
            // 
            // btnShowDetail
            // 
            this.btnShowDetail.Location = new System.Drawing.Point(10, 221);
            this.btnShowDetail.Name = "btnShowDetail";
            this.btnShowDetail.Size = new System.Drawing.Size(93, 23);
            this.btnShowDetail.TabIndex = 9;
            this.btnShowDetail.Text = "Show detail  >>";
            this.btnShowDetail.UseVisualStyleBackColor = true;
            this.btnShowDetail.Click += new System.EventHandler(this.btnShowDetail_Click);
            // 
            // ProcessStatus
            // 
            this.ProcessStatus.BackColor = System.Drawing.Color.Silver;
            this.ProcessStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProcessStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ProcessStatus.ForeColor = System.Drawing.Color.Blue;
            this.ProcessStatus.Location = new System.Drawing.Point(14, 191);
            this.ProcessStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProcessStatus.MaxValue = ((long)(100));
            this.ProcessStatus.Name = "ProcessStatus";
            this.ProcessStatus.Size = new System.Drawing.Size(526, 22);
            this.ProcessStatus.TabIndex = 8;
            this.ProcessStatus.Value = ((long)(0));
            this.ProcessStatus.ValueColor = System.Drawing.Color.SpringGreen;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Downloaded :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Time left :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Transfer rate :";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(95, 92);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(0, 13);
            this.lblTimeLeft.TabIndex = 1;
            // 
            // lblTranferRate
            // 
            this.lblTranferRate.AutoSize = true;
            this.lblTranferRate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranferRate.Location = new System.Drawing.Point(95, 68);
            this.lblTranferRate.Name = "lblTranferRate";
            this.lblTranferRate.Size = new System.Drawing.Size(0, 13);
            this.lblTranferRate.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.FillWeight = 80F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Connection";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Loaded";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // FileProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(555, 284);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Properties";
            this.Load += new System.EventHandler(this.FileProperties_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSaveto;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblResumeAble;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private CustomProcessBar ProcessStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShowDetail;
        private CustomProcessBar ProcessStatusMultiPart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTranferRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.TextBox lblMediafireLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDownloaded;
    }
}