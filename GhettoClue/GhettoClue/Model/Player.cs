using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhettoClue.Model;
using System.Collections.ObjectModel;

namespace GhettoClue.Model
{
    public enum characters
    {
        Lafawnduh, DaMarcus, Watermelondria, Jake, Ladasha, JuanCarlos
    }
    public class Player
    {
        public characters Name { get; set; }
        public string background { get; set; }

        public ObservableCollection<Characters> characterCards { get; set; }
        public ObservableCollection<Weapons> weaponCards { get; set; }
        public ObservableCollection<Rooms> roomCards { get; set; }



        
    }

}
