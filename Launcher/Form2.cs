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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            string versionFile = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\songs\version.txt";
            if (File.Exists(versionFile))
                label4.Text = File.ReadAllText(versionFile);
            else
                label4.Text = "Not available";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://bardiel83.deviantart.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://mylittlekaraoke.com/index.php?pages/Team");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 dlg = new Form3();
            dlg.ShowDialog();
        }
    }
}
