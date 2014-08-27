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
	public class Player
	{
		public Player()
		{
			MyDetectiveList = new DetectiveList();
		}

		public CharacterEnum Name { get; set; }
		public string background { get; set; }
        public ImageBrush imgBrush { get; set; }
		public DetectiveList MyDetectiveList { get; set; }

		public ObservableCollection<CharacterEnum> characterCards { get; set; }
		public ObservableCollection<WeaponEnum> weaponCards { get; set; }
		public ObservableCollection<RoomEnum> roomCards { get; set; }



		
	}

}
