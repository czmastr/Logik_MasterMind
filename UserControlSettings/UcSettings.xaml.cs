using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Logik.UserControlSettings
{
    /// <summary>
    /// Interaction logic for UcSettings.xaml
    /// </summary>
    public partial class UcSettings : UserControl
    {
        private ContentControl ccParent;


        public UcSettings(ContentControl ccParent)
        {
            InitializeComponent();

            this.ccParent = ccParent;

            chbSettingRepeatingColor.IsChecked = MySettings.RepeatColor;
            chbSettingsEmptyFigure.IsChecked = MySettings.EmptyFigure;
            chbCryptoMode.IsChecked = MySettings.CryptoMode;
            chbSettingsFillAllLine.IsChecked = MySettings.FillAllLine;

            try
            {                
                tbSettingsPathToStatistics.Text = MySettings.PathToStatisticsFolder;
            }
            catch
            { }

            LoadSelectedField();
            LoadSelectedColor();



        }
        /// <summary>
        /// Load selected number of fields
        /// </summary>
        private void LoadSelectedField()
        {
            switch (MySettings.ChoosenCountOfFields)
            {
                case 3:
                    rbSettingsField3.IsChecked = true;
                    break;

                case 4:
                    rbSettingsField4.IsChecked = true;
                    break;

                case 5:
                    rbSettingsField5.IsChecked = true;
                    break;
            }
        }
        /// <summary>
        /// Load selected color
        /// </summary>
        private void LoadSelectedColor()
        {
            switch (MySettings.ChoosenCountOfColors)
            {
                case 5:
                    rbSettingsColors5.IsChecked = true;
                    break;

                case 6:
                    rbSettingsColors6.IsChecked = true;
                    break;

                case 7:
                    rbSettingsColors7.IsChecked = true;
                    break;

                case 8:
                    rbSettingsColors8.IsChecked = true;
                    break;
            }
        }


        /// <summary>
        /// Choose number of field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSettingsField_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            MySettings.ChoosenCountOfFields = int.Parse(rb.Content.ToString());

            ////choose more then 5 colors
            //if (MySettings.ChoosenCountOfFileds == 5)
            //{
            //    //if (rbSettingsColors5.IsChecked.Value == true)
            //    //    rbSettingsColors6.IsChecked = true;

            //    rbSettingsColors5.IsEnabled = false;
            //}
            //else
            //{
            //    rbSettingsColors5.IsEnabled = true;
            //}
        }

        /// <summary>
        /// Choose number of colors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbSettingsColors_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            MySettings.ChoosenCountOfColors = int.Parse(rb.Content.ToString());
        }

        /// <summary>
        /// Repeat color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSettingRepeatingColor_Checked(object sender, RoutedEventArgs e)
        {
            MySettings.RepeatColor = true;
        }
        /// <summary>
        /// cant repeat color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSettingRepeatingColor_Unchecked(object sender, RoutedEventArgs e)
        {
            MySettings.RepeatColor = false;
        }


        /// <summary>
        /// empty figure use in code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSettingsEmptyFigure_Checked(object sender, RoutedEventArgs e)
        {
            MySettings.EmptyFigure = true;
        }
        /// <summary>
        /// Cant use empty figure in code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSettingsEmptyFigure_Unchecked(object sender, RoutedEventArgs e)
        {
            MySettings.EmptyFigure = false;
        }
        /// <summary>
        /// Turn on crypto mode (figures as image of crypto)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbCryptoMode_Checked(object sender, RoutedEventArgs e)
        {
            MySettings.CryptoMode = true;
            spAboutCrypto.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Turn of cryptomode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbCryptoMode_Unchecked(object sender, RoutedEventArgs e)
        {
            MySettings.CryptoMode = false;
            spAboutCrypto.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Button back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettingsBack_Click(object sender, RoutedEventArgs e)
        {
            ccParent.Content = MySettings.ActualContentControl;
        }
        /// <summary>
        /// Change folder for statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettingsSavePathToStatistics_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
                fbd.ShowDialog();

                if (string.IsNullOrEmpty(fbd.SelectedPath))
                    return;

                MySettings.PathToStatisticsFolder = fbd.SelectedPath;
                tbSettingsPathToStatistics.Text = MySettings.PathToStatisticsFolder;
            }
            catch
            { }


            //folder
            //if (string.IsNullOrEmpty(tbSettingsPathToStatistics.Text) == false)
            //    MySettings.PathToStatistics = tbSettingsPathToStatistics.Text;
        }
        /// <summary>
        /// Hyperlink
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            MySettings.Hyperlink(e.Uri);
        }
        /// <summary>
        /// Fill all line by figures (true)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSettingsFillAllLine_Checked(object sender, RoutedEventArgs e)
        {
            MySettings.FillAllLine = true;
        }
        /// <summary>
        /// Fill all line by figures (false)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSettingsFillAllLine_Unchecked(object sender, RoutedEventArgs e)
        {
            MySettings.FillAllLine = false;
        }
    }
}
