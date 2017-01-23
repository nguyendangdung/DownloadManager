using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace My_Download_Manager
{
    public partial class MediafireDownload : Form
    {
        private delegate void AddRowToGridCallBack(bool Checked, string FileName, long Size, MediafireStatus Status, string LinkMediaFire, string Link);
        private delegate void ClearGridCallBack();
        private delegate void DeleteRowCallBack(DataGridViewRow row);
        private delegate void SetDataForCellCallBack(int row, int col, string value);
        private delegate void SetTextCallback(Label lbl, string text);
        private System.Threading.Thread threadgetlink;
        private System.Threading.Thread threadchecklink;
        private bool IsLinkGetting = false;
        private bool IsLinkChecking = false;
        private string[] Links;
        private enum MediafireStatus { Ok, Fail, Unknown };
        private ObjLinkMediafire ObjMediaFire;
        public MediafireDownload()
        {
            InitializeComponent();
            ObjMediaFire = new ObjLinkMediafire();
            LoadCategory();
        }
        private void AddRowToGrid(bool Checked, string FileName, long Size, MediafireStatus Status, string LinkMediaFire, string Link)
        {
            if (GridFile.InvokeRequired)
            {
                AddRowToGridCallBack obj = new AddRowToGridCallBack(AddRowToGrid);
                GridFile.Invoke(obj, Checked, FileName, Size, Status, LinkMediaFire, Link);
            }
            else
            {
                string strsize = string.Empty;
                if (Size > -1)
                    strsize = ObjStatic.ToStringSize(Size);
                int index = GridFile.Rows.Add(Checked, FileName, strsize, Status.ToString(), LinkMediaFire, Link);
                DataGridViewRow row = GridFile.Rows[index];
                if (!string.IsNullOrEmpty(FileName))
                    ((CustomGridCell)row.Cells[1]).CellIcon = ObjStatic.ObjGetIcon.GetIconFromExtension(System.IO.Path.GetExtension(FileName), GetIconWindow.IconSize.Small);
                row.Tag = Size;
                row.Height = 18;
            }
        }
        private void ClearGrid()
        {
            if (GridFile.InvokeRequired)
            {
                ClearGridCallBack obj = new ClearGridCallBack(ClearGrid);
                GridFile.Invoke(obj);
            }
            else GridFile.Rows.Clear();
        }
        private void DeleteRow(DataGridViewRow row)
        {
            if (GridFile.InvokeRequired)
            {
                DeleteRowCallBack obj = new DeleteRowCallBack(DeleteRow);
                GridFile.Invoke(obj, row);
            }
            else GridFile.Rows.Remove(row);
        }
        private void SetText(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                SetTextCallback obj = new SetTextCallback(SetText);
                lbl.Invoke(obj, lbl, text);
            }
            else
            {
                lbl.Text = text;
            }
        }
        private void SetDataForCell(int row, int col, string value)
        {
            if (GridFile.InvokeRequired)
            {
                SetDataForCellCallBack obj = new SetDataForCellCallBack(SetDataForCell);
                GridFile.Invoke(obj, row, col, value);
            }
            else
            {
                GridFile.Rows[row].Cells[col].Value = value;
                if (col == 1)
                {
                    ((CustomGridCell)GridFile.Rows[row].Cells[col]).CellIcon = ObjStatic.ObjGetIcon.GetIconFromExtension(System.IO.Path.GetExtension(value), GetIconWindow.IconSize.Small);
                }
            }
        }
        private bool IsMediaFireLink(string link)
        {
            try
            {
                Uri url = new Uri(link.Trim());
                string host = url.Host.ToLower();
                return host == "www.mediafire.com" || host == "mediafire.com";
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        private bool IsLinkFolder(string link)
        {

            string[] str = link.Trim().Split('?');
            if (str.Length > 1)
            {
                string temp = str[1].ToLower();
                return temp.StartsWith("sharekey=");
            }
            return false;
        }
        private void btnGetLink_Click(object sender, EventArgs e)
        {
            if (!StopGetLink())
                return;
            string data = txtLinkMediafire.Text.Trim();
            if (!string.IsNullOrEmpty(data))
            {
                Links = data.Split('\n', '\r', '\t');
                System.Threading.ThreadStart ts = new System.Threading.ThreadStart(StartGetLink);
                threadgetlink = new System.Threading.Thread(ts);
                threadgetlink.Start();
            }
            else
            {
                MessageBox.Show("Please input link mediafire to continue !", ObjStatic.MessageBoxCaption);
                txtLinkMediafire.Focus();
            }
        }
        private void StartGetLink()
        {
            IsLinkGetting = true;
            int count = 0;
            SetText(lblStatus, "Please wait, Getting ...");
            for (int i = 0; i < Links.Length; i++)
            {
                SetText(lblStatus, "Processing link " + (i + 1) + "...");
                string link = Links[i].Trim();
                if (string.IsNullOrEmpty(link))
                    continue;
                if (IsMediaFireLink(link))
                {
                    if (IsLinkFolder(link))
                    {
                        List<string[]> list = null;
                        try
                        {
                            list = ObjMediaFire.GetLinkFolder(link);
                        }
                        catch (Exception ex)
                        {
                        }
                        if (list != null)
                        {
                            for (int j = 0; j < list.Count; j++)
                            {
                                string[] str = list[j];
                                string linkmediafire = "http://www.mediafire.com/?" + str[1];
                                long size = 0;
                                long.TryParse(str[2], out size);
                                if (size > 0)
                                {
                                    AddRowToGrid(true, str[0], size, MediafireStatus.Ok, linkmediafire, string.Empty);
                                    count++;
                                }
                            }
                        }
                    }
                    else
                    {
                        AddRowToGrid(true, string.Empty, -1, MediafireStatus.Unknown, link, string.Empty);
                        count++;
                    }
                }
            }
            SetText(lblStatus, "Process complete " + count + " link valid.");
            MessageBox.Show("Found " + count + " link valid !");
            IsLinkGetting = false;
        }
        private void StartCheckLink()
        {
            IsLinkChecking = true;
            int count = 0;
            for (int i = 0; i < GridFile.Rows.Count; i++)
            {
                DataGridViewRow row = GridFile.Rows[i];
                if ((bool)row.Cells[0].Value)
                {
                    SetDataForCell(i, 3, "...");
                    string link = row.Cells[4].Value.ToString();
                    string directlink = string.Empty;
                    try
                    {
                        directlink = ObjMediaFire.GetLinkMediaFire(link);
                    }
                    catch (Exception ex)
                    { }
                    if (!string.IsNullOrEmpty(directlink))
                    {
                        string filename = System.IO.Path.GetFileName(directlink);
                        SetDataForCell(i, 1, filename);
                        SetDataForCell(i, 3, MediafireStatus.Ok.ToString());
                        SetDataForCell(i, 5, directlink);
                        count++;
                    }
                    else SetDataForCell(i, 3, MediafireStatus.Fail.ToString());
                }
            }
            MessageBox.Show("Check link complete, " + count + " files OK", ObjStatic.MessageBoxCaption);
            IsLinkChecking = false;
        }
        private void btnCheckLink_Click(object sender, EventArgs e)
        {
            if (!StopCheckLink())
                return;
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(StartCheckLink);
            threadchecklink = new System.Threading.Thread(ts);
            threadchecklink.Start();
        }
        private void LoadCategory()
        {
            cboCategory.Items.Clear();
            int index = 0;
            string current = string.Empty;
            if (ObjStatic.FormMain.CurrentListFile != null)
                current = ObjStatic.FormMain.CurrentListFile.Name;
            for (int i = 0; i < ObjStatic.FormMain.Category.Count; i++)
            {
                cboCategory.Items.Add(ObjStatic.FormMain.Category[i]);
                if (ObjStatic.FormMain.Category[i].Name == current)
                    index = i;
            }
            cboCategory.DisplayMember = "Name";
            cboCategory.SelectedIndex = index;
            txtSaveTo.Text = ObjStatic.FormMain.Category[index].SaveTo;
        }
        private void PerformCheck(bool IsChecked)
        {
            for (int i = 0; i < GridFile.Rows.Count; i++)
            {
                GridFile.Rows[i].Cells[0].Value = IsChecked;
            }
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            PerformCheck(true);
        }
        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            PerformCheck(false);
        }
        private void btnAddtocategory_Click(object sender, EventArgs e)
        {
            if (!StopCheckLink() || !StopGetLink())
                return;
            string path = txtSaveTo.Text;
            if (!System.IO.Directory.Exists(path))
            {
                MessageBox.Show("Path save file is not exist !", ObjStatic.MessageBoxCaption);
                return;
            }
            bool iscurrent = IsCurrentListFile();
            ListFile lf = GetCurrentListFile();
            for (int i = 0; i < GridFile.Rows.Count; i++)
            {
                DataGridViewRow row = GridFile.Rows[i];
                if ((bool)row.Cells[0].Value)
                {
                    string filename = row.Cells[1].Value.ToString();
                    string linkmediafire = row.Cells[4].Value.ToString();
                    string linkdirect = row.Cells[5].Value.ToString();
                    if (string.IsNullOrEmpty(linkdirect))
                        linkdirect = linkmediafire;
                    long size = Convert.ToInt32(row.Tag);
                    File fd = new File(path + "\\" + filename, linkdirect, size, filename);
                    fd.IsMediafireLink = true;
                    fd.LinkMediaFire = linkmediafire;
                    if (iscurrent)
                        ObjStatic.FormMain.AddFileToCurrentCategory(fd);
                    else
                    {
                        lf.AddFile(fd);
                    }
                    GridFile.Rows.RemoveAt(i);
                    i--;
                }
            }
            ObjStatic.FormMain.Category[cboCategory.SelectedIndex].SaveTo = txtSaveTo.Text;
            ObjStatic.FormMain.SaveCategory();
            MessageBox.Show("The selected files have been add to categories.", ObjStatic.MessageBoxCaption);
        }
        private ListFile GetCurrentListFile()
        {
            if (cboCategory.InvokeRequired)
            {
                GetCurrentListFileCallBack obj = new GetCurrentListFileCallBack(GetCurrentListFile);
                return (ListFile)cboCategory.Invoke(obj);
            }
            return (ListFile)cboCategory.SelectedItem;
        }
        public delegate ListFile GetCurrentListFileCallBack();
        private bool IsCurrentListFile()
        {
            ListFile lf = GetCurrentListFile();
            if (ObjStatic.FormMain.CurrentListFile != null)
            {
                if (ObjStatic.FormMain.CurrentListFile.Name == lf.Name)
                    return true;
            }
            return false;
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.SelectedPath = txtSaveTo.Text;
            folder.ShowNewFolderButton = true;
            folder.ShowDialog();
            if (!string.IsNullOrEmpty(folder.SelectedPath))
                txtSaveTo.Text = folder.SelectedPath;
        }
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSaveTo.Text = ObjStatic.FormMain.Category[cboCategory.SelectedIndex].SaveTo;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (threadchecklink != null)
                threadchecklink.Abort();
            if (threadgetlink != null)
                threadgetlink.Abort();
            base.OnClosing(e);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            GridFile.Rows.Clear();
        }

        private void btnStopGetLink_Click(object sender, EventArgs e)
        {
            StopGetLink();
            StopCheckLink();
        }
        private bool StopCheckLink()
        {
            if (IsLinkChecking)
            {
                DialogResult result = MessageBox.Show("Check Link is Running ! Do you want to stop it ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return false;
                threadchecklink.Abort();
                SetText(lblStatus, "The processing has been cancel !");
                IsLinkChecking = false;
            }
            return true;
        }
        private bool StopGetLink()
        {
            if (IsLinkGetting)
            {
                DialogResult result = MessageBox.Show("Get Link is Running, Do you want to stop it ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return false;
                threadgetlink.Abort();
                SetText(lblStatus, "The processing has been cancel !");
                IsLinkGetting = false;
            }
            return true;
        }
    }
}