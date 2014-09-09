using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GhettoClue.Models;
using System.Collections.ObjectModel;

namespace GhettoClue
{
    /// <summary>
    /// Interaction logic for VisualDismissal.xaml
    /// </summary>
    public partial class VisualDismissal : Window
    {
        public Player disprovingPlayer { get; set; }
        public MainWindow ParentWin { get; set; }
        public ObservableCollection<string> listOfCards { get; set; }

        private object cardToShare { get; set; }

        private CharacterEnum charButtonVal;
        private RoomEnum roomButtonVal;
        private WeaponEnum weaponButtonVal;
        public VisualDismissal()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }
        public VisualDismissal(Player p, Suggestion sug)
        {
            InitializeComponent();
            this.DataContext = this;
            listOfCards = new ObservableCollection<string>();
            disprovingPlayer = p;

            foreach (CharacterEnum c in p.characterCards)
            {
                if (c.ToString() == sug.Character.ToString())
                {
                    //listOfCards.Add(c.ToString());
                    SetCharacterButton(c);
                }
            }
            foreach (RoomEnum r in p.roomCards)
            {
                if (r.ToString() == sug.Room.ToString())
                {
                    //listOfCards.Add(r.ToString());
                    SetSiteButton(r);
                }
            }
            foreach (WeaponEnum w in p.weaponCards)
            {
                if (w.ToString() == sug.Weapon.ToString())
                {
                    //listOfCards.Add(w.ToString());
                    SetWeaponButton(w);
                }
            }

        }

        private void SetCharacterButton(CharacterEnum c)
        {
            if (c == CharacterEnum.DaMarcus)
            {
                SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/demarcas.jpg", UriKind.Relative));
            }
            else if (c == CharacterEnum.Jake)
            {
                SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/jake.jpg", UriKind.Relative));
            }
            else if (c == CharacterEnum.JuanCarlos)
            {
                SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/juancarlos.jpg", UriKind.Relative));
            }
            else if (c == CharacterEnum.Ladasha)
            {
                SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/la-a.jpg", UriKind.Relative));
            }
            else if (c == CharacterEnum.Lafawnduh)
            {
                SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/lafawnda.jpg", UriKind.Relative));
            }
            else if (c == CharacterEnum.Watermelondrea)
            {
                SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/watermelondrea.jpg", UriKind.Relative));
            }
            SuspectButton.IsEnabled = true;
            charButtonVal = c;
        }

        private void SetWeaponButton(WeaponEnum w)
        {
            if (w == WeaponEnum.DaHeata)
            {
                WeaponImage.Source = new BitmapImage(new Uri("Tokens/gun.png",UriKind.Relative));
            }
            else if (w == WeaponEnum.PoisonedLean)
            {
                WeaponImage.Source = new BitmapImage(new Uri("Tokens/lean.png", UriKind.Relative));
            }
            else if (w == WeaponEnum.Shank)
            {
                WeaponImage.Source = new BitmapImage(new Uri("Tokens/knife.png", UriKind.Relative));
            }
            else if (w == WeaponEnum.Smack)
            {
                WeaponImage.Source = new BitmapImage(new Uri("Tokens/smack.png", UriKind.Relative));
            }
            else if (w == WeaponEnum.Weave)
            {
                WeaponImage.Source = new BitmapImage(new Uri("Tokens/weave.png", UriKind.Relative));
            }

            WeaponButton.IsEnabled = true;
            WeaponButton.InvalidateArrange();
            WeaponButton.InvalidateMeasure();
            WeaponButton.InvalidateVisual();
            weaponButtonVal = w;
        }

        private void SetSiteButton(RoomEnum r)
        {
            if (r == RoomEnum.BackAlley)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/backalley.jpg", UriKind.Relative));
            }
            else if (r == RoomEnum.BMommasPad)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/bmommapad.jpg", UriKind.Relative));
            }
            else if (r == RoomEnum.GrowHouse)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/growhouse.jpg", UriKind.Relative));
            }
            else if (r == RoomEnum.KFC)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/kfc.jpg", UriKind.Relative));
            }
            else if (r == RoomEnum.Laundrymat)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/laundromat.jpg", UriKind.Relative));
            }
            else if (r == RoomEnum.LightRoom)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/lightroom.jpg", UriKind.Relative));
            }
            else if (r == RoomEnum.LiquorStore)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/liquorstore.jpg", UriKind.Relative));
            }
            else if (r == RoomEnum.Prison)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/localprison.jpg", UriKind.Relative));
            }
            else if (r == RoomEnum.TheCorner)
            {
                SiteImage.Source = new BitmapImage(new Uri("rooms/thecorner.jpg", UriKind.Relative));
            }

            SiteButton.IsEnabled = true;
            roomButtonVal = r;
        }



        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (cardToShare==null)
            {
                MessageBox.Show("Please Select a Card from the List");
                return;
            }

            MessageBox.Show("Please Pass the laptop so the suggesting player can see the card you chose.");
            ParentWin.DetectiveNotes.Visibility = System.Windows.Visibility.Visible;
            ParentWin.PlayerHand.Visibility = System.Windows.Visibility.Visible;
            this.Close();
            MessageBox.Show("The Disproving player has " +cardToShare.ToString(),"Information" );




        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void SuspectButton_Click(object sender, RoutedEventArgs e)
        {
            cardToShare = charButtonVal;

            SelectedCardLabel.Content = "Selected Card: " + cardToShare;
        }

        private void WeaponButton_Click(object sender, RoutedEventArgs e)
        {
            cardToShare = weaponButtonVal;

            SelectedCardLabel.Content = "Selected Card: " + cardToShare;
        }

        private void SiteButton_Click(object sender, RoutedEventArgs e)
        {
            cardToShare = roomButtonVal;

            SelectedCardLabel.Content = "Selected Card: " + cardToShare;
        }
    }
}
