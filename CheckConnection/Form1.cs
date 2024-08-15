using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace CheckConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            Check();

        }
        public async void Check()
        {
            while (true)
            {
                try
                {
                    using (var ping = new Ping())
                    {
                        var result1 = ping.Send("192.168.1.1", 200);
                        var result2 = ping.Send("192.168.1.2", 200);
                        if (result1.Status != IPStatus.Success && result2.Status != IPStatus.Success)
                        {
                            this.Show();
                        }
                        else
                        {
                            this.Hide();
                        }
                    }
                }
                catch
                {
                    ;
                }
                await Task.Delay(1000);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var result1 = ping.Send("192.168.1.1", 500);
                    var result2 = ping.Send("192.168.1.2", 500);
                    if (result1.Status != IPStatus.Success && result2.Status != IPStatus.Success)
                    {
                        this.Show();
                    }
                    else
                    {
                        this.Hide();
                    }
                }
            }
            catch
            {
                this.Hide();
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Opacity = 100;
            Hide();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if (WindowState == FormWindowState.Minimized)
            {
                // Hide the form and display the NotifyIcon in the notification area
                this.Opacity = 100;
                Hide();
                notifyIcon1.Visible = true;
               
            }
        }
    }
}
