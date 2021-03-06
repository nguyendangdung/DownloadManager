/********************************
*    Author : Nguyễn văn việt   *
********************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Net;
namespace My_Download_Manager
{
    public partial class Main : Form
    {
        #region >- Variable -<
        public const string NameApplication = "My Download Manager";
        public string[] Args;
        public delegate void OpenNewMainFormCallback(object sender, string[] args);
        private GetIconWindow ObjGetIcon;
        public List<ListFile> Category;
        private Configuration Config;
        private string FileConfig = "Config.obj";
        private string FileCategory = "Category.obj";
        private string FileCategoryBackup = "Category.obj.backup";
        private string FileCookie = "Cookie.obj";
        private string[] DefaultCategory;
        public ListFile currentlistfile = null;
        private File CurrentFDInGrid = null;
        private delegate void AddRowCallBack(File file);
        private delegate void GridDeleteRowCallBack(DataGridViewRow row);
        private delegate void SetTextCallback(Control c, string text);
        private long OldTotalLoaded = 0;
        private List<int> Speeds;
        private int MaxSpeed = 0;
        private int MaxPoint = 0;
        private int w_cell = 8;
        private bool IsShowTraffic = false;
        private Hashtable ListWindowIE;
        private SHDocVw.ShellWindows Windows;
        private ImageList MainImageList;
        Mysniffer mysniff;
        Hashtable Sends = new Hashtable();
        Socket socket;
        int buffsize = 4096;
        byte[] data;
        bool Stop = false;
        private bool HasSaveCategory = false;
        public bool HasOpenGetIEWindow = false;
        private string pathconfig = string.Empty;
        private string pathcategory = string.Empty;
        private string pathcategorybackup = string.Empty;
        private string pathcookie = string.Empty;
        #endregion

        public Main()
        {
            InitializeComponent();
            ObjStatic.PathAppUserTemp = GetApplicationPath() + "\\MDM\\Data\\";
            pathcategory = ObjStatic.PathAppUserTemp + FileCategory;
            pathconfig = ObjStatic.PathAppUserTemp + FileConfig;
            pathcategorybackup = ObjStatic.PathAppUserTemp + FileCategoryBackup;
            pathcookie = ObjStatic.PathAppUserTemp + FileCookie;
            if (!Directory.Exists(ObjStatic.PathAppUserTemp))
                Directory.CreateDirectory(ObjStatic.PathAppUserTemp);
            Microsoft.Win32.SystemEvents.SessionEnded += SystemEvents_SessionEnded;
        }
        private string GetApplicationPath()
        {
            string[] str = Application.UserAppDataPath.Split('\\');
            string path = str[0];
            for (int i = 1; i < str.Length && i < 4; i++)
                path += "\\" + str[i];
            return path;
        }

        #region >- Form Event -<


        private void Main_Load(object sender, EventArgs e)
        {
            Init();
            ShowNotifyIcon();
            if (Args != null)
            {
                OpenNewMainForm(null, Args);
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
        private void StopAllDownload()
        {
            for (int i = 0; i < Category.Count; i++)
            {
                Category[i].Running = false;
                for (int j = 0; j < Category[i].Count; j++)
                    Category[i][j].Running = false;
            }
        }

        #endregion

        #region >- OnLoad -<

        public void OpenNewMainForm(object sender, string[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (args[0].ToLower().Trim() == "onstartup")
                {
                    Visible = false;
                    ShowInTaskbar = false;
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    string pathfile = Application.StartupPath + "\\" + args[0];
                    if (System.IO.File.Exists(pathfile))
                    {
                        List<string> links = new List<string>();
                        StreamReader sr = new StreamReader(pathfile);
                        while (!sr.EndOfStream)
                        {
                            string link = sr.ReadLine();
                            if (link.Length > 0)
                                links.Add(link);
                        }
                        sr.Close();
                        System.IO.File.Delete(pathfile);
                        if (links.Count == 1)
                        {
                            AddUrl addurl = new AddUrl(links[0]);
                            addurl.TopMost = true;
                            addurl.Show();
                        }
                        else if (links.Count > 1)
                        {
                            AddMultiUrl frm = new AddMultiUrl(links.ToArray());
                            frm.TopMost = true;
                            frm.Show();
                        }
                    }
                }
            }
        }
        private void Init()
        {
            LoadIcon();
            DefaultCategory = new string[] { "Document", "Video", "Music", "Application", "Orther" };
            LoadConfig();
            LoadCookie();
            ObjGetIcon = new GetIconWindow();
            LoadCategory();
            RegisterInRegistryRunOnStartUp(Config.RunOnStartup);
            ObjStatic.FormMain = this;
            ObjStatic.ObjGetIcon = ObjGetIcon;
            ObjStatic.Config = Config;
            LoadGrid();
            Speeds = new List<int>();
            MaxPoint = PictureShowTraffic.Width / w_cell;
            TimerTotalSpeed.Start();
            if (Config.RegisterWithIE)
            {
                HasOpenGetIEWindow = true;
                StartGetIEWindown();
                if (!Config.Installed)
                {
                    InstallCom(true);
                    Config.Installed = true;
                    SaveConfig();
                }
            }
            ObjStatic.UpdateAutoStartDownload();
            if (Config.AutoStartSniffer)
            {
                StartSniff();
                MainMenu_StartSniffer.Checked = true;
            }
            else MainMenu_StartSniffer.Checked = false;
        }
        private void LoadIcon()
        {
            try
            {
                MainImageList = new ImageList();
                MDMImage obj = new MDMImage(); //(MDMImage)ReadObject(Application.StartupPath + "\\Resource.dll");
                //global::My_Download_Manager.Properties.Resources.Resource
                MainImageList.Images.Add("orther", obj.Orther);
                MainImageList.Images.Add("category", obj.Category);
                MainImageList.Images.Add("document", obj.Book);
                MainImageList.Images.Add("application", obj.Application);
                MainImageList.Images.Add("music", obj.Music);
                MainImageList.Images.Add("video", obj.Video);
                ObjStatic.MdmImages = obj;
            }
            catch (Exception ex)
            {
            }
        }
        private void LoadConfig()
        {
            bool HasLoad = false;
            if (System.IO.File.Exists(pathconfig))
            {
                try
                {
                    Config = (Configuration)ReadObject(pathconfig);
                    HasLoad = true;
                }
                catch (Exception ex)
                {
                }
            }
            if (!HasLoad)
            {
                Config = new Configuration();
                SaveConfig();
            }
            if (!Directory.Exists(Config.FolderTemp))
            {
                try
                {
                    string pathtemp = GetApplicationPath() + "\\MDM\\Temp";
                    if (!Directory.Exists(pathtemp))
                        Directory.CreateDirectory(pathtemp);
                    Config.FolderTemp = pathtemp;
                    SaveConfig();
                }
                catch (Exception ex) { }
            }
            if (Config.Buffer == 0)
                Config.Buffer = 4096;
            if (Config.Connection == 0)
                Config.Connection = 16;
        }
        private void LoadCookie()
        {
            bool HasLoad = false;
            if (System.IO.File.Exists(pathcookie))
            {
                try
                {
                    ObjStatic.Cookies = (Hashtable)ReadObject(pathcookie);
                    HasLoad = true;
                }
                catch (Exception ex) { }
            }
            if (!HasLoad)
            {
                ObjStatic.Cookies = new Hashtable();
            }
        }
        private void LoadCategory()
        {
            bool HasLoad = false;
            if (System.IO.File.Exists(pathcategory))
            {
                try
                {
                    Category = (List<ListFile>)ReadObject(pathcategory);
                    HasLoad = true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (System.IO.File.Exists(pathcategorybackup))
                        {
                            Category = (List<ListFile>)ReadObject(pathcategorybackup);
                            HasLoad = true;
                        }
                        else HasLoad = false;
                        MessageBox.Show("Program has stopped suddenly, you can lose some data !", ObjStatic.MessageBoxCaption);
                    }
                    catch (Exception ex1)
                    {
                        HasLoad = false;
                    }
                }
            }
            if (!HasLoad)
            {
                Category = new List<ListFile>();
                for (int i = 0; i < DefaultCategory.Length; i++)
                {
                    ListFile lf = new ListFile(DefaultCategory[i], Config.FileConnection);
                    Category.Add(lf);
                }
                SaveCategory();
            }
            TreeCategory.Nodes.Add("Categories");
            int NodeSlectedIndex = 0;

            TreeCategory.ImageList = MainImageList;
            TreeCategory.Nodes[0].ImageKey = "category";
            TreeCategory.Nodes[0].SelectedImageKey = "category";
            for (int i = 0; i < Category.Count; i++)
            {
                ListFile temp = Category[i];
                TreeNode node = new TreeNode(temp.Name);
                node.Tag = temp;
                TreeCategory.Nodes[0].Nodes.Add(node);
                node.ImageKey = temp.Name.ToLower();
                node.SelectedImageKey = node.ImageKey;
                temp.StopDownload();
                if (!string.IsNullOrEmpty(Config.CurrentCategory) && Config.CurrentCategory == temp.Name)
                    NodeSlectedIndex = i;
            }
            TreeCategory.SelectedNode = TreeCategory.Nodes[0].Nodes[NodeSlectedIndex];
            CurrentListFile = Category[NodeSlectedIndex];
            TreeCategory.Nodes[0].ExpandAll();
        }
        System.Threading.Thread theadloadgrid;
        private void LoadGrid()
        {
            if (CurrentListFile != null)
            {
                if (theadloadgrid != null)
                {
                    try
                    {
                        theadloadgrid.Abort();
                    }
                    catch (Exception ex) { }
                }

                System.Threading.ThreadStart ts = PerformLoadGrid;
                theadloadgrid = new System.Threading.Thread(ts);
                theadloadgrid.Start();
            }
        }
        private delegate void ClearRowInGridCallBack(DataGridView grid);
        private void ClearRowInGrid(DataGridView grid)
        {
            if (grid.InvokeRequired)
            {
                ClearRowInGridCallBack obj = ClearRowInGrid;
                grid.Invoke(obj, grid);
            }
            else grid.Rows.Clear();
        }
        private void PerformLoadGrid()
        {
            int TotalComplete = 0;
            ClearRowInGrid(GridDownload);
            long totalsize = 0, completesize = 0;
            for (int i = 0; i < CurrentListFile.Count; i++)
            {
                File f = CurrentListFile[i];
                if (f.Status == DownloadStatus.Complete)
                {
                    TotalComplete++;
                    completesize += f.Size;
                }
                if (f.Size > 0)
                    totalsize += f.Size;
                AddRow(f);
            }
            UpdateStatusTooltip(CurrentListFile.Count, TotalComplete, completesize, totalsize);
            PerformSaveCategory();
        }
        private void AddRow(File file)
        {
            if (GridDownload.InvokeRequired)
            {
                AddRowCallBack callback = AddRow;
                GridDownload.Invoke(callback, file);
            }
            else
            {
                int index = GridDownload.Rows.Add();
                DataGridViewRow row = GridDownload.Rows[index];
                row.Height = 18;
                file.Row = row;
                row.Tag = file;
                row.Cells[0].Value = file.FileName;
                row.Cells[1].Value = file.GetSize();
                row.Cells[2].Value = file.GetStatus();
                row.Cells[5].Value = file.Link;
                ((CustomGridCell)row.Cells[0]).CellIcon = ObjGetIcon.GetIconFromExtension(Path.GetExtension(file.FileName), GetIconWindow.IconSize.Small);
            }
        }

        #endregion

        #region >- Form Action -<
        private void OpenHelp()
        {
            System.Diagnostics.Process.Start(ObjStatic.Website);
        }
        private void ChangeOrderInGrid(bool IsMoveUp)
        {
            List<int> lindexs = new List<int>();
            for (int i = 0; i < GridDownload.Rows.Count; i++)
            {
                if (GridDownload.Rows[i].Selected)
                {
                    lindexs.Add(i);
                }
            }
            if (IsMoveUp)
            {
                for (int i = 0; i < lindexs.Count; i++)
                {
                    if (lindexs[i] > 0)
                    {
                        File fd = currentlistfile[lindexs[i]];
                        currentlistfile.RemoveAt(lindexs[i]);
                        currentlistfile.InsertFile(lindexs[i] - 1, fd);
                        DataGridViewRow row = GridDownload.Rows[lindexs[i]];
                        GridDownload.Rows.RemoveAt(lindexs[i]);
                        GridDownload.Rows.Insert(lindexs[i] - 1, row);
                    }
                }
            }
            else
            {
                for (int i = lindexs.Count - 1; i >= 0; i--)
                {
                    if (lindexs[i] < GridDownload.Rows.Count - 1)
                    {
                        File fd = currentlistfile[lindexs[i]];
                        currentlistfile.RemoveAt(lindexs[i]);
                        currentlistfile.InsertFile(lindexs[i] + 1, fd);

                        DataGridViewRow row = GridDownload.Rows[lindexs[i]];
                        GridDownload.Rows.RemoveAt(lindexs[i]);
                        GridDownload.Rows.Insert(lindexs[i] + 1, row);
                    }
                }
            }
            SaveCategory();
            GridDownload.ClearSelection();
            for (int i = 0; i < lindexs.Count; i++)
            {
                if (IsMoveUp)
                {
                    if (lindexs[i] > 0)
                    {
                        GridDownload.Rows[lindexs[i] - 1].Selected = true;
                    }
                    else GridDownload.Rows[lindexs[i]].Selected = true;
                }
                else
                {
                    if (lindexs[i] < GridDownload.Rows.Count - 1)
                    {
                        GridDownload.Rows[lindexs[i] + 1].Selected = true;
                    }
                    else GridDownload.Rows[lindexs[i]].Selected = true;
                }
            }
        }
        private void PerformAddCategory()
        {
            InfoCategory frm = new InfoCategory();
            frm.ShowDialog();
        }
        private void OpenAddMultiUrl()
        {
            AddMultiUrl obj = new AddMultiUrl();
            obj.ShowDialog();
        }
        public void OpenAddURL()
        {
            AddUrl add = new AddUrl();
            add.ShowDialog();
        }
        public string GetCurrentPathOfCategory()
        {
            string Result = string.Empty;
            if (CurrentListFile != null)
                Result = CurrentListFile.SaveTo;
            return Result;
        }
        public void SetCurrentPathOfCategory(string path)
        {
            if (CurrentListFile != null)
            {
                CurrentListFile.SaveTo = path;
                SaveCategory();
            }
        }
        public void AddFileToCurrentCategory(File f)
        {
            if (CurrentListFile != null)
            {
                CurrentListFile.AddFile(f);
                AddRow(f);
                UpdateTotalComplete(CurrentListFile);
            }
        }
        public void AddFileToCurrentCategory(File f, bool AutoStartDownload)
        {
            if (CurrentListFile != null)
            {
                CurrentListFile.AddFile(f);
                AddRow(f);
                if (AutoStartDownload)
                    f.StartDownload();
                UpdateTotalComplete(CurrentListFile);
            }
        }
        private void ShowFormDownloadAudioBook()
        {
            GetAudioBook frm = new GetAudioBook();
            frm.ShowDialog();
        }
        private void ShowFileProperties(File f)
        {
            if (f.Status != DownloadStatus.Building)
            {
                if (f.frmProperties == null || f.frmProperties.IsDisposed)
                {
                    FileProperties fp = new FileProperties(f);
                    f.frmProperties = fp;
                    fp.Show();
                }
                else f.frmProperties.Show();
            }
        }
        public bool CheckExistCategory(string CategoryName)
        {
            for (int i = 0; i < Category.Count; i++)
            {
                if (Category[i].Name.ToLower().Trim() == CategoryName.ToLower().Trim())
                    return true;
            }
            return false;
        }
        public void AddCategory(ListFile lf)
        {
            Category.Add(lf);
            TreeNode node = new TreeNode(lf.Name);
            node.Tag = lf;
            TreeCategory.Nodes[0].Nodes.Add(node);
        }
        public void UpdateTotalComplete(ListFile lf)
        {
            try
            {
                int total = 0;
                int complete = 0;
                long totalize = 0, completesize = 0;
                if (CurrentListFile != null && (lf == CurrentListFile || lf == null))
                {
                    total = CurrentListFile.Count;
                    for (int i = 0; i < CurrentListFile.Count; i++)
                    {
                        if (CurrentListFile[i].Status == DownloadStatus.Complete)
                        {
                            complete++;
                            completesize += CurrentListFile[i].Size;
                        }
                        if (CurrentListFile[i].Size > 0)
                            totalize += CurrentListFile[i].Size;
                    }
                }
                UpdateStatusTooltip(total, complete, completesize, totalize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region >- IO -<

        public void WriteObject(object data, string pathfile)
        {
            lock (data)
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = new FileStream(pathfile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                bf.Serialize(f, data);
                f.Close();
            }
        }
        public object ReadObject(string pathfile)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream f = new FileStream(pathfile, FileMode.Open);
            object data = bf.Deserialize(f);
            f.Close();
            return data;
        }
        public void SaveConfig()
        {
            try
            {
                WriteObject(Config, pathconfig);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Save Config :" + ex.Message);
            }
        }
        public void SaveCookie()
        {
            try
            {
                WriteObject(ObjStatic.Cookies, pathcookie);
            }
            catch (Exception ex) { }
        }
        public void SaveCategory()
        {
            HasSaveCategory = true;
        }
        private bool PerformSaveCategory()
        {
            try
            {
                if (System.IO.File.Exists(pathcategorybackup))
                    System.IO.File.Delete(pathcategorybackup);
                if (System.IO.File.Exists(pathcategory))
                    Microsoft.VisualBasic.FileSystem.Rename(pathcategory, pathcategorybackup);
                WriteObject(Category, pathcategory);
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        #endregion

        #region >- Main Menu Event -<
        private void menuFile_AddMultiUrl_Click(object sender, EventArgs e)
        {
            OpenAddMultiUrl();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMainForm();
        }
        private void AddUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAddURL();
        }

        private void AddCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PerformAddCategory();
        }
        private void MenuGetAudiobooktuoitre_Click(object sender, EventArgs e)
        {
            ShowFormDownloadAudioBook();
        }
        private void MainMenu_Option_Click(object sender, EventArgs e)
        {
            ConfigurationForm frm = new ConfigurationForm();
            frm.ShowDialog();
        }
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenHelp();
        }
        #endregion

        #region >- Grid Event -<
        private bool ControlPressed = false;
        private void MenuGrid_MoveUp_Click(object sender, EventArgs e)
        {
            if (currentlistfile != null)
                ChangeOrderInGrid(true);
        }
        private void MenuGrid_MoveDown_Click(object sender, EventArgs e)
        {
            if (currentlistfile != null)
                ChangeOrderInGrid(false);
        }
        private void DeleteSelectedFile()
        {
            if (GridDownload.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Do you want to delete selected files ?", "Confirm Delete !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                        System.Threading.ThreadStart ts = ThreadDeleteFile;
                        System.Threading.Thread t = new System.Threading.Thread(ts);
                        t.Start();
                }
            }
        }
        private void GridDeleteRow(DataGridViewRow row)
        {
            try
            {
                if (GridDownload.InvokeRequired)
                {
                    GridDeleteRowCallBack obj = GridDeleteRow;
                    GridDownload.Invoke(obj, row);
                }
                else GridDownload.Rows.Remove(row);
            }
            catch (Exception ex) { }
        }
        private void ThreadDeleteFile()
        {
            lock (this)
            {
                List<DataGridViewRow> rows = new List<DataGridViewRow>();
                for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                {
                    File f = (File)GridDownload.SelectedRows[i].Tag;
                    rows.Add(f.Row);
                    CurrentListFile.RemoveFile(f);
                }
                for (int i = 0; i < rows.Count; i++)
                    GridDeleteRow(rows[i]);
                //GridDownload.Rows.Remove(rows[i]);
                SaveCategory();
                UpdateTotalComplete(CurrentListFile);
            }
        }
        private void GridDownload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.D)
            {
                DeleteSelectedFile();
            }
            ControlPressed = e.Control;
        }
        private void GridDownload_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                File fd = (File)GridDownload.Rows[e.RowIndex].Tag;
                ShowFileProperties(fd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GridDownload_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (!ControlPressed)
                    {
                        for (int i = 0; i < GridDownload.SelectedRows.Count; )
                        {
                            GridDownload.SelectedRows[i].Selected = false;
                        }
                    }
                    GridDownload.Rows[e.RowIndex].Selected = true;
                    CurrentFDInGrid = (File)GridDownload.Rows[e.RowIndex].Tag;
                    if (CurrentFDInGrid.Running)
                    {
                        GridMenu_StopDownload.Enabled = true;
                        GridMenu_StartDownload.Enabled = false;
                        GridMenu_ResumeDownload.Enabled = false;
                        GridMenu_Redownload.Enabled = false;
                        GridMenu_Open.Enabled = false;
                        GridMenu_OpenFolder.Enabled = false;
                        GridMenu_Delete.Enabled = false;
                        GridMenu_Move.Enabled = false;
                    }
                    else
                    {
                        GridMenu_StopDownload.Enabled = false;
                        GridMenu_Delete.Enabled = true;
                        GridMenu_Move.Enabled = true;

                        GridMenu_StartDownload.Enabled = (CurrentFDInGrid.Status == DownloadStatus.Create);
                        GridMenu_ResumeDownload.Enabled = (CurrentFDInGrid.Status != DownloadStatus.Create && CurrentFDInGrid.Status != DownloadStatus.Complete && CurrentFDInGrid.Status != DownloadStatus.Building);
                        GridMenu_Redownload.Enabled = true; //(CurrentFDInGrid.Status == DownloadStatus.Complete || CurrentFDInGrid.Status == DownloadStatus.Error || CurrentFDInGrid.Status == DownloadStatus.Disconect || CurrentFDInGrid.Status == DownloadStatus.Create);
                        GridMenu_Open.Enabled = CurrentFDInGrid.Status == DownloadStatus.Complete;
                        GridMenu_OpenFolder.Enabled = CurrentFDInGrid.Status == DownloadStatus.Complete;
                    }
                    GridMenu.Show(Cursor.Position);
                }
            }
        }
        private void GridMenu_Open_Click(object sender, EventArgs e)
        {
            if (GridDownload.SelectedRows.Count > 0)
            {
                for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                {
                    File f = (File)GridDownload.SelectedRows[i].Tag;
                    if (f.Status == DownloadStatus.Complete && System.IO.File.Exists(f.PathFile))
                    {
                        System.Diagnostics.Process.Start(f.PathFile);
                    }
                }
            }
        }
        private void GridMenu_OpenFolder_Click(object sender, EventArgs e)
        {
            if (GridDownload.SelectedRows.Count > 0)
            {
                for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                {
                    File f = (File)GridDownload.SelectedRows[i].Tag;
                    if (f.Status == DownloadStatus.Complete && System.IO.File.Exists(f.PathFile))
                    {
                        System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                        psi.Arguments = "/select," + f.PathFile;
                        System.Diagnostics.Process.Start(psi);
                    }
                }
            }
        }
        private void GridMenu_StopDownload_Click(object sender, EventArgs e)
        {
            if (GridDownload.SelectedRows.Count > 0)
            {
                for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                {
                    File f = (File)GridDownload.SelectedRows[i].Tag;
                    if (f.Running)
                        f.StopDownload();
                }
            }
        }
        private void GridMenu_Redownload_Click(object sender, EventArgs e)
        {
            if (GridDownload.SelectedRows.Count > 0)
            {
                for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                {
                    File f = (File)GridDownload.SelectedRows[i].Tag;
                    if (!f.Running)//f.Status == DownloadStatus.Complete || f.Status == DownloadStatus.Error || f.Status == DownloadStatus.Disconect || f.Status == DownloadStatus.Create)
                    {
                        f.Redownload();
                    }
                }
                UpdateTotalComplete(CurrentListFile);
            }
        }
        private void GridMenu_Delete_Click(object sender, EventArgs e)
        {
            DeleteSelectedFile();
        }
        private void GridMenu_Properties_Click(object sender, EventArgs e)
        {
            if (GridDownload.SelectedRows.Count > 0)
            {
                for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                {
                    File f = (File)GridDownload.SelectedRows[i].Tag;
                    ShowFileProperties(f);
                }
            }
        }
        private void GridMenu_Move_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null && GridDownload.SelectedRows.Count > 0)
            {
                SelectCategory obj = new SelectCategory(CurrentListFile, Category);
                obj.ShowDialog();
            }
        }
        private void GridMenu_StartDownload_Click(object sender, EventArgs e)
        {
            if (GridDownload.SelectedRows.Count > 0)
            {
                for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                {
                    File f = (File)GridDownload.SelectedRows[i].Tag;

                    if (f.Status != DownloadStatus.Complete && !f.Running)
                    {
                        f.StartDownload();
                    }
                }
            }
        }
        private void GridMenu_StartDownload_Click_1(object sender, EventArgs e)
        {
            if (GridDownload.SelectedRows.Count > 0)
            {
                for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                {
                    File f = (File)GridDownload.SelectedRows[i].Tag;
                    if (!f.Running && f.Status == DownloadStatus.Create)
                        f.StartDownload();
                }
            }
        }

        #endregion

        #region >- Tree Event -<

        private void TreeCategory_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                ListFile temp = (ListFile)e.Node.Tag;
                if (CurrentListFile != temp)
                {
                    CurrentListFile = temp;
                    LoadGrid();
                }
                TreeCategory.SelectedNode = e.Node;
                ObjStatic.Config.CurrentCategory = e.Node.Text;
                if (e.Button == MouseButtons.Right)
                {
                    e.Node.ContextMenuStrip = TreeMenu;
                    TreeMenu_Start.Enabled = !CurrentListFile.Running;
                    TreeMenu_Stop.Enabled = CurrentListFile.Running;
                }
            }
        }
        private void TreeCategory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1 && CurrentListFile != null)
            {
                InfoCategory frm = new InfoCategory(CurrentListFile);
                frm.ShowDialog();
            }
        }
        private void Menutree_AddUrl_Click(object sender, EventArgs e)
        {
            OpenAddURL();
        }
        private void TreeMenu_AddCategory_Click(object sender, EventArgs e)
        {
            PerformAddCategory();
        }
        private void TreeMenu_Properties_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null)
            {
                InfoCategory frm = new InfoCategory(CurrentListFile);
                frm.ShowDialog();
            }
        }
        private void TreeMenu_Start_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null && !CurrentListFile.Running)
            {
                CurrentListFile.StartDownload();
            }
        }
        private void TreeMenu_Stop_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null)
                CurrentListFile.StopDownload();
        }
        private void MenuTree_Delete_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null)
            {
                string name = CurrentListFile.Name.ToLower().Trim();
                for (int i = 0; i < DefaultCategory.Length; i++)
                {
                    if (DefaultCategory[i].ToLower() == name)
                    {
                        MessageBox.Show("Can't delete default category !");
                        return;
                    }
                }
                CurrentListFile.Clear();
                Category.Remove(CurrentListFile);
                CurrentListFile = Category[0];
                LoadGrid();
                TreeCategory.SelectedNode = TreeCategory.Nodes[0].Nodes[0];
            }
        }
        private void TreeMenu_Export_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null && CurrentListFile.Count > 0)
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.CheckFileExists = false;
                openfile.ShowDialog();
                if (!string.IsNullOrEmpty(openfile.FileName) && Directory.Exists(Path.GetDirectoryName(openfile.FileName)))
                {
                    try
                    {
                        WriteObject(CurrentListFile, openfile.FileName);
                        MessageBox.Show("Export Complete !");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }
        private void TreeMenu_Import_Click(object sender, EventArgs e)
        {
            Import frm = new Import();
            frm.ShowDialog();
        }
        private void TreeMenu_Export_ToHTML_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null && CurrentListFile.Count > 0)
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.CheckFileExists = false;
                openfile.ShowDialog();

                if (!string.IsNullOrEmpty(openfile.FileName) && Directory.Exists(Path.GetDirectoryName(openfile.FileName)))
                {
                    try
                    {
                        string HTML = "<html><head><title>" + CurrentListFile.Name + "</title></head><body>";
                        for (int i = 0; i < CurrentListFile.Count; i++)
                        {
                            HTML += (i + 1) + ". <a href='" + CurrentListFile[i].Link + "'>" + CurrentListFile[i].FileName + "</a><br/>";
                        }
                        HTML += "</body></html>";
                        StreamWriter sw = new StreamWriter(openfile.FileName, false, Encoding.UTF8);
                        sw.Write(HTML);
                        sw.Close();
                        DialogResult result = MessageBox.Show("Export complete ! Do you want to open this file ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(openfile.FileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message, ObjStatic.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else MessageBox.Show("Not found file to export !", ObjStatic.MessageBoxCaption);
        }

        #endregion

        #region >- Traffic & Total Speed -<

        private void SetText(Control c, string text)
        {
            if (c.InvokeRequired)
            {
                SetTextCallback obj = SetText;
                c.Invoke(obj, c, text);
            }
            else c.Text = text;
        }
        private void UpdateStatusTooltip(int totalfile, int complete, long ConpleteSize, long TotalSize)
        {
            string format = "Total {0} files : {1} files complete ( {2} / {3} )";
            SetText(lblStatusToolStrip, string.Format(format, totalfile, complete, ObjStatic.ToStringSize(ConpleteSize), ObjStatic.ToStringSize(TotalSize)));
        }
        private void TimerTotalSpeed_Tick(object sender, EventArgs e)
        {
            long Current = ObjStatic.TotalLoad;
            int value = (int)(Current - OldTotalLoaded);
            OldTotalLoaded = Current;
            string strspeed = ObjStatic.ToStringSize(value) + "/sec";
            SetText(lblTotalSpeed, "Speed : " + strspeed);
            if (value > MaxSpeed)
            {
                MaxSpeed = value;
                SetText(lblMaxSpeed, "Max speed : " + strspeed);
            }
            Speeds.Add(value);
            if (Speeds.Count > MaxPoint)
                Speeds.RemoveAt(0);
            if (IsShowTraffic && MaxSpeed > 0)
            {
                DrawTrafic();
            }
            if (HasSaveCategory)
            {
                HasSaveCategory = !PerformSaveCategory();
            }
            CheckAutoDownload();
        }
        private void DrawTrafic()
        {
            int W = PictureShowTraffic.Width;
            int DeltaY = 20;
            int Start_Y = DeltaY;
            int H = PictureShowTraffic.Height - DeltaY;
            Point[] Points = new Point[Speeds.Count + 3];
            Points[0] = new Point(W, PictureShowTraffic.Height);
            int count = 1;
            for (int i = Speeds.Count - 1; i >= 0; i--)
            {
                int y = Start_Y + (H - (int)H * Speeds[i] / MaxSpeed);
                Points[count++] = new Point(W, y);
                W -= w_cell;
                if (i == 0)
                {
                    Points[count++] = new Point(W, y);// PictureShowTraffic.Height);
                }
            }
            Points[count] = new Point(W - w_cell, PictureShowTraffic.Height);
            Color ColorEnd = Color.LightCyan;
            Color ColorStart = Color.DarkGreen;
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, PictureShowTraffic.Width, PictureShowTraffic.Height), ColorStart, ColorEnd, LinearGradientMode.Vertical);
            Pen pen = new Pen(Color.DarkBlue);
            GraphicsPath path = new GraphicsPath();
            path.AddCurve(Points);
            path.CloseFigure();
            Bitmap bitmap = new Bitmap(PictureShowTraffic.Width, PictureShowTraffic.Height);
            Image img = (Image)bitmap;
            Graphics grbitmap = Graphics.FromImage(img);
            grbitmap.SmoothingMode = SmoothingMode.AntiAlias;
            grbitmap.FillPath(brush, path);
            grbitmap.DrawPath(pen, path);
            grbitmap.Dispose();
            PictureShowTraffic.Image = img;
            brush.Dispose();
        }
        private Color GetColor(Color color, bool IsDarkMore)
        {
            int delta = 100;
            if (IsDarkMore)
                delta = -50;
            int r = (int)color.R + delta;
            int b = (int)color.B + delta;
            int g = (int)color.G + delta;
            if (r < 0) r = 0;
            if (r > 255) r = 255;

            if (b < 0) b = 0;
            if (b > 255) b = 255;

            if (g < 0) g = 0;
            if (g > 255) g = 255;

            return Color.FromArgb(r, g, b);
        }
        private void btnShowTraffic_Click(object sender, EventArgs e)
        {
            IsShowTraffic = !IsShowTraffic;
            PictureShowTraffic.Visible = IsShowTraffic;
            if (IsShowTraffic)
            {
                btnShowTraffic.Text = "<< Hidden traffic";
            }
            else btnShowTraffic.Text = "Show traffic >>";
        }

        #endregion

        #region >- Move To Orther Category -<

        public void MoveFileSelectToOrtherCategory(ListFile to)
        {
            List<int> lstIndex = new List<int>();
            for (int i = 0; i < GridDownload.SelectedRows.Count; i++)
                lstIndex.Add(GridDownload.SelectedRows[i].Index);
            for (int i = 0; i < lstIndex.Count; i++)
            {
                File f = (File)GridDownload.Rows[lstIndex[i]].Tag;
                DownloadStatus status = f.Status;
                CurrentListFile.RemoveFile(f);
                to.AddFile(f);
                f.Status = status;
                GridDownload.Rows.Remove(f.Row);
            }
            lstIndex.Clear();
            SaveCategory();
            UpdateTotalComplete(CurrentListFile);
        }

        #endregion

        #region >- Catcher IE-<
        Queue<string> AutoLinks;
        public void StartGetIEWindown()
        {
            AutoLinks = new Queue<string>();
            Windows = new SHDocVw.ShellWindowsClass();
            ListWindowIE = new Hashtable();
            foreach (SHDocVw.InternetExplorer ie in Windows)
            {
                ListWindowIE[ie.HWND] = ie;
                ie.BeforeNavigate2 += ie_BeforeNavigate2;
            }
            Windows.WindowRegistered += WINDOW_WindowRegistered;
        }
        private void CheckAutoDownload()
        {
            if (AutoLinks != null && AutoLinks.Count > 0)
            {
                string link = AutoLinks.Dequeue();
                AddUrl objadd = new AddUrl(link);
                objadd.Show();
            }
        }
        private void WINDOW_WindowRegistered(int lCookie)
        {
            foreach (SHDocVw.InternetExplorer ie in Windows)
            {

                if (ListWindowIE[ie.HWND] == null)
                {
                    ie.BeforeNavigate2 += ie_BeforeNavigate2;
                    ListWindowIE[ie.HWND] = ie;
                }
            }
        }
        private void ie_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            string url = Convert.ToString(URL);
            if (ObjStatic.IsExtensionAutoDownload(Path.GetExtension(url).ToLower()))
            {
                AutoLinks.Enqueue(url);
                Cancel = true;
            }
        }
        #endregion

        #region >- Register Com & Create Key -<
        public void RegisterInRegistryRunOnStartUp(bool RunOnStartup)
        {
            try
            {
                string key = @"Software\Microsoft\Windows\CurrentVersion\Run";
                Microsoft.Win32.RegistryKey KeyRun = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(key, true);
                if (RunOnStartup)
                {
                    string strvalue = Application.StartupPath + "\\MDM.exe onstartup";
                    KeyRun.SetValue(NameApplication, strvalue, Microsoft.Win32.RegistryValueKind.String);
                }
                else
                {
                    KeyRun.DeleteValue(NameApplication);
                }
            }
            catch (Exception ex) { }
        }
        public bool InstallCom(bool IsRegister)
        {
            try
            {
                System.Runtime.InteropServices.RegistrationServices register = new System.Runtime.InteropServices.RegistrationServices();
                string strkeyie = @"Software\Microsoft\Internet Explorer";
                Microsoft.Win32.RegistryKey KeyIE = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strkeyie, true);
                string StrKeyMDM = "Download with MDM";
                if (IsRegister)
                {
                    try
                    {
                        register.RegisterAssembly(typeof(MDMCom.DownloadWithMDM).Assembly, System.Runtime.InteropServices.AssemblyRegistrationFlags.SetCodeBase);
                        // bool rb=register.RegisterAssembly(typeof(MDMCom.MainDownload).Assembly, System.Runtime.InteropServices.AssemblyRegistrationFlags.SetCodeBase);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Register with IE fail :" + ex.Message);
                    }
                    if (KeyIE != null)
                    {
                        //KeyIE.SetValue("DownloadUI", typeof(MDMCom.MainDownload).GUID.ToString());
                        Microsoft.Win32.RegistryKey KeyMenuExt = KeyIE.OpenSubKey("MenuExt", true);
                        if (KeyMenuExt != null)
                        {
                            Microsoft.Win32.RegistryKey KeyMDM = KeyMenuExt.CreateSubKey(StrKeyMDM, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree);
                            if (KeyMDM != null)
                            {
                                KeyMDM.SetValue("", Application.StartupPath + "\\DownloadWithMDM.htm", Microsoft.Win32.RegistryValueKind.String);
                                KeyMDM.SetValue("contexts", 243, Microsoft.Win32.RegistryValueKind.DWord);
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        register.UnregisterAssembly(typeof(MDMCom.DownloadWithMDM).Assembly);
                    }
                    catch (Exception ex) { }
                    // register.UnregisterAssembly(typeof(MDMCom.MainDownload).Assembly);
                    Microsoft.Win32.RegistryKey KeyMenuExt = KeyIE.OpenSubKey("MenuExt", true);
                    if (KeyMenuExt != null)
                    {
                        try
                        {
                            KeyMenuExt.DeleteSubKey(StrKeyMDM);
                        }
                        catch (Exception ex) { }
                    }
                }
                if (KeyIE != null)
                    KeyIE.Close();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error :" + ex.Message);
            }
            return false;
        }
        /*
         public bool RegisterInRegistry(bool IsRegister)
        {
            Microsoft.Win32.RegistryKey keysoftware = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
            string NameKeyApp = "My Download Manager";
            if (IsRegister)
            {
                try
                {
                    Microsoft.Win32.RegistryKey KeyApp = keysoftware.OpenSubKey(NameKeyApp, true);
                    if (KeyApp == null)
                    {
                        KeyApp = keysoftware.CreateSubKey(NameKeyApp);
                    }
                    KeyApp.SetValue("DownloadExtension", ObjStatic.Config.AutoDownload, Microsoft.Win32.RegistryValueKind.String);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
                try
                {
                    keysoftware.DeleteSubKey(NameKeyApp);
                }
                catch (Exception ex)
                {
                    return false;
                }
            return true;
        }
        */
        #endregion

        #region >- Notify Icon -<
        private void NotifyMenuAudioBook_Click(object sender, EventArgs e)
        {
            ShowFormDownloadAudioBook();
        }
        private void NotifyMenuMediaFire_Click(object sender, EventArgs e)
        {
            OpenMediaDownload();
        }

        private void MainNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowMainForm();
        }
        private void ShowNotifyIcon()
        {
            MainNotifyIcon.Icon = Icon;
            MainNotifyIcon.Visible = true;
        }
        public void CloseMainForm()
        {
            try
            {
                StopAllDownload();
                PerformSaveCategory();
                SaveConfig();
                StopSniff();
                SaveCookie();
                TimerTotalSpeed.Stop();
                Application.Exit();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void MenuNotify_Exit_Click(object sender, EventArgs e)
        {
            CloseMainForm();
        }
        private void ShowMainForm()
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            Show();
            Activate();
        }
        private void MenuNotify_Restore_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }
        private void MenuNotify_Configuration_Click(object sender, EventArgs e)
        {
            ConfigurationForm frm = new ConfigurationForm();
            frm.ShowDialog();
        }
        private void Menu_Notify_AddMultiUrl_Click(object sender, EventArgs e)
        {
            OpenAddMultiUrl();
        }
        private void Menu_Notify_AddUrl_Click(object sender, EventArgs e)
        {
            OpenAddURL();
        }
        private void MenuNotify_Help_Click(object sender, EventArgs e)
        {
            OpenHelp();
        }
        #endregion

        #region >- Sniffer -<

        private void NotifyMenu_Sniffer_Click(object sender, EventArgs e)
        {
            ObjStatic.ShowFormSniff();
        }
        private void Mysniff()
        {
            try
            {
                LoadExtentionNoSniff();
                IPHostEntry host = Dns.GetHostByName("");
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.Unspecified);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
                byte[] inn = new byte[4] { 1, 0, 0, 0 };
                byte[] outt = new byte[4] { 1, 0, 0, 0 };
                socket.Bind(new IPEndPoint(host.AddressList[0], 0));
                socket.IOControl(IOControlCode.ReceiveAll, inn, outt);
                data = new byte[buffsize];
                socket.BeginReceive(data, 0, buffsize, SocketFlags.None, GetData, null);
            }
            catch (Exception ex) { }
        }
        private void GetData(IAsyncResult ar)
        {
            try
            {
                int revice = socket.EndReceive(ar);
                ProcessData(data, revice);
                if (!Stop)
                {
                    socket.BeginReceive(data, 0, buffsize, SocketFlags.None, GetData, null);
                }
                else StopSniff();
            }
            catch (Exception ex) { }
        }

        private void StartSniff()
        {
            ObjStatic.CreateSniffForm();
            if (mysniff == null)
                mysniff = new Mysniffer();
            Stop = false;
            Mysniff();
        }
        public void StopSniff()
        {
            try
            {
                socket.Close();
                Stop = true;
            }
            catch (Exception ex) { }
        }
        private void ProcessData(byte[] data, int total)
        {
            mysniff.Sniff(data);
            if (mysniff.packet == null || mysniff.packet.Data == null || mysniff.packet.Data.Length < 32)
                return;
            if (IsHTTPProtocol(mysniff.packet.SourcePort, mysniff.packet.DestinationPort))
            {

                string firstline = Encoding.ASCII.GetString(mysniff.packet.Data, 0, 5);
                bool IsSend = firstline.StartsWith("GET ");
                bool IsReceive = firstline.StartsWith("HTTP/");
                if (IsSend || IsReceive)
                {
                    HttpPacket http = new HttpPacket();
                    string HTMLData = Encoding.ASCII.GetString(mysniff.packet.Data);
                    http.Parse(HTMLData, IsSend);
                    if (IsSend)
                    {
                        if (http.UserAgent != ObjStatic.UserAgent)
                        {
                            Sends[mysniff.packet.Acknowledgement] = http;
                        }
                    }
                    else
                    {
                        int indextype = IsTypeFileSniffer(http.ContentType);
                        if (indextype > -1 && http.Size >= 0)
                        {
                            if (Sends[mysniff.packet.Sequence] != null)
                            {
                                HttpPacket temp = (HttpPacket)Sends[mysniff.packet.Sequence];
                                string link = temp.Url;
                                string filename = GetFileNameFromURL(temp.Url);
                                if (IsContentNoSniff(filename))
                                    Sends[mysniff.packet.Sequence] = null;
                                else
                                {
                                    FileSniffer fs = new FileSniffer(filename, http.Size, temp.Url.ToLower(), indextype);
                                    ObjStatic.FrmShowFileSniff.AddFile(fs);
                                }
                            }
                        }
                        else Sends[mysniff.packet.Sequence] = null;
                    }
                }
            }
        }
        private int IsTypeFileSniffer(string type)
        {
            if (string.IsNullOrEmpty(type))
                return -1;
            if (type.IndexOf("form") >= 0)
                return -1;
            for (int i = 0; i < ObjStatic.Config.DefaultTypeSniffer.Length; i++)
            {
                TypeSniffer obj = ObjStatic.Config.DefaultTypeSniffer[i];
                if (obj.Selected)
                {
                    if (type.StartsWith(obj.Type))
                        return i;
                }
            }
            return -1;
        }
        private bool IsHTTPProtocol(int sourceport, int descport)
        {
            return (sourceport == 80 || sourceport == 8080 || descport == 80 || descport == 8080);
        }
        private string GetFileNameFromURL(string url)
        {
            try
            {
                string httpurl = url.Split('?')[0];
                string filename = Path.GetFileName(httpurl);
                if (string.IsNullOrEmpty(filename))
                {
                    return "Unknown";
                }
                return filename;
            }
            catch (Exception ex) { }
            return "Unknown";
        }
        Hashtable ExtensiontNoSniffers = new Hashtable();
        public void LoadExtentionNoSniff()
        {
            if (!string.IsNullOrEmpty(ObjStatic.Config.ExtensionNoSniff))
            {
                ExtensiontNoSniffers = new Hashtable();
                string[] str = ObjStatic.Config.ExtensionNoSniff.ToLower().Split(' ');
                for (int i = 0; i < str.Length; i++)
                {
                    ExtensiontNoSniffers[str[i]] = true;
                }
            }
        }
        private bool IsContentNoSniff(string filename)
        {
            string extension = Path.GetExtension(filename).ToLower();
            if (extension.Length > 0)
            {
                extension = extension.Remove(0, 1);
                if (ExtensiontNoSniffers != null)
                    return ExtensiontNoSniffers[extension] != null;
            }
            return false;
        }
        #endregion

        #region >- Download MediaFire -<

        private void OpenMediaDownload()
        {
            MediafireDownload obj = new MediafireDownload();
            obj.Show();
        }
        #endregion

        #region >- Properties -<
        public ListFile CurrentListFile
        {
            get
            {
                if (currentlistfile == null)
                    currentlistfile = Category[0];
                return currentlistfile;
            }
            set { currentlistfile = value; }
        }
        #endregion

        #region >- Orther -<

        private void OpenFormAbout()
        {
            FrmAbout obj = new FrmAbout();
            obj.ShowDialog();
        }
        private void MainMenu_DownloadMediaFire_Click(object sender, EventArgs e)
        {
            OpenMediaDownload();
        }
        private void btnShowGetAudioBook_Click(object sender, EventArgs e)
        {
            ShowFormDownloadAudioBook();
        }
        private void btnShowGetMediaFire_Click(object sender, EventArgs e)
        {
            OpenMediaDownload();
        }
        private void btnShowSniffer_Click(object sender, EventArgs e)
        {
            ObjStatic.ShowFormSniff();
        }
        private void MainMenuShowSniffer_Click(object sender, EventArgs e)
        {
            ObjStatic.ShowFormSniff();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAbout();
        }
        private void MenuNotify_About_Click(object sender, EventArgs e)
        {
            OpenFormAbout();
        }
        private void MainMenu_StartSniffer_Click(object sender, EventArgs e)
        {
            if (!MainMenu_StartSniffer.Checked)
            {
                StopSniff();
            }
            else
            {
                StartSniff();
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null && !CurrentListFile.Running)
                CurrentListFile.StartDownload();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null && CurrentListFile.Running)
                CurrentListFile.StopDownload();
        }
        private void btnDeleteAllComplete_Click(object sender, EventArgs e)
        {
            if (CurrentListFile != null)
            {
                DialogResult res = MessageBox.Show("Do you want to delete all files completed ?", ObjStatic.MessageBoxCaption, MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    long totalsize = 0;
                    for (int i = 0; i < CurrentListFile.Count; i++)
                    {
                        if (CurrentListFile[i].Status == DownloadStatus.Complete)
                        {
                            GridDownload.Rows.Remove(CurrentListFile[i].Row);
                            CurrentListFile.RemoveFileAt(i);
                            i--;
                        }
                        else if (CurrentListFile[i].Size > 0)
                            totalsize += CurrentListFile[i].Size;
                    }
                    UpdateStatusTooltip(CurrentListFile.Count, 0, 0, totalsize);
                }
            }
        }

        #endregion

        #region >- System Event -<

        private void SystemEvents_SessionEnded(object sender, Microsoft.Win32.SessionEndedEventArgs e)
        {
            CloseMainForm();
        }

        #endregion
    }
}