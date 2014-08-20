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
using GhettoClue.Model;

namespace GhettoClue
{
    /// <summary>
    /// Interaction logic for SuggestionPopUpWindow.xaml
    /// </summary>
    public partial class SuggestionPopUpWindow : Window
    {
        public SuggestionPopUpWindow()
        {
            InitializeComponent();

            CharacterComboBox.ItemsSource = Enum.GetValues(typeof(CharacterCards));
            foreach (object o in CharacterComboBox.ItemsSource)
            {
                Console.WriteLine(o.ToString());
            }
            RoomComboBox.ItemsSource = Enum.GetValues(typeof (room));
            WeaponComboBox.ItemsSource = Enum.GetValues(typeof(weapon));


        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Button confirm = (Button)sender;
            ((Window)((StackPanel)confirm.Parent).Parent).Close();
        }
    }
}
