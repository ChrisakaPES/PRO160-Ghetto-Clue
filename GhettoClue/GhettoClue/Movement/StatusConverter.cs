using GhettoClue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GhettoClue.Movement
{
    public class StatusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush();

            Player current = (Player)values[6];

            if ((bool)values[0])
            {
                if (current.Name == CharacterEnum.Lafawnduh)
                {
                    brush.Color = Colors.Red;
                }
                else if (current.Name == CharacterEnum.DaMarcus)
                {
                    brush.Color = Colors.Cyan;
                }
                else if (current.Name == CharacterEnum.Ladasha)
                {
                    brush.Color = Colors.Yellow;
                }
                else if (current.Name == CharacterEnum.Watermelondrea)
                {
                    brush.Color = Colors.Green;
                }
                else if (current.Name == CharacterEnum.Jake)
                {
                    brush.Color = Colors.BlanchedAlmond;
                }
                else if (current.Name == CharacterEnum.JuanCarlos)
                {
                    brush.Color = Colors.Orange;
                }
                else
                {
                    brush.Color = Colors.DarkGray;
                }
            }
            //}
            //else if ((bool)values[1])
            //{
            //    brush.Color = Colors.White;
            //    //Room
            //}
            else if ((bool)values[2])
            {
                brush.Color = Colors.Brown;
                //Avalable
            }
            else if ((bool)values[3])
            {
                brush.Color = Colors.Gray;
                //Open
            }
            else if ((bool)values[4])
            {
                brush.Color = Colors.Purple;
            }
            else if ((bool)values[5])
            {
                brush.Color = Colors.DarkGray;
            }
            else
            {
                brush.Color = Colors.White;
            }

            return brush;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
