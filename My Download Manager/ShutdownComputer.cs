using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace My_Download_Manager
{
    public partial class ShutdownComputer : Form
    {
        public ShutdownComputer()
        {
            InitializeComponent();
        }
        private delegate void SetTextCallBack(Label l, string Text);
        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case 0x0112:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == 0xF010)
                        return;
                    break;
            }
            base.WndProc(ref message);
        }
        int count = 0;
        private void ShutdownComputer_Load(object sender, EventArgs e)
        {
            count = 30;
            TimerCountShutdown.Start();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            TimerCountShutdown.Stop();
            base.OnClosing(e);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            TimerCountShutdown.Stop();
            Close();
        }
        private void TimerCountShutdown_Tick(object sender, EventArgs e)
        {
            
            string str = "This system will shutdown in {0} seconds.";
            if (count > 0)
            {
                count--;
                lblStatus.Text = string.Format(str, count);
            }
            else
            {
                TimerCountShutdown.Stop();
                System.Diagnostics.Process.Start("shutdown", "-s -t 0");
                Application.Exit();
            }
        }

    }

}