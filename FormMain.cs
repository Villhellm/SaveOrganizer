using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Security.Principal;
using System.Drawing;

namespace SaveOrganizer
{
    public partial class FormMain : Form
    {
        //Unnecessary additions to a functional program
        KeyHooker Hooker;
        GameHooker dsHooker;
        GithubUpdater Updater;
        private static ListSortDirection SaveSortOrder;
        private static DataGridViewColumn SaveSortColumn;
        private string PreviousFileName = "";
        private bool PreviousReadOnly;
        string TempDel = "";
        Configuration CurrentConfig;

        Point StartPoint()
        {
            Point Inter = new Point(this.Location.X + Width / 2 - 186, Location.Y + Height - 170);
            return Inter;
        }

        public FormMain()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Configuration.CreateConfiguration();
            CurrentConfig = Configuration.Load();
            CurrentConfig.VerifyXMLConfigFile();
            ReadGlobalConfigurations();
            if (CurrentConfig.LastOpen.Game == "")
            {
                ComboBoxSelectGame.SelectedIndex = 0;
                ComboBoxSelectSubDirectory.SelectedValue = "Default";
            }
            else
            {
                ComboBoxSelectGame.Text = CurrentConfig.LastOpen.Game;
                ComboBoxSelectSubDirectory.Text = CurrentConfig.LastOpen.Profile;
            }
            Hooker = new KeyHooker();
            Hooker.Initialize();
            Hooker.PropertyChanged += new PropertyChangedEventHandler(KeyPressed);
            dsHooker = new GameHooker();
            Updater = new GithubUpdater();
            Updater.CurrentVersion = CurrentConfig.LastCommitID;
            Updater.LaunchUpdater();
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void KeyPressed(object sender, PropertyChangedEventArgs e)
        {
            if (CurrentConfig.EnableHotkeys)
            {
                string Modifier = ((Keys)Hooker.Modifier).ToString();
                string KeyCode = ((Keys)Hooker.CurrentKey).ToString();
                foreach (Hotkey HotK in CurrentConfig.Hotkeys)
                {
                    if (HotK.Modifier == Modifier && HotK.KeyCode == KeyCode && HotK.Enabled == true)
                    {
                        switch (HotK.Name)
                        {
                            case "ExportSave":
                                ExportSave();
                                break;
                            case "ImportSave":
                                ImportCurrentSave();
                                break;
                            case "ToggleReadOnly":
                                FileInfo SelectedSave = new FileInfo(CurrentConfig.GetPath(ComboBoxSelectGame.Text));
                                SetReadOnly(CurrentConfig.GetPath(ComboBoxSelectGame.Text), !SelectedSave.IsReadOnly);
                                break;
                            case "Quicksave":
                                if(ComboBoxSelectGame.Text == "Dark Souls")
                                {
                                    dsHooker.QuitToMenuDoThingsThenLoadSaveMenu(CreateQuickSave);
                                }
                                else
                                {
                                    ActionCenter.Toast("That only works for Dark Souls 1, oops :/", StartPoint(), 1);
                                }
                                break;
                            case "Quickload":
                                if (ComboBoxSelectGame.Text == "Dark Souls")
                                {
                                    dsHooker.QuitToMenuDoThingsThenLoadSaveMenu(LoadQuicksave);
                                }
                                else
                                {
                                    ActionCenter.Toast("That only works for Dark Souls 1, oops :/", StartPoint(), 1);
                                }
                                break;
                            case "Warp":
                                if (ComboBoxSelectGame.Text == "Dark Souls")
                                {
                                    dsHooker.ToggleNoClip();
                                    //dsHooker.WarpToStart();
                                }
                                else
                                {
                                    ActionCenter.Toast("That only works for Dark Souls 1, oops :/", StartPoint(), 1);
                                }
                                break;
                        }
                    }
                }

            }
        }

        private string CurrentDirectory()
        {
            return Configuration.AppDataRoamingPath + "\\" + ComboBoxSelectGame.Text;
        }

        private string CurrentSubDirectory()
        {
            return Configuration.AppDataRoamingPath + "\\" + ComboBoxSelectGame.Text + "\\" + ComboBoxSelectSubDirectory.Text;
        }

