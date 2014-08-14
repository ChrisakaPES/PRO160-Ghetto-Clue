using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Model
{
   public class Weapons
    {
        public weapon leathals { get; set; }
        public bool show { get; set; }

        public enum weapon
        {
            Shank, DaHeata, Smack, Weave, PoisonedLean
        }
    }
}
