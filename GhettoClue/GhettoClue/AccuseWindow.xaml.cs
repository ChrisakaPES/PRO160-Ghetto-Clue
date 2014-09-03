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
    /// Interaction logic for AccuseWindow.xaml
    /// </summary>
    public partial class AccuseWindow : Window
    {
        public MainWindow ParentWin { get; set; }
        public Player CurrentPlayer { get; set; }

        public AccuseWindow()
        {

            InitializeComponent();
            this.DataContext = this;
            CharacterComboBox.ItemsSource = Enum.GetValues(typeof(CharacterEnum));
            //foreach (object o in CharacterComboBox.ItemsSource)
            //{
            //    Console.WriteLine(o.ToString());
            //}
            RoomComboBox.ItemsSource = Enum.GetValues(typeof(RoomEnum));
            WeaponComboBox.ItemsSource = Enum.GetValues(typeof(WeaponEnum));
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            CharacterEnum suspect = (CharacterEnum)CharacterComboBox.SelectedItem;
            RoomEnum suspectedMurderScene = (RoomEnum)RoomComboBox.SelectedItem;
            WeaponEnum suspectedMurderWeapon = (WeaponEnum)WeaponComboBox.SelectedItem;

            Accusation acc = new Accusation(suspect, suspectedMurderScene, suspectedMurderWeapon);

            ParentWin.CurrentAccusation = acc;


            this.Close();
        }
    }
}