        private string CurrentFile()
        {
            return DGVSaveFiles.CurrentRow.Cells[0].Value.ToString();
        }

        private string CurrentPath()
        {
            return Configuration.AppDataRoamingPath + "\\" + ComboBoxSelectGame.Text + "\\" + ComboBoxSelectSubDirectory.Text + "\\" + DGVSaveFiles.CurrentRow.Cells[0].Value.ToString();
        }       

        private void ReadGlobalConfigurations()
        {
            List<string> GameList = new List<string>();

            foreach(Game xGame in CurrentConfig.Games)
            {
                GameList.Add(xGame.Name);
            }
            GameList.Add("Add new...");

            ComboBoxSelectGame.DataSource = GameList;
        }

        private void SaveLastOpened()
        {
            CurrentConfig.LastOpen.Game = ComboBoxSelectGame.Text;
            CurrentConfig.LastOpen.Profile = ComboBoxSelectSubDirectory.Text;
            CurrentConfig.Save();
        }

        private void GetFileNames(bool WithFilter)
        {
            DGVSaveFiles.Rows.Clear();

            DataTable FileTable = new DataTable();
            FileTable.Columns.Add("SaveName", typeof(string));
            FileTable.Columns.Add("DateCreated", typeof(string));
            FileTable.Columns.Add("ReadOnly", typeof(bool));

            string[] Files = Directory.GetFiles(CurrentSubDirectory());
            foreach (string File_ in Files)
            {
                FileInfo File_Info = new FileInfo(File_);
                FileTable.Rows.Add(File_Info.Name, File_Info.LastWriteTime, File_Info.IsReadOnly);
            }
            DataView FileView = new DataView(FileTable);
            FileView.RowFilter = string.Format("SaveName LIKE '%{0}%'", TxtFileSearch.Text);
            FileTable = FileView.ToTable();
            for (int i = 0; i < FileTable.Rows.Count; i++)
            {
                DGVSaveFiles.Rows.Add(FileTable.Rows[i][0], FileTable.Rows[i][1], FileTable.Rows[i][2]);
            }
        }

        public static void SaveSorting(DataGridView DGV)
        {
            SaveSortOrder = DGV.SortOrder == SortOrder.Ascending ?
                ListSortDirection.Ascending : ListSortDirection.Descending;
            SaveSortColumn = DGV.SortedColumn;
        }

        public static void RestoreSorting(DataGridView DGV)
        {
            if (SaveSortColumn != null)
            {
                DataGridViewColumn newCol = DGV.Columns[SaveSortColumn.Name];
                DGV.Sort(newCol, SaveSortOrder);
            }
            else
            {
                DGV.Sort(DGV.Columns[0], ListSortDirection.Ascending);
            }
        }

        private void GetFileNames()
        {
            SaveSorting(DGVSaveFiles);
            DGVSaveFiles.Rows.Clear();
            TxtFileSearch.Text = "Search...";
            DataTable FileTable = new DataTable();
            FileTable.Columns.Add("SaveName", typeof(string));
            FileTable.Columns.Add("DateCreated", typeof(DateTime));
            FileTable.Columns.Add("ReadOnly", typeof(bool));

            string[] Files = Directory.GetFiles(CurrentSubDirectory());
            foreach (string File_ in Files)
            {
                FileInfo File_Info = new FileInfo(File_);
                FileTable.Rows.Add(File_Info.Name, File_Info.LastWriteTime, File_Info.IsReadOnly);
            }

            for (int i = 0; i < FileTable.Rows.Count; i++)
            {
                DGVSaveFiles.Rows.Add(FileTable.Rows[i][0], FileTable.Rows[i][1], FileTable.Rows[i][2]);
            }
            RestoreSorting(DGVSaveFiles);
        }

        private void GetSubDirectories()
        {
            string[] SubDirs = Directory.GetDirectories(CurrentDirectory());
            ComboBoxSelectSubDirectory.Items.Clear();
            foreach (string Dir in SubDirs)
            {
                ComboBoxSelectSubDirectory.Items.Add(Path.GetFileName(Dir));
            }

            ComboBoxSelectSubDirectory.Items.Add("Add new ...");
        }

