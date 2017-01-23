using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace My_Download_Manager
{
    public partial class ShowFileSniffer : Form
    {
        private delegate void SetFormVisibleCalback();
        private delegate void AddControlToFormCallback(ControlSniffFile csf, bool IsAdd);
        private delegate void SetPositionControlSniffFileCallback(ControlSniffFile csf, int top);
        private delegate void SetTopHeightFromCallback(int top, int height);
        private delegate void ClearControlCallback();
        private int MaxElement = 12;
        private List<ControlSniffFile> lstcontrol;
        Timer TimerShowFile;
        int deltay = 20;
        int maxheight = 0;
        bool IsRunning = false;
        int temp = 0;
        int MinHeight = 24;
        int timeoff = 300;
        int WorkingHeight = 0;
        int w_top = 20;
        public ShowFileSniffer()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case 0x0112:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == 0xF010)
                        return;
                    break;
            }
            base.WndProc(ref message);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            temp = 0;
            if (deltay > 0)
                deltay = -deltay;
            e.Cancel = true;
        }
        private void ShowFileSniffer_Load(object sender, EventArgs e)
        {
            MinHeight = Height;
            Rectangle rec = Screen.PrimaryScreen.WorkingArea;
            Left = rec.Width - Width;
            Top = rec.Height - Height;
            WorkingHeight = rec.Height;
            lstcontrol = new List<ControlSniffFile>();
            TimerShowFile = new Timer();
            TimerShowFile.Tick += new EventHandler(TimerShowFile_Tick);
            TimerShowFile.Interval = 150;
            TimerShowFile.Enabled = true;
        }
        private void TimerShowFile_Tick(object sender, EventArgs e)
        {
            if (temp % timeoff == 0)
            {
                int top = Top - deltay;
                int height = Height + deltay;
                if (deltay > 0)
                {
                    if (height > maxheight)
                    {
                        top = WorkingHeight - maxheight;
                        height = maxheight;
                        deltay = -deltay;
                        temp = 1;
                    }
                }
                else
                {
                    if (height < MinHeight)
                    {
                        top = WorkingHeight - MinHeight;
                        height = MinHeight;
                        for (int i = 0; i < lstcontrol.Count; i++)
                        {
                            ObjStatic.FormSniffer.AddFileSniffer((FileSniffer)lstcontrol[i].Tag);
                        }
                        ObjStatic.FormSniffer.SaveFileSniff();
                        ClearControl();
                        lstcontrol.Clear();
                        temp = 1;
                        Visible = false;
                    }
                }
                SetTopHeightFrom(top, height);
            }
            else
            {
                if (!Bounds.Contains(Cursor.Position))
                    temp++;
                else
                {
                    temp = 0;
                    deltay = -deltay;
                }
            }
        }
        private void SetTopHeightFrom(int top, int height)
        {
            if (InvokeRequired)
            {
                SetTopHeightFromCallback obj = new SetTopHeightFromCallback(SetTopHeightFrom);
                Invoke(obj, top, height);
            }
            else
            {
                Top = top;
                Height = height;
            }
        }
        private void SetFormVisible()
        {
            if (InvokeRequired)
            {
                SetFormVisibleCalback obj = new SetFormVisibleCalback(SetFormVisible);
                Invoke(obj);
            }
            else
            {
                if (!Visible)
                    Visible = true;
            }
        }
        private void AddControlToForm(ControlSniffFile csf, bool IsAdd)
        {
            if (InvokeRequired)
            {
                AddControlToFormCallback obj = new AddControlToFormCallback(AddControlToForm);
                Invoke(obj, csf, IsAdd);
            }
            else
            {
                if (IsAdd)
                    Controls.Add(csf);
                else Controls.Remove(csf);
            }
        }
        public void AddFile(FileSniffer file)
        {
            if (IsExistLink(file.Link))
                return;
            SetFormVisible();
            ControlSniffFile csf = new ControlSniffFile(file.FileName, ObjStatic.ToStringSize(file.Size));
            csf.Tag = file;
            csf.PerformDeleteFile += new ControlSniffFile.DeleteFile(csf_PerformDeleteFile);
            csf.StartDownloadFile += new ControlSniffFile.FileDownload(csf_StartDownloadFile);
            lstcontrol.Insert(0, csf);
            AddControlToForm(csf, true);
            if (lstcontrol.Count > MaxElement)
            {
                AddControlToForm(lstcontrol[MaxElement], false);
                lstcontrol.RemoveAt(MaxElement);
            }
            int W_Y = 2;
            maxheight = MinHeight + lstcontrol.Count * (csf.Height + W_Y);
            int start = w_top + W_Y;
            for (int i = 0; i < lstcontrol.Count; i++)
            {
                SetPositionControlSniffFile(lstcontrol[i], start);
                start += csf.Height + W_Y;
            }
            if (!IsRunning)
            {
                IsRunning = true;
                TimerShowFile.Start();
            }
            if (deltay < 0)
                deltay = -deltay;
            temp = 0;
        }

        void csf_StartDownloadFile(ControlSniffFile control)
        {
            FileSniffer fs = (FileSniffer)control.Tag;
            string saveat = ObjStatic.Config.DefaultTypeSniffer[fs.TypeIndex].PathSave;

            string ptemp = ObjStatic.Config.GetPathSaveFileFromExtension(System.IO.Path.GetExtension(fs.FileName));
            if (!string.IsNullOrEmpty(ptemp))
                saveat = ptemp;
            OpenFileDialog fbd = new OpenFileDialog();
            fbd.InitialDirectory = saveat;
            fbd.CheckFileExists = false;
            fbd.FileName = fs.FileName;
            fbd.ShowDialog();
            if (!string.IsNullOrEmpty(fbd.FileName))
            {
                saveat = System.IO.Path.GetDirectoryName(fbd.FileName);
            }
            if (!string.IsNullOrEmpty(saveat) && saveat.Length > 0)
            {

                ObjStatic.Config.DefaultTypeSniffer[fs.TypeIndex].PathSave = saveat;
                ObjStatic.Config.SaveConfigExtension(saveat);

                string txtpathfile = fbd.FileName;
                bool Iscancel = false;
                if (System.IO.File.Exists(txtpathfile))
                {
                    DialogResult dr = MessageBox.Show("This file is always exist !\nDo you want to replace it ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
                    Iscancel = (dr == DialogResult.No);
                }
                if (!Iscancel)
                {
                    File fd = new File(txtpathfile, fs.Link, fs.Size, System.IO.Path.GetFileName(txtpathfile));
                    ObjStatic.FormMain.AddFileToCurrentCategory(fd, true);
                    RemoveFile(control);
                }
            }
        }
        void csf_PerformDeleteFile(ControlSniffFile control)
        {
            RemoveFile(control);
        }
        private void SetPositionControlSniffFile(ControlSniffFile csf, int top)
        {
            if (csf.InvokeRequired)
            {
                SetPositionControlSniffFileCallback obj = new SetPositionControlSniffFileCallback(SetPositionControlSniffFile);
                csf.Invoke(obj, csf, top);
            }
            else csf.Top = top;
        }
        private void ClearControl()
        {
            if (InvokeRequired)
            {
                ClearControlCallback obj = new ClearControlCallback(ClearControl);
                Invoke(obj);
            }
            else
            {
                for (int i = 0; i < lstcontrol.Count; i++)
                    Controls.Remove(lstcontrol[i]);
            }
        }
        public void RemoveFile(ControlSniffFile csf)
        {
            lstcontrol.Remove(csf);
            AddControlToForm(csf, false);
            int W_Y = 2;
            maxheight = MinHeight + lstcontrol.Count * (csf.Height + W_Y);
            int start = w_top + W_Y;
            for (int i = 0; i < lstcontrol.Count; i++)
            {
                SetPositionControlSniffFile(lstcontrol[i], start);
                start += csf.Height + W_Y;
            }
            SetTopHeightFrom(Top + csf.Height, Height - csf.Height);
            if (lstcontrol.Count == 0)
                temp = 0;
        }
        private void LinkDownloadAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lstcontrol.Count > 0)
            {
                if (CheckExistFileName())
                {
                    MessageBox.Show("Have some similar file name !\nChange file name by click at the file name.", ObjStatic.MessageBoxCaption);
                    return;
                }
                FileSniffer fs0 = (FileSniffer)lstcontrol[0].Tag;
                string savepath = ObjStatic.Config.DefaultTypeSniffer[fs0.TypeIndex].PathSave;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.SelectedPath = savepath;
                fbd.ShowNewFolderButton = true;
                fbd.ShowDialog();
                if (!string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    string path = fbd.SelectedPath;
                    for (int i = 0; i < lstcontrol.Count; )
                    {
                        FileSniffer fs = (FileSniffer)lstcontrol[i].Tag;
                        string pathfile = path + "\\" + fs.FileName;
                        if (!System.IO.File.Exists(pathfile))
                        {
                            File fd = new File(pathfile, fs.Link, fs.Size, fs.FileName);
                            ObjStatic.FormMain.AddFileToCurrentCategory(fd, true);
                            RemoveFile(lstcontrol[i]);
                        }
                        else i++;
                    }
                    if (lstcontrol.Count > 0)
                        MessageBox.Show("Some file always exist, please rename to continue download !", ObjStatic.MessageBoxCaption);
                    else
                    {
                        temp = 0;
                        if (deltay > 0)
                            deltay = -deltay;
                    }
                }
            }
        }
        private bool CheckExistFileName()
        {
            System.Collections.Hashtable has = new System.Collections.Hashtable();
            for (int i = 0; i < lstcontrol.Count; i++)
            {
                string filename = ((FileSniffer)lstcontrol[0].Tag).FileName.Trim();
                if (has[filename] != null)
                    return true;
                has[filename] = true;
            }
            return false;
        }
        private bool IsExistLink(string link)
        {
            for (int i = 0; i < lstcontrol.Count; i++)
            {
                FileSniffer f = (FileSniffer)lstcontrol[i].Tag;
                if (f.Link == link)
                    return true;
            }
            return false;
        }
        private void btnBrowser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ObjStatic.ShowFormSniff();
        }
    }
}