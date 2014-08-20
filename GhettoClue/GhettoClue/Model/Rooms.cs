using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Model
{
	public enum room
	{
		TheCorner, GrowHouse, BackAlley, BMommasPad, Laundrymat,
		Prison, LightRoom, KFC, LiquorStore, TheSpot
	}

	public class Rooms
	{
		public room Room { get; set; }
		public string location { get; set; }
		public bool show { get; set; }


	}
}
