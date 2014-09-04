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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GhettoClue.UserControls
{
	/// <summary>
	/// Interaction logic for DisprovalPopUpWindow.xaml
	/// </summary>
	public partial class DisprovalPopUpWindow : UserControl
	{
		public DisprovalPopUpWindow()
		{
			InitializeComponent();
		}

		public void Populate_DisproveComboBoxes(Suggestion suggestion)
		{
			//Set the sent choices to instance variables to then be bound to the combobox
			CharacterEnum ch = suggestion.Character;
			RoomEnum rm = suggestion.Room;
			WeaponEnum wp = suggestion.Weapon;

			//CharacterSelection.ItemsSource = ch;
			//RoomSelection.ItemsSource = rm;
			//WeaponSelection.ItemsSource = wp;
		}

		private void DisproveButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
