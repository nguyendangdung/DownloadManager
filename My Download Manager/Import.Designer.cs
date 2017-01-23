namespace My_Download_Manager
{
    partial class Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileImport = new System.Windows.Forms.TextBox();
            this.btnBrowserFileImport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaveto = new System.Windows.Forms.TextBox();
            this.btnBrowserSaveto = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File import :";
            // 
            // txtFileImport
            // 
            this.txtFileImport.Location = new System.Drawing.Point(78, 15);
            this.txtFileImport.Name = "txtFileImport";
            this.txtFileImport.Size = new System.Drawing.Size(320, 21);
            this.txtFileImport.TabIndex = 1;
            // 
            // btnBrowserFileImport
            // 
            this.btnBrowserFileImport.Location = new System.Drawing.Point(407, 13);
            this.btnBrowserFileImport.Name = "btnBrowserFileImport";
            this.btnBrowserFileImport.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserFileImport.TabIndex = 2;
            this.btnBrowserFileImport.Text = "Browser";
            this.btnBrowserFileImport.UseVisualStyleBackColor = true;
            this.btnBrowserFileImport.Click += new System.EventHandler(this.btnBrowserFileImport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Save to :";
            // 
            // txtSaveto
            // 
            this.txtSaveto.Location = new System.Drawing.Point(78, 50);
            this.txtSaveto.Name = "txtSaveto";
            this.txtSaveto.Size = new System.Drawing.Size(320, 21);
            this.txtSaveto.TabIndex = 1;
            // 
            // btnBrowserSaveto
            // 
            this.btnBrowserSaveto.Location = new System.Drawing.Point(407, 48);
            this.btnBrowserSaveto.Name = "btnBrowserSaveto";
            this.btnBrowserSaveto.Size = new System.Drawing.Size(75, 23);
            this.btnBrowserSaveto.TabIndex = 2;
            this.btnBrowserSaveto.Text = "Browser";
            this.btnBrowserSaveto.UseVisualStyleBackColor = true;
            this.btnBrowserSaveto.Click += new System.EventHandler(this.btnBrowserSaveto_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(165, 76);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(255, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(494, 108);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowserSaveto);
            this.Controls.Add(this.btnBrowserFileImport);
            this.Controls.Add(this.txtSaveto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileImport);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Import";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.Import_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileImport;
        private System.Windows.Forms.Button btnBrowserFileImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaveto;
        private System.Windows.Forms.Button btnBrowserSaveto;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}