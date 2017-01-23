using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace My_Download_Manager
{
    public partial class SelectCategory : Form
    {
        public SelectCategory(ListFile lf,List<ListFile> category)
        {
            InitializeComponent();
            for (int i = 0; i < category.Count; i++)
            {
                if (category[i] != lf)
                {
                    CboCategory.Items.Add(category[i]);
                    CboCategory.DisplayMember = "Name";
                }
            }
            CboCategory.SelectedIndex = 0;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            ListFile lf = (ListFile)CboCategory.SelectedItem;
            ObjStatic.FormMain.MoveFileSelectToOrtherCategory(lf);
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}