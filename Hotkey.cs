using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveOrganizer
{
    class Hotkey
    {
        public string Name { get; set; }
        public string Modifier { get; set; } = "None";
        public string KeyCode { get; set; } = "None";
        public bool Enabled { get; set; }

        public Hotkey(string Name, string Modifier, string KeyCode, bool Enabled)
        {
            this.Name = Name;
            this.Modifier = Modifier;
            this.KeyCode = KeyCode;
            this.Enabled = Enabled;
        }

        public Hotkey(string Name, string KeyCode, bool Enabled)
        {
            this.Name = Name;
            this.Modifier = Modifier;
            this.KeyCode = KeyCode;
            this.Enabled = Enabled;
        }
        public Hotkey()
        {

        }
    }
}
