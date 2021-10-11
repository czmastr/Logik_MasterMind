using Logik.UserControlFigures;
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

namespace Logik.UserControlGameField.Field4
{
    /// <summary>
    /// Interaction logic for UcGameField4.xaml
    /// </summary>
    public partial class UcGameField4 : UserControl
    {
        UcBase4 ucBase4;

        public UcGameField4()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Uc game fields 4 
        /// </summary>        
        /// <param name="gamePlay">play game</param>
        public UcGameField4(bool gamePlay)
        {
            InitializeComponent();

            //play with 4 fields

            //BASE (CODE)
            ucBase4 = new UcBase4(gamePlay);
            ccBase.Content = ucBase4; 

            UcFigures8 ucFigures8 = new UcFigures8();
            UcFigures7 ucFigures7 = new UcFigures7();
            UcFigures6 ucFigures6 = new UcFigures6();
            UcFigures5 ucFigures5 = new UcFigures5();


            //switch content by number of colors
            switch (MySettings.ChoosenCountOfColors)
            {
                case 5:
                    ccUser.Content = ucFigures5;
                    NumberOfColors5(ucFigures5);
                    break;

                case 6:
                    ccUser.Content = ucFigures6;
                    NumberOfColors6(ucFigures6);
                    break;

                case 7:
                    ccUser.Content = ucFigures7;
                    NumberOfColors7(ucFigures7);
                    break;

                case 8:
                    ccUser.Content = ucFigures8;
                    NumberOfColors8(ucFigures8);
                    break;
            }
        }


        /// <summary>
        /// User figures of 5 colors
        /// </summary>
        /// <param name="ucFigures">5 colors</param>
        private void NumberOfColors5(UcFigures5 ucFigures)
        {
            cc01.Content = new UcField4(ucBase4, ucFigures, false, 1);
            cc02.Content = new UcField4(ucBase4, ucFigures, false, 2);
            cc03.Content = new UcField4(ucBase4, ucFigures, false, 3);
            cc04.Content = new UcField4(ucBase4, ucFigures, false, 4);
            cc05.Content = new UcField4(ucBase4, ucFigures, false, 5);
            cc06.Content = new UcField4(ucBase4, ucFigures, false, 6);
            cc07.Content = new UcField4(ucBase4, ucFigures, false, 7);
            cc08.Content = new UcField4(ucBase4, ucFigures, false, 8);
            cc09.Content = new UcField4(ucBase4, ucFigures, false, 9);
            cc10.Content = new UcField4(ucBase4, ucFigures, true, 10);
        }

        /// <summary>
        /// User figures of 6 colors
        /// </summary>
        /// <param name="ucFigures">6 colors</param>
        private void NumberOfColors6(UcFigures6 ucFigures)
        {
            cc01.Content = new UcField4(ucBase4, ucFigures, false, 1);
            cc02.Content = new UcField4(ucBase4, ucFigures, false, 2);
            cc03.Content = new UcField4(ucBase4, ucFigures, false, 3);
            cc04.Content = new UcField4(ucBase4, ucFigures, false, 4);
            cc05.Content = new UcField4(ucBase4, ucFigures, false, 5);
            cc06.Content = new UcField4(ucBase4, ucFigures, false, 6);
            cc07.Content = new UcField4(ucBase4, ucFigures, false, 7);
            cc08.Content = new UcField4(ucBase4, ucFigures, false, 8);
            cc09.Content = new UcField4(ucBase4, ucFigures, false, 9);
            cc10.Content = new UcField4(ucBase4, ucFigures, true, 10);
        }

        /// <summary>
        /// User figures of 7 colors
        /// </summary>
        /// <param name="ucFigures">7 colors</param>
        private void NumberOfColors7(UcFigures7 ucFigures)
        {
            cc01.Content = new UcField4(ucBase4, ucFigures, false, 1);
            cc02.Content = new UcField4(ucBase4, ucFigures, false, 2);
            cc03.Content = new UcField4(ucBase4, ucFigures, false, 3);
            cc04.Content = new UcField4(ucBase4, ucFigures, false, 4);
            cc05.Content = new UcField4(ucBase4, ucFigures, false, 5);
            cc06.Content = new UcField4(ucBase4, ucFigures, false, 6);
            cc07.Content = new UcField4(ucBase4, ucFigures, false, 7);
            cc08.Content = new UcField4(ucBase4, ucFigures, false, 8);
            cc09.Content = new UcField4(ucBase4, ucFigures, false, 9);
            cc10.Content = new UcField4(ucBase4, ucFigures, true, 10);
        }


        /// <summary>
        /// User figures of 8 colors
        /// </summary>
        /// <param name="ucFigures">8 colors</param>
        private void NumberOfColors8(UcFigures8 ucFigures)
        {
            cc01.Content = new UcField4(ucBase4, ucFigures, false, 1);
            cc02.Content = new UcField4(ucBase4, ucFigures, false, 2);
            cc03.Content = new UcField4(ucBase4, ucFigures, false, 3);
            cc04.Content = new UcField4(ucBase4, ucFigures, false, 4);
            cc05.Content = new UcField4(ucBase4, ucFigures, false, 5);
            cc06.Content = new UcField4(ucBase4, ucFigures, false, 6);
            cc07.Content = new UcField4(ucBase4, ucFigures, false, 7);
            cc08.Content = new UcField4(ucBase4, ucFigures, false, 8);
            cc09.Content = new UcField4(ucBase4, ucFigures, false, 9);
            cc10.Content = new UcField4(ucBase4, ucFigures, true, 10);
        }
    }
}
