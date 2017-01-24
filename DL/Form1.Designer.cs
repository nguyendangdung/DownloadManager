namespace DL
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.fileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localPathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadedSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadedSizeMbDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customProcessBar1 = new My_Download_Manager.CustomProcessBar();
            this.customProcessBar2 = new My_Download_Manager.CustomProcessBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(674, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileDataGridViewTextBoxColumn,
            this.startDataGridViewTextBoxColumn,
            this.endDataGridViewTextBoxColumn,
            this.localPathDataGridViewTextBoxColumn,
            this.downloadedSizeDataGridViewTextBoxColumn,
            this.downloadedSizeMbDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.partBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(737, 82);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(737, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // fileDataGridViewTextBoxColumn
            // 
            this.fileDataGridViewTextBoxColumn.DataPropertyName = "File";
            this.fileDataGridViewTextBoxColumn.HeaderText = "File";
            this.fileDataGridViewTextBoxColumn.Name = "fileDataGridViewTextBoxColumn";
            // 
            // startDataGridViewTextBoxColumn
            // 
            this.startDataGridViewTextBoxColumn.DataPropertyName = "Start";
            this.startDataGridViewTextBoxColumn.HeaderText = "Start";
            this.startDataGridViewTextBoxColumn.Name = "startDataGridViewTextBoxColumn";
            // 
            // endDataGridViewTextBoxColumn
            // 
            this.endDataGridViewTextBoxColumn.DataPropertyName = "End";
            this.endDataGridViewTextBoxColumn.HeaderText = "End";
            this.endDataGridViewTextBoxColumn.Name = "endDataGridViewTextBoxColumn";
            // 
            // localPathDataGridViewTextBoxColumn
            // 
            this.localPathDataGridViewTextBoxColumn.DataPropertyName = "LocalPath";
            this.localPathDataGridViewTextBoxColumn.HeaderText = "LocalPath";
            this.localPathDataGridViewTextBoxColumn.Name = "localPathDataGridViewTextBoxColumn";
            // 
            // downloadedSizeDataGridViewTextBoxColumn
            // 
            this.downloadedSizeDataGridViewTextBoxColumn.DataPropertyName = "DownloadedSize";
            this.downloadedSizeDataGridViewTextBoxColumn.HeaderText = "DownloadedSize";
            this.downloadedSizeDataGridViewTextBoxColumn.Name = "downloadedSizeDataGridViewTextBoxColumn";
            // 
            // downloadedSizeMbDataGridViewTextBoxColumn
            // 
            this.downloadedSizeMbDataGridViewTextBoxColumn.DataPropertyName = "DownloadedSizeMb";
            this.downloadedSizeMbDataGridViewTextBoxColumn.HeaderText = "DownloadedSizeMb";
            this.downloadedSizeMbDataGridViewTextBoxColumn.Name = "downloadedSizeMbDataGridViewTextBoxColumn";
            this.downloadedSizeMbDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // partBindingSource
            // 
            this.partBindingSource.DataSource = typeof(DL.Part);
            // 
            // customProcessBar1
            // 
            this.customProcessBar1.BackColor = System.Drawing.Color.Silver;
            this.customProcessBar1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.customProcessBar1.Location = new System.Drawing.Point(12, 183);
            this.customProcessBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customProcessBar1.MaxValue = ((long)(100));
            this.customProcessBar1.Name = "customProcessBar1";
            this.customProcessBar1.Size = new System.Drawing.Size(737, 27);
            this.customProcessBar1.TabIndex = 6;
            this.customProcessBar1.Value = ((long)(0));
            this.customProcessBar1.ValueColor = System.Drawing.Color.Blue;
            // 
            // customProcessBar2
            // 
            this.customProcessBar2.BackColor = System.Drawing.Color.Silver;
            this.customProcessBar2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.customProcessBar2.Location = new System.Drawing.Point(12, 218);
            this.customProcessBar2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customProcessBar2.MaxValue = ((long)(100));
            this.customProcessBar2.Name = "customProcessBar2";
            this.customProcessBar2.Size = new System.Drawing.Size(737, 27);
            this.customProcessBar2.TabIndex = 7;
            this.customProcessBar2.Value = ((long)(0));
            this.customProcessBar2.ValueColor = System.Drawing.Color.Blue;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 492);
            this.Controls.Add(this.customProcessBar2);
            this.Controls.Add(this.customProcessBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadedSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadedSizeMbDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource partBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private My_Download_Manager.CustomProcessBar customProcessBar1;
        private My_Download_Manager.CustomProcessBar customProcessBar2;
    }
}