        private string GetNewGameSaveLocation()
        {
            OpenFileDialog GetPath = new OpenFileDialog();

            GetPath.Title = ComboBoxSelectGame.Text + " savefile location";

            if (GetPath.ShowDialog() == DialogResult.OK)
            {
                return GetPath.FileName;
            }
            return "";
        }

        private void SetGameSaveLocation(string GameName)
        {
            CurrentConfig.Game(GameName).Path = GetNewGameSaveLocation();
            CurrentConfig.Save();
        }

        private void CopyFile(string ReadPath, string WritePath)
        {
            string FullFilePath = WritePath + "\\CurrentSave";
            string FullFilePathTemp = WritePath + "\\CurrentSave";
            int Count = 0;
            while (File.Exists(FullFilePathTemp))
            {
                Count++;
                FullFilePathTemp = FullFilePath;
                FullFilePathTemp = FullFilePathTemp + "_" + Count;
            }

            FullFilePath = FullFilePathTemp;

            try
            {
                File.Copy(ReadPath, FullFilePath);
            }
            catch
            {

            }
        }

        private void FileEdit(string FileName, string NewFileName, bool ReadOnly)
        {
            FileAttributes OldAttributes = File.GetAttributes(FileName);
            if (ReadOnly)
            {
                OldAttributes = OldAttributes | FileAttributes.ReadOnly;
                File.SetAttributes(FileName, OldAttributes);
            }
            else
            {
                OldAttributes = OldAttributes & ~FileAttributes.ReadOnly;
                File.SetAttributes(FileName, OldAttributes);
            }

            try
            {
                File.Move(FileName, NewFileName);

            }
            catch (IOException)
            {

            }

        }

        private void SetReadOnly(string File_, bool ReadOnly)
        {
            FileAttributes OldAttributes = File.GetAttributes(File_);
            if (ReadOnly)
            {
                OldAttributes = OldAttributes | FileAttributes.ReadOnly;
                File.SetAttributes(File_, OldAttributes);
            }
            else
            {
                OldAttributes = OldAttributes & ~FileAttributes.ReadOnly;
                File.SetAttributes(File_, OldAttributes);
            }
        }

        private void ImportProfile()
        {
            FolderBrowserDialog SelectProfile = new FolderBrowserDialog();
            DialogResult DR = SelectProfile.ShowDialog();
            if (DR == DialogResult.OK)
            {
                string ProfileName = Path.GetFileName(SelectProfile.SelectedPath);
                if(VerifyValidity(Configuration.AppDataRoamingPath + "\\" + ComboBoxSelectGame.Text + "\\" + ProfileName, ProfileName))
                {
                    DirectoryCopy(SelectProfile.SelectedPath, Configuration.AppDataRoamingPath + "\\" + ComboBoxSelectGame.Text + "\\" + ProfileName, false);
                    GetSubDirectories();
                    ComboBoxSelectSubDirectory.SelectedIndex = ComboBoxSelectSubDirectory.Items.IndexOf(ProfileName);

                }
            }
        }

        private void AddNewProfile()
        {
            FormRename NewProfileName = new FormRename();
            NewProfileName.StartPosition = FormStartPosition.CenterParent;
            DialogResult DR = NewProfileName.ShowDialog();
            if (DR == DialogResult.OK)
            {
                string DirectoryPath = CurrentDirectory() + "\\" + NewProfileName.NewName;
                if (VerifyValidity(DirectoryPath, NewProfileName.NewName))
                {
                    Directory.CreateDirectory(CurrentDirectory() + "\\" + NewProfileName.NewName);
                    GetSubDirectories();
                    ComboBoxSelectSubDirectory.SelectedIndex = ComboBoxSelectSubDirectory.Items.IndexOf(NewProfileName.NewName);

                }
            }
            if (DR == DialogResult.Cancel)
            {
                ComboBoxSelectSubDirectory.SelectedIndex = ComboBoxSelectSubDirectory.Items.IndexOf("Default");
            }
        }

