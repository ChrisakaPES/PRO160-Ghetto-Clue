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
            RoomsList = new ObservableCollection<Room>() 
            {
              new Room { RoomValue = RoomEnum.BMommasPad , RoomString=RoomEnum.BMommasPad.ToString() },
              new Room { RoomValue = RoomEnum.GrowHouse, RoomString=RoomEnum.GrowHouse.ToString()},
              new Room { RoomValue = RoomEnum.KFC, RoomString=RoomEnum.KFC.ToString() },
              new Room { RoomValue = RoomEnum.Laundrymat,RoomString=RoomEnum.Laundrymat.ToString() },
              new Room { RoomValue = RoomEnum.LightRoom, RoomString=RoomEnum.LightRoom.ToString() },
              new Room { RoomValue = RoomEnum.LiquorStore, RoomString=RoomEnum.LiquorStore.ToString() },
              new Room { RoomValue = RoomEnum.Prison,RoomString=RoomEnum.Prison.ToString() },
              new Room { RoomValue = RoomEnum.TheCorner, RoomString=RoomEnum.TheCorner.ToString() },
              new Room { RoomValue = RoomEnum.TheSpot, RoomString=RoomEnum.TheSpot.ToString() },
              new Room { RoomValue = RoomEnum.BackAlley, RoomString = RoomEnum.BackAlley.ToString() }
            };
            

			WeaponsList = new ObservableCollection<Weapon> 
            { 
              new Weapon{WeaponString = WeaponEnum.Shank.ToString(), WeaponValue = WeaponEnum.Shank},
              new Weapon{WeaponString = WeaponEnum.DaHeata.ToString(), WeaponValue = WeaponEnum.DaHeata},
              new Weapon{WeaponString = WeaponEnum.PoisonedLean.ToString(), WeaponValue = WeaponEnum.PoisonedLean},
              new Weapon{WeaponString = WeaponEnum.Smack.ToString(), WeaponValue = WeaponEnum.Smack},
              new Weapon{WeaponString = WeaponEnum.Weave.ToString(), WeaponValue = WeaponEnum.Weave}
            
            };
			CharactersList = new ObservableCollection<Character>{
              new Character{CharacterValue = CharacterEnum.Ladasha, CharacterString = CharacterEnum.Ladasha.ToString()  },
              new Character{CharacterValue = CharacterEnum.DaMarcus, CharacterString = CharacterEnum.DaMarcus.ToString()  },
              new Character{CharacterValue = CharacterEnum.Jake, CharacterString = CharacterEnum.Jake.ToString()  },
              new Character{CharacterValue = CharacterEnum.JuanCarlos, CharacterString = CharacterEnum.JuanCarlos.ToString()  },
              new Character{CharacterValue = CharacterEnum.Lafawnduh, CharacterString = CharacterEnum.Lafawnduh.ToString()  },
              new Character{CharacterValue = CharacterEnum.Watermelondrea, CharacterString = CharacterEnum.Watermelondrea.ToString()  }
            };
		}

		public ObservableCollection<Room> RoomsList { get; set; }
		public ObservableCollection<Weapon> WeaponsList { get; set; }
		public ObservableCollection<Character> CharactersList { get; set; }

	}
}
