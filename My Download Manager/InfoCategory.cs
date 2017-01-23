using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace My_Download_Manager
{
    public partial class InfoCategory : Form
    {

        ListFile lf;

        #region >- Content -<
        
        public InfoCategory()
        {
            InitializeComponent();
        }
        public InfoCategory(ListFile lf)
        {
            InitializeComponent();
            this.lf = lf;
        }
        private void InfoCategory_Load(object sender, EventArgs e)
        {
            if (lf == null)
            {
                btnOK.Text = "Cancel";
                NUDDownload.Value = 2;
                cboChangeDirectory.Enabled = false;
            }
            else
            {
                txtName.ReadOnly = true;
                btnAction.Text = "Update";
                txtName.Text = lf.Name;
                txtSaveTo.Text = lf.SaveTo;
                NUDDownload.Value = lf.FileConnection;
                cboChangeDirectory.Enabled = true;
                cboChangeDirectory.Checked = false;
                CboShutdownWhencomplete.Checked = lf.ExitWindownWhenComplete;
            }
        }
        private void btnAction_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please input category name !",ObjStatic.MessageBoxCaption);
                return;
            }
            if (lf == null && ObjStatic.FormMain.CheckExistCategory(txtName.Text))
            {
                MessageBox.Show("This category is always exists !",ObjStatic.MessageBoxCaption);
                return;
            }
            int connection = Convert.ToInt32(NUDDownload.Value);

            if (txtSaveTo.Text.Length > 0 && !System.IO.Directory.Exists(txtSaveTo.Text))
            {
                MessageBox.Show("Folder not exist !",ObjStatic.MessageBoxCaption);
                txtSaveTo.Focus();
                return;
            }
            if (lf != null)
            {
                lf.FileConnection = connection;
                lf.SaveTo = txtSaveTo.Text;
                lf.ExitWindownWhenComplete = CboShutdownWhencomplete.Checked;
                if (cboChangeDirectory.Checked)
                {
                    for (int i = 0; i < lf.Count; i++)
                    {
                        if (!lf[i].Running && lf[i].Status != DownloadStatus.Building && lf[i].Status != DownloadStatus.Complete)
                        {
                            lf[i].PathFile = txtSaveTo.Text + "\\" + lf[i].FileName;
                        }
                    }
                }
                ObjStatic.FormMain.SaveCategory();
                Close();
            }
            else
            {
                ListFile lfnew = new ListFile(txtName.Text, connection);
                lfnew.SaveTo = txtSaveTo.Text;
                lfnew.ExitWindownWhenComplete = CboShutdownWhencomplete.Checked;
                ObjStatic.FormMain.AddCategory(lfnew);
                ObjStatic.FormMain.SaveCategory();
                Close();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.ShowDialog();
            if (!string.IsNullOrEmpty(folder.SelectedPath))
            {
                if (System.IO.Directory.Exists(folder.SelectedPath))
                {
                    txtSaveTo.Text = folder.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Folder not exist !",ObjStatic.MessageBoxCaption);
                }
            }
        }

        #endregion
    }
}