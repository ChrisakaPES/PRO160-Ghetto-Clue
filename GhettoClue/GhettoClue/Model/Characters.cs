using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Model
{
   public class Characters
    {
        public string character { get; set; }
        public bool show { get; set; }

        public enum CharacterCards
        {
            Lafawnduh = 1, 
            DaMarcus, 
            Watermelondria, 
            Jake, 
            Ladasha, 
            JuanCarlos
        }
    }
}
