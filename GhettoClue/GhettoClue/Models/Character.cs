using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
	public enum CharacterEnum
	{
		Lafawnduh, DaMarcus,Watermelondrea, Jake, Ladasha, JuanCarlos
	}
    public class Character
    {
        public CharacterEnum CharacterValue { get; set; }
        public string CharacterString { get; set; }
        public bool Show { get; set; }
    }
}
