using GhettoClue.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
namespace GhettoClue
{

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		#region Variables
		List<Player> players = new List<Player>();
		Random rand = new Random();
		public int rolled;
        List<Characters> startupCharacters = new List<Characters>
            {
                Characters.Lafawnduh, Characters.DaMarcus,Characters.Watermelondrea,Characters.Jake,Characters.Ladasha,Characters.JuanCarlos
            };
        List<Rooms> startupRooms = new List<Rooms>
            {
                Rooms.TheCorner, Rooms.GrowHouse, Rooms.BackAlley, Rooms.BMommasPad, Rooms.Laundrymat, 
                Rooms.Prison, Rooms.LightRoom, Rooms.KFC, Rooms.LiquorStore, Rooms.TheSpot
            };
        List<Weapons> startupWeapons = new List<Weapons>
            {
                Weapons.Shank, Weapons.DaHeata, Weapons.Smack, Weapons.Weave, Weapons.PoisonedLean
            };

        MurderScenario theAnswer;
        
		#endregion


		public MainWindow()
		{
			InitializeComponent();

			#region PlayerVariables

            //var LafC = RandomEnumValue<Characters>();
            //var LafR = RandomEnumValue<Rooms>();
            //var LafW = RandomEnumValue<Weapons>();

            //var DaC = RandomEnumValue<Characters>();
            //var DaR = RandomEnumValue<Rooms>();
            //var DaW = RandomEnumValue<Weapons>();

            //var WatC = RandomEnumValue<Characters>();
            //var WatR = RandomEnumValue<Rooms>();
            //var WatW = RandomEnumValue<Weapons>();

            //var JC = RandomEnumValue<Characters>();
            //var JR = RandomEnumValue<Rooms>();
            //var JW = RandomEnumValue<Weapons>();

            //var LaC = RandomEnumValue<Characters>();
            //var LaR = RandomEnumValue<Rooms>();
            //var LaW = RandomEnumValue<Weapons>();

            //var JuanC = RandomEnumValue<Characters>();
            //var JuanR = RandomEnumValue<Rooms>();
            //var JuanW = RandomEnumValue<Weapons>();
			#endregion
			#region Players
            ObservableCollection<ObservableCollection<Characters>> allCharacterLists = new ObservableCollection<ObservableCollection<Characters>>()
            {
                new ObservableCollection<Characters>(),
                new ObservableCollection<Characters>(),
                new ObservableCollection<Characters>(),
                new ObservableCollection<Characters>(),
                new ObservableCollection<Characters>(),
                new ObservableCollection<Characters>()
            };
            int playerListIndex = 0;
            while(startupCharacters.Count()>0)
            {
                int characterSelectionIndex = rand.Next(startupCharacters.Count());
                allCharacterLists[playerListIndex%6].Add(startupCharacters[characterSelectionIndex]);
                startupCharacters.RemoveAt(characterSelectionIndex);
                playerListIndex++;
            }
            ObservableCollection<ObservableCollection<Rooms>> allCharacterRoomsLists = new ObservableCollection<ObservableCollection<Rooms>>()
            {
                new ObservableCollection<Rooms>(),
                new ObservableCollection<Rooms>(),
                new ObservableCollection<Rooms>(),
                new ObservableCollection<Rooms>(),
                new ObservableCollection<Rooms>(),
                new ObservableCollection<Rooms>()
            };
            while (startupRooms.Count() > 0)
            {
                int roomSelectionIndex = rand.Next(startupRooms.Count());
                allCharacterRoomsLists[playerListIndex % 6].Add(startupRooms[roomSelectionIndex]);
                startupRooms.RemoveAt(roomSelectionIndex);
                playerListIndex++;
            }
            ObservableCollection<ObservableCollection<Weapons>> allCharacterWeaponsLists = new ObservableCollection<ObservableCollection<Weapons>>()
            {
                new ObservableCollection<Weapons>(),
                new ObservableCollection<Weapons>(),
                new ObservableCollection<Weapons>(),
                new ObservableCollection<Weapons>(),
                new ObservableCollection<Weapons>(),
                new ObservableCollection<Weapons>()
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
                    Name = Characters.Lafawnduh, 
                    background = "not yet defined", 
                    characterCards = allCharacterLists[0],
				    roomCards = allCharacterRoomsLists[0], 
				    weaponCards = allCharacterWeaponsLists[0]
                },
			    new Player
                { 
                    Name = Characters.DaMarcus, 
                    background = "not yet defined", 
                    characterCards = allCharacterLists[1],
				    roomCards = allCharacterRoomsLists[1], 
				    weaponCards = allCharacterWeaponsLists[1] 
                },
			    new Player
                { 
                    Name = Characters.Jake, 
				    background = "not yet defined", 
                    characterCards = allCharacterLists[2],
				    roomCards = allCharacterRoomsLists[2], 
				    weaponCards = allCharacterWeaponsLists[2]
                },
			    new Player
                { 
                    Name = Characters.JuanCarlos, 
                    background = "not yet defined", 
                    characterCards = allCharacterLists[3],
				    roomCards = allCharacterRoomsLists[3], 
				    weaponCards = allCharacterWeaponsLists[3]
                },
				new Player
                { 
                    Name = Characters.Ladasha, 
                    background = "not yet defined", 
                    characterCards = allCharacterLists[4],
				    roomCards = allCharacterRoomsLists[4], 
				    weaponCards = allCharacterWeaponsLists[4]
                },
			    new Player
                { 
                    Name = Characters.Watermelondrea,
                    background = "not yet defined", 
                    characterCards = allCharacterLists[5],
				    roomCards = allCharacterRoomsLists[5], 
				    weaponCards = allCharacterWeaponsLists[5]
                }
			};
			playerComboBox.ItemsSource = players;
            playerComboBox.SelectedIndex = 0;

#endregion
			#region Detective Notes