        private void RenameProfile()
        {
            if (ComboBoxSelectSubDirectory.Text == "Default")
            {
                ActionCenter.Toast("You cannot rename the default profile.", StartPoint());
            }
            else
            {
                FormRename NewProfileName = new FormRename();
                NewProfileName.StartPosition = FormStartPosition.CenterParent;
                DialogResult DR = NewProfileName.ShowDialog();
                if (DR == DialogResult.OK)
                {
                    string NewPath = CurrentDirectory() + "\\" + NewProfileName.NewName;
                    if (VerifyValidity(NewPath, NewProfileName.NewName))
                    {
                        Directory.Move(CurrentSubDirectory(), NewPath);
                        GetSubDirectories();
                        ComboBoxSelectSubDirectory.SelectedIndex = ComboBoxSelectSubDirectory.Items.IndexOf(NewProfileName.NewName);
                    }
                }
            }
        }

        private bool VerifyValidity(string DirectoryPath, string FileName)
        {
            if(FileName == "")
            {
                ActionCenter.Toast("Please enter a valid name", StartPoint(), 2);
                return false;
            }
            if (Directory.Exists(DirectoryPath))
            {
                ActionCenter.Toast("That name already exists, try again", StartPoint(), 2);
                return false;
            }
            foreach(char Check in FileName)
            {
                foreach(char Illegal in Path.GetInvalidFileNameChars())
                {
                    if(Check == Illegal)
                    {
                        ActionCenter.Toast("Invalid character detected. Please remove '" + Check + "' and try again", StartPoint(), 2);

                        return false;
                    }
                }
            }

            return true;
        }

        private void ImportCurrentSave()
        {
            string Path = CurrentConfig.GetPath(ComboBoxSelectGame.Text);
            if (Path == "")
            {
                SetGameSaveLocation(ComboBoxSelectGame.Text);
                Path = CurrentConfig.GetPath(ComboBoxSelectGame.Text);
            }
            CopyFile(CurrentConfig.GetPath(ComboBoxSelectGame.Text), CurrentSubDirectory());
            GetFileNames();

            DGVSaveFiles.ClearSelection();
            DateTime Latest = new DateTime(1999, 1, 1);
            int RowIndex = 0;
            foreach (DataGridViewRow Row in DGVSaveFiles.Rows)
            {
                if (Convert.ToDateTime(Row.Cells[1].Value) > Latest)
                {
                    Latest = Convert.ToDateTime(Row.Cells[1].Value);
                    RowIndex = Row.Index;
                }
            }

            DGVSaveFiles.CurrentCell = DGVSaveFiles.Rows[RowIndex].Cells[0];
        }

        private void ExportSave()
        {
            try
            {
                SetReadOnly(CurrentConfig.GetPath(ComboBoxSelectGame.Text), false);
                File.Copy(CurrentConfig.GetPath(ComboBoxSelectGame.Text), Configuration.AppDataRoamingPath + "\\" + "TempExp", true);
                File.Copy(CurrentSubDirectory() + "\\" + DGVSaveFiles.CurrentRow.Cells[0].Value.ToString(), CurrentConfig.GetPath(ComboBoxSelectGame.Text), true);
            }
            catch (ArgumentException)
            {

            }
            catch (NullReferenceException)
            {

            }
        }

        private void UndoExport()
        {
            try
            {
                File.Copy(Configuration.AppDataRoamingPath + "\\" + "TempExp", CurrentConfig.GetPath(ComboBoxSelectGame.Text), true);
            }
            catch (ArgumentException)
            {

            }
            catch (NullReferenceException)
            {

            }
        }

        private void UndoDelete()
        {
            try
            {
                File.Copy(Configuration.AppDataRoamingPath + "\\" + "TempDel", CurrentSubDirectory() + "\\" + TempDel, true);
                File.Delete(Configuration.AppDataRoamingPath + "\\" + "TempDel");
                GetFileNames();
            }
            catch (ArgumentException)
            {

            }
            catch (NullReferenceException)
            {

            }
        }

        private void CreateQuickSave()
        {
            SetReadOnly(CurrentDirectory() + "\\" + "Quicksave", false);
            File.Copy(CurrentConfig.GetPath(ComboBoxSelectGame.Text), CurrentDirectory() + "\\" + "Quicksave", true);
        }

