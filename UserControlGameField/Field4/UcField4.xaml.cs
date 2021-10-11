using Logik.Logic;
using Logik.UserControlFigures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Field4.xaml
    /// </summary>
    public partial class UcField4 : UserControl
    {        
        EvaluatedLogic logic = new EvaluatedLogic(); //class evaluated logic
        UcBase4 ucBase4; //uc base = code
        bool isFinalLine; //is final line
        int numberOfLine;

        UcFigures5 uc5;
        UcFigures6 uc6;
        UcFigures7 uc7;
        UcFigures8 uc8;

        private Point startPoint; //start position of mouse

        /// <summary>
        /// User control one line (4 fields)
        /// </summary>
        /// <param name="base4">base field 4 (code)</param>
        /// <param name="isFinalLine">is final line</param>
        public UcField4(UcBase4 base4, bool isFinalLine)
        {
            InitializeComponent();
            this.ucBase4 = base4;
            this.isFinalLine = isFinalLine;
        }


        /// <summary>
        /// User control one line (4 fields)
        /// </summary>
        /// <param name="base4">base field 4 (code)</param>
        /// <param name="uc">user field with 5 colors</param>
        /// <param name="isFinalLine">is final line</param>
        /// <param name="numberOfLine">number of line</param>
        public UcField4(UcBase4 base4, UcFigures5 uc, bool isFinalLine, int numberOfLine)
        {
            InitializeComponent();
            this.ucBase4 = base4;
            this.isFinalLine = isFinalLine;
            this.uc5 = uc;
            this.numberOfLine = numberOfLine;
        }

        /// <summary>
        /// User control one line (4 fields)
        /// </summary>
        /// <param name="base4">base field 4 (code)</param>
        /// <param name="uc">user field with 6 colors</param>
        /// <param name="isFinalLine">is final line</param>
        /// <param name="numberOfLine">number of line</param>
        public UcField4(UcBase4 base4, UcFigures6 uc, bool isFinalLine, int numberOfLine)
        {
            InitializeComponent();
            this.ucBase4 = base4;
            this.isFinalLine = isFinalLine;
            this.uc6 = uc;
            this.numberOfLine = numberOfLine;
        }

        /// <summary>
        /// User control one line (4 fields)
        /// </summary>
        /// <param name="base4">base field 4 (code)</param>
        /// <param name="uc">user field with 7 colors</param>
        /// <param name="isFinalLine">is final line</param>
        /// <param name="numberOfLine">number of line</param>
        public UcField4(UcBase4 base4, UcFigures7 uc, bool isFinalLine, int numberOfLine)
        {
            InitializeComponent();
            this.ucBase4 = base4;
            this.isFinalLine = isFinalLine;
            this.uc7 = uc;
            this.numberOfLine = numberOfLine;
        }

        /// <summary>
        /// User control one line (4 fields)
        /// </summary>
        /// <param name="base4">base field 4 (code)</param>
        /// <param name="uc">user field with 8 colors</param>
        /// <param name="isFinalLine">is final line</param>
        /// <param name="numberOfLine">number of line</param>
        public UcField4(UcBase4 base4, UcFigures8 uc, bool isFinalLine, int numberOfLine)
        {
            InitializeComponent();
            this.ucBase4 = base4;
            this.isFinalLine = isFinalLine;
            this.uc8 = uc;
            this.numberOfLine = numberOfLine;
        }

        /// <summary>
        /// Drag enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_DragEnter(object sender, DragEventArgs e)
        {
            //if sender = source do nothing
            if(sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        /// <summary>
        /// drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Drop(object sender, DragEventArgs e)
        {
            //sender as textblock
            TextBlock tb = (TextBlock)sender;            
            tb.Text = e.Data.GetData(DataFormats.Text) as string; //pass on value

            //if sound is turn on
            if (MySettings.SoundOn)
                MySettings.PlaySound(true);
        }

        /// <summary>
        /// Confirm line and evaluted it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Line1Done_Checked(object sender, RoutedEventArgs e)
        {
            //convert the value from texblock
            int.TryParse(tb0.Text, out int value0);
            int.TryParse(tb1.Text, out int value1);
            int.TryParse(tb2.Text,out int value2);            
            int.TryParse(tb3.Text, out int value3);

            //new field of values
            int[] field = new int[] { value0, value1, value2, value3 };

            //if is not filled all line and is not turn on empty figure
            if (MySettings.FillAllLine && MySettings.EmptyFigure == false)
            {
                for (int i = 0; i < field.Count(); i++)
                {
                    if (field[i] == 0)
                    {
                        MessageBox.Show(Application.Current.Resources.MergedDictionaries[0]["LanguageFillAllLineMessage"].ToString(), "Info", MessageBoxButton.OK, MessageBoxImage.Hand);
                        Line1Done.IsChecked = false;
                        return;
                    }
                }
            }

            //evaluated value
            int[] fieldEvaluated = logic.Evaluated(field);

            //insert value into textblock
            tbEvaluated0.Text = fieldEvaluated[0].ToString();
            tbEvaluated1.Text = fieldEvaluated[1].ToString();
            tbEvaluated2.Text = fieldEvaluated[2].ToString();
            tbEvaluated3.Text = fieldEvaluated[3].ToString();

            //if sound is turn on
            if(MySettings.SoundOn)
                MySettings.PlaySound(false);
            
            //lock the field for changes
            gridField.IsEnabled = false;

            //visible all figures (user)
            switch (MySettings.ChoosenCountOfColors)
            {
                case 5:
                    uc5.VisibleAllUserFigures();
                    break;

                case 6:
                    uc6.VisibleAllUserFigures();
                    break;

                case 7:
                    uc7.VisibleAllUserFigures();
                    break;

                case 8:
                    uc8.VisibleAllUserFigures();
                    break;
            }

            //if sum of value is 10 (black color is right color and position) then is succes
            if (fieldEvaluated.Sum(x => x) == 10)
            {
                ShowCode();
                MySettings.StopTimer(true, DateTime.Now, numberOfLine);
                return;
            }

            //if is final line and code is not unresolved
            if (isFinalLine)
            {
                MySettings.StopTimer(false, DateTime.Now, numberOfLine);
                ShowCode();
            }

        }

        /// <summary>
        /// Show code (and cover collapsed)
        /// </summary>
        private void ShowCode()
        {
            ucBase4.gridBase.Visibility = Visibility.Visible; //visible base field (code)
            ucBase4.gridCover.Visibility = Visibility.Collapsed; //collapsed cover of code
        }

        /// <summary>
        /// Mouse move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null); //actual position of mouse
            Vector diff = startPoint - mousePos; //difference

            //if left mouse button is pressed and min drag disnace is OK
            if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                TextBlock tb = sender as TextBlock; //convert sender as Texblock
                TextBlock t = (TextBlock)e.Source; //source of event

                //do drag drop (move)
                DragDrop.DoDragDrop(tb, t.Text, DragDropEffects.Move);
                tb.Text = "-1";
            }
        }

        /// <summary>
        /// Set the position of mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }        
    }
}
