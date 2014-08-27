using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
    public class Accusation
    {
        public CharacterEnum Character { get; set; }
        public RoomEnum Room { get; set; }
        public WeaponEnum Weapon { get; set; }
        public Accusation(CharacterEnum c, RoomEnum r, WeaponEnum w)
        {
            Character = c;
            Room = r;
            Weapon = w;
        }

        public bool CheckForPlayerWin(MurderScenario answer)
        {
            return answer.Perpetrator==Character&& answer.MurderScene==Room&&answer.MurderWeapon==Weapon;  
            
        }
    }
}

