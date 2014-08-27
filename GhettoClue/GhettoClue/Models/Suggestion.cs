using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
    public class Suggestion
    {
        public Characters Character { get; set; }
        public Rooms Room { get; set; }
        public Weapons Weapon { get; set; }
        public Suggestion(Characters c, Rooms r, Weapons w)
        {
            Character = c;
            Room = r;
            Weapon = w;
        }

        public bool CheckForDisproveEligibility(Player p)
        {
            foreach(Characters c in p.characterCards)
            {
                if (c == Character)
                {
                    return true;
                }
            }
            foreach (Rooms r in p.roomCards)
            {
                if (r == Room)
                {
                    return true;
                }
            }
            foreach (Weapons w in p.weaponCards)
            {
                if (w == Weapon)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

