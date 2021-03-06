using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
namespace My_Download_Manager
{
    public partial class GetAudioBook : Form
    {
        #region >- Variable -<

        private delegate void SetTextCallback(Label lbl, string text);
        private delegate void AddRowToGridCallback(string Name, int BookID, string Link);
        private System.Threading.Thread threadGetBookInfo;
        private System.Threading.Thread threadGetFile;
        bool StopGet = true;
        private string SaveTo = string.Empty;
        int CurrentFile = 0;
        string FormatLinkBook = "http://media.tuoitre.com.vn/BookDetail.aspx?BookID=";
        string FormatLinkAudioBook = "http://media.tuoitre.com.vn/Playlist.aspx?Book=";

        #endregion

        #region >- Content -<

        public GetAudioBook()
        {
            InitializeComponent();
            LoadCategory();
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.ShowDialog();
            if (folder.SelectedPath != null && folder.SelectedPath.Length > 0)
            {
                txtSaveTo.Text = folder.SelectedPath;
            }
        }
        private void SetText(Label lbl, string text)
        {
            if (lbl.InvokeRequired)
            {
                SetTextCallback obj = SetText;
                lbl.Invoke(obj, lbl, text);
            }
            else
            {
                lbl.Text = text;
            }
        }
        private string GetTitleBook(int BookID)
        {
            string Title = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://media.tuoitre.com.vn/BookDetail.aspx?BookID=" + BookID);
                request.UserAgent = ObjStatic.UserAgent;
                StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream());
                string str = sr.ReadToEnd();
                sr.Close();
                string patern = "<div(.*)spPath(.*)TopAlbumHeaderText(.*)>(.*)</div>";
                Regex r = new Regex(patern, RegexOptions.IgnoreCase ^ RegexOptions.Multiline);
                Match match = r.Match(str);
                if (match.Groups.Count > 4)
                {
                    Title = match.Groups[4].Value;
                }
            }
            catch (Exception ex)
            {
            }
            return Title;
        }
        private void AddRowToGrid(string Name, int BookID, string Link)
        {
            if (GridListBook.InvokeRequired)
            {
                AddRowToGridCallback obj = AddRowToGrid;
                GridListBook.Invoke(obj, Name, BookID, Link);
            }
            else
            {
                GridListBook.Rows.Add(true, Name, BookID, Link);
            }
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            GridListBook.Rows.Clear();
            StopGet = false;
            System.Threading.ThreadStart ts = StartGetBookInfo;
            threadGetBookInfo = new System.Threading.Thread(ts);
            threadGetBookInfo.Start();
        }
        private void StartGetBookInfo()
        {
            int from = 0;
            int to = 0;
            if (IsNumber(txtFrom.Text))
            {
                from = Convert.ToInt32(txtFrom.Text);
            }
            else
            {
                MessageBox.Show("BookID không hợp lệ, BookID phải là số lớn hơn 0 và ít hơn 5 chữ số !", ObjStatic.MessageBoxCaption);
                txtFrom.Focus();
                return;
            }
            if (IsNumber(txtTo.Text))
            {
                to = Convert.ToInt32(txtTo.Text);
            }
            else
            {
                MessageBox.Show("BookID không hợp lệ, BookID phải là số lớn hơn 0 và ít hơn 5 chữ số !", ObjStatic.MessageBoxCaption);
                txtTo.Focus();
                return;
            }
            int f = Math.Min(from, to);
            int t = Math.Max(from, to);
            int count = 0;
            for (int i = f; i <= t; i++)
            {
                string TitleBook = GetTitleBook(i);
                if (TitleBook.Length > 0)
                {
                    AddRowToGrid(TitleBook, i, FormatLinkBook + i);
                    SetText(lblEbookValid, "" + (++count));
                }
            }
            MessageBox.Show("Tìm thấy " + count + " Audiobooks !", ObjStatic.MessageBoxCaption);
            StopGet = true;
        }
        private Boolean IsNumber(string value)
        {
            return Regex.IsMatch(value, @"^([0-9]){1,4}$");
        }
        private void GetAudioBook_Load(object sender, EventArgs e)
        {
            txtSaveTo.Text = ObjStatic.FormMain.GetCurrentPathOfCategory();
        }
        private void GetAudioBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!StopGet)
            {
                DialogResult result = MessageBox.Show("Bạn thực sự muốn thoát ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (threadGetBookInfo != null)
                        threadGetBookInfo.Abort();
                    if (threadGetFile != null)
                        threadGetFile.Abort();
                }
                else e.Cancel = true;
            }
        }
        private void PerformCheckAll(bool ischeck)
        {
            for (int i = 0; i < GridListBook.Rows.Count; i++)
            {
                GridListBook.Rows[i].Cells[0].Value = ischeck;
            }
        }
        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            PerformCheckAll(true);
        }
        private void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            PerformCheckAll(false);
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (StopGet)
            {
                Close();
            }
            else MessageBox.Show("Đang load file bạn vui lòng chờ một tí nhé ^_^ !", ObjStatic.MessageBoxCaption);
        }
        private void StartGetFile()
        {
            bool iscurrent = IsCurrentListFile();
            ListFile lf = GetCurrentListFile();
            for (int i = 0; i < GridListBook.Rows.Count; i++)
            {
                if (Convert.ToBoolean(GridListBook.Rows[i].Cells[0].Value))
                {
                    int bookid = Convert.ToInt32(GridListBook.Rows[i].Cells[2].Value);
                    string bookname = GridListBook.Rows[i].Cells[1].Value.ToString();
                    PerformGetFile(lf, iscurrent, bookid, bookname);
                }
            }
            ObjStatic.FormMain.SaveCategory();
            MessageBox.Show("Đã thêm vào category !", ObjStatic.MessageBoxCaption);
            StopGet = true;
        }
        private void PerformGetFile(ListFile lf, bool IsCurrent, int IDBook, string BookName)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(FormatLinkAudioBook + IDBook);
                request.UserAgent = ObjStatic.UserAgent;
                request.ConnectionGroupName = BookName;
                StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream());
                string input = sr.ReadToEnd();
                sr.Close();
                string format = "href=\"(.*?)\"";
                MatchCollection matches = Regex.Matches(input, format, RegexOptions.IgnoreCase);
                foreach (Match m in matches)
                {
                    if (m.Groups.Count > 1)
                    {
                        string link = m.Groups[1].Value.Trim().Replace("mms:", "http:");
                        string filename = Path.GetFileName(link);
                        if (filename.Length > 0)
                        {
                            File fd = new File(SaveTo + "\\" + BookName + "\\" + filename, link, -1, filename);
                            if (IsCurrent)
                                ObjStatic.FormMain.AddFileToCurrentCategory(fd);
                            else lf.AddFile(fd);
                            CurrentFile++;
                            SetText(lblTotalFile, CurrentFile.ToString());
                        }
                    }
                }
                request.GetResponse().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xãy ra :" + ex.Message);
            }
        }
        private bool HasChooseFile()
        {
            for (int i = 0; i < GridListBook.Rows.Count; i++)
            {
                if (Convert.ToBoolean(GridListBook.Rows[i].Cells[0].Value))
                    return true;
            }
            return false;
        }
        private void btnGetFile_Click(object sender, EventArgs e)
        {
            if (!StopGet)
            {
                MessageBox.Show("Chương trình đang lấy sách, bạn vui lòng chờ tí nhé ^_^ !", ObjStatic.MessageBoxCaption);
                return;
            }
            if (txtSaveTo.Text.Length > 0 && Directory.Exists(txtSaveTo.Text))
            {
                if (HasChooseFile())
                {
                    StopGet = false;
                    SaveTo = txtSaveTo.Text;
                    SetText(lblTotalFile, "0");
                    CurrentFile = 0;
                    System.Threading.ThreadStart ts = StartGetFile;
                    threadGetFile = new System.Threading.Thread(ts);
                    threadGetFile.Start();
                }
                else MessageBox.Show("Bạn chưa chọn Audio book cần download !", ObjStatic.MessageBoxCaption);
            }
            else
            {
                MessageBox.Show("Đường dẫn lưu file không hợp lệ !", ObjStatic.MessageBoxCaption);
                txtSaveTo.Focus();
            }
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
        }
        private ListFile GetCurrentListFile()
        {
            if (cboCategory.InvokeRequired)
            {
                GetCurrentListFileCallBack obj = GetCurrentListFile;
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
        #endregion
    }
}