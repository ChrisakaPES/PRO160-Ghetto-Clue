using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhettoClue.Movement
{
    class Cell : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        bool isRoom;
        bool isDoor;
        bool isOpen;
        bool isAvailable;

        public bool IsRoom
        {
            get
            {
                return IsRoom;
            }
            set
            {
                IsRoom = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsRoom"));
            }

        }

        public bool IsDoor
        {
            get
            {
                return IsDoor;
            }
            set
            {
                IsDoor= value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsDoor"));
            }

        }

        public bool IsOpen
        {
            get
            {
                return IsOpen;
            }
            set
            {
                IsOpen= value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsOpen"));
            }

        }

        public bool IsAvailable
        {
            get
            {
                return IsAvailable;
            }
            set
            {
                IsAvailable = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsAvailable"));
            }

        }
    }
}
