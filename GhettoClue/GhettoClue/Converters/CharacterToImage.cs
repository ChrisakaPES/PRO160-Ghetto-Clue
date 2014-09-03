using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using GhettoClue.Models;
using System.Windows.Media.Imaging;
namespace GhettoClue.Converters
{
    public class CharacterToImage: IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageBrush brush = new ImageBrush();
            Player p = (Player)value;
            if (p.Name == CharacterEnum.Lafawnduh)
            {
                brush.ImageSource = new BitmapImage(new Uri("CharacterPictures/lawfawnda.jpg", UriKind.Relative));
            }
            else if (p.Name == CharacterEnum.DaMarcus)
            {
                brush.ImageSource = new BitmapImage(new Uri("CharacterPictures/demarcus.jpg", UriKind.Relative));
            }
            else if (p.Name == CharacterEnum.Watermelondrea)
            {
                brush.ImageSource = new BitmapImage(new Uri("CharacterPictures/watermelondrea.jpg", UriKind.Relative));
            }
            else if (p.Name == CharacterEnum.Jake)
            {
                brush.ImageSource = new BitmapImage(new Uri("CharacterPictures/jake.jpg", UriKind.Relative));
            }
            else if (p.Name == CharacterEnum.Ladasha)
            {
                brush.ImageSource = new BitmapImage(new Uri("CharacterPictures/la-a.jpg", UriKind.Relative));
            }
            else if (p.Name == CharacterEnum.JuanCarlos)
            {
                brush.ImageSource = new BitmapImage(new Uri("CharacterPictures/juancarlos.jpg", UriKind.Relative));
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
