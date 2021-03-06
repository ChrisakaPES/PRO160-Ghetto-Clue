﻿using System;
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

namespace GhettoClue
{
    /// <summary>
    /// Interaction logic for SuggestionPopUpWindow.xaml
    /// </summary>
    public partial class SuggestionPopUpWindow : Window
    {
        public MainWindow ParentWin { get; set; }
        public Player currentPlayer { get; set; }
        public SuggestionPopUpWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CharacterComboBox.ItemsSource = Enum.GetValues(typeof(CharacterEnum));
            foreach (object o in CharacterComboBox.ItemsSource)
            {
                Console.WriteLine(o.ToString());
            }
            RoomComboBox.ItemsSource = Enum.GetValues(typeof (RoomEnum));
            WeaponComboBox.ItemsSource = Enum.GetValues(typeof(WeaponEnum));



        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Button confirm = (Button)sender;
            if (CharacterComboBox.SelectedIndex == -1 || RoomComboBox.SelectedIndex==-1 || WeaponComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please make sure all three combo boxes are selected.");
                return;
            }
            CharacterEnum suspect = (CharacterEnum)CharacterComboBox.SelectedItem;
            RoomEnum suspectedMurderScene = (RoomEnum)RoomComboBox.SelectedItem;
            WeaponEnum suspectedMurderWeapon = (WeaponEnum)WeaponComboBox.SelectedItem;

            Suggestion suggest = new Suggestion(suspect, suspectedMurderScene, suspectedMurderWeapon);

            ParentWin.CurrentSuggestion = suggest;

            ParentWin.DetectiveNotes.Visibility = System.Windows.Visibility.Hidden;
            ParentWin.PlayerHand.Visibility = System.Windows.Visibility.Hidden;

            ((Window)((StackPanel)confirm.Parent).Parent).Close();
        }

    }
}
