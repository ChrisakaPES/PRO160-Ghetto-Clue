using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhettoClue.Models;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.ComponentModel;

namespace GhettoClue.Models
{
	public class Player :INotifyPropertyChanged
	{

        private bool _isTurn;
        private bool _isInRoom;

		public Player()
		{
			MyDetectiveList = new DetectiveList();
		}

		public CharacterEnum Name { get; set; }
		public string background { get; set; }
        public ImageBrush imgBrush { get; set; }
		public DetectiveList MyDetectiveList { get; set; }

        public bool hasRolled = false;

        public bool IsInRoom
        {
            get
            {
                return _isInRoom;
            }
            set
            {
                _isInRoom = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsInRoom"));
                }
            }
        }

        public bool IsTurn 
        {
            get 
            {
                return _isTurn;
            }
            set 
            {
                _isTurn = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsTurn"));
                }
            }
        }

		public ObservableCollection<CharacterEnum> characterCards { get; set; }
		public ObservableCollection<WeaponEnum> weaponCards { get; set; }
		public ObservableCollection<RoomEnum> roomCards { get; set; }




        public override string ToString()
        {
            return Name.ToString();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
