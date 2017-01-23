using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace My_Download_Manager
{
    public partial class AddMultiUrl : Form
    {
        #region >- Variable -<
        
        private string[] Links;
        private delegate void AddRowCallback(string link);
        private delegate void AddControlToFlowLayoutCallback(string extension);
        private delegate void SetDataForCellCallBack(int row, int col, string value);
        private delegate void SetTextControlCallback(Control obj,string text);

        System.Threading.Thread threadGetSizeFile;
        private Hashtable ListExtension;
        private List<string> Extensions;
        private bool ischeckall = true;

        #endregion

        #region >- Content -<
        private bool IsAutoOpen = true;
        public AddMultiUrl()
        {
            InitializeComponent();
            IsAutoOpen = false;
            ListExtension = new Hashtable();
            Extensions = new List<string>();
            LoadCategory();
        }
        public AddMultiUrl(string[] links)
        {
            Links = links;
            InitializeComponent();
        }
        private void AddMultiUrl_Load(object sender, EventArgs e)
        {
            if (Links != null && Links.Length > 0)
            {
                LoadCategory();
                ListExtension = new Hashtable();
                Extensions = new List<string>();
                System.Threading.ThreadStart tsgetsize = GetSizeFile;
                threadGetSizeFile = new System.Threading.Thread(tsgetsize);
                threadGetSizeFile.Start();
            }
            else if(IsAutoOpen)
            {
                MessageBox.Show("Links not found !",ObjStatic.MessageBoxCaption);
                Close();
            }
        }
        private void AddUrls(string data)
        {
            if(!string.IsNullOrEmpty( data))
            {
                string[] str = data.Split('\n', ' ', '\t', '\r');
                for (int i = 0; i < str.Length; i++)
                {
                    string uri = str[i].ToLower();
                    if (uri.StartsWith("http://") || uri.StartsWith("https://"))
                        AddRow(uri);
                }
            }
        }
        private void ShowFilterCheckBox()
        {
            if (ListExtension.Count > 1)
            {
                for (int i = 0; i < 10 && i < Extensions.Count; i++)
                {
                    int max = 0;
                    int index = 0;
                    for (int j = 0; j < Extensions.Count; j++)
                    {
                        int current = Convert.ToInt32(ListExtension[Extensions[j]]);
                        if (current > max)
                        {
                            max = current;
                            index = j;
                        }
                    }
                    if (max > 0)
                    {
                        string ex = Extensions[index];
                        AddControlToFlowLayout(ex);
                        Extensions.RemoveAt(index);
                        ListExtension.Remove(ex);
                        i--;
                    }
                }
            }
        }
        private void AddControlToFlowLayout(string extension)
        {
            if (FilterFlowLayout.InvokeRequired)
            {
                AddControlToFlowLayoutCallback obj = AddControlToFlowLayout;
                FilterFlowLayout.Invoke(obj, extension);
            }
            else
            {
                CheckBox cbo = new CheckBox();
                cbo.Text = extension;
                cbo.Checked = true;
                cbo.AutoSize = true;
                cbo.CheckedChanged += cbo_CheckedChanged;
                FilterFlowLayout.Controls.Add(cbo);
                cbo.Show();
            }
        }
        private void cbo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbo = sender as CheckBox;
            for (int i = 0; i < GridLink.Rows.Count; i++)
            {
                DataGridViewRow row = GridLink.Rows[i];
                string filename = row.Cells[1].Value.ToString().ToLower();
                if (filename.EndsWith(cbo.Text))
                {
                    row.Visible = cbo.Checked;
                    row.Cells[0].Value = cbo.Checked;
                }
            }
        }
        private void GetSizeFile()
        {
            for (int i = 0; i < Links.Length; i++)
            {
                string link = Links[i];
                AddRow(link);
            }
            ShowFilterCheckBox();
        }
        private void AddRow(string link)
        {
            if (GridLink.InvokeRequired)
            {
                AddRowCallback obj = AddRow;
                GridLink.Invoke(obj, link);
            }
            else
            {
                string filename = GetFileNameFromURL(link);
                int index = GridLink.Rows.Add(true, filename, "Unknown", link);
                GridLink.Rows[index].Tag = -1;
                GridLink.Rows[index].Height = 18;
                if (!string.IsNullOrEmpty(filename))
                {
                    ((CustomGridCell)GridLink.Rows[index].Cells[1]).CellIcon = ObjStatic.ObjGetIcon.GetIconFromExtension(System.IO.Path.GetExtension(filename), GetIconWindow.IconSize.Small);
                    string extension = System.IO.Path.GetExtension(filename).ToLower();
                    if (extension.Length > 0)
                    {
                        if (ListExtension[extension] == null)
                        {
                            ListExtension[extension] = 1;
                            Extensions.Add(extension);
                        }
                        else ListExtension[extension] = Convert.ToInt32(ListExtension[extension]);
                    }
                }
            }
        }
        private string GetFileNameFromURL(string url)
        {
            try
            {
                string httpurl = url.Split('?')[0];
                string filename = System.IO.Path.GetFileName(httpurl);
                if (string.IsNullOrEmpty(filename))
                {
                    return "Unknown.htm";
                }
                return filename;
            }
            catch (Exception ex) { }
            return "Unknown.htm";
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.ShowDialog();
            if (!string.IsNullOrEmpty(folder.SelectedPath))
            {
                txtSaveto.Text = folder.SelectedPath;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaveto.Text))
            {
                MessageBox.Show("Please select folder to save files !",ObjStatic.MessageBoxCaption);
                txtSaveto.Focus();
                return;
            }
            string saveto = txtSaveto.Text;
            if (System.IO.Directory.Exists(saveto))
            {
                for (int i = 0; i < GridLink.Rows.Count; i++)
                {
                    DataGridViewRow row = GridLink.Rows[i];
                    if (row.Visible && Convert.ToBoolean(row.Cells[0].Value))
                    {
                        long size = -1;
                        string filename = row.Cells[1].Value.ToString();
                        string link = row.Cells[3].Value.ToString();
                        size = Convert.ToInt32(row.Tag);
                        File fd = new File(saveto + "\\" + filename, link, size, filename);
                        ObjStatic.FormMain.AddFileToCurrentCategory(fd);
                    }
                }
                ObjStatic.FormMain.Category[cboCategory.SelectedIndex].SaveTo = txtSaveto.Text;
                ObjStatic.FormMain.SaveCategory();
                Close();
            }
            else
            {
                MessageBox.Show("Folder save file not exist !");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (threadGetSizeFile != null)
            {
                try
                {
                    threadGetSizeFile.Abort();
                }
                catch (Exception ex) { }
            }
            if (threadCheckSize != null)
            {
                try
                {
                    threadCheckSize.Abort();
                }
                catch (Exception ex) { }
            }
            base.OnClosing(e);
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            ischeckall = !ischeckall;
            for (int i = 0; i < GridLink.Rows.Count; i++)
            {
                DataGridViewRow row = GridLink.Rows[i];
                if (row.Visible)
                {
                    row.Cells[0].Value = ischeckall;
                }
            }
            if (ischeckall)
            {
                btnCheckAll.Text = "Uncheck All";
            }
            else btnCheckAll.Text = "Check All";
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
            txtSaveto.Text = ObjStatic.FormMain.Category[index].SaveTo;
        }
        #endregion
        private void SetDataForCell(int row, int col, string value)
        {
            if (GridLink.InvokeRequired)
            {
                SetDataForCellCallBack obj = SetDataForCell;
                GridLink.Invoke(obj, row, col, value);
            }
            else
            {
                GridLink.Rows[row].Cells[col].Value = value;
                if (col == 1)
                {
                    ((CustomGridCell)GridLink.Rows[row].Cells[col]).CellIcon = ObjStatic.ObjGetIcon.GetIconFromExtension(System.IO.Path.GetExtension(value), GetIconWindow.IconSize.Small);
                }
            }
        }
        private void StartCheckLink()
        {
            for (int i = 0; i < GridLink.Rows.Count; i++)
            {
                DataGridViewRow row= GridLink.Rows[i];
                if (row.Visible&&(bool)row.Cells[0].Value)
                {
                    string link = row.Cells[3].Value.ToString();
                    row.Cells[2].Value = "...";
                    LinkInfo lf = new LinkInfo(link);
                    if (lf.FileExist)
                    {
                        row.Tag = lf.Size;
                        row.Cells[1].Value = lf.FileName;
                        row.Cells[2].Value = ObjStatic.ToStringSize(lf.Size);
                    }
                    else
                    {
                        row.Cells[2].Value = "Error";
                    }
                }
            }
            IsCheckinglink = false;
            SetText(btnCheckLink, "Check link");
        }
        private System.Threading.Thread threadCheckSize;
        private bool IsCheckinglink = false;
        private void btnCheckLink_Click(object sender, EventArgs e)
        {
            if (!IsCheckinglink)
            {
                IsCheckinglink = true;
                System.Threading.ThreadStart ts = StartCheckLink;
                threadCheckSize = new System.Threading.Thread(ts);
                threadCheckSize.Start();
                btnCheckLink.Text = "Stop check link";
            }
            else
            {
                try
                {
                    threadCheckSize.Abort();
                }
                catch (Exception ex) { }
                IsCheckinglink = false;
                SetText(btnCheckLink, "Check link");
            }
        }
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSaveto.Text = ObjStatic.FormMain.Category[cboCategory.SelectedIndex].SaveTo;
        }
        private void SetText(Control obj,string text)
        {
            if (obj.InvokeRequired)
            {
                SetTextControlCallback objcallback = SetText;
                obj.Invoke(objcallback, obj, text);
            }
            else obj.Text = text;
        }

        private void btnAddLinks_Click(object sender, EventArgs e)
        {
            if (txtURLs.Text.Length > 0)
            {
                AddUrls(txtURLs.Text);
            }
            else
            {
                MessageBox.Show("Please input text contain link in this textbox !", ObjStatic.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtURLs.Focus();
            }

        }
    }
}