using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace SaveOrganizer
{
    class Configuration
    {
        public string LastCommitID { get; set; }
        public bool AlwaysOnTop { get; set; }
        public bool EnableHotkeys { get; set; }
        public List<Hotkey> Hotkeys { get; set; }
        public List<Game> Games { get; set; }
        public LastOpened LastOpen {get;set;}

        public static string AppDataRoamingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveOrganizer";
        public static string ConfigurationFile = AppDataRoamingPath + @"\Config.xml";

        public static Configuration Load()
        {
            XDocument Xml = XDocument.Load(ConfigurationFile);
            Configuration InitialConfig = new Configuration();
            XElement xAlwaysOnTop = Xml.Element("Configs").Element("AlwaysOnTop");
            if (Convert.ToBoolean(xAlwaysOnTop.Value))
            {
                InitialConfig.AlwaysOnTop = true;
            }
            else
            {
                InitialConfig.AlwaysOnTop = false;
            }
            XElement xLastCommitID = Xml.Element("Configs").Element("LastCommitID");
            InitialConfig.LastCommitID = xLastCommitID.Value;
            InitialConfig.LastOpen = new LastOpened(Xml.Element("Configs").Element("LastOpened").Element("Game").Value, Xml.Element("Configs").Element("LastOpened").Element("Profile").Value);
            XElement xEnableHotkeys = Xml.Element("Configs").Element("EnableHotkeys");
            InitialConfig.EnableHotkeys = Convert.ToBoolean(xEnableHotkeys.Value);

            IEnumerable<XElement> xGames = Xml.Element("Configs").Element("Games").Elements("Game");

            InitialConfig.Games = new List<Game>();
            foreach (XElement xGame in xGames)
            {
                Game AddGame = new Game(xGame.Element("Name").Value, xGame.Element("Path").Value);
                InitialConfig.Games.Add(AddGame);
            }

            IEnumerable<XElement> xHotkeys = Xml.Element("Configs").Element("Hotkeys").Elements("Hotkey");
            InitialConfig.Hotkeys = new List<Hotkey>();
            foreach (XElement xHotkey in xHotkeys)
            {
                Hotkey AddHotkey = new Hotkey();
                AddHotkey.Name = xHotkey.Element("Name").Value;
                AddHotkey.Modifier = xHotkey.Element("Modifier").Value;
                AddHotkey.KeyCode = xHotkey.Element("KeyCode").Value;
                AddHotkey.Enabled =Convert.ToBoolean(xHotkey.Element("Enabled").Value);
                InitialConfig.Hotkeys.Add(AddHotkey);
            }
            return InitialConfig;
        }

        public void Save()
        {
            XDocument Xml = XDocument.Load(ConfigurationFile);
            Xml.Element("Configs").Element("EnableHotkeys").Value = EnableHotkeys.ToString();
            Xml.Element("Configs").Element("AlwaysOnTop").Value = AlwaysOnTop.ToString();
            Xml.Element("Configs").Element("LastOpened").Element("Game").Value = LastOpen.Game;
            Xml.Element("Configs").Element("LastOpened").Element("Profile").Value = LastOpen.Profile;
            Xml.Element("Configs").Element("LastCommitID").Value = LastCommitID;
            Xml.Element("Configs").Element("Games").RemoveAll();
            Xml.Element("Configs").Element("Hotkeys").RemoveAll();
            foreach (Game xGame in Games)
            {
                Xml.Element("Configs").Element("Games").Add(new XElement("Game", new XElement("Name", xGame.Name), new XElement("Path", xGame.Path)));
            }
            foreach(Hotkey xHotkey in Hotkeys)
            {
                Xml.Element("Configs").Element("Hotkeys").Add(new XElement("Hotkey", new XElement("Name", xHotkey.Name), new XElement("Modifier", xHotkey.Modifier), new XElement("KeyCode", xHotkey.KeyCode), new XElement("Enabled", xHotkey.Enabled.ToString())));
            }
            Xml.Save(ConfigurationFile);
        }

        public void AddHotkey(string HotkeyName, string Modifier, string KeyPress, bool Enabled)
        {
            Hotkey AddHotkey = new Hotkey();
            AddHotkey.Name = HotkeyName;
            AddHotkey.Modifier = Modifier;
            AddHotkey.KeyCode = KeyPress;
            AddHotkey.Enabled = Enabled;
            Hotkeys.Add(AddHotkey);
        }

        public static void CreateConfiguration()
        {
            if (!File.Exists(ConfigurationFile))
            {
                Directory.CreateDirectory(AppDataRoamingPath);
                Directory.CreateDirectory(AppDataRoamingPath + "\\Dark Souls\\Default");
                Directory.CreateDirectory(AppDataRoamingPath + "\\Dark Souls II\\Default");
                Directory.CreateDirectory(AppDataRoamingPath + "\\Dark Souls II SotFS\\Default");
                Directory.CreateDirectory(AppDataRoamingPath + "\\Dark Souls III\\Default");
                XmlTextWriter Writer = new XmlTextWriter(ConfigurationFile, Encoding.UTF8);
                Writer.Formatting = Formatting.Indented;
                Writer.WriteStartElement("Configs");
                Writer.WriteStartElement("Games");
                Writer.WriteStartElement("Game");
                Writer.WriteStartElement("Name");
                Writer.WriteString("Dark Souls");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Path");
                Writer.WriteEndElement();
                Writer.WriteEndElement();
                Writer.WriteStartElement("Game");
                Writer.WriteStartElement("Name");
                Writer.WriteString("Dark Souls II");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Path");
                Writer.WriteEndElement();
                Writer.WriteEndElement();
                Writer.WriteStartElement("Game");
                Writer.WriteStartElement("Name");
                Writer.WriteString("Dark Souls II SotFS");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Path");
                Writer.WriteEndElement();
                Writer.WriteEndElement();
                Writer.WriteStartElement("Game");
                Writer.WriteStartElement("Name");
                Writer.WriteString("Dark Souls III");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Path");
                Writer.WriteEndElement();
                Writer.WriteEndElement();
                Writer.WriteEndElement();

                Writer.WriteStartElement("EnableHotkeys");
                Writer.WriteString("False");
                Writer.WriteEndElement();

                Writer.WriteStartElement("AlwaysOnTop");
                Writer.WriteString("False");
                Writer.WriteEndElement();

                Writer.WriteStartElement("LastOpened");
                Writer.WriteStartElement("Game");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Profile");
                Writer.WriteEndElement();
                Writer.WriteEndElement();

                Writer.WriteStartElement("LastCommitID");
                Writer.WriteString("none");
                Writer.WriteEndElement();

                Writer.WriteStartElement("Hotkeys");

                Writer.WriteStartElement("Hotkey");
                Writer.WriteStartElement("Name");
                Writer.WriteString("ImportSave");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Modifier");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("KeyCode");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Enabled");
                Writer.WriteString("False");
                Writer.WriteEndElement();
                Writer.WriteEndElement();

                Writer.WriteStartElement("Hotkey");
                Writer.WriteStartElement("Name");
                Writer.WriteString("ExportSave");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Modifier");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("KeyCode");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Enabled");
                Writer.WriteString("False");
                Writer.WriteEndElement();
                Writer.WriteEndElement();

                Writer.WriteStartElement("Hotkey");
                Writer.WriteStartElement("Name");
                Writer.WriteString("ToggleReadOnly");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Modifier");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("KeyCode");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Enabled");
                Writer.WriteString("False");
                Writer.WriteEndElement();
                Writer.WriteEndElement();

                Writer.WriteStartElement("Hotkey");
                Writer.WriteStartElement("Name");
                Writer.WriteString("Quicksave");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Modifier");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("KeyCode");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Enabled");
                Writer.WriteString("False");
                Writer.WriteEndElement();
                Writer.WriteEndElement();

                Writer.WriteStartElement("Hotkey");
                Writer.WriteStartElement("Name");
                Writer.WriteString("Quickload");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Modifier");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("KeyCode");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Enabled");
                Writer.WriteString("False");
                Writer.WriteEndElement();
                Writer.WriteEndElement();

                Writer.WriteStartElement("Hotkey");
                Writer.WriteStartElement("Name");
                Writer.WriteString("Warp");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Modifier");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("KeyCode");
                Writer.WriteString("None");
                Writer.WriteEndElement();
                Writer.WriteStartElement("Enabled");
                Writer.WriteString("False");
                Writer.WriteEndElement();
                Writer.WriteEndElement();

                Writer.WriteEndElement();

                Writer.WriteEndElement();
                Writer.Close();
            }
        }

        public void VerifyXMLConfigFile()
        {
            XDocument Xml = XDocument.Load(ConfigurationFile);

            VerifyLastOpened(Xml);
            VerifyConfigSetting(Xml, "AlwaysOnTop");
            VerifyConfigSetting(Xml, "EnableHotkeys");
            VerifyCommitNode(Xml);
            VerifyHotkeyNode(Xml, "ImportSave");
            VerifyHotkeyNode(Xml, "ExportSave");
            VerifyHotkeyNode(Xml, "ToggleReadOnly");
            VerifyHotkeyNode(Xml, "Quicksave");
            VerifyHotkeyNode(Xml, "Quickload");
            VerifyHotkeyNode(Xml, "Warp");
            VerifyHotkeyNode(Xml, "ToggleNoClip");
            VerifyHotkeyNode(Xml, "ToggleDamage");
            VerifyHotkeyNode(Xml, "ToggleAI");
        }

        private void VerifyCommitNode(XDocument Xml)
        {
            XElement Config = Xml.Element("Configs").Element("LastCommitID");
            if (Config == null)
            {
                Xml.Descendants("Configs").FirstOrDefault().Add(new XElement("LastCommitID", "none"));
            }
            Xml.Save(ConfigurationFile);
        }

        private void VerifyGame(XDocument Xml, string GameName)
        {
            XElement Game = Xml.Element("Configs").Element("Games").Elements("Game").Where(x => x.Element("Name").Value == GameName).SingleOrDefault();

            if (Game == null)
            {
                Xml.Descendants("Games").FirstOrDefault().Add(new XElement("Game", new XElement("Name", GameName), new XElement("Path")));
            }
            Xml.Save(ConfigurationFile);
        }

        private void VerifyLastOpened(XDocument Xml)
        {
            XElement LO = Xml.Element("Configs").Element("LastOpened");

            if (LO == null)
            {
                Xml.Descendants("Configs").FirstOrDefault().Add(new XElement("LastOpened", new XElement("Game"), new XElement("Profile")));
            }
            Xml.Save(ConfigurationFile);
        }

        private void VerifyConfigSetting(XDocument Xml, string ConfigName)
        {
            XElement Config = Xml.Element("Configs").Element(ConfigName);
            if (Config == null)
            {
                Xml.Descendants("Configs").FirstOrDefault().Add(new XElement(ConfigName, new XElement("Enabled", "False")));
            }
            Xml.Save(ConfigurationFile);
        }

        private void VerifyHotkeyNode(XDocument Xml, string HotkeyName)
        {
            XElement xHotkey = Xml.Element("Configs").Element("Hotkeys").Elements("Hotkey").Where(x => x.Element("Name").Value == HotkeyName).SingleOrDefault();

            if (xHotkey == null)
            {
                Xml.Descendants("Hotkeys").FirstOrDefault().Add(new XElement("Hotkey", new XElement("Name", HotkeyName), new XElement("Modifier", "None"), new XElement("KeyCode", "None"), new XElement("Enabled", "False")));
            }
            Xml.Save(ConfigurationFile);
        }

        public void RemoveGame(string GameName)
        {
            Game RemoveThis = Games.Where(x => x.Name == GameName).FirstOrDefault();
            Games.Remove(RemoveThis);
        }

        public string GetPath(string GameName)
        {
            Game HasPath = Games.Where(x => x.Name == GameName).FirstOrDefault();
            return HasPath.Path;
        }

        public Game Game(string GameName)
        {
            Game ReturnGame = new Game();
            ReturnGame = Games.Where(x => x.Name == GameName).FirstOrDefault();
            return ReturnGame;
        }
    }
}
