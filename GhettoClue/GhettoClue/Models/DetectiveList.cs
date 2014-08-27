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
			RoomsList = new ObservableCollection<Rooms> { new Rooms { Room = Rooms.BackAlley },
														new Rooms { Room = Rooms.BMommasPad },
														new Rooms { Room = Rooms.GrowHouse },
														new Rooms { Room = Rooms.KFC },
														new Rooms { Room = Rooms.Laundrymat },
														new Rooms { Room = Rooms.LightRoom },
														new Rooms { Room = Rooms.LiquorStore },
														new Rooms { Room = Rooms.Prison },
														new Rooms { Room = Rooms.TheCorner },
														new Rooms { Room = Rooms.TheSpot }};
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
