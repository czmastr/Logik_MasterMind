using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Logik.Statistics.Convertors
{
    public class NumberOfWinGames : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            string winGames = "-1";
            string namePlayer = (string)value;

            try
            {
                winGames = MySettings.Statistics.Where(x => x.Player == namePlayer && x.CodeBroken == true).Count().ToString() + "/";
            }
            catch
            { }
            return winGames;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
