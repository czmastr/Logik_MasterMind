using Logik.Guide;
using Logik.Resources;
using Logik.UserControlAboutApp;
using Logik.UserControlFigures;
using Logik.UserControlGameField.Field3;
using Logik.UserControlGameField.Field4;
using Logik.UserControlGameField.Field5;
using Logik.UserControlSettings;
using Logik.UserControlStatistics;
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
using System.Windows.Threading;

namespace Logik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool gamePlay = false;
        //if user push restart, not necesseary create new game (it was crated). The timer is stopped and restart
        private bool isRestart = false; 

        //UcSettings ucSettings;

        //private DispatcherTimer timer = new DispatcherTimer();
        //private DateTime startTime;

        public MainWindow()
        {
            InitializeComponent();

            //ccGame.Content = new UcGuideCz();
            SelectGuide();
        }

        /// <summary>
        /// Select Guide (language)
        /// </summary>
        private void SelectGuide()
        {
            if(MySettings.SelectedLanguageCz)
            {
                ccGame.Content = new UcGuideCz();
            }
            else
            {
                ccGame.Content = new UcGuideEng();
            }
        }


        #region GAME (BUTTON - play; restart, SETUP, TIMER, SOUND)

        /// <summary>
        /// Button Play Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            //stopped timer (for sure)
            if (MySettings.Timer.IsEnabled)
                MySettings.Timer.Stop();

            gamePlay = true;
            
            //if wasnt push restart button, create new game
            if (isRestart == false)            
                Game();

            //setup timer
            MySettings.Timer.Interval = TimeSpan.FromSeconds(1);
            MySettings.Timer.Tick += Timer_Tick;
            MySettings.Timer.Start();
            MySettings.StartTime = DateTime.Now;

            isRestart = false; //set up restart to false
            btnRestart.IsEnabled = true;

            //startTime = DateTime.Now;

            //labelStatus.Content = "Nova hra se generuje";
            //Thread thread = new Thread(() =>
            //{
            //    try
            //    {
            //        try
            //        {
            //            try
            //            {
            //                newGame = true;
            //                gamePlay = true;
            //                //Game();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //            }

            //            Dispatcher.Invoke((Action)(() =>
            //            {
            //                if (newGame == true)
            //                {
            //                    Game();
            //                    labelStatus.Content = "Hodne stesti";
            //                }

            //            }), null);
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //    catch (Exception ex)
            //    { }
            //    //System.Windows.Threading.Dispatcher.Run(); //thread will be still running
            //});
            //thread.SetApartmentState(ApartmentState.STA);
            //thread.IsBackground = true;
            //thread.Start();

        }

        /// <summary>
        /// Restart game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
            //stopped timer
            if (MySettings.Timer.IsEnabled)
                MySettings.Timer.Stop();

            labelStatus.Content = MySettings.VersionOfApp;
            gamePlay = true; //hide the code (cover)

            Game();

            isRestart = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            labelStatus.Content = new DateTime(DateTime.Now.Ticks - MySettings.StartTime.Ticks).ToString("HH:mm:ss");
            
        }

        /// <summary>
        /// Set up game
        /// </summary>
        private void Game()
        {
            //stop timer (reset); for sure
            if(MySettings.Timer.IsEnabled)
                MySettings.Timer.Stop();

            //if is restart -> version of app (not time)
            if (isRestart)
                labelStatus.Content = MySettings.VersionOfApp;

            Random random = new Random();
            int randomNumber;

            //number of color
            int[] choosenColorOfFigure = new int[MySettings.ChoosenCountOfColors];

            //number of figure field (base)
            MySettings.BaseFieldFigure = new int[MySettings.ChoosenCountOfFields];

            //filled base of figure (code) 
            for (int i = 1; i <= MySettings.ChoosenCountOfFields; i++)
            {
                //use empty figure in code (will not)
                if (MySettings.EmptyFigure == false)
                {
                    randomNumber = random.Next(1, MySettings.ChoosenCountOfColors);
                }
                else //empty figure use in code
                {
                    randomNumber = random.Next(0, MySettings.ChoosenCountOfColors);
                }

                //dont repeating of color
                if (MySettings.RepeatColor == false)
                {
                    if (!MySettings.BaseFieldFigure.Contains(randomNumber))
                        MySettings.BaseFieldFigure[i - 1] = randomNumber;
                    else
                        i--;
                }
                else //repeating color
                {
                    MySettings.BaseFieldFigure[i - 1] = randomNumber;
                }
            }


            //fields content
            switch (MySettings.ChoosenCountOfFields)
            {
                case 3:
                    ccGame.Content = new UcGameField3(gamePlay);
                    break;

                case 4:
                    ccGame.Content = new UcGameField4(gamePlay);
                    break;

                case 5:
                    ccGame.Content = new UcGameField5(gamePlay);
                    break;
            }                        
        }

        /// <summary>
        /// Turn on sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSoundOnOf_Checked(object sender, RoutedEventArgs e)
        {
            MySettings.SoundOn = true;
        }

        /// <summary>
        /// Turn off sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbSoundOnOf_Unchecked(object sender, RoutedEventArgs e)
        {
            MySettings.SoundOn = false;
        }

        #endregion

        /// <summary>
        /// Button settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            UcSettings ucSettings = new UcSettings(ccGame);
            //this.ucSettings = new UcSettings(ccGame);

            if (ccGame.Content.ToString() != ucSettings.ToString())
            {
                MySettings.ActualContentControl = (ContentControl)ccGame.Content;
                ccGame.Content = ucSettings; //new UcSettings(ccGame); 
            }                       
        }

        /// <summary>
        /// Button Statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            UcStatistics ucStatistics = new UcStatistics(ccGame);
            if (ccGame.Content.ToString() != ucStatistics.ToString())
            {
                MySettings.ActualContentControl = (ContentControl)ccGame.Content;
                ccGame.Content = ucStatistics;
            }
        }
        /// <summary>
        /// Load window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MySettings.LoadStatistics();

            btnRestart.IsEnabled = false;
            labelStatus.Content = MySettings.VersionOfApp;
        }

        /// <summary>
        /// Closing save statistics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            MySettings.SaveStatistics();
        }

        /// <summary>
        /// Button Guide (information)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuide_Click(object sender, RoutedEventArgs e)
        {
            SelectGuide();
        }

        /// <summary>
        /// Language czech
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLanguageCz_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("CZ");            
            LanguageChange.Language(true);
            SelectGuide();
        }

        /// <summary>
        /// Language english
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLanguageEng_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("ENG");
            LanguageChange.Language(false);
            SelectGuide();
        }

        /// <summary>
        /// About APP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAboutApp_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("APP");
            UcAboutApp ucAboutApp = new UcAboutApp(ccGame);
            if (ccGame.Content.ToString() != ucAboutApp.ToString())
            {
                MySettings.ActualContentControl = (ContentControl)ccGame.Content;
                ccGame.Content = ucAboutApp;
            }
        }


    }
}