        private void LoadQuicksave()
        {
            if(File.Exists(CurrentDirectory() + "\\" + "Quicksave"))
            {
                SetReadOnly(CurrentConfig.GetPath(ComboBoxSelectGame.Text), false);
                File.Copy(CurrentDirectory() + "\\" + "Quicksave", CurrentConfig.GetPath(ComboBoxSelectGame.Text), true);
            }
        }

        private void DeleteCurrentProfile()
        {
            if (ComboBoxSelectSubDirectory.Text == "Default")
            {
                DialogResult DRe = ActionCenter.DialogResponse("You cannot delete the default profile. Would you like to clear its contents?");
                if (DRe == DialogResult.OK)
                {
                    string[] Files = Directory.GetFiles(CurrentSubDirectory());
                    foreach (string File_ in Files)
                    {
                        SetReadOnly(File_, false);
                    }
                    Directory.Delete(CurrentSubDirectory(), true);
                    Directory.CreateDirectory(CurrentSubDirectory());
                }

                GetSubDirectories();
                ComboBoxSelectSubDirectory.SelectedIndex = ComboBoxSelectSubDirectory.Items.IndexOf("Default");
                return;
            }

            DialogResult DR = ActionCenter.DialogResponse("Are you sure you want to delete this profile?");
            if (DR == DialogResult.OK)
            {
                string[] Files = Directory.GetFiles(CurrentSubDirectory());
                foreach (string File_ in Files)
                {
                    SetReadOnly(File_, false);
                }

                Directory.Delete(CurrentSubDirectory(), true);
                GetSubDirectories();
                ComboBoxSelectSubDirectory.SelectedIndex = ComboBoxSelectSubDirectory.Items.IndexOf("Default");
            }
        }

        private void DeleteSelectedSave()
        {
            try
            {
                string FileName = CurrentSubDirectory() + "\\" + DGVSaveFiles.CurrentRow.Cells[0].Value.ToString();
                FileAttributes OldAttributes = File.GetAttributes(FileName);

                OldAttributes = OldAttributes & ~FileAttributes.ReadOnly;
                File.SetAttributes(FileName, OldAttributes);
                TempDel = DGVSaveFiles.CurrentRow.Cells[0].Value.ToString();
                File.Copy(FileName, Configuration.AppDataRoamingPath + "\\" + "TempDel", true);

                File.Delete(FileName);
                DGVSaveFiles.Rows.RemoveAt(DGVSaveFiles.CurrentRow.Index);
            }
            catch (NullReferenceException)
            {

            }
            catch (ArgumentNullException)
            {

            }
        }

        private void OpenSettingsForm()
        {
            CurrentConfig.EnableHotkeys = false;
            FormSettings Settings = new FormSettings();
            Settings.StartPosition = FormStartPosition.CenterParent;
            Settings.ShowDialog();
            CurrentConfig = Configuration.Load();
            ReadGlobalConfigurations();
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: " + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);

                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        private void ComboBoxSelectGame_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectGame.Text == "Add new...")
            {
                AddGameToList();
            }
            else
            {
                GetSubDirectories();
                ComboBoxSelectSubDirectory.Text = "Default";
                GetFileNames();
            }
        }

        private void AddGameToList()
        {
            string GameName = "";
            FormRename NewGame = new FormRename();
            NewGame.ShowDialog();

            if(NewGame.DialogResult == DialogResult.OK)
            {
                if (NewGame.NewName != "")
                {
                    GameName = NewGame.NewName;
                    CurrentConfig.Games.Add(new Game(GameName, ""));
                }

                Directory.CreateDirectory(Configuration.AppDataRoamingPath + "//" + GameName + "//" + "Default");

                LoadGameList();
                ComboBoxSelectGame.Text = GameName;
            }
        }

        private void LoadGameList()
        {
            ComboBoxSelectGame.DataSource = null;
            ComboBoxSelectGame.Items.Clear();

            List<string> GameList = new List<string>();
            foreach (Game xGame in CurrentConfig.Games)
            {
                GameList.Add(xGame.Name);
            }
            GameList.Add("Add new...");

            ComboBoxSelectGame.DataSource = GameList;
        }

