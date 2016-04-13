using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
namespace My_Little_Karaoke_Launcher {
    class UpdaterClass {

        public void CheckForUpdates() {
            try {
                var GameFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                var FileAddressList = GetFileAddressesListFromWeb(new Uri("https://www.mylittlekaraoke.com/store/webinst/windows.webinst"));
                var InstalledPackage = GetPackageVersion(GameFolder);
                var RemotePackage = GetRemotePackageVersion(FileAddressList);
                //Conditions: installed and remote packages exist, installed package is one of the remote ones and not the freshest one
                if (!InstalledPackage.Equals("none") && !RemotePackage.Equals("none") && ListContains(FileAddressList, InstalledPackage) && !InstalledPackage.Equals(RemotePackage)) {
                    if (MessageBox.Show("An update for My Little Karaoke is available. Open installer now?", "Update Time!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                        if (File.Exists(Path.Combine(GameFolder, "MyLittleKaraoke_WebInstall.exe"))) {
                            Process.Start(Path.Combine(GameFolder, "MyLittleKaraoke_WebInstall.exe"));
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

        public bool ListContains(string[,] list, string item) {
            //Too sloppy?
            List<string> flattenedList = new List<string>();
            for (int i = 0; i < list.Length/2; ++i) {
                flattenedList.Add(list[i, 0].Contains('/') ? list[i, 0].Substring(list[i, 0].LastIndexOf('/') + 1) : list[i, 0]);
            }
            return flattenedList.Contains(item);
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