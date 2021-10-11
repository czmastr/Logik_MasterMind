using Logik.SoundUtility;
using Logik.Statistics;
using Logik.Statistics.Object;
using Logik.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Logik
{
    public static class MySettings
    {
        private static string versionOfApp = "0.9.0 - test";

        //3 / 4 / 5 fields
        private static int choosenCountOfFields = 5;

        //colors of figures (random from them)
        private static List<int> gameColors = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

        private static int minCountOfColors = 5;
        private static int maxCountOfColors = 8;
        private static int choosenCountOfColors = 8;

        private static int[] baseFieldFigure = null;

        private static bool repeatColor = false;
        private static bool emptyFigure = false;

        private static PlayerSound ps = new PlayerSound();
        private static bool soundOn = true;

        private static bool cryptoMode = false;

        //allways turn on fill all figures (3, 4, 5)
        private static bool fillAllLine = true;

        private static bool selectedLanguageCz = true;

        //Actual content
        private static ContentControl actualContentControl;

        //Timer
        private static DispatcherTimer timer = new DispatcherTimer();
        private static DateTime startTime;

        //Statistics
        private static ObservableCollection<ObjectStatistics> statistics = new ObservableCollection<ObjectStatistics>();
        private static string xmlStatisticsFile = "LogikStatistics.xml";
        private static string pathToStatisticsFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static string pathToStatistics = Path.Combine(pathToStatisticsFolder, xmlStatisticsFile);
        private static StatisticsLoadSave statisticsLoadSave = new StatisticsLoadSave();


        /// <summary>
        /// Play sound
        /// </summary>
        /// <param name="user"></param>
        public static void PlaySound(bool user)
        {
            //if sound is turn on
            if (soundOn)
                ps.PlaySound(user); //play sound (user move or evaluated
        }

        /// <summary>
        /// Game is finish
        /// </summary>
        /// <param name="successfullyBrokenCode">success / not success of broken code</param>
        /// <param name="stopTime">time of finish game</param>
        /// <param name="numberOfMoves">number of moves of game</param>
        public static void StopTimer(bool successfullyBrokenCode, DateTime stopTime, int numberOfMoves)
        {
            timer.Stop(); //stop timer

            wPlayerName windowPlayerName = new wPlayerName();
            windowPlayerName.ShowDialog();
            string playerName = windowPlayerName.PlayerName;


            ObjectStatistics os = new ObjectStatistics();
            //os.Date = DateTime.Now.Date;
            if (string.IsNullOrEmpty(playerName) == false)
                os.Player = playerName;

            os.ElapsedTime = new DateTime(stopTime.Ticks - startTime.Ticks);
            os.NumberOfMoves = numberOfMoves;
            os.CodeBroken = successfullyBrokenCode;

            MySettings.statistics.Add(os);
        }

        /// <summary>
        /// Load statistics (and path to file)
        /// </summary>
        public static bool LoadStatistics()
        {
            return MySettings.statisticsLoadSave.LoadStatistics();
        }
        /// <summary>
        /// Save statistics (and path to file)
        /// </summary>
        /// <returns></returns>
        public static bool SaveStatistics()
        {
            return MySettings.statisticsLoadSave.SaveStatistics();
        }

        /// <summary>
        /// Hyperlink
        /// </summary>
        /// <param name="link"></param>
        public static void Hyperlink(Uri link)
        {
            try
            {
                System.Diagnostics.Process.Start(link.AbsoluteUri);
            }
            catch(Exception ex)
            { }
        }

        /// <summary>
        /// ChoosenCountOfFileds (3 / 4 / 5)
        /// </summary>
        public static int ChoosenCountOfFields { get => choosenCountOfFields; set => choosenCountOfFields = value; }
        /// <summary>
        /// Game colors
        /// </summary>
        public static List<int> GameColors { get => gameColors; set => gameColors = value; }
        /// <summary>
        /// Min colors (5)
        /// </summary>
        public static int MinCountOfColors { get => minCountOfColors; set => minCountOfColors = value; }
        /// <summary>
        /// Max colors (8)
        /// </summary>
        public static int MaxCountOfColors { get => maxCountOfColors; set => maxCountOfColors = value; }
        /// <summary>
        /// Choosen count of colors
        /// </summary>
        public static int ChoosenCountOfColors { get => choosenCountOfColors; set => choosenCountOfColors = value; }
        /// <summary>
        /// Base filed figure
        /// </summary>
        public static int[] BaseFieldFigure { get => baseFieldFigure; set => baseFieldFigure = value; }
        /// <summary>
        /// Sound on/off
        /// </summary>
        public static bool SoundOn { get => soundOn; set => soundOn = value; }
        /// <summary>
        /// Repeate color of figure (more the same color)
        /// </summary>
        public static bool RepeatColor { get => repeatColor; set => repeatColor = value; }
        /// <summary>
        /// Empty figure as normal figure (is code)
        /// </summary>
        public static bool EmptyFigure { get => emptyFigure; set => emptyFigure = value; }
        /// <summary>
        /// Crypto mode - figure are icon of cryptocurrencies
        /// </summary>
        public static bool CryptoMode { get => cryptoMode; set => cryptoMode = value; }
        /// <summary>
        /// Actual content control
        /// </summary>
        public static ContentControl ActualContentControl
        {
            get
            {
                return actualContentControl;
            }

            set
            {
                actualContentControl = value;
            }
        }
        /// <summary>
        /// Timer
        /// </summary>
        public static DispatcherTimer Timer
        {
            get
            {
                return timer;
            }

            set
            {
                timer = value;
            }
        }
        /// <summary>
        /// Start time of game (new)
        /// </summary>
        public static DateTime StartTime { get => startTime; set => startTime = value; }
        /// <summary>
        /// Statistics
        /// </summary>
        public static ObservableCollection<ObjectStatistics> Statistics { get => statistics; set => statistics = value; }
        /// <summary>
        /// Path to xml statistics (saved games); If User doesnt define path -> path from Logik.exe
        /// </summary>
        public static string PathToStatistics
        { 
            get
            { 
                //if user doesnt specify path (is null)
                //if(string.IsNullOrEmpty(pathToStatisticsUser))
                //{
                //    return pathToStatistics; //path, where is exe file Logik game
                //}
                //else
                //{
                //    return pathToStatisticsUser; //path whitch define user
                //}
                return pathToStatistics; 
            }
            set
            { 
                pathToStatistics = value; 
            }
        }
        /// <summary>
        /// Selected language (TRUE = CZ, FALSE = ENG)
        /// </summary>
        public static bool SelectedLanguageCz { get => selectedLanguageCz; set => selectedLanguageCz = value; }
        /// <summary>
        /// Path to statistics folder
        /// </summary>
        public static string PathToStatisticsFolder { get => pathToStatisticsFolder; set => pathToStatisticsFolder = value; }
        /// <summary>
        /// Fill all line by figures (3/ 4/ 5)
        /// </summary>
        public static bool FillAllLine { get => fillAllLine; set => fillAllLine = value; }
        /// <summary>
        /// Version of application
        /// </summary>
        public static string VersionOfApp
        {
            get
            {
                return versionOfApp;
            }

            set
            {
                versionOfApp = value;
            }
        }
    }
}
