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
	/// Interaction logic for UserGuide.xaml
	/// </summary>
	public partial class UserGuide : UserControl
	{
		public UserGuide()
		{
			InitializeComponent();
		}

		private void ShowUserGuide()
		{
				ThicknessAnimation slideIn = new ThicknessAnimation();
				slideIn.From = new Thickness(this.ActualWidth, 0, 0, 0);
				slideIn.To = new Thickness(0, 0, 0, 0);
				slideIn.Duration = new Duration(TimeSpan.FromSeconds(.2));
				Storyboard.SetTargetName(slideIn, userGuideSection.Name);
				Storyboard.SetTargetProperty(slideIn, new PropertyPath(Border.MarginProperty));

				userGuideSection.Margin = slideIn.From.Value;
				userGuideSection.Visibility = System.Windows.Visibility.Visible;

				Storyboard sb = new Storyboard();
				sb.Children.Add(slideIn);
				sb.Begin(this);
		}

		private void HideUserGuide()
		{
			ThicknessAnimation slideIn = new ThicknessAnimation();
			slideIn.From = new Thickness(0, 0, 0, 0);
			slideIn.To = new Thickness(this.ActualWidth, 0, 0, 0);
			slideIn.Duration = new Duration(TimeSpan.FromSeconds(.2));
			Storyboard.SetTargetName(slideIn, userGuideSection.Name);
			Storyboard.SetTargetProperty(slideIn, new PropertyPath(Border.MarginProperty));

			userGuideSection.Margin = slideIn.From.Value;

			Storyboard sb = new Storyboard();
			sb.Children.Add(slideIn);
			sb.Completed += (o, ar) =>
			{
				userGuideSection.Visibility = Visibility.Collapsed;
			};
			sb.Begin(this);
		}

		private void DoHideUserGuide(object sender, RoutedEventArgs e)
		{
			HideUserGuide();
		}

		private void CanvasClick(object sender, MouseButtonEventArgs e)
		{
			ShowUserGuide();
		}

	}
}
