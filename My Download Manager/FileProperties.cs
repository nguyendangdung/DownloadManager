using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace My_Download_Manager
{
    public partial class FileProperties : Form
    {
        #region >- Variable -<

        private FileDownload file;
        private delegate void SetTextCallBack(Label l, string Text);
        private delegate void SetProcessBarValueCallBack(long value, bool isValue);
        private delegate void UpdateProcessMultiPartCallback();
        private System.Threading.Thread TimerShowStatus;
        private int timersleep = 1000;

        #endregion

        #region >- Content -<

        public FileProperties(FileDownload file)
        {
            InitializeComponent();
            this.file = file;
        }
        private void ShowDetail(bool show)
        {
            if (show)
            {
                this.Height += panel1.Height;
            }
            else this.Height -= panel1.Height;
            panel1.Visible = show;
        }
        private void FileProperties_Load(object sender, EventArgs e)
        {
            ShowDetail(false);
            lblFileName.Text = System.IO.Path.GetFileName(this.file.PathFile);
            lblFileSize.Text = ObjStatic.ToStringSize(this.file.Size);
            if (this.file.IsMediafireLink)
                lblMediafireLink.Text = this.file.LinkMediaFire;
            lblResumeAble.Text = this.file.Resume.ToString();
            if (this.file.Resume == ResumeAble.No)
            {
                lblResumeAble.ForeColor = Color.Red;
            }
            txtLink.Text = this.file.Link;
            txtSaveto.Text = this.file.PathFile;
            if (!this.file.Running && this.file.Status != DownloadStatus.Complete)
            {
                btnBrowser.Enabled = true;
                txtSaveto.ReadOnly = false;
            }
            else
            {
                btnBrowser.Enabled = false;
                txtSaveto.ReadOnly = true;
            }
            SetTranferRate(string.Empty, string.Empty);
            if (file.Size > 0)
            {
                ProcessStatus.MaxValue = file.Size;
                ProcessStatus.Value = file.Loaded;
            }
            if (!file.Running)
            {
                file_CompleteDownload(null);
                file.BeginDownload -= new FileDownload.EventStartDownload(file_BeginDownload);
                file.BeginDownload += new FileDownload.EventStartDownload(file_BeginDownload);
            }
            else file_BeginDownload(null);
            file.CompleteDownload -= new FileDownload.EventDownloadComplete(file_CompleteDownload);
            file.CompleteDownload += new FileDownload.EventDownloadComplete(file_CompleteDownload);
        }
        private void file_CompleteDownload(object sender)
        {
            if (file.Status == DownloadStatus.Complete)
            {
                SetProcessBarValue(file.Size, true);
                ProcessStatus.Text = file.Status.ToString();
            }
            else
            {
                SetProcessBarValue(file.Loaded, true);
            }
            if (panel1.Visible)
            {
                try
                {
                    UpdateProcessMultiPart();
                }
                catch (Exception ex) { }
            }
        }
        private void file_BeginDownload(object sender)
        {
            ProcessStatusMultiPart.MaxValue = file.Size;
            ProcessStatusMultiPart.Parts = file.GetParts();
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(ShowStatus);
            TimerShowStatus = new System.Threading.Thread(ts);
            TimerShowStatus.Start();
        }
        private void SetText(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                SetTextCallBack obj = new SetTextCallBack(SetText);
                lbl.Invoke(obj, lbl, text);
            }
            else
            {
                lbl.Text = text;
            }
        }
        private void SetProcessBarValue(long value, bool isValue)
        {
            if (ProcessStatus.InvokeRequired)
            {
                SetProcessBarValueCallBack obj = new SetProcessBarValueCallBack(SetProcessBarValue);
                ProcessStatus.Invoke(obj, value, isValue);
            }
            else
            {
                if (isValue)
                    ProcessStatus.Value = value;
                else ProcessStatus.MaxValue = value;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PerformClose()
        {
            if (TimerShowStatus != null)
                TimerShowStatus.Abort();
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowNewFolderButton = true;
            f.ShowDialog();
            if (f.SelectedPath != null && f.SelectedPath.Length > 0)
            {
                txtSaveto.Text = f.SelectedPath + "\\" + lblFileName.Text;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSaveto.Text != this.file.PathFile)
            {
                this.file.PathFile = txtSaveto.Text;
            }
            this.Close();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            PerformClose();
            base.OnClosing(e);
        }
        private void ShowStatus()
        {
            while (file.Running && !this.Disposing)
            {
                SetProcessBarValue(file.Loaded, true);
                if (panel1.Visible)
                {
                    UpdateProcessMultiPart();
                }
                System.Threading.Thread.Sleep(timersleep);
            }
            ProcessStatus.Text = file.Status.ToString();
        }
        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            ShowDetail(!panel1.Visible);
            if (panel1.Visible)
            {
                btnShowDetail.Text = "<< Hide detail";
            }
            else btnShowDetail.Text = "Show detail >>";
        }
        private void UpdateProcessMultiPart()
        {
            if (ProcessStatusMultiPart.InvokeRequired)
            {
                UpdateProcessMultiPartCallback obj = new UpdateProcessMultiPartCallback(UpdateProcessMultiPart);
                ProcessStatusMultiPart.Invoke(obj);
            }
            else ProcessStatusMultiPart.UpdateValue();
        }
        public void SetTranferRate(string tranfer, string timeleft)
        {
            try
            {
                SetText(lblTranferRate, tranfer);
                SetText(lblTimeLeft, timeleft);
                string loaded = loaded = ObjStatic.ToStringSize(file.Loaded);
                SetText(lblDownloaded, loaded);
            }
            catch (Exception ex) { }
        }
        #endregion
    }
}
