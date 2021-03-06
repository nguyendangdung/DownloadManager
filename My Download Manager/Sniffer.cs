using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Collections;
namespace My_Download_Manager
{
    public partial class Sniffer : Form
    {
        List<List<FileSniffer>> ListFileSniffer;
        string pathsavefilesniff = "Sniffer.obj";
        private TreeNode CurrentNode = null;
        private delegate void AddRowToGridCallBack(FileSniffer file);
        private delegate void DeleteRowInGridCallback(DataGridViewRow row);
        private delegate void ClearGridCallback();
        private delegate void PerformCheckCallback(bool IsCheck);
        public Sniffer()
        {
            InitializeComponent();
            LoadTreeTypefile();
            LoadListFile();
        }
        private void Sniffer_Load(object sender, EventArgs e)
        {
        }
        private void LoadTreeTypefile()
        {
            ImageList imgs = new ImageList();
            imgs.Images.Add("root", ObjStatic.MdmImages.Category);
            imgs.Images.Add("child", ObjStatic.MdmImages.Orther);
            TreeTypeSniffer.ImageList = imgs;
            TreeTypeSniffer.Nodes.Add("File Type", "File Type");
            TreeNode node = TreeTypeSniffer.Nodes[0];
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            for (int i = 0; i < ObjStatic.Config.DefaultTypeSniffer.Length; i++)
            {
                TypeSniffer obj = ObjStatic.Config.DefaultTypeSniffer[i];
                TreeNode n = node.Nodes.Add(obj.Type, obj.Type);
                n.ImageIndex = 1;
                n.SelectedImageIndex = 1;
            }
            node.Expand();
        }
        private void LoadListFile()
        {
            string path = ObjStatic.PathAppUserTemp + pathsavefilesniff;
            if (System.IO.File.Exists(path))
            {
                try
                {
                    ListFileSniffer = (List<List<FileSniffer>>)ObjStatic.FormMain.ReadObject(path);
                }
                catch (Exception ex) { }
            }
            if (ListFileSniffer == null)
            {
                ListFileSniffer = new List<List<FileSniffer>>();
                for (int i = 0; i < ObjStatic.Config.DefaultTypeSniffer.Length; i++)
                {
                    ListFileSniffer.Add(new List<FileSniffer>());
                }
                SaveFileSniff();
            }
        }
        public void SaveFileSniff()
        {
            try
            {
                ObjStatic.FormMain.WriteObject(ListFileSniffer, ObjStatic.PathAppUserTemp + pathsavefilesniff);
            }
            catch (Exception ex) { }
        }
        System.Threading.Thread threadloadgrid;
        public void PerformLoadFileToGrid()
        {
            if (threadloadgrid != null)
            {
                try
                {
                    threadloadgrid.Abort();
                }
                catch (Exception ex) { }
            }
            System.Threading.ThreadStart ts = LoadFileToGrid;
            threadloadgrid = new System.Threading.Thread(ts);
            threadloadgrid.Start();
        }
        private void LoadFileToGrid()
        {
            int index = 0;
            if (CurrentNode != null)
                index = CurrentNode.Index;
            ClearGrid();
            for (int i = 0; i < ListFileSniffer[index].Count; i++)
            {
                AddRowToGrid(ListFileSniffer[index][i]);
            }
        }
        public void AddFileSniffer(FileSniffer fs)
        {
            if (IsExistLink(fs))
                return;
            ListFileSniffer[fs.TypeIndex].Add(fs);
            int index = 0;
            if (CurrentNode != null)
                index = CurrentNode.Index;
            if (index == fs.TypeIndex)
                AddRowToGrid(fs);
        }
        private bool IsExistLink(FileSniffer fs)
        {
            int index = fs.TypeIndex;
            for (int i = 0; i < ListFileSniffer[index].Count; i++)
                if (ListFileSniffer[index][i].Link == fs.Link)
                    return true;
            return false;
        }

