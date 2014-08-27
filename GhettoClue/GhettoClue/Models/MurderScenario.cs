using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
    public class MurderScenario
    {
        public Characters Perpetrator { get; private set; }
        public Weapons MurderWeapon { get; private set; }
        public Rooms MurderScene{get; private set;}

        public MurderScenario(Characters c, Rooms r,Weapons w)
        {
            Perpetrator = c;
            MurderWeapon = w;
            MurderScene = r;
        }

    }
}
