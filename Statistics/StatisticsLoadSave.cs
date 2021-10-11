using Logik.Statistics.Object;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Logik.Statistics
{
    /// <summary>
    /// Load || Save statistics and Path to statistics
    /// </summary>
    public class StatisticsLoadSave
    {
        /// <summary>
        /// Load statistics and path to file
        /// </summary>
        /// <returns></returns>
        public bool LoadStatistics()
        {
            bool output = false;

            try
            {
                XmlDocument xmld = new XmlDocument();

                if(File.Exists(MySettings.PathToStatistics))
                {
                    xmld.Load(MySettings.PathToStatistics);
                }
                else
                {
                    return false; //file doesnt exists
                }

                try
                {
                    //if user change path
                    MySettings.PathToStatistics = xmld.SelectSingleNode("Statistics/PathToXmlStatisticsFile").InnerText;
                }
                catch
                { }

                XmlNodeList xnl = xmld.SelectNodes("Statistics/Games/Game");
                {
                    foreach (XmlNode xn in xnl)
                    {
                        DateTime date = DateTime.Parse(xn.SelectSingleNode("Date").InnerText);
                        string player = xn.SelectSingleNode("Player").InnerText;
                        int numberOfFields = int.Parse(xn.SelectSingleNode("NumberOfFields").InnerText);
                        int numberOfColors = int.Parse(xn.SelectSingleNode("NumberOfColors").InnerText);
                        bool isRepeatColor = bool.Parse(xn.SelectSingleNode("IsRepeatColor").InnerText);
                        bool isEmptyFigure = bool.Parse(xn.SelectSingleNode("IsEmptyFigure").InnerText);
                        DateTime elapsedTime = DateTime.Parse(xn.SelectSingleNode("ElapsedTime").InnerText); ;
                        int numberOfMoves = int.Parse(xn.SelectSingleNode("NumberOfMoves").InnerText); ;
                        bool codeBroken = bool.Parse(xn.SelectSingleNode("CodeBroken").InnerText);

                        MySettings.Statistics.Add(new ObjectStatistics(date, player, numberOfFields, numberOfColors, isRepeatColor, isEmptyFigure, elapsedTime, numberOfMoves, codeBroken));
                    }
                }

                return true;
            }
            catch
            { }

            return output;
        }


        /// <summary>
        /// Save statistics and path to file
        /// </summary>
        /// <returns></returns>
        public bool SaveStatistics()
        {
            try
            {
                try
                {
                    //if file exists
                    if (File.Exists(MySettings.PathToStatistics))
                        File.Delete(MySettings.PathToStatistics); //delete 
                }
                catch
                { }

                //create new xml document
                XmlDocument xmld = new XmlDocument();
                xmld.AppendChild(xmld.CreateXmlDeclaration("1.0", "UTF-8", null));

                //root element
                XmlNode root = xmld.CreateElement("Statistics");
                xmld.AppendChild(root);

                XmlNode pathToXmlStatisticsFile = xmld.CreateElement("PathToXmlStatisticsFile");
                pathToXmlStatisticsFile.InnerText = MySettings.PathToStatistics;
                root.AppendChild(pathToXmlStatisticsFile);

                XmlNode games = xmld.CreateElement("Games");
                root.AppendChild(games);

                foreach(ObjectStatistics os in MySettings.Statistics)
                {
                    XmlNode game = xmld.CreateElement("Game");
                    games.AppendChild(game);

                    XmlNode valueToSave = xmld.CreateElement("Date");
                    valueToSave.InnerText = os.Date.ToString();
                    game.AppendChild(valueToSave);

                    valueToSave = xmld.CreateElement("Player");
                    valueToSave.InnerText = os.Player;
                    game.AppendChild(valueToSave);

                    valueToSave = xmld.CreateElement("NumberOfFields");
                    valueToSave.InnerText = os.NumberOfFields.ToString();
                    game.AppendChild(valueToSave);

                    valueToSave = xmld.CreateElement("NumberOfColors");
                    valueToSave.InnerText = os.NumberOfColors.ToString();
                    game.AppendChild(valueToSave);

                    valueToSave = xmld.CreateElement("IsRepeatColor");
                    valueToSave.InnerText = os.IsRepeatColor.ToString();
                    game.AppendChild(valueToSave);

                    valueToSave = xmld.CreateElement("IsEmptyFigure");
                    valueToSave.InnerText = os.IsEmptyFigure.ToString();
                    game.AppendChild(valueToSave);

                    valueToSave = xmld.CreateElement("ElapsedTime");
                    valueToSave.InnerText = os.ElapsedTime.ToString();
                    game.AppendChild(valueToSave);

                    valueToSave = xmld.CreateElement("NumberOfMoves");
                    valueToSave.InnerText = os.NumberOfMoves.ToString();
                    game.AppendChild(valueToSave);

                    valueToSave = xmld.CreateElement("CodeBroken");
                    valueToSave.InnerText = os.CodeBroken.ToString();
                    game.AppendChild(valueToSave);
                }

                xmld.Save(MySettings.PathToStatistics);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
