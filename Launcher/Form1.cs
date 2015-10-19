﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace My_Little_Karaoke_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://mylittlekaraoke.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\";
            Process.Start(folder + "ultrastardx.exe");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 dlg = new Form3();
            dlg.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.mylittlekaraoke.com/store/beta/releases.html");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/forms/d/1UlKJQIycptQKK-re-Ps_2htehzz5GVLiBGikbQ-n2Kw/viewform");
        }
            
        }
    }