        private void DeleteGame(string GameName)
        {
            FormToastResponse VerifyDecision = new FormToastResponse("Are you sure you want to delete this game and all its saves?");
            DialogResult DR = VerifyDecision.ShowDialog();
            if(DR == DialogResult.OK)
            {
                if(ComboBoxSelectGame.Items.Count == 2)
                {
                    ActionCenter.Toast("Denied. You must have at least one game.", StartPoint(), 2);
                }
                else
                {
                    Directory.Delete(Configuration.AppDataRoamingPath + "//" + GameName, true);
                    CurrentConfig.RemoveGame(GameName);
                    CurrentConfig.Save();
                    LoadGameList();
                }
            }
        }

        private void ComboBoxSelectSubDirectory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxSelectSubDirectory.Text == "Add new ...")
            {
                AddNewProfile();
            }
            else
            {
                GetFileNames();
            }
        }

        private void BtnImportSave_Click(object sender, EventArgs e)
        {
            ImportCurrentSave();
        }

        private void TxtFileSearch_TextChanged(object sender, EventArgs e)
        {
            if (TxtFileSearch.Text != "Search...")
            {
                GetFileNames(true);
            }
        }

        private void DGVSaveFiles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVSaveFiles.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGVSaveFiles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGVSaveFiles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGVSaveFiles.Columns[0].FillWeight = 40;
            DGVSaveFiles.Columns[1].FillWeight = 40;
            DGVSaveFiles.Columns[2].FillWeight = 20;
            DGVSaveFiles.Columns[0].HeaderText = "Name";
            DGVSaveFiles.Columns[1].HeaderText = "Date Created";
            DGVSaveFiles.Columns[2].HeaderText = "Read Only";
            DGVSaveFiles.Columns[1].ReadOnly = true;
            DGVSaveFiles.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void DGVSaveFiles_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            PreviousFileName = DGVSaveFiles.CurrentRow.Cells[0].Value.ToString();
            PreviousReadOnly = Convert.ToBoolean(DGVSaveFiles.CurrentRow.Cells[2].Value);
        }

        private void DGVSaveFiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string FileName = DGVSaveFiles.CurrentRow.Cells[0].Value.ToString();
                bool ReadOnly = Convert.ToBoolean(DGVSaveFiles.CurrentRow.Cells[2].Value);
                if (FileName != PreviousFileName || ReadOnly != PreviousReadOnly)
                {
                    FileEdit(CurrentSubDirectory() + "\\" + PreviousFileName, CurrentSubDirectory() + "\\" + FileName, ReadOnly);
                }
            }
            catch (NullReferenceException)
            {
                DGVSaveFiles.CurrentRow.Cells[0].Value = PreviousFileName;
            }

        }

        private void renameCurrentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameProfile();
        }

        private void addNewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewProfile();
        }

        private void deleteCurrentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCurrentProfile();
        }

        private void importExistingProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportProfile();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hooker.CloseHooker();
            SaveLastOpened();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        private void BtnDeleteSave_Click(object sender, EventArgs e)
        {
            undoFileDeleteToolStripMenuItem.Enabled = true;
            DeleteSelectedSave();
        }

        private void BtnExportSave_Click(object sender, EventArgs e)
        {
            undoExportToolStripMenuItem.Enabled = true;
            ExportSave();
        }

        private void changeSavefileSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGameSaveLocation(ComboBoxSelectGame.Text);
        }

        private void DGVSaveFiles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGVSaveFiles.IsCurrentCellDirty)
            {
                DGVSaveFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DGVSaveFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVSaveFiles.CurrentCell != null)
            {
                if (DGVSaveFiles.CurrentCell == DGVSaveFiles.CurrentRow.Cells[2])
                {
                    SetReadOnly(CurrentPath(), Convert.ToBoolean(DGVSaveFiles.CurrentCell.Value));
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
            if (CurrentConfig.LastOpen.Game == "")
            {
                ComboBoxSelectGame.SelectedIndex = 0;
                ComboBoxSelectSubDirectory.SelectedValue = "Default";
            }
            else
            {
                ComboBoxSelectGame.Text = CurrentConfig.LastOpen.Game;
                ComboBoxSelectSubDirectory.Text = CurrentConfig.LastOpen.Profile;
            }
        }

        private void TSBtnHelp_Click(object sender, EventArgs e)
        {
            FormHelp Help = new FormHelp();
            Help.StartPosition = FormStartPosition.CenterParent;
            Help.ShowDialog();
        }

        private void DGVSaveFiles_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if(e.Column.Index == 1)
            {
                DateTime Cell1Date = Convert.ToDateTime(e.CellValue1.ToString());
                DateTime Cell2Date = Convert.ToDateTime(e.CellValue2.ToString());
                e.SortResult = DateTime.Compare(Cell2Date, Cell1Date);
                if (e.SortResult == 0)
                {
                    string NumbersCell1 = GetLeadingDigits(DGVSaveFiles.Rows[e.RowIndex1].Cells[0].Value.ToString());


                    string NumbersCell2 = GetLeadingDigits(DGVSaveFiles.Rows[e.RowIndex2].Cells[0].Value.ToString());

                    if (NumbersCell1 == "" || NumbersCell2 == "")
                    {
                        e.SortResult = System.String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
                    }
                    else
                    {
                        e.SortResult = int.Parse(NumbersCell1).CompareTo(int.Parse(NumbersCell2));
                    }

                    e.Handled = true;
                }
            }
            else if(e.Column.Index == 2)
            {
                e.SortResult = System.String.Compare(e.CellValue2.ToString(), e.CellValue1.ToString());
                if (e.SortResult == 0)
                {
                    string NumbersCell1 = GetLeadingDigits(DGVSaveFiles.Rows[e.RowIndex1].Cells[0].Value.ToString());


                    string NumbersCell2 = GetLeadingDigits(DGVSaveFiles.Rows[e.RowIndex2].Cells[0].Value.ToString());

                    if (NumbersCell1 == "" || NumbersCell2 == "")
                    {
                        e.SortResult = System.String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
                    }
                    else
                    {
                        e.SortResult = int.Parse(NumbersCell1).CompareTo(int.Parse(NumbersCell2));
                    }

                    e.Handled = true;
                }
            }
            else
            {
                string NumbersCell1 = GetLeadingDigits(e.CellValue1.ToString());

                string NumbersCell2 = GetLeadingDigits(e.CellValue2.ToString());

                if (NumbersCell1 == "" || NumbersCell2 == "")
                {
                    e.SortResult = System.String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString());
                }
                else
                {
                    e.SortResult = int.Parse(NumbersCell1).CompareTo(int.Parse(NumbersCell2));
                }

                e.Handled = true;
            }
        }

        private string GetLeadingDigits(string CellStringValue)
        {
            string CellNumberValue = "";
            int CurrentIndex = 0;
            int NameLength2 = CellStringValue.Length;
            while (CurrentIndex < NameLength2 && char.IsDigit(CellStringValue[CurrentIndex]))
            {
                CellNumberValue = CellNumberValue + CellStringValue[CurrentIndex];
                CurrentIndex++;
            }
            return CellNumberValue;
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameProfile();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCurrentProfile();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewProfile();
        }

        private void importExistingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportProfile();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteSelectedSave();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportSave();
        }

        private void openInFileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(CurrentSubDirectory());
        }

        private void TxtFileSearch_Enter(object sender, EventArgs e)
        {
            if (TxtFileSearch.Text == "Search...")
            {
                TxtFileSearch.Text = "";
            }
        }

        private void TxtFileSearch_Leave(object sender, EventArgs e)
        {
            if (TxtFileSearch.Text == "")
            {
                TxtFileSearch.Text = "Search...";
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                ActionCenter.Toast("Not running as admin, global hotkeys will not work while in game", StartPoint(), 2);
            }
        }

        private void setSavefileSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGameSaveLocation(ComboBoxSelectGame.Text);
        }

        private void deleteGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteGame(ComboBoxSelectGame.Text);
        }

        private void deleteGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteGame(ComboBoxSelectGame.Text);
        }

        private void undoFileDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndoDelete();
            undoFileDeleteToolStripMenuItem.Enabled = false;
        }

        private void undoExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndoExport();
            undoExportToolStripMenuItem.Enabled = false;
        }
    }
}