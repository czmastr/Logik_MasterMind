using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Logik.Resources
{
    public static class LanguageChange
    {
        /// <summary>
        /// Change language in app
        /// </summary>
        /// <param name="lang">language (TRUE = CZ; FALSE = ENG)</param>
        public static void Language(bool lang)
        {
            try
            {
                MySettings.SelectedLanguageCz = lang;

                ResourceDictionary dict = new ResourceDictionary();

                //CZ
                if(MySettings.SelectedLanguageCz == true)
                {
                    dict.Source = new Uri("..\\Resources\\LanguageCz.xaml", UriKind.Relative);
                }
                else //ENG
                {
                    dict.Source = new Uri("..\\Resources\\LanguageEng.xaml", UriKind.Relative);
                }

                //delete dictionary
                Application.Current.Resources.MergedDictionaries.Clear();

                //add dictionary
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
            catch(Exception ex)
            { }
        }
    }
}
