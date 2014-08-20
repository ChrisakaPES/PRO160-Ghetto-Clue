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
			var randC = RandomEnumValue<Characters.CharacterCards>();
			var randR = RandomEnumValue<Rooms.room>();
			var randW = RandomEnumValue<Weapons.weapon>();
			players = new List<Player>
			{
				new Player{ Name = characters.Lafawnduh, background = "not yet defined", characterCards = new ObservableCollection<Characters> 
				{
					new Characters { character = randC.ToString()},
					new Characters { character = randC.ToString()}
				},
				 roomCards = new ObservableCollection<Rooms>
				 {
					new Rooms { location = randR.ToString()}
				 }, 
				  weaponCards = new ObservableCollection<Weapons>
				  {
					  new Weapons { leathals = randW.ToString()}
				  }
				}};

			player.ItemsSource = players;
		}

		private T RandomEnumValue<T>()
		{
			return Enum.GetValues(typeof(T)).Cast<T>().OrderBy(x => rand.Next()).FirstOrDefault(); 
		}

		private void player_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int i = player.SelectedIndex;
			CharacterGrid.ItemsSource = players[i].characterCards;
			WeaponGrid.ItemsSource = players[i].weaponCards;
			RoomGrid.ItemsSource = players[i].roomCards;

			DNotes_Characters.ItemsSource = players[i].characterCards;
			DNotes_Weapons.ItemsSource = players[i].weaponCards;
			DNotes_Rooms.ItemsSource = players[i].roomCards;
		}

		private void play_Click(object sender, RoutedEventArgs e)
		{

			//takes away display screen


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
	}
}

