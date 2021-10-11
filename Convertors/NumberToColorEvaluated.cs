using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Logik.Convertors
{
    class NumberToColorEvaluated : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            try
            {
                int number = int.Parse(value.ToString()); //vstup je cislo

                switch (number)
                {
                    case 1: //1 = bila
                        return Brushes.White;

                    case 2: //2 = cerna
                        return Brushes.Black;


                    default:
                        return Brushes.Transparent; //-1
                }
            }
            catch
            {
                return Brushes.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}