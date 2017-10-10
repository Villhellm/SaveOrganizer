using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveOrganizer
{
    class GithubUpdater
    {
        public static string VersionURL = "https://raw.githubusercontent.com/Villhellm/SaveOrganizer/master/Version.txt";
        public static string ExecutableDownloadURL = "https://github.com/Villhellm/SaveOrganizer/raw/master/bin/Debug/SaveOrganizer.exe";
        private string ConfigurationFile = Configuration.ConfigurationFile;
        public string LatestVersion { get; set; }
        public string CurrentVersion { get; set; }
        private Point FormStartPoint;
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
            if (CurrentVersion != "" && LatestVersion != "" && VersionCompare(CurrentVersion, LatestVersion))
            {
                FormUpdatePrompt Prompt = new FormUpdatePrompt("Version " + LatestVersion + " is available, would you like to update?");
                DialogResult DR = Prompt.ShowDialog();
                if (DR == DialogResult.Yes)
                {
                    UpdateProgram();
                }
                if(DR == DialogResult.Abort)
                {
                    Configuration CurrentConfig = Configuration.Load();
                    CurrentConfig.LastCommitID = "9999999.9.9.9";
                    CurrentConfig.Save();
                }
            }
        }

        public bool VersionCompare(string VersionOriginal, string VersionToCheck)
        {
            int VO1, VO2, VO3, VO4, VC1, VC2, VC3, VC4;

            VO1 = Convert.ToInt32(VersionOriginal.Substring(0, VersionOriginal.IndexOf('.')));
            VersionOriginal = VersionOriginal.Substring(VersionOriginal.IndexOf('.') + 1);
            VO2 = Convert.ToInt32(VersionOriginal.Substring(0, VersionOriginal.IndexOf('.')));
            VersionOriginal = VersionOriginal.Substring(VersionOriginal.IndexOf('.') + 1);
            VO3 = Convert.ToInt32(VersionOriginal.Substring(0, VersionOriginal.IndexOf('.')));
            VersionOriginal = VersionOriginal.Substring(VersionOriginal.IndexOf('.') + 1);
            VO4 = Convert.ToInt32(VersionOriginal);

            VC1 = Convert.ToInt32(VersionToCheck.Substring(0, VersionToCheck.IndexOf('.')));
            VersionToCheck = VersionToCheck.Substring(VersionToCheck.IndexOf('.') + 1);
            VC2 = Convert.ToInt32(VersionToCheck.Substring(0, VersionToCheck.IndexOf('.')));
            VersionToCheck = VersionToCheck.Substring(VersionToCheck.IndexOf('.') + 1);
            VC3 = Convert.ToInt32(VersionToCheck.Substring(0, VersionToCheck.IndexOf('.')));
            VersionToCheck = VersionToCheck.Substring(VersionToCheck.IndexOf('.') + 1);
            VC4 = Convert.ToInt32(VersionToCheck);

            if (VC1 > VO1)
                return true;
            else if(VC1 == VO1)
            {
                if (VC2 > VO2)
                    return true;
                else if (VC2 == VO2)
                {
                    if (VC3 > VO3)
                        return true;
                    else if (VC3 == VO3)
                    {
                        if (VC4 > VO4)
                            return true;
                    }
                }
            }

            return false;

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
            Configuration CurrentConfig = Configuration.Load();
            CurrentConfig.LastCommitID = LatestVersion;
            CurrentConfig.Save();
        }

    }
}
