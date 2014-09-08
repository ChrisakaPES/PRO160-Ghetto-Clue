using GhettoClue.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GhettoClue.Movement
{
    public class Cell : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isRoom = false;
        private bool _isDoor = false;
        private bool _isOpen = true;
        private bool _isAvailable = false;
        private bool _isCurrent = false;
        private bool _hasPlayer = false;
        private Player _player = new Player { Name = CharacterEnum.Empty };
        private static Player playerTransfer = new Player { Name = CharacterEnum.Empty };
        public static bool IsInHand = false;

        public bool IsRoom
        {
            get
            {
                return _isRoom;
            }
            set
            {
                _isRoom = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsRoom"));
            }

        }

        public bool HasPlayer
        {
            get
            {
                return _hasPlayer;
            }
            set
            {
                _hasPlayer = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HasPlayer"));
            }

        }

        public bool IsDoor
        {
            get
            {
                return _isDoor;
            }
            set
            {
                _isDoor = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsDoor"));
            }

        }

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                _isOpen = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsOpen"));
            }

        }

        public bool IsAvailable
        {
            get
            {
                return _isAvailable;
            }
            set
            {
                _isAvailable = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsAvailable"));
            }

        }

        public bool IsCurrent
        {
            get
            {
                return _isCurrent;
            }
            set
            {
                _isCurrent = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsCurrent"));
            }

        }

        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                if (Player != null)
                {
                    HasPlayer = true;
                }
                else
                {
                    HasPlayer = false;
                }
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Player"));
            }

        }

        public void parentClicked(object sender, MouseEventArgs e)
        {
            if (IsInHand)
            {
                if(!HasPlayer){

                if (IsAvailable)
                {
                    IsCurrent = !IsCurrent;
                    IsInHand = !IsInHand;
                    if(playerTransfer.Name != CharacterEnum.Empty)
                    {
                        HasPlayer = !HasPlayer;
                    }
                    Player = playerTransfer;
                    playerTransfer = new Player { Name = CharacterEnum.Empty };
                }
                }
            }
            else if (IsCurrent)
            {
                if(Player.hasRolled)
                {
                    IsInHand = !IsInHand;
                    IsCurrent = !IsCurrent;
                    playerTransfer = Player;
                    if (Player.Name != CharacterEnum.Empty)
                    {
                        HasPlayer = !HasPlayer;
                    }
                    Player = new Player { Name = CharacterEnum.Empty};
                }
            }
        }
    }
}
