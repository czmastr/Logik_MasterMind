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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Logik.UserControlAboutApp
{
    /// <summary>
    /// Interaction logic for UcAboutApp.xaml
    /// </summary>
    public partial class UcAboutApp : UserControl
    {
        ContentControl ccParent;
        /// <summary>
        /// About app
        /// </summary>
        /// <param name="ccParent">parent content control</param>
        public UcAboutApp(ContentControl ccParent)
        {
            InitializeComponent();

            this.ccParent = ccParent;
        }
        /// <summary>
        /// Button back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAboutAppBack_Click(object sender, RoutedEventArgs e)
        {
            ccParent.Content = MySettings.ActualContentControl;
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
    }
}
