using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Logik.Statistics.Convertors
{
    public class BestTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            bool isBestTime = bool.Parse(parameter.ToString()); //TRUE best time; FALSE number of moves
            string output = ""; //error
            string namePlayer = (string)value;

            try
            {
                if (isBestTime)
                {
                    output = "        ";
                    output = MySettings.Statistics.Where(x => x.Player == namePlayer && x.CodeBroken == true).Min(x => x.ElapsedTime).ToString("HH:mm:ss");
                }
                else
                {
                    //output = "";
                    output = MySettings.Statistics.Where(x => x.Player == namePlayer && x.CodeBroken == true).Min(x => x.NumberOfMoves).ToString();
                }
            }
            catch
            { }
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
