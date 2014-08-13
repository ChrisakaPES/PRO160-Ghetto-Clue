using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Model
{
    public class Cards
    {
        public CharacterCards chara { get; set; }
        public Rooms location { get; set; }
        public Weapons leathals { get; set; }
        public bool show {get; set;}
    }
    #region Enums
    public enum CharacterCards
    {
        Lafawnduh, DaMarcus, Watermelondria, Jake, Ladasha, JuanCarlos
    }
    public enum Rooms
    {
        TheCorner, GrowHouse, BackAlley, BMommasPad, Laundrymat,
        Prison, LightRoom, KFC, LiquorStore, TheSpot
    }
    public enum Weapons
    {
        Shank, DaHeata, Smack, Weave, PoisonedLean
    }

    #endregion
}
