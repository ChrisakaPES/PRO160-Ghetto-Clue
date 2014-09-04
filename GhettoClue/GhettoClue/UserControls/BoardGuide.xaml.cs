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
	public partial class BoardGuide : UserControl
	{
		public BoardGuide()
		{
			InitializeComponent();
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
		}

		private void DoHideBoardGuide(object sender, RoutedEventArgs e)
		{
			HideBoardGuide();
		}
	}
}
