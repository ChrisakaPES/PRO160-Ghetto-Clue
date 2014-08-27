using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Model
{
	public enum CharacterCards
	{
		Lafawnduh = 1,
		DaMarcus,
		Watermelondria,
		Jake,
		Ladasha,
		JuanCarlos
	}
	public class Characters
	{
		public CharacterCards Character { get; set; }

		public string character { get; set; }
		public bool show { get; set; }


	}
}
