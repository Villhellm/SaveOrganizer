using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveOrganizer
{
    class Game
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Game(string Name, string Path)
        {
            this.Name = Name;
            this.Path = Path;
        }
    }
}
