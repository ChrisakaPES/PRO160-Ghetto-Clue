using GhettoClue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GhettoClue.Converters
{
    public class CharacterToColor: IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush();
            Player p = (Player)value;
            if (p.Name == CharacterEnum.Lafawnduh)
            {
                brush.Color=Colors.Red;
            }
            else if (p.Name == CharacterEnum.DaMarcus)
            {
                brush.Color = Colors.Cyan;
            }
            else if (p.Name == CharacterEnum.Watermelondrea)
            {
                brush.Color = Colors.Green;
            }
            else if (p.Name == CharacterEnum.Jake)
            {
                brush.Color = Colors.BlanchedAlmond;
            }
            else if (p.Name == CharacterEnum.Ladasha)
            {
                brush.Color = Colors.Yellow;
            }
            else if (p.Name == CharacterEnum.JuanCarlos)
            {
                brush.Color = Colors.Orange;
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
