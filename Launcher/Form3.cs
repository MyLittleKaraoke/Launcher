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
            Open(Environment.ExpandEnvironmentVariables(@"%appdata%\ultrastardx"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Open(@"\MyLittleKaraoke_WebInstall.exe");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Open(@"\songs\");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Open(@"\themes\");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Open(@"\");
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Open(string path) {
            try {
                Process.Start(folder + path);
            }
            catch (Exception ex) {  
                MessageBox.Show("Couldn't open the desired file/folder, sorry!\n\n" + ex.Message, "Action failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