			#endregion

			
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
            Characters murderer = startupCharacters[index];
            startupCharacters.RemoveAt(index);

            index = rand.Next(totalNumberOfRooms);
            Rooms murderHouse = startupRooms[index];
            startupRooms.RemoveAt(index);

            index = rand.Next(totalNumberOfWeapons);
            Weapons murderWeapon = startupWeapons[index];
            startupWeapons.RemoveAt(index);

            theAnswer = new MurderScenario(murderer, murderHouse, murderWeapon);
        }

		private T RandomEnumValue<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<T>().OrderBy(x => rand.Next()).FirstOrDefault(); 
		}

		private void player_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            int i = playerComboBox.SelectedIndex;

            Player currentPlayer = players[i];
            CharacterGrid.ItemsSource = currentPlayer.characterCards;
            CharacterGrid.Columns.Add(new DataGridTextColumn());
            CharacterGrid.Columns[0].Width = new DataGridLength(100);
            CharacterGrid.Columns[0].Header = "Characters";
            CharacterGrid.Columns.Add(new DataGridCheckBoxColumn());
            WeaponGrid.ItemsSource = currentPlayer.weaponCards;
            RoomGrid.ItemsSource = currentPlayer.roomCards;

            //Removes the extra column that wasn't necessary for the cards area
            //CharacterGrid.Columns.Remove(CharacterGrid.Columns[0]);
            //WeaponGrid.Columns.Remove(WeaponGrid.Columns[0]);
            //RoomGrid.Columns.Remove(RoomGrid.Columns[0]);

            DetectiveNotes.DataContext = currentPlayer;

            DNotes_Characters.ItemsSource = currentPlayer.characterCards;
            DNotes_Weapons.ItemsSource = currentPlayer.MyDetectiveList.WeaponsList;
            DNotes_Rooms.ItemsSource = currentPlayer.MyDetectiveList.RoomsList;

            //Removes the extra column that wasn't necessary for the detective list
            //DNotes_Characters.Columns.Remove(DNotes_Characters.Columns[1]);
            //DNotes_Weapons.Columns.Remove(DNotes_Weapons.Columns[1]);
            //DNotes_Rooms.Columns.Remove(DNotes_Rooms.Columns[1]);

		}


		#region Button methods
		private void play_Click(object sender, RoutedEventArgs e)
		{

			//takes away splash screen


		}
		#region Die Click / Rolling methods
		private void roll_Click(object sender, RoutedEventArgs e)
		{
			//rolls the dice and calls the method to change the background
			Random gen = new Random();
			rolled = gen.Next(1, 7);

			roll_Die(rolled);
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
            MessageBoxResult res= MessageBox.Show("Are you sure You would like to End your turn?", "50%Fact, 50% Magic, 100% Results", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                int currentPlayerIndex = playerComboBox.SelectedIndex;
                currentPlayerIndex++;
                if (currentPlayerIndex == players.Count())
                {
                    currentPlayerIndex = 0;
                }
                playerComboBox.SelectedIndex = currentPlayerIndex;
                rolled = 0;
                roll.IsEnabled = true;
            }
            else if (res == MessageBoxResult.No)
            {

            }
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

        private void DNotes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "show")
            {
                e.Column.Header = "Known";
            }
        }


        private void help_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

       private void start_Click(object sender, RoutedEventArgs e)
       {
           SpashScreen.Visibility = System.Windows.Visibility.Hidden;
           welcome.Visibility = System.Windows.Visibility.Hidden;
           start.Visibility = System.Windows.Visibility.Hidden;
           ruleHeader.Visibility = System.Windows.Visibility.Hidden;
           rules1.Visibility = System.Windows.Visibility.Hidden;
           rules2.Visibility = System.Windows.Visibility.Hidden;
           rules3.Visibility = System.Windows.Visibility.Hidden;
       }

        private void help_MouseDown(object sender, RoutedEventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }

	}
}

