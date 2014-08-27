using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
	public enum RoomEnum
	{
		TheCorner, GrowHouse, BackAlley, BMommasPad, Laundrymat,
		Prison, LightRoom, KFC, LiquorStore, TheSpot
	}

   public class Room
   {
       public RoomEnum RoomValue { get; set; }
       public string RoomString { get; set; }
       public bool Show { get; set; }


   }
}