        private void TreeTypeSniffer_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            CurrentNode = e.Node;
            PerformLoadFileToGrid();
            int Index = e.Node.Index;
            txtPathSave.Text = ObjStatic.Config.DefaultTypeSniffer[Index].PathSave;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            SaveFileSniff();
            base.OnClosing(e);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete selected files ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int index = 0;
                if (CurrentNode != null)
                    index = CurrentNode.Index;
                for (int i = GridFile.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = GridFile.Rows[i];
                    if ((bool)row.Cells[0].Value)
                    {
                        ListFileSniffer[index].Remove((FileSniffer)row.Tag);
                        DeleteRowInGrid(row);
                    }
                }
            }
        }

        #region >- Grid Callback -<

        public void AddRowToGrid(FileSniffer file)
        {
            if (GridFile.InvokeRequired)
            {
                AddRowToGridCallBack obj = AddRowToGrid;
                GridFile.Invoke(obj, file);
            }
            else
            {
                int index = GridFile.Rows.Add(false, file.FileName, ObjStatic.ToStringSize(file.Size), file.Link);
                GridFile.Rows[index].Tag = file;
                GridFile.Rows[index].Height = 18;
                ((CustomGridCell)GridFile.Rows[index].Cells[1]).CellIcon = ObjStatic.ObjGetIcon.GetIconFromExtension(Path.GetExtension(file.FileName), GetIconWindow.IconSize.Small);
            }
        }
        private void DeleteRowInGrid(DataGridViewRow row)
        {
            if (GridFile.InvokeRequired)
            {
                DeleteRowInGridCallback obj = DeleteRowInGrid;
                GridFile.Invoke(obj, row);
            }
            else GridFile.Rows.Remove(row);
        }
        private void ClearGrid()
        {
            if (GridFile.InvokeRequired)
            {
                ClearGridCallback obj = ClearGrid;
                GridFile.Invoke(obj);
            }
            else GridFile.Rows.Clear();
        }
        private void PerformCheck(bool IsCheck)
        {
            if (GridFile.InvokeRequired)
            {
                PerformCheckCallback obj = PerformCheck;
                GridFile.Invoke(obj, IsCheck);
            }
            else
            {
                for (int i = 0; i < GridFile.Rows.Count; i++)
                    GridFile.Rows[i].Cells[0].Value = IsCheck;
            }
        }
        #endregion

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.ShowDialog();
            if (!string.IsNullOrEmpty(fbd.SelectedPath))
                txtPathSave.Text = fbd.SelectedPath;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadFileSelected(true);
        }
        private void DownloadFileSelected(bool IsStart)
        {
            if (Directory.Exists(txtPathSave.Text))
            {
                for (int i = GridFile.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = GridFile.Rows[i];
                    if ((bool)row.Cells[0].Value)
                    {
                        FileSniffer fs = (FileSniffer)row.Tag;
                        File fd = new File(txtPathSave.Text + "\\" + fs.FileName, fs.Link, fs.Size, fs.FileName);
                        ObjStatic.FormMain.AddFileToCurrentCategory(fd, IsStart);
                        ListFileSniffer[fs.TypeIndex].Remove(fs);
                        DeleteRowInGrid(row);
                    }
                }
            }
            else MessageBox.Show("Path save file is not exist !", ObjStatic.MessageBoxCaption);
        }

        private void btnDownloadlater_Click(object sender, EventArgs e)
        {
            DownloadFileSelected(false);
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            PerformCheck(true);
        }

        private void btnUnCheckAll_Click(object sender, EventArgs e)
        {
            PerformCheck(false);
        }
    }
    [Serializable()]
    public class FileSniffer
    {
        public string FileName;
        public long Size;
        public string Link;
        public int TypeIndex = 0;
        public FileSniffer()
        {
        }
        public FileSniffer(string filename, long size, string link,int typeindex)
        {
            FileName = filename;
            Size = size;
            Link = link;
            TypeIndex = typeindex;
        }
    }
}
