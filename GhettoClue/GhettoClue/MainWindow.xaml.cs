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
        List<Player> players = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
            players = new List<Player>
            {
                new Player{ Name = characters.Lafawnduh, background = "not yet defined", characterCards = new ObservableCollection<Characters>
                {
                    new Characters { character = Characters.CharacterCards.JuanCarlos},
                    new Characters { character = Characters.CharacterCards.Ladasha}
                },
                 roomCards = new ObservableCollection<Rooms>
                 {
                     new Rooms { location = Rooms.room.GrowHouse},
                     new Rooms { location = Rooms.room.LightRoom}
                 }, 
                  weaponCards = new ObservableCollection<Weapons>
                  {
                      new Weapons { leathals = Weapons.weapon.DaHeata},
                      new Weapons { leathals = Weapons.weapon.Shank}
                  }}};
            player.ItemsSource = players;
        }
        private void player_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = player.SelectedIndex;
            CharacterGrid.ItemsSource = players[i].characterCards;
            WeaponGrid.ItemsSource = players[i].weaponCards;
            RoomGrid.ItemsSource = players[i].roomCards;
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {

            //takes away display screen


        }

        private void roll_Click(object sender, RoutedEventArgs e)
        {
            //rolls the dice and displays the number in the label
            Random gen = new Random();
            int temp = 0;
            temp = gen.Next(1, 7);

            //switch(temp)
            //{
            //	case 1:
            //		die_Face.Background
            //}
        }

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

