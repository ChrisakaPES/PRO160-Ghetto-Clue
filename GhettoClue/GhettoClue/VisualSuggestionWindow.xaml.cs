using GhettoClue.Models;
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
namespace GhettoClue
{
    /// <summary>
    /// Interaction logic for VisualSuggestionWindow.xaml
    /// </summary>
    public partial class VisualSuggestionWindow : Window
    {
        public MainWindow ParentWin { get; set; }
        public Player currentPlayer { get; set; }
        public Suggestion suggest { get; set; }

        private RoomEnum murderSite;
        private bool hasRoomBeenPicked = false;
        private WeaponEnum murderWeapon;
        private bool hasWeaponBeenPicked = false;
        private CharacterEnum murderCharacter;
        private bool hasCharacterBeenPicked = false;

        private bool buttonPromptedClose = false;

        public VisualSuggestionWindow(RoomEnum room)
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        private void LaFawndaButton_Click(object sender, RoutedEventArgs e)
        {
            hasCharacterBeenPicked = true;
            murderCharacter = CharacterEnum.Lafawnduh;

            SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/lafawnda.jpg", UriKind.Relative));
            MurderSuspectLabel.Content = "Murder Suspect: Lafawnduh";
        }

        private void DamarcusButton_Click(object sender, RoutedEventArgs e)
        {
            hasCharacterBeenPicked = true;
            murderCharacter = CharacterEnum.DaMarcus;

            SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/demarcas.jpg", UriKind.Relative));
            MurderSuspectLabel.Content = "Murder Suspect: DaMarcus";
        }

        private void JakeButton_Click(object sender, RoutedEventArgs e)
        {
            hasCharacterBeenPicked = true;
            murderCharacter = CharacterEnum.Jake;

            SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/jake.jpg", UriKind.Relative));
            MurderSuspectLabel.Content = "Murder Suspect: Jake";
        }

        private void LadashaButton_Click(object sender, RoutedEventArgs e)
        {
            hasCharacterBeenPicked = true;
            murderCharacter = CharacterEnum.Ladasha;

            SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/la-a.jpg", UriKind.Relative));
            MurderSuspectLabel.Content = "Murder Suspect: La-a";
        }

        private void JuanCarlosButton_Click(object sender, RoutedEventArgs e)
        {
            hasCharacterBeenPicked = true;
            murderCharacter = CharacterEnum.JuanCarlos;

            SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/juancarlos.jpg", UriKind.Relative));
            MurderSuspectLabel.Content = "Murder Suspect: Juan Carlos";
        }

        private void WatermelondreaButton_Click(object sender, RoutedEventArgs e)
        {
            hasCharacterBeenPicked = true;
            murderCharacter = CharacterEnum.Watermelondrea;

            SuspectImage.Source = new BitmapImage(new Uri("Character Pictures/watermelondrea.jpg", UriKind.Relative));
            MurderSuspectLabel.Content = "Murder Suspect: Watermelondrea";
        }

        private void DaHeataButton_Click(object sender, RoutedEventArgs e)
        {
            hasWeaponBeenPicked = true;
            murderWeapon = WeaponEnum.DaHeata;

            WeaponImage.Source= new BitmapImage(new Uri("Tokens/gun.png",UriKind.Relative));
            MurderWeaponLabel.Content = "Murder Weapon: DaHeata";
        }

        private void ShankButton_Click(object sender, RoutedEventArgs e)
        {
            hasWeaponBeenPicked = true;
            murderWeapon = WeaponEnum.Smack;

            WeaponImage.Source = new BitmapImage(new Uri("Tokens/knife.png", UriKind.Relative));
            MurderWeaponLabel.Content = "Murder Weapon: Shank";
        }

        private void PoisonedLeanButton_Click(object sender, RoutedEventArgs e)
        {
            hasWeaponBeenPicked = true;
            murderWeapon = WeaponEnum.PoisonedLean;

            WeaponImage.Source = new BitmapImage(new Uri("Tokens/lean.png", UriKind.Relative));
            MurderWeaponLabel.Content = "Murder Weapon: Poisoned Lean";
        }

