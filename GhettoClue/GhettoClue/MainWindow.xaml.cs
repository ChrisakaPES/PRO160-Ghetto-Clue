using GhettoClue.Model;
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
		#endregion


		public MainWindow()
		{
			InitializeComponent();
			#region PlayerVariables
			var LafC = RandomEnumValue<CharacterCards>();
			var LafR = RandomEnumValue<room>();
			var LafW = RandomEnumValue<weapon>();

			var DaC = RandomEnumValue<CharacterCards>();
			var DaR = RandomEnumValue<room>();
			var DaW = RandomEnumValue<weapon>();

			var WatC = RandomEnumValue<CharacterCards>();
			var WatR = RandomEnumValue<room>();
			var WatW = RandomEnumValue<weapon>();

			var JC = RandomEnumValue<CharacterCards>();
			var JR = RandomEnumValue<room>();
			var JW = RandomEnumValue<weapon>();

			var LaC = RandomEnumValue<CharacterCards>();
			var LaR = RandomEnumValue<room>();
			var LaW = RandomEnumValue<weapon>();

			var JuanC = RandomEnumValue<CharacterCards>();
			var JuanR = RandomEnumValue<room>();
			var JuanW = RandomEnumValue<weapon>();
			#endregion
			#region Players
			players = new List<Player>
			{
				new Player{ Name = characters.Lafawnduh, background = "not yet defined", characterCards = new ObservableCollection<Characters> 
				{
					new Characters { character = LafC.ToString()},
				},
				 roomCards = new ObservableCollection<Rooms>
				 {
					new Rooms { location = LafR.ToString()}
				 }, 
				  weaponCards = new ObservableCollection<Weapons>
				  {
					  new Weapons { leathals = LafW.ToString()}
				  }},
						new Player{ Name = characters.DaMarcus, background = "not yet defined", characterCards = new ObservableCollection<Characters> 
				{
					new Characters { character = DaC.ToString()},
				},
				 roomCards = new ObservableCollection<Rooms>
				 {
					new Rooms { location = DaR.ToString()}
				 }, 
				  weaponCards = new ObservableCollection<Weapons>
				  {
					  new Weapons { leathals = DaW.ToString()}
				  }},
						new Player{ Name = characters.Jake, background = "not yet defined", characterCards = new ObservableCollection<Characters> 
				{
					new Characters { character = JC.ToString()},
				},
				 roomCards = new ObservableCollection<Rooms>
				 {
					new Rooms { location = JR.ToString()}
				 }, 
				  weaponCards = new ObservableCollection<Weapons>
				  {
					  new Weapons { leathals = JW.ToString()}
				  }},
						new Player{ Name = characters.JuanCarlos, background = "not yet defined", characterCards = new ObservableCollection<Characters> 
				{
					new Characters { character = JuanC.ToString()},
				},
				 roomCards = new ObservableCollection<Rooms>
				 {
					new Rooms { location = JuanR.ToString()}
				 }, 
				  weaponCards = new ObservableCollection<Weapons>
				  {
					  new Weapons { leathals = JuanW.ToString()}
				  }},
						new Player{ Name = characters.Ladasha, background = "not yet defined", characterCards = new ObservableCollection<Characters> 
				{
					new Characters { character = LaC.ToString()},
				},
				 roomCards = new ObservableCollection<Rooms>
				 {
					new Rooms { location = LaR.ToString()}
				 }, 
				  weaponCards = new ObservableCollection<Weapons>
				  {
					  new Weapons { leathals = LaW.ToString()}
				  }},
						new Player{ Name = characters.Watermelondria, background = "not yet defined", characterCards = new ObservableCollection<Characters> 
				{
					new Characters { character = WatC.ToString()},
				},
				 roomCards = new ObservableCollection<Rooms>
				 {
					new Rooms { location = WatR.ToString()}
				 }, 
				  weaponCards = new ObservableCollection<Weapons>
				  {
					  new Weapons { leathals = WatW.ToString()}
				  }}
			};
			player.ItemsSource = players;
#endregion
			#region Detective Notes

			#endregion

			
		}

		private T RandomEnumValue<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<T>().OrderBy(x => rand.Next()).FirstOrDefault(); 
		}

		private void player_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int i = player.SelectedIndex;

			Player currentPlayer = players[i];
			CharacterGrid.ItemsSource = currentPlayer.characterCards;
			WeaponGrid.ItemsSource = currentPlayer.weaponCards;
			RoomGrid.ItemsSource = currentPlayer.roomCards;

			//Removes the extra column that wasn't necessary for the cards area
			CharacterGrid.Columns.Remove(CharacterGrid.Columns[0]);
			WeaponGrid.Columns.Remove(WeaponGrid.Columns[0]);
			RoomGrid.Columns.Remove(RoomGrid.Columns[0]);
			
			DetectiveNotes.DataContext = currentPlayer.MyDetectiveList;

			DNotes_Characters.ItemsSource = currentPlayer.MyDetectiveList.CharactersList;
			DNotes_Weapons.ItemsSource = currentPlayer.MyDetectiveList.WeaponsList;
			DNotes_Rooms.ItemsSource = currentPlayer.MyDetectiveList.RoomsList;

			//Removes the extra column that wasn't necessary for the detective list
			DNotes_Characters.Columns.Remove(DNotes_Characters.Columns[1]);
			DNotes_Weapons.Columns.Remove(DNotes_Weapons.Columns[1]);
			DNotes_Rooms.Columns.Remove(DNotes_Rooms.Columns[1]);

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
			System.Windows.Point position = e.GetPosition(this);
			double pX = position.X;
			double pY = position.Y;

			Canvas.SetLeft(Token1, pX - 20);
			Canvas.SetTop(Token1, pY - 30);

		}
		

		private void nextTurn_Click(object sender, RoutedEventArgs e)
		{
			//turn taking
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
	}
}

