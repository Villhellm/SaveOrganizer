using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SaveOrganizer
{
    class GithubUpdater
    {
        public static string VersionURL = "https://raw.githubusercontent.com/Villhellm/QuickStream/master/StreamStarter/Version.txt";
        public static string ExecutableDownloadURL = "https://github.com/Villhellm/SaveOrganizer/raw/master/bin/Debug/SaveOrganizer.exe";
        private string ConfigurationFile = FormMain.ConfigurationFile;
        public string LatestVersion { get; set; }
        public string CurrentVersion { get; set; }
        string MemeURLCacheBlocker = "?t=" + DateTime.Now.ToString().Replace(" ", "");

        public string GetLatestVersion()
        {
            try
            {
                WebClient Checker = new WebClient();
                Checker.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
                return Checker.DownloadString(VersionURL + MemeURLCacheBlocker);
            }
            catch
            {
                return "";
            }
        }

        public void LaunchUpdater()
        {
            BackgroundWorker UpdateChecker = new BackgroundWorker();
            UpdateChecker.DoWork += CheckForUpdate;
            UpdateChecker.RunWorkerAsync();
        }

        public void CheckForUpdate(object sender, DoWorkEventArgs e)
        {
            LatestVersion = GetLatestVersion();
            if (CurrentVersion != "" && LatestVersion != "" && LatestVersion != CurrentVersion)
            {
                DialogResult DR = MessageBox.Show("Version " + LatestVersion + " is available, would you like to update?", "Update", MessageBoxButtons.YesNo);
                if (DR == DialogResult.Yes)
                {
                    UpdateProgram();
                }
            }
        }

        public void DownloadInternetFile(string sourceURL, string destinationPath)
        {
            long fileSize = 0;
            int bufferSize = 1024;
            bufferSize *= 1000;
            long existLen = 0;

            FileStream saveFileStream;

            if (File.Exists(destinationPath))
            {
                File.Delete(destinationPath);
            }

            saveFileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

            HttpWebRequest httpReq;
            HttpWebResponse httpRes;
            httpReq = (HttpWebRequest)HttpWebRequest.Create(sourceURL);
            httpReq.AddRange((int)existLen);
            Stream resStream;
            httpRes = (HttpWebResponse)httpReq.GetResponse();
            resStream = httpRes.GetResponseStream();

            fileSize = httpRes.ContentLength;

            int byteSize;
            byte[] downBuffer = new byte[bufferSize];

            while ((byteSize = resStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
            {
                saveFileStream.Write(downBuffer, 0, byteSize);
            }
        }

        private void UpdateProgram()
        {
            DownloadInternetFile(ExecutableDownloadURL + MemeURLCacheBlocker, System.Reflection.Assembly.GetEntryAssembly().Location + "t");
            SelfDestruct();
        }

        private void SelfDestruct()
        {
            if (File.Exists(Application.ExecutablePath + "t"))
            {
                UpdateVersion();
                string ProgName = Path.GetFileName(Application.ExecutablePath);
                string ProgPathWithName = Application.ExecutablePath;
                string ProgPath = Path.GetDirectoryName(Application.ExecutablePath);
                Process.Start("cmd.exe", "/C timeout 3 & Del \"" + ProgPathWithName + "\"& RENAME \"" + ProgPathWithName + "t\" " + "\"" + ProgName + "\"" + " & start \"" + ProgPath + "\" \"" + ProgName + "\"");
                Environment.Exit(0);
            }
        }

        public void UpdateVersion()
        {
            XDocument Xml = XDocument.Load(ConfigurationFile);
            XElement xVersion = Xml.Element("Configs").Element("LastCommitID");
            xVersion.Value = LatestVersion;
            Xml.Save(ConfigurationFile);
        }

    }
}
