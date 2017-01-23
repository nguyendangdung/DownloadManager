using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace My_Download_Manager
{
    public partial class Import : Form
    {
        #region >- Content -<
        
        public Import()
        {
            InitializeComponent();
        }
        private void Import_Load(object sender, EventArgs e)
        {
            txtSaveto.Text = ObjStatic.FormMain.GetCurrentPathOfCategory();
        }
        private string GetFolder()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.ShowDialog();
            return folder.SelectedPath;
        }
        private void btnBrowserFileImport_Click(object sender, EventArgs e)
        {
            txtFileImport.Text = GetFolder();
        }
        private void btnBrowserSaveto_Click(object sender, EventArgs e)
        {
            txtSaveto.Text = GetFolder();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(txtFileImport.Text))
            {
                if (System.IO.Directory.Exists(txtSaveto.Text))
                {
                    ListFile lf;
                    try
                    {
                        lf = (ListFile)ObjStatic.FormMain.ReadObject(txtFileImport.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File eror : "+ex.Message);
                        return;
                    }
                    if (lf != null)
                    {
                        for (int i = 0; i < lf.Count; i++)
                        {
                            FileDownload f = lf[i];
                            f.Loaded = 0;
                            f.Status = DownloadStatus.Create;
                            f.GetParts().Clear();
                            f.Size = -1;
                            f.PathFile = txtSaveto.Text + "\\" + f.FileName;
                            ObjStatic.FormMain.AddFileToCurrentCategory(f);
                        }
                        MessageBox.Show("Import complete !",ObjStatic.MessageBoxCaption);
                        Close();
                    }
                }
            }
            else MessageBox.Show("File import not exist !",ObjStatic.MessageBoxCaption);
        }

        #endregion
    }
}