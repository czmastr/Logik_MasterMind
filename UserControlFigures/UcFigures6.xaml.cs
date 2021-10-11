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
using Logik.SoundUtility;

namespace Logik.UserControlFigures
{
    /// <summary>
    /// Interaction logic for UcFigures6.xaml
    /// </summary>
    public partial class UcFigures6 : UserControl
    {
        //start point from mouse
        private Point startPoint;

        /// <summary>
        /// User control of figure of 6 (bottom - user choose colors)
        /// </summary>
        public UcFigures6()
        {
            InitializeComponent();

            //last.Width = ColumnDefinition.WidthProperty.;

            tbUser0.Text = "1";
            tbUser1.Text = "2";
            tbUser2.Text = "3";
            tbUser3.Text = "4";
            tbUser4.Text = "5";
            tbUser5.Text = "6";
        }

        /// <summary>
        /// Mouse move (drag drop)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUser_MouseMove(object sender, MouseEventArgs e)
        {
            //position of mouse and difference
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            //if left mouse button is pressed and min drag disnace is OK
            if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {                
                TextBlock tb = sender as TextBlock; //convert sender as Texblock
                TextBlock t = (TextBlock)e.Source; //source of event

                //do drag drop (copy)
                DragDrop.DoDragDrop(tb, t.Text, DragDropEffects.Copy);
            }
        }

        /// <summary>
        /// Set the position of mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //save position
            startPoint = e.GetPosition(null);
        }

        /// <summary>
        /// If checked = collapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbHide_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chb = (CheckBox)sender;
            int positionUserFigure = int.Parse( chb.Name.Substring(chb.Name.Length-1, 1));

            switch (positionUserFigure)
            {
                case 0:
                    gridFigure0.Visibility = Visibility.Collapsed;
                    break;

                case 1:
                    gridFigure1.Visibility = Visibility.Collapsed;
                    break;

                case 2:
                    gridFigure2.Visibility = Visibility.Collapsed;
                    break;

                case 3:
                    gridFigure3.Visibility = Visibility.Collapsed;
                    break;

                case 4:
                    gridFigure4.Visibility = Visibility.Collapsed;
                    break;

                case 5:
                    gridFigure5.Visibility = Visibility.Collapsed;
                    break;
            }

        }
        /// <summary>
        /// Unchecked = visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbHide_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chb = (CheckBox)sender;
            int positionUserFigure = int.Parse(chb.Name.Substring(chb.Name.Length - 1, 1));

            switch (positionUserFigure)
            {
                case 0:
                    gridFigure0.Visibility = Visibility.Visible;
                    break;

                case 1:
                    gridFigure1.Visibility = Visibility.Visible;
                    break;

                case 2:
                    gridFigure2.Visibility = Visibility.Visible;
                    break;

                case 3:
                    gridFigure3.Visibility = Visibility.Visible;
                    break;

                case 4:
                    gridFigure4.Visibility = Visibility.Visible;
                    break;

                case 5:
                    gridFigure5.Visibility = Visibility.Visible;
                    break;
            }
        }

        /// <summary>
        /// Visible all figures
        /// </summary>
        public void VisibleAllUserFigures()
        {
            gridFigure0.Visibility = Visibility.Visible;
            gridFigure1.Visibility = Visibility.Visible;
            gridFigure2.Visibility = Visibility.Visible;
            gridFigure3.Visibility = Visibility.Visible;
            gridFigure4.Visibility = Visibility.Visible;
            gridFigure5.Visibility = Visibility.Visible;

            chbHide0.IsChecked = false;
            chbHide1.IsChecked = false;
            chbHide2.IsChecked = false;
            chbHide3.IsChecked = false;
            chbHide4.IsChecked = false;
            chbHide5.IsChecked = false;
        }
    }
}
