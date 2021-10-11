using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Logik.Windows
{
    /// <summary>
    /// Interaction logic for wPlayerName.xaml
    /// </summary>
    public partial class wPlayerName : Window
    {
        public string PlayerName { get; private set; } = null;

        public wPlayerName()
        {
            InitializeComponent();
            tbPlayerName.Text = null;
            tbPlayerName.Focus();

            cmbSelectPlayer.ItemsSource = MySettings.Statistics.Select(x => x.Player).Distinct().ToList();
        }

        /// <summary>
        /// save player name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveName_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPlayerName.Text))
                return;

            PlayerName = tbPlayerName.Text;
            this.Close();
        }

        /// <summary>
        /// default name Player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefaultName_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Press enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPlayerName_KeyDown(object sender, KeyEventArgs e)
        {
            //enter key
            if (e.Key == Key.Enter)
                btnSaveName_Click(null, null);
        }
        /// <summary>
        /// Selected name of player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSelectPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbSelectPlayer.SelectedIndex> -1)
            {
                tbPlayerName.Text = cmbSelectPlayer.SelectedValue.ToString();
            }
        }
    }
}
