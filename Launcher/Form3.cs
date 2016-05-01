using System;
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
            OpenFolder(Environment.ExpandEnvironmentVariables(@"%appdata%\ultrastardx"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFolder(@"\MyLittleKaraoke_WebInstall.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFolder(@"\songs\");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFolder(@"\themes\");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFolder(@"\");
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenFolder(string path) {
            try {
                Process.Start(folder + path);
            }
            catch {
                MessageBox.Show("Couldn't open the desired folder, sorry!", "Opening folder failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
