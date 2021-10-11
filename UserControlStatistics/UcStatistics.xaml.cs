using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Logik.UserControlStatistics
{
    /// <summary>
    /// Interaction logic for UcStatistics.xaml
    /// </summary>
    public partial class UcStatistics : UserControl
    {
        //CollectionViewSource cvsStatistics =
        ContentControl ccParent;

        /// <summary>
        /// Statistics
        /// </summary>
        /// <param name="ccParent">parrent content control</param>
        public UcStatistics(ContentControl ccParent)
        {
            InitializeComponent();

            this.ccParent = ccParent;

            //if is any games, hide datagride
            if (MySettings.Statistics.Count == 0)
            {
                dgStatistics.Visibility = Visibility.Collapsed;
                return;
            }
            //dgStatistics.ItemsSource = null;
            dgStatistics.ItemsSource = MySettings.Statistics;
            ICollectionView cvStatistics = CollectionViewSource.GetDefaultView(dgStatistics.ItemsSource);

            if (cvStatistics != null && cvStatistics.CanGroup == true)
            {
                cvStatistics.GroupDescriptions.Clear();
                cvStatistics.GroupDescriptions.Add(new PropertyGroupDescription("Player"));
                //cvStatistics.GroupDescriptions.Add(new PropertyGroupDescription("CodeBroken"));
            }

            //dgStatistics.ItemsSource = MySettings.Statistics;
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            Expander expander = (Expander)sender;

            if (expander.IsExpanded)
            {
                dgStatistics.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.VisibleWhenSelected;
                //MessageBox.Show(dgStatisticsDetail)
            }
            else
            {
                dgStatistics.RowDetailsVisibilityMode = DataGridRowDetailsVisibilityMode.Collapsed;
            }
        }
        /// <summary>
        /// Button back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatisticsBack_Click(object sender, RoutedEventArgs e)
        {
            ccParent.Content = MySettings.ActualContentControl;
        }
    }
}
