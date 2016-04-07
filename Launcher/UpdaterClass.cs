using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
namespace My_Little_Karaoke_Launcher {
    class UpdaterClass {

        public void CheckForUpdates() {
            try {
                //run on separate thread, don't block
                var GameFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                var FileAddressList = GetFileAddressesListFromWeb(new Uri("https://www.mylittlekaraoke.com/store/webinst/windows.webinst"));
                var InstalledPackage = GetPackageVersion(GameFolder);
                var RemotePackage = GetRemotePackageVersion(FileAddressList);
                if (!InstalledPackage.Equals("none") && !RemotePackage.Equals("none") && !InstalledPackage.Equals(RemotePackage)) {
                    if (MessageBox.Show("An update for My Little Karaoke is available. Open installer now?", "Update Time!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                        if (File.Exists(GameFolder + "\\MyLittleKaraoke_WebInstall.exe")) {
                            Process.Start(GameFolder + "\\MyLittleKaraoke_WebInstall.exe");
                        }
                    }
                }
            }
            catch { }
        }

        public string GetRemotePackageVersion(string[,] RemoteAddressList) {
            try {
                var result = RemoteAddressList[RemoteAddressList.GetLength(0) - 1, 0];
                return result.Contains('/') ? result.Substring(result.LastIndexOf('/') + 1) : result;
            }
            catch {
                return "none";
            }
        }

        public string GetPackageVersion(string InstallFilePath) {
            try {
                return File.ReadAllLines(Path.Combine(InstallFilePath, "packageversion.txt")).First().ToString();
            }
            catch {
                return "none";
            }
        }

        public string[,] GetFileAddressesListFromWeb(Uri UpdaterFileAddressUrl) {
            string[] WebPageContentLines = GetWebPageContent(UpdaterFileAddressUrl.OriginalString).Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[,] FileTableNx2 = new string[WebPageContentLines.Length / 2, 2];
            for (int i = 0; i < WebPageContentLines.Length - 1; i++) //-1 because of the linux-typical line-break at file-end
            {
                try {
                    FileTableNx2[i / 2, i % 2] = WebPageContentLines[i];
                }
                catch { }
            }
            return FileTableNx2;
        }

        private string GetWebPageContent(string PageURL) {
            try {
                WebRequest Request = WebRequest.Create(PageURL);
                WebResponse Response = Request.GetResponse();
                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                return Reader.ReadToEnd();
            }
            catch {
                return "none";
            }
        }
    }
}