        private void SmackButton_Click(object sender, RoutedEventArgs e)
        {
            hasWeaponBeenPicked = true;
            murderWeapon = WeaponEnum.Smack;

            WeaponImage.Source = new BitmapImage(new Uri("Tokens/smack.png", UriKind.Relative));
            MurderWeaponLabel.Content = "Murder Weapon: Smack";
        }

        private void WeaveButton_Click(object sender, RoutedEventArgs e)
        {
            hasWeaponBeenPicked = true;
            murderWeapon = WeaponEnum.Weave;

            WeaponImage.Source = new BitmapImage(new Uri("Tokens/weave.png", UriKind.Relative));
            MurderWeaponLabel.Content = "Murder Weapon: Weave";
        }

        private void TheCornerButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.TheCorner;

            SiteImage.Source = new BitmapImage(new Uri("rooms/thecorner.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: The Corner";
        }

        private void GrowHouseButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.GrowHouse;

            SiteImage.Source = new BitmapImage(new Uri("rooms/growhouse.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: Grow House";
        }

        private void BackAlleyButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.BackAlley;

            SiteImage.Source = new BitmapImage(new Uri("rooms/backalley.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: Back Alley";
        }

        private void BMommasPadButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.BMommasPad;

            SiteImage.Source = new BitmapImage(new Uri("rooms/bmommapad.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: Baby Momma's Pad";
        }

        private void LaundryMatButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.Laundrymat;

            SiteImage.Source = new BitmapImage(new Uri("rooms/laundromat.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: Laundrymat";

        }

        private void PrisonButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.Prison;

            SiteImage.Source = new BitmapImage(new Uri("rooms/localprison.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: Prison";
        }

        private void LightRoomButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.LightRoom;

            SiteImage.Source = new BitmapImage(new Uri("rooms/lightroom.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: Light Room";
        }

        private void KFCButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.KFC;

            SiteImage.Source = new BitmapImage(new Uri("rooms/kfc.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: KFC";
        }

        private void LiquorStoreButton_Click(object sender, RoutedEventArgs e)
        {
            hasRoomBeenPicked = true;
            murderSite = RoomEnum.LiquorStore;

            SiteImage.Source = new BitmapImage(new Uri("rooms/liquorstore.jpg", UriKind.Relative));
            MurderSiteLabel.Content = "Murder Site: The Liquor Store";
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (hasCharacterBeenPicked && hasRoomBeenPicked && hasWeaponBeenPicked)
            {
                suggest = new Suggestion(murderCharacter, murderSite, murderWeapon);

                ParentWin.CurrentSuggestion = suggest;

                ParentWin.DetectiveNotes.Visibility = System.Windows.Visibility.Hidden;
                ParentWin.PlayerHand.Visibility = System.Windows.Visibility.Hidden;
                buttonPromptedClose = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please make sure you have selected a character, a weapon, and a room");
                return;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!buttonPromptedClose)
            {
            
                if (hasCharacterBeenPicked && hasRoomBeenPicked && hasWeaponBeenPicked)
                {
                    MessageBoxResult res = MessageBox.Show("If you close this window your current suggestions will be used as your suggestion is this OK?", "You Sure?", MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.Yes)
                    {
                        suggest = new Suggestion(murderCharacter, murderSite, murderWeapon);

                        ParentWin.CurrentSuggestion = suggest;

                        ParentWin.DetectiveNotes.Visibility = System.Windows.Visibility.Hidden;
                        ParentWin.PlayerHand.Visibility = System.Windows.Visibility.Hidden;

                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    MessageBox.Show("Please make sure you have chosen a character, a weapon, and a room", "Suggestion Incomplete");
                    e.Cancel = true;

                }
            }
        }

        
    }
}
