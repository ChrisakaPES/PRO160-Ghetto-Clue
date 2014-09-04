using GhettoClue.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DisprovePopUp.xaml
    /// </summary>
    public partial class DisprovePopUp : Window
    {
        public Player disprovingPlayer { get; set; }
        public MainWindow ParentWin { get; set; }
        public ObservableCollection<string> listOfCards { get; set; }
        

        public DisprovePopUp()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }
        public DisprovePopUp(Player p, Suggestion sug)
        {
            InitializeComponent();
            this.DataContext = this;
            listOfCards = new ObservableCollection<string>();
            disprovingPlayer = p;

            foreach (CharacterEnum c in p.characterCards)
            {
                if (c.ToString() == sug.Character.ToString())
                {
                    listOfCards.Add(c.ToString());
                }
            }
            foreach (RoomEnum r in p.roomCards)
            {
                if (r.ToString() == sug.Room.ToString())
                {
                    listOfCards.Add(r.ToString());
                }
            }
            foreach (WeaponEnum w in p.weaponCards)
            {
                if (w.ToString() == sug.Weapon.ToString())
                {
                    listOfCards.Add(w.ToString());
                }
            }

            matchingCardsComboBox.ItemsSource = listOfCards;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (matchingCardsComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Card from the List");
                return;
            }

            MessageBox.Show("Please prepare to show the current player the card you chose.");
            ParentWin.DetectiveNotes.Visibility = System.Windows.Visibility.Visible;
            ParentWin.PlayerHand.Visibility = System.Windows.Visibility.Visible;
            this.Close();
            MessageBox.Show(matchingCardsComboBox.SelectedItem.ToString());

        }



    }
}
