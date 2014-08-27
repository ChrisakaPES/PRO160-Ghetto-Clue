using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Model
{
	public class DetectiveList
	{
		
		public DetectiveList()
		{
			RoomsList = new ObservableCollection<Rooms> { new Rooms { Room = room.BackAlley },
														new Rooms { Room = room.BMommasPad },
														new Rooms { Room = room.GrowHouse },
														new Rooms { Room = room.KFC },
														new Rooms { Room = room.Laundrymat },
														new Rooms { Room = room.LightRoom },
														new Rooms { Room = room.LiquorStore },
														new Rooms { Room = room.Prison },
														new Rooms { Room = room.TheCorner },
														new Rooms { Room = room.TheSpot }};
			WeaponsList = new ObservableCollection<Weapons> { new Weapons{Weapon = weapon.Shank},
														new Weapons{Weapon = weapon.DaHeata},
														new Weapons{Weapon = weapon.PoisonedLean},
														new Weapons{Weapon = weapon.Smack},
														new Weapons{Weapon = weapon.Weave}};
			CharactersList = new ObservableCollection<Characters>{new Characters{Character = CharacterCards.Ladasha},
														new Characters{Character = CharacterCards.DaMarcus},
														new Characters{Character = CharacterCards.Jake},
														new Characters{Character = CharacterCards.JuanCarlos},
														new Characters{Character = CharacterCards.Lafawnduh},
														new Characters{Character = CharacterCards.Watermelondria}};
		}

		public ObservableCollection<Rooms> RoomsList { get; set; }
		public ObservableCollection<Weapons> WeaponsList { get; set; }
		public ObservableCollection<Characters> CharactersList { get; set; }

	}
}
