using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhettoClue.Models;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace GhettoClue.Models
{
    //public enum characters
    //{
    //    Lafawnduh, DaMarcus, Watermelondria, Jake, Ladasha, JuanCarlos
    //}
	public class Player
	{
		public Player()
		{
			MyDetectiveList = new DetectiveList();
		}

		public Characters Name { get; set; }
		public string background { get; set; }
        public ImageBrush imgBrush { get; set; }
		public DetectiveList MyDetectiveList { get; set; }

		public ObservableCollection<Characters> characterCards { get; set; }
		public ObservableCollection<Weapons> weaponCards { get; set; }
		public ObservableCollection<Rooms> roomCards { get; set; }



		
	}

}
