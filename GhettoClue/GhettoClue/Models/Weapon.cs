using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Models
{
	public enum WeaponEnum
	{
		Shank, DaHeata, Smack, Weave, PoisonedLean
	}
    public class Weapon
    {
        public WeaponEnum WeaponValue { get; set; }
        public string WeaponString { get; set; }
        public bool Show { get; set; }


    }
}
