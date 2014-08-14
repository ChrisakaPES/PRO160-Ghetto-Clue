using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Model
{
   public class Rooms
    {
        public room location { get; set; }
        public bool show { get; set; }

        public enum room
        {
            TheCorner, GrowHouse, BackAlley, BMommasPad, Laundrymat,
            Prison, LightRoom, KFC, LiquorStore, TheSpot
        }
    }
}
