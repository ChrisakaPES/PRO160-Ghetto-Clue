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
            Player p = (Player)value;
            if (p.Name == CharacterEnum.Lafawnduh)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("Character Pictures/lafawnda.jpg", UriKind.Relative);
                bi3.EndInit();
                return bi3;
            }
            else if (p.Name == CharacterEnum.DaMarcus)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("Character Pictures/demarcas.jpg", UriKind.Relative);
                bi3.EndInit();
                return bi3;
            }
            else if (p.Name == CharacterEnum.Watermelondrea)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("Character Pictures/watermelondrea.jpg", UriKind.Relative);
                bi3.EndInit();
                return bi3;
            }
            else if (p.Name == CharacterEnum.Jake)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("Character Pictures/jake.jpg", UriKind.Relative);
                bi3.EndInit();
                return bi3;
            }
            else if (p.Name == CharacterEnum.Ladasha)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("Character Pictures/la-a.jpg", UriKind.Relative);
                bi3.EndInit();
                return bi3;
            }
            else if (p.Name == CharacterEnum.JuanCarlos)
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("Character Pictures/juancarlos.jpg", UriKind.Relative);
                bi3.EndInit();
                return bi3;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
