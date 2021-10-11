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
    public class NumberToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            try
            {
                int number = int.Parse(value.ToString()); //vstup je cislo
                string packUri;

                switch (number)
                {
                    case 1:
                        if (MySettings.CryptoMode == true)
                        {
                            packUri = "pack://application:,,,/Logik;component/Images/btc.png";
                            ImageSource im = (ImageSource)new ImageSourceConverter().ConvertFromString(packUri);
                            ImageBrush ib = new ImageBrush(im);
                            return ib;
                        }
                        else
                        {
                            return Brushes.Green;
                        }

                    case 2:
                        if (MySettings.CryptoMode == true)
                        {
                            packUri = "pack://application:,,,/Logik;component/Images/eth.png";
                            ImageSource im = (ImageSource)new ImageSourceConverter().ConvertFromString(packUri);
                            ImageBrush ib = new ImageBrush(im);
                            return ib;
                        }
                        else
                        {
                            return Brushes.Yellow;
                        }                        

                    case 3:
                        if (MySettings.CryptoMode == true)
                        {
                            packUri = "pack://application:,,,/Logik;component/Images/ltc.png";
                            ImageSource im = (ImageSource)new ImageSourceConverter().ConvertFromString(packUri);
                            ImageBrush ib = new ImageBrush(im);
                            return ib;
                        }
                        else
                        {                            
                            return Brushes.Blue;
                        }                        

                    case 4:
                        if (MySettings.CryptoMode == true)
                        {
                            packUri = "pack://application:,,,/Logik;component/Images/link.png";
                            ImageSource im = (ImageSource)new ImageSourceConverter().ConvertFromString(packUri);
                            ImageBrush ib = new ImageBrush(im);
                            return ib;
                        }
                        else
                        {
                            return Brushes.Red;
                        }                        

                    case 5:
                        if (MySettings.CryptoMode == true)
                        {
                            packUri = "pack://application:,,,/Logik;component/Images/monero.png";
                            ImageSource im = (ImageSource)new ImageSourceConverter().ConvertFromString(packUri);
                            ImageBrush ib = new ImageBrush(im);
                            return ib;
                        }
                        else
                        {
                            return Brushes.Black;
                        }
                        
                    case 6:
                        if (MySettings.CryptoMode == true)
                        {
                            packUri = "pack://application:,,,/Logik;component/Images/cardano.png";
                            ImageSource im = (ImageSource)new ImageSourceConverter().ConvertFromString(packUri);
                            ImageBrush ib = new ImageBrush(im);
                            return ib;
                        }
                        else
                        {
                            return Brushes.White;
                        }                        

                    case 7:
                        if (MySettings.CryptoMode == true)
                        {
                            packUri = "pack://application:,,,/Logik;component/Images/dot.png";
                            ImageSource im = (ImageSource)new ImageSourceConverter().ConvertFromString(packUri);
                            ImageBrush ib = new ImageBrush(im);
                            return ib;
                        }
                        else
                        {
                            return Brushes.Gray;
                        }                        

                    case 8:
                        if (MySettings.CryptoMode == true)
                        {
                            packUri = "pack://application:,,,/Logik;component/Images/bat.png";
                            ImageSource im = (ImageSource)new ImageSourceConverter().ConvertFromString(packUri);
                            ImageBrush ib = new ImageBrush(im);
                            return ib;
                        }
                        else
                        {
                            return Brushes.Orange;
                        }                        

                    default:
                        return Brushes.Transparent;
                }
            }
            catch(Exception ex)
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
