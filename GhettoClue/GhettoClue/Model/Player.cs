using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhettoClue.Model;
using System.Collections.ObjectModel;

namespace GhettoClue.Model
{
    public enum Characters
    {
        Lafawnduh, DaMarcus, Watermelondria, Jake, Ladasha, JuanCarlos
    }
    public class Player
    {
        public Characters Name { get; set; }
        public string background { get; set; }
        public ObservableCollection<Cards> Cards { get; set; }
        
    }

}
