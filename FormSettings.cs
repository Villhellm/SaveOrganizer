using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace SaveOrganizer
{
    public partial class FormSettings : Form
    {
        KeyHooker Hooker;
        Label FocusedLabel;
        GithubUpdater Updater;
        Configuration CurrentConfig;

        public FormSettings()
        {
            InitializeComponent();
            CurrentConfig = Configuration.Load();
            ReadGlobalConifurations();
            Hooker = new KeyHooker();
            Hooker.Initialize();
            Hooker.PropertyChanged += new PropertyChangedEventHandler(KeyPressed);
            LblVersion.Text = "Version " + CurrentConfig.LastCommitID;
            Updater = new GithubUpdater();
        }

        private void KeyPressed(object sender, PropertyChangedEventArgs e)
        {
            if(FocusedLabel != null)
            {
                if (Hooker.CurrentKey == 0)
                {
                    FocusedLabel.Text = ((Keys)Hooker.Modifier).ToString();
                }
                else if (Hooker.Modifier == 0)
                {
                    FocusedLabel.Text = ((Keys)Hooker.CurrentKey).ToString();
                }
                else
                {
                    FocusedLabel.Text = ((Keys)Hooker.Modifier).ToString() + " + " + ((Keys)Hooker.CurrentKey).ToString();
                }
            }
        }

        private void ReadGlobalConifurations()
        {

            TopMost = CurrentConfig.AlwaysOnTop;

            CBAlwaysOnTop.Checked = CurrentConfig.AlwaysOnTop;
            CBToggleGlobalHotkeys.Checked = CurrentConfig.EnableHotkeys;

            foreach (Hotkey xHotkey in CurrentConfig.Hotkeys)
            {
                if (xHotkey.Name == "ImportSave")
                {
                    CBImportCurrentSave.Checked = xHotkey.Enabled;
                    if(xHotkey.Modifier != "None")
                    {
                        TxtImportSaveHotkey.Text = xHotkey.Modifier + " + " + xHotkey.KeyCode;
                    }
                    else
                    {
                        TxtImportSaveHotkey.Text = xHotkey.KeyCode;
                    }
                }
                if (xHotkey.Name == "ExportSave")
                {
                    CBExportSelectedSave.Checked = xHotkey.Enabled;
                    if (xHotkey.Modifier != "None")
                    {
                        TxtExportSaveHotkey.Text = xHotkey.Modifier + " + " + xHotkey.KeyCode;
                    }
                    else
                    {
                        TxtExportSaveHotkey.Text = xHotkey.KeyCode;
                    }
                }
                if (xHotkey.Name == "ToggleReadOnly")
                {
                    CBToggleReadOnly.Checked = xHotkey.Enabled;
                    if (xHotkey.Modifier != "None")
                    {
                        TxtToggleReadOnlyHotkey.Text = xHotkey.Modifier + " + " + xHotkey.KeyCode;
                    }
                    else
                    {
                        TxtToggleReadOnlyHotkey.Text = xHotkey.KeyCode;
                    }
                }
                if (xHotkey.Name == "Quicksave")
                {
                    CBQuicksave.Checked = xHotkey.Enabled;
                    if (xHotkey.Modifier != "None")
                    {
                        TxtQuickSaveHotkey.Text = xHotkey.Modifier + " + " + xHotkey.KeyCode;
                    }
                    else
                    {
                        TxtQuickSaveHotkey.Text = xHotkey.KeyCode;
                    }
                }
                if (xHotkey.Name == "Quickload")
                {
                    CBQuickload.Checked = xHotkey.Enabled;
                    if (xHotkey.Modifier != "None")
                    {
                        TxtQuickLoadHotkey.Text = xHotkey.Modifier + " + " + xHotkey.KeyCode;
                    }
                    else
                    {
                        TxtQuickLoadHotkey.Text = xHotkey.KeyCode;
                    }
                }
                if (xHotkey.Name == "Warp")
                {
                    CBWarp.Checked = xHotkey.Enabled;
                    if (xHotkey.Modifier != "None")
                    {
                        TxtWarp.Text = xHotkey.Modifier + " + " + xHotkey.KeyCode;
                    }
                    else
                    {
                        TxtWarp.Text = xHotkey.KeyCode;
                    }
                }
            }
        }

        private void CBToggleGlobalHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            List<CheckBox> HotKeyEnablers = new List<CheckBox>() { CBExportSelectedSave, CBImportCurrentSave, CBToggleReadOnly, CBQuicksave, CBQuickload, CBWarp };
            List<Label> HotKeyEnablersBox = new List<Label>() { TxtExportSaveHotkey, TxtImportSaveHotkey, TxtToggleReadOnlyHotkey, TxtQuickSaveHotkey, TxtQuickLoadHotkey, TxtWarp };

            foreach (CheckBox Enabler in HotKeyEnablers)
            {
                Enabler.Enabled = !Enabler.Enabled;
            }

            foreach(Label Txt in HotKeyEnablersBox)
            {
                Txt.Enabled = !Txt.Enabled;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (FocusedLabel != null)
            {
                if (FocusedLabel.Text == "Recording...")
                {
                    FocusedLabel.Text = "None";
                }
            }

            CurrentConfig.AlwaysOnTop = CBAlwaysOnTop.Checked;

            CurrentConfig.EnableHotkeys = CBToggleGlobalHotkeys.Checked;

            CurrentConfig.Hotkeys.Clear();

            AddHotkey("ImportSave", CBImportCurrentSave, TxtImportSaveHotkey);

            AddHotkey("ExportSave", CBExportSelectedSave, TxtExportSaveHotkey);

            AddHotkey("ToggleReadOnly", CBToggleReadOnly, TxtToggleReadOnlyHotkey);

            AddHotkey("Quicksave", CBQuicksave, TxtQuickSaveHotkey);

            AddHotkey("Quickload", CBQuickload, TxtQuickLoadHotkey);

            AddHotkey("Warp", CBWarp, TxtWarp);

            CurrentConfig.Save();
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddHotkey(string Name, CheckBox Enabler, Label Keys)
        {
            Hotkey AddHotkey;
            if (Keys.Text.Contains(" + "))
            {
                AddHotkey = new Hotkey(Name, Keys.Text.Substring(0, Keys.Text.IndexOf(" + ")), Keys.Text.Substring(Keys.Text.IndexOf(" + ")).Replace(" + ", ""), Enabler.Checked);
            }
            else
            {
                AddHotkey = new Hotkey(Name, Keys.Text, Enabler.Checked);
            }
            CurrentConfig.Hotkeys.Add(AddHotkey);
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hooker.CloseHooker();
        }

        private void SaveHotkey_Click(object sender, EventArgs e)
        {
            if(FocusedLabel != null)
            {
                if(FocusedLabel.Text == "Recording...")
                {
                    FocusedLabel.Text = "None";
                }
            }
            FocusedLabel = ((Label)sender);
            ((Label)sender).Text = "Recording...";
        }

        private void SaveHotkey_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("No more");
        }

        private void SaveHotkey_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("yes focus");
        }

        private void BtnManualUpdateCheck_Click(object sender, EventArgs e)
        {
            Updater.CurrentVersion = CurrentConfig.LastCommitID;
            Updater.LaunchUpdater();
            if(CurrentConfig.LastCommitID == Updater.GetLatestVersion())
            {
                ActionCenter.Toast("No update available", StartPoint());
            }
        }

        Point StartPoint()
        {
            Point Inter = new Point(this.Location.X + Width / 2 - 186, Location.Y + Height - 170);
            return Inter;
        }
    }
}
