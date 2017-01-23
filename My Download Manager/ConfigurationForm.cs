using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace My_Download_Manager
{
    public partial class ConfigurationForm : Form
    {
        #region >- Variable -<
        
        private int[] ListBuffer;
        private int[] ListConnection;
        #endregion

        #region >- Content -<

        public ConfigurationForm()
        {
            InitializeComponent();
        }
       // private void TabFileType_btnDefault_Click(object sender, EventArgs e)
       // {
           // string[] videoormusic = new string[] { "mp3", "flv", "wmv", "wav", "mp4", "mpg", "avi" };
          //  string[] orther = new string[] {"rar","zip","exe","iso","img","ogg","7z","" };
       // }
        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            ListBuffer = new int[] { 1024, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608 };
            ListConnection = new int[] { 1, 2, 4, 8, 16};
            LoadConnectBuffer();
            LoadConnection();
            txtTemporaryFolder.Text = ObjStatic.Config.FolderTemp;
            txtExtensionNoSniff.Text = ObjStatic.Config.ExtensionNoSniff;
            txtAutoDownloadExtension.Text = ObjStatic.Config.ExtensionAutoDownload;
            cboIERegister.Checked = ObjStatic.Config.RegisterWithIE;
            cboAutostartsniffer.Checked = ObjStatic.Config.AutoStartSniffer;
            cboRunOnStart.Checked = ObjStatic.Config.RunOnStartup;
            LoadSniffer();

        }
        #region >- Sniffer Config -<

        private void SaveSnifferConfig()
        {
            for (int i = 0; i < ClbSniffer.Items.Count; i++)
            {
                bool selected = false;
                for (int j = 0; j < ClbSniffer.CheckedItems.Count; j++)
                {
                    if (ClbSniffer.Items[i] == ClbSniffer.CheckedItems[j])
                    {
                        selected = true;
                        break;
                    }
                }
                ObjStatic.Config.DefaultTypeSniffer[i].Selected = selected;
            }
            
        }
        private void LoadSniffer()
        {
            ClbSniffer.Items.Clear();
            for (int i = 0; i < ObjStatic.Config.DefaultTypeSniffer.Length; i++)
            {
                TypeSniffer temp = ObjStatic.Config.DefaultTypeSniffer[i];
                ClbSniffer.Items.Add(temp.Description, temp.Selected);
            }
        }

        #endregion
        private void LoadConnectBuffer()
        {
            CboBuffer.Items.Clear();
            for (int i = 0; i < ListBuffer.Length; i++)
            {
                int index = CboBuffer.Items.Add(ObjStatic.ToStringSize(ListBuffer[i], "0"));
                if (ObjStatic.Config.Buffer == ListBuffer[i])
                {
                    CboBuffer.SelectedIndex = index;
                }
            }
            if (CboBuffer.SelectedIndex < 0)
                CboBuffer.SelectedIndex = 0;
        }
        private void LoadConnection()
        {
            CboNumberConnection.Items.Clear();
            for (int i = 0; i < ListConnection.Length; i++)
            {
                int index=CboNumberConnection.Items.Add(ListConnection[i]);
                if (ListConnection[i] == ObjStatic.Config.Connection)
                    CboNumberConnection.SelectedIndex = index;
            }
            if (CboNumberConnection.SelectedIndex < 0)
                CboNumberConnection.SelectedIndex = 0;
        }
        private void btnTemBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.SelectedPath = txtTemporaryFolder.Text;
            folder.ShowDialog();
            if (!string.IsNullOrEmpty(folder.SelectedPath))
                txtTemporaryFolder.Text = folder.SelectedPath;
        }
        #endregion
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists(txtTemporaryFolder.Text))
            {
                ObjStatic.Config.FolderTemp = txtTemporaryFolder.Text;
            }
            if (CboNumberConnection.SelectedIndex < 0)
                CboNumberConnection.SelectedIndex = 4;
            ObjStatic.Config.Connection = ListConnection[CboNumberConnection.SelectedIndex];
            if (CboBuffer.SelectedIndex < 0)
                CboBuffer.SelectedIndex = 2;
            ObjStatic.Config.Buffer = ListBuffer[CboBuffer.SelectedIndex];
            ObjStatic.Config.RunOnStartup = cboRunOnStart.Checked;
            ObjStatic.FormMain.RegisterInRegistryRunOnStartUp(ObjStatic.Config.RunOnStartup);
            if (txtExtensionNoSniff.Text.ToLower().Trim() != ObjStatic.Config.ExtensionNoSniff)
            {
                ObjStatic.Config.ExtensionNoSniff = txtExtensionNoSniff.Text.ToLower().Trim();
                ObjStatic.FormMain.LoadExtentionNoSniff();
            }
            if (txtAutoDownloadExtension.Text.ToLower().Trim() != ObjStatic.Config.ExtensionAutoDownload)
            {
                ObjStatic.Config.ExtensionAutoDownload = txtAutoDownloadExtension.Text.ToLower().Trim();
                ObjStatic.UpdateAutoStartDownload();
            }
            if (ObjStatic.Config.RegisterWithIE != cboIERegister.Checked)
            {
                bool result = ObjStatic.FormMain.InstallCom(cboIERegister.Checked);
                if (result)
                {
                    ObjStatic.Config.RegisterWithIE = cboIERegister.Checked;
                    if (!ObjStatic.FormMain.HasOpenGetIEWindow)
                        ObjStatic.FormMain.StartGetIEWindown();
                }
            }
            SaveSnifferConfig();
            ObjStatic.Config.AutoStartSniffer = cboAutostartsniffer.Checked;
            ObjStatic.FormMain.SaveConfig();
            this.Close();
        }
        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtExtensionNoSniff.Text = ObjStatic.Config.DefaultNoSniff;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDefaultAutoDownload_Click(object sender, EventArgs e)
        {
            txtAutoDownloadExtension.Text = ObjStatic.Config.DefaultAutoDownload;
        }

    }
}