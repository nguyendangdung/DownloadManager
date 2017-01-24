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
    public partial class Main : Form
    {
        private readonly File _file;
        public Main()
        {
            InitializeComponent();
            _file = new File();
            _file.PropertyChanged += File_PropertyChanged;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
            await _file.RequestInfoAsync();
            label2.Text = _file.Size.ToString();
            partBindingSource.DataSource = _file.Parts;
            customProcessBar1.MaxValue = _file.Size;
            customProcessBar1.Parts = _file.Parts.ToList();

            customProcessBar2.MaxValue = _file.Size;
            customProcessBar2.Value = _file.DownloadedSize;
            
            await _file.DownloadAsync();
            label3.Text += "    " + DateTime.Now.ToLongTimeString();
        }

        private void File_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            label1.Text = _file.DownloadedSize.ToString();
            customProcessBar2.Value = _file.DownloadedSize;
            customProcessBar1.UpdateValue();
            // customProcessBar2.UpdateValue();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _file.Url = textBox1.Text;
        }
    }
}
