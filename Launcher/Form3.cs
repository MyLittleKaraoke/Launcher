using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace My_Little_Karaoke_Launcher
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                string folder = Environment.ExpandEnvironmentVariables(@"%appdata%\ultrastardx");
                Process.Start(folder);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\";
            Process.Start(folder + "updatecheck.url");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\songs\";
            Process.Start(folder);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\themes\";
            Process.Start(folder);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\";
            Process.Start(folder);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
