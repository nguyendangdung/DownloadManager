using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DL
{
    public partial class Form1 : Form
    {
        File file = new File()
        {
            Url = "http://dn3.freedownloadmanager.org/5/5.1-latest/fdm5_x64_setup.exe"
        };
        public Form1()
        {
            InitializeComponent();
            file.PropertyChanged += File_PropertyChanged;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await file.RequestInfoAsync();
            label2.Text = file.Size.ToString();
            partBindingSource.DataSource = file.Parts;
            await file.DownloadAsync();
        }

        private void File_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            label1.Text = file.DownloadedSize.ToString();
        }
    }
}
