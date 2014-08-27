using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
	public class DetectiveList
	{
		
		public DetectiveList()
		{
            RoomsList = new ObservableCollection<Rooms> 
            { 
                Rooms.BackAlley,
				Rooms.BMommasPad,
				Rooms.GrowHouse,
				Rooms.KFC,
				Rooms.Laundrymat,
				Rooms.LightRoom,
				Rooms.LiquorStore,
				Rooms.Prison,
				Rooms.TheCorner,
				Rooms.TheSpot
            };
			WeaponsList = new ObservableCollection<Weapons> 
            { 
                Weapons.Shank,
				Weapons.DaHeata,
				Weapons.PoisonedLean,
				Weapons.Smack,
				Weapons.Weave
            };
			CharactersList = new ObservableCollection<Characters>{
                Characters.Ladasha,
				Characters.DaMarcus,
				Characters.Jake,
				Characters.JuanCarlos,
				Characters.Lafawnduh,
				Characters.Watermelondria
            };
		}

		public ObservableCollection<Rooms> RoomsList { get; set; }
		public ObservableCollection<Weapons> WeaponsList { get; set; }
		public ObservableCollection<Characters> CharactersList { get; set; }

	}
}
