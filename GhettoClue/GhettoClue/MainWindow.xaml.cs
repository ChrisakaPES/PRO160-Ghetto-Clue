using GhettoClue.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace GhettoClue
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		#region Variables
		List<Player> players = new List<Player>();
        Player currentPlayer = null;
		Random rand = new Random();
        Random gen = new Random();
        private int timerLoop=0;
		public int rolled;
        private int _roll;
        public int NumRoll
        {
            get
            {
                return _roll;
            }
            set
            {
                _roll = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("NumRoll"));
                }
            }
        }
        List<CharacterEnum> startupCharacters = new List<CharacterEnum>
            {
                CharacterEnum.Lafawnduh, CharacterEnum.DaMarcus,CharacterEnum.Watermelondrea,CharacterEnum.Jake,CharacterEnum.Ladasha,CharacterEnum.JuanCarlos
            };
        List<RoomEnum> startupRooms = new List<RoomEnum>
            {
                RoomEnum.TheCorner, RoomEnum.GrowHouse, RoomEnum.BackAlley, RoomEnum.BMommasPad, RoomEnum.Laundrymat, 
                RoomEnum.Prison, RoomEnum.LightRoom, RoomEnum.KFC, RoomEnum.LiquorStore, RoomEnum.TheSpot
            };
        List<WeaponEnum> startupWeapons = new List<WeaponEnum>
            {
                WeaponEnum.Shank, WeaponEnum.DaHeata, WeaponEnum.Smack, WeaponEnum.Weave, WeaponEnum.PoisonedLean
            };

        public Suggestion CurrentSuggestion { get; set; }
        MurderScenario theAnswer;
        public Accusation CurrentAccusation { get; set; }

        bool suggestTrue = false;




		#endregion


		public MainWindow()
		{
			InitializeComponent();
            this.InvalidateVisual();
			CreateMurderScenario();
            #region Players
            ObservableCollection<ObservableCollection<CharacterEnum>> allCharacterLists = new ObservableCollection<ObservableCollection<CharacterEnum>>()
            {
                new ObservableCollection<CharacterEnum>(),
                new ObservableCollection<CharacterEnum>(),
                new ObservableCollection<CharacterEnum>(),
                new ObservableCollection<CharacterEnum>(),
                new ObservableCollection<CharacterEnum>(),
                new ObservableCollection<CharacterEnum>()
            };
            int playerListIndex = 0;
            while(startupCharacters.Count()>0)
            {
                int characterSelectionIndex = rand.Next(startupCharacters.Count());
                allCharacterLists[playerListIndex%6].Add(startupCharacters[characterSelectionIndex]);
                startupCharacters.RemoveAt(characterSelectionIndex);
                playerListIndex++;
            }
            ObservableCollection<ObservableCollection<RoomEnum>> allCharacterRoomsLists = new ObservableCollection<ObservableCollection<RoomEnum>>()
            {
                new ObservableCollection<RoomEnum>(),
                new ObservableCollection<RoomEnum>(),
                new ObservableCollection<RoomEnum>(),
                new ObservableCollection<RoomEnum>(),
                new ObservableCollection<RoomEnum>(),
                new ObservableCollection<RoomEnum>()
            };
            while (startupRooms.Count() > 0)
            {
                int roomSelectionIndex = rand.Next(startupRooms.Count());
                allCharacterRoomsLists[playerListIndex % 6].Add(startupRooms[roomSelectionIndex]);
                startupRooms.RemoveAt(roomSelectionIndex);
                playerListIndex++;
            }
            ObservableCollection<ObservableCollection<WeaponEnum>> allCharacterWeaponsLists = new ObservableCollection<ObservableCollection<WeaponEnum>>()
            {
                new ObservableCollection<WeaponEnum>(),
                new ObservableCollection<WeaponEnum>(),
                new ObservableCollection<WeaponEnum>(),
                new ObservableCollection<WeaponEnum>(),
                new ObservableCollection<WeaponEnum>(),
                new ObservableCollection<WeaponEnum>()
            };
            while (startupWeapons.Count() > 0)
            {
                int weaponSelectionIndex = rand.Next(startupWeapons.Count());
                allCharacterWeaponsLists[playerListIndex % 6].Add(startupWeapons[weaponSelectionIndex]);
                startupWeapons.RemoveAt(weaponSelectionIndex);
                playerListIndex++;
            }



			players = new List<Player>
			{
				new Player
                { 
                    Name = CharacterEnum.Lafawnduh, 
                    background = "not yet defined", 
                    characterCards = allCharacterLists[0],
				    roomCards = allCharacterRoomsLists[0], 
				    weaponCards = allCharacterWeaponsLists[0]
                },
			    new Player
                { 
                    Name = CharacterEnum.DaMarcus, 
                    background = "not yet defined", 
                    characterCards = allCharacterLists[1],
				    roomCards = allCharacterRoomsLists[1], 
				    weaponCards = allCharacterWeaponsLists[1] 
                },
			    new Player
                { 
                    Name = CharacterEnum.Jake, 
				    background = "not yet defined", 
                    characterCards = allCharacterLists[2],
				    roomCards = allCharacterRoomsLists[2], 
				    weaponCards = allCharacterWeaponsLists[2]
                },
			    new Player
                { 
                    Name = CharacterEnum.JuanCarlos, 
                    background = "not yet defined", 
                    characterCards = allCharacterLists[3],
				    roomCards = allCharacterRoomsLists[3], 
				    weaponCards = allCharacterWeaponsLists[3]
                },
				new Player
                { 
                    Name = CharacterEnum.Ladasha, 
                    background = "not yet defined", 
                    characterCards = allCharacterLists[4],
				    roomCards = allCharacterRoomsLists[4], 
				    weaponCards = allCharacterWeaponsLists[4]
                },
			    new Player
                { 
                    Name = CharacterEnum.Watermelondrea,
                    background = "not yet defined", 
                    characterCards = allCharacterLists[5],
				    roomCards = allCharacterRoomsLists[5], 
				    weaponCards = allCharacterWeaponsLists[5]
                }
			};
			playerComboBox.ItemsSource = players;
            playerComboBox.SelectedIndex = 0;

#endregion
            
            gameControl.UpdatePlayers(players);
            gameControl.CreateBoard();
            turn.IsEnabled = false;
            this.InvalidateVisual();
            //playerComboBox.DataContext = this;
		}

        /** 
         * Hey this is the how things should work 
         */
        private void CreateMurderScenario()
        {
            int totalNumberOfCharacters = startupCharacters.Count();
            int totalNumberOfRooms = startupRooms.Count();
            int totalNumberOfWeapons = startupWeapons.Count(); 

            int index = rand.Next(totalNumberOfCharacters);
            CharacterEnum murderer = startupCharacters[index];
            startupCharacters.RemoveAt(index);

            index = rand.Next(totalNumberOfRooms);
            RoomEnum murderHouse = startupRooms[index];
            startupRooms.RemoveAt(index);

            index = rand.Next(totalNumberOfWeapons);
            WeaponEnum murderWeapon = startupWeapons[index];
            startupWeapons.RemoveAt(index);

            theAnswer = new MurderScenario(murderer, murderHouse, murderWeapon);
        }


		private void player_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            int i = playerComboBox.SelectedIndex;

            currentPlayer = players[i]; 
            DetectiveNotes.DataContext = currentPlayer.MyDetectiveList;
            DNotes_Characters.ItemsSource = currentPlayer.MyDetectiveList.CharactersList;
            DNotes_Weapons.ItemsSource = currentPlayer.MyDetectiveList.WeaponsList;
            DNotes_Rooms.ItemsSource = currentPlayer.MyDetectiveList.RoomsList;

            CharacterHand.ItemsSource = currentPlayer.characterCards;
            RoomHand.ItemsSource = currentPlayer.roomCards;
            WeaponHand.ItemsSource = currentPlayer.weaponCards;

		}


		#region Button methods

		#region Die Click / Rolling methods
        private void roll_Click(object sender, RoutedEventArgs e)
        {
            //rolls the dice and calls the method to change the background
            this.InvalidateVisual();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.Start();
            

            //NumRoll = gen.Next(1, 7);
            //gameControl.HighlightSpots(NumRoll);
            //roll_Die(NumRoll);
            //roll.IsEnabled = false;
            //turn.IsEnabled = true;

            //This bool will be set by movement actions but is always set to true for testing
           


                
        }

        void timer_Tick(object sender, EventArgs e)
        {
            int num = gen.Next(1, 7);
            //gameControl.HighlightSpots(num);
            roll_Die(num);
            if (timerLoop == 30)
            {
                ((DispatcherTimer)sender).Stop();
                roll.IsEnabled = false;
                turn.IsEnabled = true;
                gameControl.HighlightSpots(num);
                timerLoop = 0;
            }
            timerLoop++;
            
        }

		public void roll_Die(int num)
		{			
			//Clear current background
			die_placement.Source = null;

				//Determine which new die face will be displayed then change image source
				switch (num)
				{
					case 1:
						die_placement.Source = new BitmapImage(new Uri(@"/Images/1.png", UriKind.Relative));
						break;
					case 2:
						die_placement.Source = new BitmapImage(new Uri(@"/Images/2.png", UriKind.Relative));
						break;
					case 3:
						die_placement.Source = new BitmapImage(new Uri(@"/Images/3.png", UriKind.Relative));
						break;
					case 4:
						die_placement.Source = new BitmapImage(new Uri(@"/Images/4.png", UriKind.Relative));
						break;
					case 5:
						die_placement.Source = new BitmapImage(new Uri(@"/Images/5.png", UriKind.Relative));
						break;
					case 6:
						die_placement.Source = new BitmapImage(new Uri(@"/Images/6.png", UriKind.Relative));
						break;
					default:
						break;
				}
                die_placement.InvalidateVisual();
		}
		#endregion


		private void gameboard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
            //System.Windows.Point position = e.GetPosition(this);
            //double pX = position.X;
            //double pY = position.Y;

            //Canvas.SetLeft(Token1, pX - 20);
            //Canvas.SetTop(Token1, pY - 30);

		}


        private void nextTurn_Click(object sender, RoutedEventArgs e)
        {
            //turn taking
            bool isPlayerInRoom = true;

            if (isPlayerInRoom)
            {
                MessageBoxResult res = MessageBox.Show("Would You like to Accuse Someone?", "Accuse?", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    //Do Accuse shenanigans 
                    this.InvalidateVisual();
                    AccuseWindow accuseWindow = new AccuseWindow();
                    accuseWindow.ParentWin = this;
                    accuseWindow.CurrentPlayer = players[playerComboBox.SelectedIndex];
                    accuseWindow.ShowDialog();

                    if (CurrentAccusation.CheckForPlayerWin(theAnswer))
                    {
                        MessageBox.Show("Ayo YOU WON DA GAME!");
                        System.Windows.Application.Current.Shutdown();
                    }
                    else
                    {
                        MessageBox.Show("Oh SugarSnaps you done messed up yous outta da game.");
                        players.RemoveAt(playerComboBox.SelectedIndex);
                        int playerSelect = playerComboBox.SelectedIndex;
                        playerSelect--;
                        if (playerSelect == -1)
                        {
                            playerSelect = players.Count() - 1;
                        }
                        playerComboBox.ItemsSource = players;
                        playerComboBox.SelectedIndex = playerSelect; 
                        this.InvalidateVisual();


                    }

                    
                }
                else
                {
                    this.InvalidateVisual();
                    res = MessageBox.Show("Would You like to Suggest a scenario?", "Suggest?", MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.Yes)
                    {
                        SuggestionPopUpWindow suggestPop = new SuggestionPopUpWindow();
                        suggestPop.ParentWin = this;
                        suggestPop.currentPlayer = (Player)playerComboBox.SelectedItem;
                        suggestPop.ShowDialog();
                        this.InvalidateVisual();


                        int i = playerComboBox.SelectedIndex + 1;
                        if (i == players.Count())
                        {
                            i = 0;
                        }
                        int timesLoopedThrough = 0;
                        do
                        {
                            if (CurrentSuggestion.CheckForDisproveEligibility(players[i]))
                            {
                                DisprovePopUp disprovePop = new DisprovePopUp(players[i], CurrentSuggestion);
                                disprovePop.ParentWin = this;

                                disprovePop.ShowDialog();
                                this.InvalidateVisual();

                                break;
                            }
                            if (timesLoopedThrough >= 5)
                            {
                                MessageBox.Show("None of the other players have any matching cards.", "Well what do you know?"); 
                                break;
                            }
                            i++;
                            if (i == players.Count())
                            {
                                i = 0;
                            }
                            timesLoopedThrough++;
                            
                        } while (true);
                    }
                    roll.IsEnabled = true;
                    
                }
            }
                int currentPlayerIndex = playerComboBox.SelectedIndex;
                currentPlayerIndex++;
                if (currentPlayerIndex == players.Count())
                {
                    currentPlayerIndex = 0;
                }
                playerComboBox.SelectedIndex = currentPlayerIndex;
                rolled = 0;
                gameControl.UpdateNextTurn((Player)playerComboBox.SelectedItem);
                gameControl.clearHighlights();

                MessageBox.Show("It is now "+ playerComboBox.SelectedItem.ToString()+"\'s roll!");
                this.InvalidateVisual();
                turn.IsEnabled = false;
                roll.IsEnabled = true;
       }
            
        

		private void suggest_Click(object sender, RoutedEventArgs e)
		{
			//suggest a card
            SuggestionPopUpWindow suggestPopUp = new SuggestionPopUpWindow();
            suggestPopUp.Show();
            suggestPopUp.Activate();
            
		}

		private void disprove_Click(object sender, RoutedEventArgs e)
		{
			//disprove the cards
		}
		
		private void accuse_Click(object sender, RoutedEventArgs e)
		{
			//accuse the murder
		}
		#endregion



       private void start_Click(object sender, RoutedEventArgs e)
       {
           SpashScreen.Visibility = System.Windows.Visibility.Hidden;
          
           start.Visibility = System.Windows.Visibility.Hidden;
           playerComboBox.InvalidateVisual();

       }

        private void help_MouseDown(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}

