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
        string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public Form3()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(folder + Environment.ExpandEnvironmentVariables(@"%appdata%\ultrastardx"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(folder + @"\MyLittleKaraoke_WebInstall.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(folder + @"\songs\");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(folder + @"\themes\");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start(folder + @"\");
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
