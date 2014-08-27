using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
    public class Suggestion
    {
        public CharacterEnum Character { get; set; }
        public RoomEnum Room { get; set; }
        public WeaponEnum Weapon { get; set; }
        public Suggestion(CharacterEnum c, RoomEnum r, WeaponEnum w)
        {
            Character = c;
            Room = r;
            Weapon = w;
        }

        public bool CheckForDisproveEligibility(Player p)
        {
            foreach(CharacterEnum c in p.characterCards)
            {
                if (c == Character)
                {
                    return true;
                }
            }
            foreach (RoomEnum r in p.roomCards)
            {
                if (r == Room)
                {
                    return true;
                }
            }
            foreach (WeaponEnum w in p.weaponCards)
            {
                if (w == Weapon)
                {
                    return true;
                }
            }
            return false;
        }

        //Send the suggestion off to the Disprove box
        public Suggestion SendSuggestion()
        {
            if (CheckForDisproveEligibility())
            {

            }
            else
            {

            }
        }
    }
}

