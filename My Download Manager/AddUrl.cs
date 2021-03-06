using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace My_Download_Manager
{
    public partial class AddUrl : Form
    {
        #region >- Variable -<

        LinkInfo Info = null;
        File filedownload = null;
        private Timer timerGetFileSize;
        private delegate void SetTextCallback(Control l, string text);
        private delegate void SetIconCallback(PictureBox pic, Image image);

        #endregion

        #region >- Content -<

        public AddUrl()
        {
            InitializeComponent();
        }
        public AddUrl(string link)
        {
            InitializeComponent();
            this.link = link;
        }
        private string link = string.Empty;
        private void AddUrl_Load(object sender, EventArgs e)
        {
            string data = link;
            if (string.IsNullOrEmpty(data))
            {
                string str = Clipboard.GetText().Trim().ToLower();
                if (str.StartsWith("http"))
                {
                    data = str;
                }
                link = data;
                txtLinkFile.Text = data;
                Height = Height - panel2.Height;
                panel2.Visible = false;
            }
            else
            {
                txtLinkFile.Text = link;
                PerformWhenOK();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (timerGetFileSize != null)
                timerGetFileSize.Stop();
            base.OnClosing(e);
        }
        private void PerformWhenOK()
        {
            if (txtLinkFile.Text.Length > 0)
            {
                panel2.Visible = true;
                panel1.Visible = false;
                Height = panel2.Height + 30;
                string filename = System.IO.Path.GetFileName(txtLinkFile.Text);
                if (string.IsNullOrEmpty(filename))
                    filename = "Index.htm";
                string extension = System.IO.Path.GetExtension(filename).ToLower();
                if(ObjStatic.Config.LastPathSaveFile==null)
                    ObjStatic.Config.LastPathSaveFile=new System.Collections.Hashtable();
                string folder=ObjStatic.FormMain.GetCurrentPathOfCategory() ;
                if (ObjStatic.Config.LastPathSaveFile[extension] != null)
                    folder = ObjStatic.Config.LastPathSaveFile[extension].ToString();
                string saveto = folder + "\\" + filename;
                txtSaveto.Text = saveto;
                
                Icon icon = ObjStatic.ObjGetIcon.GetIconFromExtension(extension, GetIconWindow.IconSize.Large);
                if (icon != null)
                    picIconFile.Image = (Image)icon.ToBitmap();
                else picIconFile.Image = picIconFile.ErrorImage;
                lblFileSize.Text = "Unknown";
                filedownload = new File(saveto, txtLinkFile.Text, -1, filename);
                timerGetFileSize = new Timer();
                timerGetFileSize.Interval = 100;
                timerGetFileSize.Tick += timerGetFileSize_Tick;
                timerGetFileSize.Start();
            }
            else MessageBox.Show("Url is invalid !",ObjStatic.MessageBoxCaption);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            PerformWhenOK();
        }
        private void timerGetFileSize_Tick(object sender, EventArgs e)
        {
            timerGetFileSize.Stop();
            StartGetFileSize();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.ShowDialog();
            if (folder.SelectedPath != null && folder.SelectedPath.Length > 0)
            {
                txtSaveto.Text = folder.SelectedPath + "\\" + System.IO.Path.GetFileName(txtSaveto.Text);
            }
            else MessageBox.Show("Url is invalid !", ObjStatic.MessageBoxCaption);
        }
        private void btnCancelDownload_Click(object sender, EventArgs e)
        {
            filedownload.Dispose();
            Close();
        }
        private void btnStartDownload_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtSaveto.Text)))
            {
                if (System.IO.File.Exists(txtSaveto.Text))
                {
                    DialogResult result = MessageBox.Show("This file is always exsit, do you want to override it ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                }
                filedownload.PathFile = txtSaveto.Text;
                ObjStatic.FormMain.AddFileToCurrentCategory(filedownload);
                if (Info!=null&& Info.FileExist)
                {
                    if (!filedownload.Running)
                        filedownload.StartDownload();
                }
                else
                {
                    ObjStatic.FormMain.SaveCategory();
                    MessageBox.Show("File not found !",ObjStatic.MessageBoxCaption);
                }
                ObjStatic.Config.SaveConfigExtension(txtSaveto.Text);
                Close();
            }
            else MessageBox.Show("Folder is invalid !",ObjStatic.MessageBoxCaption);
        }
        private void btnDownloadLater_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(txtSaveto.Text)))
            {
                if (System.IO.File.Exists(txtSaveto.Text))
                {
                    DialogResult result = MessageBox.Show("This file is always exsit, do you want to override it ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;
                }
                filedownload.PathFile = txtSaveto.Text;
                if (filedownload.Running)
                    filedownload.StopDownload();
                ObjStatic.FormMain.AddFileToCurrentCategory(filedownload);
                ObjStatic.FormMain.SaveCategory();
                ObjStatic.Config.SaveConfigExtension(txtSaveto.Text);
                Close();
            }
            else MessageBox.Show("Folder is invalid !", ObjStatic.MessageBoxCaption);
        }
        private void StartGetFileSize()
        {

            Info = new LinkInfo(txtLinkFile.Text);
            string saveto = System.IO.Path.GetDirectoryName(txtSaveto.Text) + "\\" + Info.FileName;
            SetText(txtSaveto, saveto);
            string extension = System.IO.Path.GetExtension(Info.FileName);
            Icon icon = ObjStatic.ObjGetIcon.GetIconFromExtension(extension, GetIconWindow.IconSize.Large);
           if (icon != null)
            {
                SetIcon(picIconFile, (Image)icon.ToBitmap());
            }
            else SetIcon(picIconFile, picIconFile.ErrorImage);
            if (Info.Size >= 0)
            {
                SetText(lblFileSize, ObjStatic.ToStringSize(Info.Size));
                filedownload.Size = Info.Size;
                filedownload.PathFile = saveto;
            }
            if (ObjStatic.Config.AutoDownloadWhenHasLink)
            {
                filedownload.StartDownload();
            }
        }
        private void SetText(Control l, string text)
        {
            if (l.InvokeRequired)
            {
                SetTextCallback obj = SetText;
                l.Invoke(obj, l, text);
            }
            else
            {
                l.Text = text;
            }
        }
        private void SetIcon(PictureBox pic, Image img)
        {
            if (pic.InvokeRequired)
            {
                SetIconCallback obj = SetIcon;
                pic.Invoke(obj, pic, img);
            }
            else
            {
                pic.Image = pic.ErrorImage;
                pic.Refresh();
                pic.Image = img;
                pic.Refresh();
            }
        }
        #endregion
    }
}