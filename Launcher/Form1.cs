using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

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
            Process.Start("https://www.mylittlekaraoke.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process game = new Process();
                game.StartInfo.FileName = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "ultrastardx.exe");
                game.StartInfo.WorkingDirectory = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                game.StartInfo.UseShellExecute = false;
                game.StartInfo.RedirectStandardOutput = false;
                game.Start();
                this.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Sorry, was not able to find the file \"ultrastardx.exe\". Please retry!", "Opening MLK failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Sorry, was not able to open the file \"ultrastardx.exe\". Please retry!", "Opening MLK failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
            new Thread(new UpdaterClass().CheckForUpdates).Start();
        }
    }
}
