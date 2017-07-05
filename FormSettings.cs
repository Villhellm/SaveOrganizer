using System;
using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
using System.ComponentModel;

namespace SaveOrganizer
{
    public partial class FormSettings : Form
    {
        KeyHooker Hooker;
        Label FocusedLabel;

        public FormSettings()
        {
            InitializeComponent();
            ReadGlobalConifurations();
            Hooker = new KeyHooker();
            Hooker.Initialize();
            Hooker.PropertyChanged += new PropertyChangedEventHandler(KeyPressed);
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
            XmlDocument Xml = new XmlDocument();
            Xml.Load(FormMain.ConfigurationFile);

            XmlNode AlwaysTopNode = Xml.SelectSingleNode("//AlwaysOnTop//Enabled");
            CBAlwaysOnTop.Checked= Convert.ToBoolean(AlwaysTopNode.InnerText);
            if (CBAlwaysOnTop.Checked)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
       

            XmlNode GlobalHotkeysNode = Xml.SelectSingleNode("//EnableHotkeys//Enabled");
            CBToggleGlobalHotkeys.Checked = Convert.ToBoolean(GlobalHotkeysNode.InnerText);

            XmlNodeList HotKeyNodes = Xml.SelectNodes("//Hotkeys//Hotkey");

            foreach (XmlNode Node in HotKeyNodes)
            {
                if (Node["Name"].InnerText == "ImportSave")
                {
                    CBImportCurrentSave.Checked = Convert.ToBoolean(Node["Enabled"].InnerText);
                    if(Node["Modifier"].InnerText != "None")
                    {
                        TxtImportSaveHotkey.Text = Node["Modifier"].InnerText + " + " + Node["KeyCode"].InnerText;
                    }
                    else
                    {
                        TxtImportSaveHotkey.Text = Node["KeyCode"].InnerText;
                    }
                }
                if (Node["Name"].InnerText == "ExportSave")
                {
                    CBExportSelectedSave.Checked = Convert.ToBoolean(Node["Enabled"].InnerText);
                    if (Node["Modifier"].InnerText != "None")
                    {
                        TxtExportSaveHotkey.Text = Node["Modifier"].InnerText + " + " + Node["KeyCode"].InnerText;
                    }
                    else
                    {
                        TxtExportSaveHotkey.Text = Node["KeyCode"].InnerText;
                    }
                }
                if (Node["Name"].InnerText == "ToggleReadOnly")
                {
                    CBToggleReadOnly.Checked = Convert.ToBoolean(Node["Enabled"].InnerText);
                    if (Node["Modifier"].InnerText != "None")
                    {
                        TxtToggleReadOnlyHotkey.Text = Node["Modifier"].InnerText + " + " + Node["KeyCode"].InnerText;
                    }
                    else
                    {
                        TxtToggleReadOnlyHotkey.Text = Node["KeyCode"].InnerText;
                    }
                }
            }
        }

        private void CBToggleGlobalHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            List<CheckBox> HotKeyEnablers = new List<CheckBox>() { CBExportSelectedSave, CBImportCurrentSave, CBToggleReadOnly };
            List<Label> HotKeyEnablersBox = new List<Label>() { TxtExportSaveHotkey, TxtImportSaveHotkey, TxtToggleReadOnlyHotkey };

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

            XmlDocument Xml = new XmlDocument();
            Xml.Load(FormMain.ConfigurationFile);

            XmlNode AlwaysTopNode = Xml.SelectSingleNode("//AlwaysOnTop//Enabled");
            AlwaysTopNode.InnerText = CBAlwaysOnTop.Checked.ToString();

            XmlNode GlobalHotkeysNode = Xml.SelectSingleNode("//EnableHotkeys//Enabled");
            GlobalHotkeysNode.InnerText = CBToggleGlobalHotkeys.Checked.ToString();

            XmlNodeList HotKeyNodes = Xml.SelectNodes("//Hotkeys//Hotkey");

            foreach (XmlNode Node in HotKeyNodes)
            {
                if (Node["Name"].InnerText == "ImportSave")
                {
                    SaveHotkey(Node, CBImportCurrentSave, TxtImportSaveHotkey);
                }
                if (Node["Name"].InnerText == "ExportSave")
                {
                    SaveHotkey(Node, CBExportSelectedSave, TxtExportSaveHotkey);
                }
                if (Node["Name"].InnerText == "ToggleReadOnly")
                {
                    SaveHotkey(Node, CBToggleReadOnly, TxtToggleReadOnlyHotkey);
                }
            }

            Xml.Save(FormMain.ConfigurationFile);
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveHotkey(XmlNode Node, CheckBox Enabler, Label Keys)
        {
            Node["Enabled"].InnerText = Enabler.Checked.ToString();
            if (Keys.Text.Contains(" + "))
            {
                Node["Modifier"].InnerText = Keys.Text.Substring(0, Keys.Text.IndexOf(" + "));
                Node["KeyCode"].InnerText = Keys.Text.Substring(Keys.Text.IndexOf(" + ")).Replace(" + ", "");
            }
            else
            {
                Node["Modifier"].InnerText = "None";
                Node["KeyCode"].InnerText = Keys.Text;
            }
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

    }
}
