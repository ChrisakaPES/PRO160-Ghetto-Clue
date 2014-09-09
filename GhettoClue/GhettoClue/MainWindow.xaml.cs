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
using GhettoClue.UserControls;
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
        MediaPlayer music = new MediaPlayer();
        

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
			playerListBox.ItemsSource = players;
			playerListBox.SelectedIndex = 0;

#endregion
			
			gameControl.UpdatePlayers(players);
			gameControl.CreateBoard();
			turn.IsEnabled = false;
			this.InvalidateVisual();
			playerListBox.InvalidateVisual();
			userGuide.ShowGuide();

            music.Open(new Uri("Music/Trap Banger Instrumental Beat 2014 - Hold up.mp3", UriKind.RelativeOrAbsolute));
            music.MediaEnded += music_MediaEnded;
            music.Play();
		}

        private void music_MediaEnded(object sender, EventArgs e)
        {
            music.Position = TimeSpan.Zero;
            music.Play();
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
			int i = playerListBox.SelectedIndex;

			currentPlayer = players[i]; 
			DetectiveNotes.DataContext = currentPlayer.MyDetectiveList;
			DNotes_Characters.ItemsSource = currentPlayer.MyDetectiveList.CharactersList;
			DNotes_Weapons.ItemsSource = currentPlayer.MyDetectiveList.WeaponsList;
			DNotes_Rooms.ItemsSource = currentPlayer.MyDetectiveList.RoomsList;

			CharacterHand.ItemsSource = currentPlayer.characterCards;
			RoomHand.ItemsSource = currentPlayer.roomCards;
			WeaponHand.ItemsSource = currentPlayer.weaponCards;

            playerListBox.ScrollIntoView(playerListBox.SelectedItem);
		}


		#region Button methods

		#region Die Click / Rolling methods
		private void roll_Click(object sender, RoutedEventArgs e)
		{

			//rolls the dice and calls the method to change the background
			this.InvalidateVisual();
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(90);
			timer.Tick += timer_Tick;
			timer.Start();
            currentPlayer.hasRolled = true;
			//Hide the guide
			userGuide.HideGuide();
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
				boardGuide.ShowGuide();
				
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


		private void nextTurn_Click(object sender, RoutedEventArgs e)
		{
			//turn taking
			bool isPlayerInRoom = false;
            currentPlayer.hasRolled = false;
            //if (currentPlayer.IsInRoom)
            //{
            //    MessageBoxResult res = MessageBox.Show("Would You like to Accuse Someone?", "Accuse?", MessageBoxButton.YesNo);
            //    if (res == MessageBoxResult.Yes)
            //    {
            //        //Do Accuse shenanigans 
            //        this.InvalidateVisual();
            //        AccuseWindow accuseWindow = new AccuseWindow();
            //        accuseWindow.ParentWin = this;
            //        accuseWindow.CurrentPlayer = players[playerListBox.SelectedIndex];
            //        accuseWindow.ShowDialog();

            //        if (CurrentAccusation.CheckForPlayerWin(theAnswer))
            //        {
            //            MessageBox.Show("Ayo YOU WON DA GAME!");
            //            System.Windows.Application.Current.Shutdown();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Oh SugarSnaps you done messed up yous outta da game.");
            //            players.RemoveAt(playerListBox.SelectedIndex);
            //            int playerSelect = playerListBox.SelectedIndex;
            //            playerSelect--;
            //            if (playerSelect == -1)
            //            {
            //                playerSelect = players.Count() - 1;
            //            }
            //            playerListBox.ItemsSource = players;
            //            playerListBox.SelectedIndex = playerSelect; 
            //            this.InvalidateVisual();


            //        }

					
            //    }
            //    else
            //    {
            //        this.InvalidateVisual();
            //        res = MessageBox.Show("Would You like to Suggest a scenario?", "Suggest?", MessageBoxButton.YesNo);
            //        if (res == MessageBoxResult.Yes)
            //        {
            //            SuggestionPopUpWindow suggestPop = new SuggestionPopUpWindow();
            //            suggestPop.ParentWin = this;
            //            suggestPop.currentPlayer = (Player)playerListBox.SelectedItem;
            //            suggestPop.ShowDialog();
            //            this.InvalidateVisual();


            //            int i = playerListBox.SelectedIndex + 1;
            //            if (i == players.Count())
            //            {
            //                i = 0;
            //            }
            //            int timesLoopedThrough = 0;
            //            do
            //            {
            //                if (CurrentSuggestion.CheckForDisproveEligibility(players[i]))
            //                {
            //                    DisprovePopUp disprovePop = new DisprovePopUp(players[i], CurrentSuggestion);
            //                    disprovePop.ParentWin = this;

            //                    disprovePop.ShowDialog();
            //                    this.InvalidateVisual();

            //                    break;
            //                }
            //                if (timesLoopedThrough >= 5)
            //                {
            //                    MessageBox.Show("None of the other players have any matching cards.", "Well what do you know?");
            //                    DetectiveNotes.Visibility = System.Windows.Visibility.Visible;
            //                    PlayerHand.Visibility = System.Windows.Visibility.Visible;
            //                    break;
            //                }
            //                i++;
            //                if (i == players.Count())
            //                {
            //                    i = 0;
            //                }
            //                timesLoopedThrough++;
							
            //            } while (true);
            //        }
            //        roll.IsEnabled = true;
					
            //    }
            //}
            Player lastPlayer = new Player();
            lastPlayer = (Player)playerListBox.SelectedItem;
            gameControl.inRoom(lastPlayer);
				

                if (lastPlayer.IsInRoom)
                {
                    MessageBoxResult res = MessageBox.Show("Would You like to Accuse Someone?", "Accuse?", MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.Yes)
                    {
                        //Do Accuse shenanigans 
                        this.InvalidateVisual();
                        VisualAccuseWindow accuseWindow = new VisualAccuseWindow();
                        accuseWindow.ParentWin = this;
                        accuseWindow.CurrentPlayer = players[playerListBox.SelectedIndex];
                        accuseWindow.ShowDialog();

                        if (CurrentAccusation.CheckForPlayerWin(theAnswer))
                        {
                            MessageBox.Show("Ayo YOU WON DA GAME!");
                            System.Windows.Application.Current.Shutdown();
                        }
                        else
                        {
                            MessageBox.Show("Oh SugarSnaps you done messed up yous outta da game.");
                            players.RemoveAt(playerListBox.SelectedIndex);
                            int playerSelect = playerListBox.SelectedIndex;
                            playerSelect--;
                            if (playerSelect == -1)
                            {
                                playerSelect = players.Count() - 1;
                            }
                            playerListBox.ItemsSource = players;
                            playerListBox.SelectedIndex = playerSelect;
                            this.InvalidateVisual();
                        }
                    }
                    else
                    {
                        this.InvalidateVisual();
                        res = MessageBox.Show("Would You like to Suggest a scenario?", "Suggest?", MessageBoxButton.YesNo);
                        if (res == MessageBoxResult.Yes)
                        {
                            VisualSuggestionWindow suggestPop = new VisualSuggestionWindow(RoomEnum.BackAlley);
                            suggestPop.ParentWin = this;
                            suggestPop.currentPlayer = (Player)playerListBox.SelectedItem;
                            suggestPop.ShowDialog();
                            this.InvalidateVisual();


                            int i = playerListBox.SelectedIndex + 1;
                            if (i == players.Count())
                            {
                                i = 0;
                            }
                            int timesLoopedThrough = 0;
                            do
                            {
                                if (CurrentSuggestion.CheckForDisproveEligibility(players[i]))
                                {
                                    VisualDismissal disprovePop = new VisualDismissal(players[i], CurrentSuggestion);
                                    disprovePop.InvalidateVisual();
                                    disprovePop.ParentWin = this;

                                    disprovePop.ShowDialog();
                                    this.InvalidateVisual();

                                    break;
                                }
                                if (timesLoopedThrough >= 5)
                                {
                                    MessageBox.Show("None of the other players have any matching cards.", "Well what do you know?");
                                    DetectiveNotes.Visibility = System.Windows.Visibility.Visible;
                                    PlayerHand.Visibility = System.Windows.Visibility.Visible;
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

                int currentPlayerIndex = playerListBox.SelectedIndex;
                currentPlayerIndex++;
                if (currentPlayerIndex == players.Count())
                {
                    currentPlayerIndex = 0;
                }
                playerListBox.SelectedIndex = currentPlayerIndex;
                rolled = 0;
                gameControl.UpdateNextTurn((Player)playerListBox.SelectedItem);
                gameControl.clearHighlights();

				turn.IsEnabled = false;
				userGuide.helptext.Text = "Hey "+ playerListBox.SelectedItem.ToString()+"! \n\n It is now your turn. Click the roll button to start your turn";
				userGuide.ShowGuide();
				roll.IsEnabled = true;
	   }
			
		

		private void suggest_Click(object sender, RoutedEventArgs e)
		{
			//suggest a card
            VisualSuggestionWindow suggestPop = new VisualSuggestionWindow(RoomEnum.BackAlley);
            suggestPop.ParentWin = this;
            suggestPop.currentPlayer = (Player)playerListBox.SelectedItem;
            suggestPop.ShowDialog();
            this.InvalidateVisual();


            int i = playerListBox.SelectedIndex + 1;
            if (i == players.Count())
            {
                i = 0;
            }
            int timesLoopedThrough = 0;
            do
            {
                if (CurrentSuggestion.CheckForDisproveEligibility(players[i]))
                {
                    VisualDismissal disprovePop = new VisualDismissal(players[i], CurrentSuggestion);
                    disprovePop.InvalidateVisual();
                    disprovePop.ParentWin = this;

                    disprovePop.ShowDialog();
                    this.InvalidateVisual();

                    break;
                }
                if (timesLoopedThrough >= 5)
                {
                    MessageBox.Show("None of the other players have any matching cards.", "Well what do you know?");
                    DetectiveNotes.Visibility = System.Windows.Visibility.Visible;
                    PlayerHand.Visibility = System.Windows.Visibility.Visible;
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
		
		private void accuse_Click(object sender, RoutedEventArgs e)
		{
			//accuse the murder
            this.InvalidateVisual();
            VisualAccuseWindow accuseWindow = new VisualAccuseWindow();
            accuseWindow.ParentWin = this;
            accuseWindow.CurrentPlayer = players[playerListBox.SelectedIndex];
            accuseWindow.ShowDialog();

            if (CurrentAccusation.CheckForPlayerWin(theAnswer))
            {
                MessageBox.Show("Ayo YOU WON DA GAME!");
                System.Windows.Application.Current.Shutdown();
            }
            else
            {
                MessageBox.Show("Oh SugarSnaps you done messed up yous outta da game.");
                players.RemoveAt(playerListBox.SelectedIndex);
                int playerSelect = playerListBox.SelectedIndex;
                playerSelect--;
                if (playerSelect == -1)
                {
                    playerSelect = players.Count() - 1;
                }
                playerListBox.ItemsSource = players;
                playerListBox.SelectedIndex = playerSelect;
                this.InvalidateVisual();
            }
		}
		#endregion

		private void help_MouseDown(object sender, RoutedEventArgs e)
		{
			Help help = new Help();
			help.ShowDialog();
		}


		public event PropertyChangedEventHandler PropertyChanged;

        //private void start_Click(object sender, RoutedEventArgs e)
        //{
        //    Splash.Visibility = System.Windows.Visibility.Hidden;
        //    start.Visibility = System.Windows.Visibility.Hidden;
        //}
	}
}

