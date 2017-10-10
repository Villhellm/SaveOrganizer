using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveOrganizer
{
    class LastOpened
    {
        public string Game { get; set; }
        public string Profile { get; set; }

        public LastOpened(string Game, string Profile)
        {
            this.Game = Game;
            this.Profile = Profile;
        }
    }
}
