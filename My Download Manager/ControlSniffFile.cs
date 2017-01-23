using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace My_Download_Manager
{
    public partial class ControlSniffFile : UserControl
    {
        public int ColorNormal = 233;
        public delegate void FileDownload(ControlSniffFile control);
        public delegate void DeleteFile(ControlSniffFile control);
        public event FileDownload StartDownloadFile;
        public event DeleteFile PerformDeleteFile;
        private TextBox txtEdit;
        public ControlSniffFile()
        {
            InitializeComponent();
        }
        public ControlSniffFile(string filename, string filesize)
            : this()
        {
            Icon icon = ObjStatic.ObjGetIcon.GetIconFromExtension(System.IO.Path.GetExtension(filename), GetIconWindow.IconSize.Large);
            if (icon != null)
                picIconFile.Image = (Image)icon.ToBitmap();
            else picIconFile.Image = picIconFile.ErrorImage;
            lblFileName.Text =filename;
            lblSize.Text = filesize;
            SetFocus(false);
        }
        private void ShowTextBox(bool IsShow)
        {
            if (txtEdit == null)
            {
                txtEdit = new TextBox();
                this.Controls.Add(txtEdit);
                txtEdit.Left = lblFileName.Left;
                txtEdit.Top = lblFileName.Top;
                txtEdit.Width = lblFileName.Width;
                txtEdit.Height = lblFileName.Height;
                txtEdit.Text = lblFileName.Text;
                txtEdit.LostFocus += new EventHandler(txtEdit_LostFocus);
            }
            if (IsShow)
            {
                lblFileName.Hide();
                txtEdit.Show();
            }
            else
            {
                lblFileName.Show();
                txtEdit.Hide();
                if (txtEdit.Text.Trim().Length > 0)
                {
                    lblFileName.Text = txtEdit.Text.Trim();
                    FileSniffer fs = (FileSniffer)this.Tag;
                    fs.FileName = txtEdit.Text.Trim();
                }
            }
        }
        void txtEdit_LostFocus(object sender, EventArgs e)
        {
            ShowTextBox(false);
        }
        private void lblFileName_Click(object sender, EventArgs e)
        {
            ShowTextBox(true);
        }
        private void SetFocus(bool IsFocus)
        {
            if (IsFocus)
            {
                int colorfocus = ColorNormal - 15;
                this.BackColor = Color.FromArgb(colorfocus, colorfocus, colorfocus);
                this.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                this.BackColor = Color.FromArgb(ColorNormal, ColorNormal, ColorNormal);
                this.BorderStyle = BorderStyle.None;
            }
        }
        private void ControlSniffFile_MouseHover(object sender, EventArgs e)
        {
            SetFocus(true);
        }
        private void ControlSniffFile_MouseLeave(object sender, EventArgs e)
        {
            SetFocus(false);
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (StartDownloadFile != null)
                StartDownloadFile(this);
        }
        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (PerformDeleteFile != null)
                PerformDeleteFile(this);
        }
    }
}
