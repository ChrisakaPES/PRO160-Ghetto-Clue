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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GhettoClue.UserControls
{
	/// <summary>
	/// Interaction logic for BoardGuide.xaml
	/// </summary>
	/// 


	public partial class BoardGuide : UserControl
	{
		public MainWindow MainWin { get; set; }

		private int page = 2;

		public BoardGuide()
		{
			InitializeComponent();
			startBoardGuide();
		}

		private void startBoardGuide()
		{
			downarrow.Visibility = Visibility.Hidden;
			board_helptext.Text = "Movement:\nAfter you roll, the board will mark spaces you can move to in purple.\n\nClick the Next button to continue...";
			board_nextbutton.Visibility = Visibility.Visible;
			board_guidepages.Content = "1 / 4";
		}

		private void NextButtonClick(object sender, RoutedEventArgs e)
		{

			if (page < 5)
			{
				switch (page)
				{
					case 2:
						board_helptext.Text = "To move your piece you must first click it to pick it up.\nIt will disappear, but don't worry you're holding it.\n\nClick the Next button to continue...";
						board_guidepages.Content = "2 / 4";
						break;

					case 3:
						board_helptext.Text = "While holding your piece, click once on any of the purple squares to move it there.\n\nClick the Next button to continue...";
						board_guidepages.Content = "3 / 4";
						break;

					case 4:
						board_helptext.Text = "Go ahead move your piece now!\n(Under the blue arrow)";
						board_hidebutton.Content = "Okay";
						downarrow.Visibility = Visibility.Visible;
						board_nextbutton.Visibility = Visibility.Hidden;
						board_guidepages.Content = "4 / 4";
						break;

					default:
						break;
				}
				page++;
			}
		}

		public void ShowGuide()
		{
			ShowBoardGuide();
		}

		public void HideGuide()
		{
			HideBoardGuide();
		}

		private void ShowBoardGuide()
		{
			ThicknessAnimation slideIn = new ThicknessAnimation();
			slideIn.From = new Thickness(this.ActualWidth, 0, 0, 0);
			slideIn.To = new Thickness(0, 0, 0, 0);
			slideIn.Duration = new Duration(TimeSpan.FromSeconds(.2));
			Storyboard.SetTargetName(slideIn, boardGuideSection.Name);
			Storyboard.SetTargetProperty(slideIn, new PropertyPath(Border.MarginProperty));

			boardGuideSection.Margin = slideIn.From.Value;
			boardGuideSection.Visibility = System.Windows.Visibility.Visible;

			Storyboard sb = new Storyboard();
			sb.Children.Add(slideIn);
			sb.Begin(this);
		}

		private void HideBoardGuide()
		{

			ThicknessAnimation slideIn = new ThicknessAnimation();
			slideIn.From = new Thickness(0, 0, 0, 0);
			slideIn.To = new Thickness(this.ActualWidth, 0, 0, 0);
			slideIn.Duration = new Duration(TimeSpan.FromSeconds(.2));
			Storyboard.SetTargetName(slideIn, boardGuideSection.Name);
			Storyboard.SetTargetProperty(slideIn, new PropertyPath(Border.MarginProperty));

			boardGuideSection.Margin = slideIn.From.Value;

			Storyboard sb = new Storyboard();
			sb.Children.Add(slideIn);
			sb.Completed += (o, ar) =>
			{
				boardGuideSection.Visibility = Visibility.Collapsed;
			};
			sb.Begin(this);

			page = 2;
		}

		private void DoHideBoardGuide(object sender, RoutedEventArgs e)
		{
			HideBoardGuide();
		}

	}
}
