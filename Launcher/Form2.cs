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
            string songs = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\songs\";
            if (Directory.Exists(songs))
                label4.Text = File.ReadAllText(songs + "version.txt");
            else
                label4.Text = "Not available";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://bardiel83.deviantart.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://mylittlekaraoke.com/index.php?pages/Team");
        }
    }
}
