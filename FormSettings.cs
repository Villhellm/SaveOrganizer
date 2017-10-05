using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;

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
                CheckBox CB = new CheckBox();
                CB.Text = AddSpaces(xHotkey.Name);
                CB.Checked = xHotkey.Enabled;
                CB.Enabled = CurrentConfig.EnableHotkeys;
                Label Lbl = new Label();
                Lbl.BorderStyle = BorderStyle.FixedSingle;
                Lbl.Click += SaveHotkey_Click;
                Lbl.Enabled = CurrentConfig.EnableHotkeys;
                if (xHotkey.Modifier == "None")
                {
                    Lbl.Text = xHotkey.KeyCode;
                }
                else
                {
                    Lbl.Text = xHotkey.Modifier + " + " + xHotkey.KeyCode;
                }

                FLPHotkeys.Controls.Add(CB);
                FLPHotkeys.Controls.Add(Lbl);
                FLPHotkeys.SetFlowBreak(Lbl, true);
            }
        }

        private void CBToggleGlobalHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control Enabler in FLPHotkeys.Controls)
            {
                Enabler.Enabled = !Enabler.Enabled;
            }
        }

        private string AddSpaces(string Change)
        {
            return Regex.Replace(Change, "(\\B[A-Z])", " $1");
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

            foreach(Control C in FLPHotkeys.Controls)
            {
                if(C is CheckBox)
                {
                    AddHotkey(C.Text.Replace(" ", ""), (CheckBox)C, (Label)FLPHotkeys.Controls[FLPHotkeys.Controls.IndexOf(C) + 1]);
                }
            }

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
