﻿using System;
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

namespace Logik.UserControlGameField.Field5
{
    /// <summary>
    /// Interaction logic for UcBase5.xaml
    /// </summary>
    public partial class UcBase5 : UserControl
    {
        /// <summary>
        /// Constructor (CODE)
        /// </summary>
        public UcBase5()
        {
            InitializeComponent();
        }

        /// <summary>
        /// User control base (CODE)
        /// </summary>        
        /// <param name="gamePlay">play game</param>
        public UcBase5(bool gamePlay)
        {
            InitializeComponent();

            //if is game in play mode
            if(gamePlay)
            {               
                gridCover.Visibility = Visibility.Visible; //grid cover is cover
                gridBase.Visibility = Visibility.Collapsed; //code is collapsed

                if (MySettings.CryptoMode)
                {
                    labelHodl.Visibility = Visibility.Visible;
                }
                else
                {
                    labelHodl.Visibility = Visibility.Collapsed;
                }
            }

            //insert code into base field
            tbInput0.Text = MySettings.BaseFieldFigure[0].ToString();
            tbInput1.Text = MySettings.BaseFieldFigure[1].ToString();
            tbInput2.Text = MySettings.BaseFieldFigure[2].ToString();
            tbInput3.Text = MySettings.BaseFieldFigure[3].ToString();
            tbInput4.Text = MySettings.BaseFieldFigure[4].ToString();

        }

        //COMMENT IT
        /// <summary>
        /// Hack for uncover code (for testing)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCover_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            gridBase.Visibility = Visibility.Visible;
            gridCover.Visibility = Visibility.Collapsed;
        }
    }
}
