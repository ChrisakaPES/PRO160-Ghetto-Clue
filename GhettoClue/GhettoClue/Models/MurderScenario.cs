using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
    public class MurderScenario
    {
        public CharacterEnum Perpetrator { get; private set; }
        public WeaponEnum MurderWeapon { get; private set; }
        public RoomEnum MurderScene{get; private set;}

        public MurderScenario(CharacterEnum c, RoomEnum r,WeaponEnum w)
        {
            Perpetrator = c;
            MurderWeapon = w;
            MurderScene = r;
        }

    }
}
