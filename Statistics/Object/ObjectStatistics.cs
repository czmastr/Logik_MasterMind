using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logik.Statistics.Object
{
    /// <summary>
    /// Object od statistics
    /// </summary>
    public class ObjectStatistics : INotifyPropertyChanged, IEditableObject
    {
        private DateTime date = DateTime.Now.Date;
        private string player = "Player";
        private int numberOfFields = MySettings.ChoosenCountOfFields;
        private int numberOfColors = MySettings.ChoosenCountOfColors;
        private bool isRepeatColor = MySettings.RepeatColor;
        private bool isEmptyFigure = MySettings.EmptyFigure;
        private DateTime elapsedTime;
        private int numberOfMoves = 1;
        private bool codeBroken = false;

        //data for undoing canceled edits
        private ObjectStatistics temp_ObjectStatistics = null;
        private bool isEditing = false;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Change the property
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotiFyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Empty construcor (object)
        /// </summary>
        public ObjectStatistics()
        { }
        /// <summary>
        /// Object statistics
        /// </summary>
        /// <param name="date">Date of game</param>
        /// <param name="player">Player name</param>
        /// <param name="numberOfFields">Number of fields that are selected (choosen)</param>
        /// <param name="numberOfColors">Number of coloers that are selected (choosen)</param>
        /// <param name="isRepeatColor">Is repeating color in code</param>
        /// <param name="isEmptyFigure">Is empty figure in code</param>
        /// <param name="elapsedTime">Elapsed time</param>
        /// <param name="numberOfMoves">Number of moves to break code</param>
        /// <param name="codeBroken">Succesfull / Not succesfull break code</param>
        public ObjectStatistics(DateTime date, string player, int numberOfFields, int numberOfColors, bool isRepeatColor, bool isEmptyFigure, DateTime elapsedTime, int numberOfMoves, bool codeBroken)
        {
            this.date = date;
            this.player = player;
            this.numberOfFields = numberOfFields;
            this.numberOfColors = numberOfColors;
            this.isRepeatColor = isRepeatColor;
            this.isEmptyFigure = isEmptyFigure;
            this.elapsedTime = elapsedTime;
            this.numberOfMoves = numberOfMoves;
            this.codeBroken = codeBroken;
        }

        /// <summary>
        /// Object statistics
        /// </summary>
        /// <param name="player">Player name</param>
        /// <param name="elapsedTime">Elapsed time</param>
        /// <param name="numberOfMoves">Number of moves to break code</param>
        /// <param name="codeBroken">Succesfull / Not succesfull break code</param>
        public ObjectStatistics(string player, DateTime elapsedTime, int numberOfMoves, bool codeBroken)
        {
            this.player = player;
            this.elapsedTime = elapsedTime;
            this.numberOfMoves = numberOfMoves;
            this.codeBroken = codeBroken;
        }


        /// <summary>
        /// Date of game
        /// </summary>
        public DateTime Date
        {
            get => date; 
            
            set
            {
                if (value != this.date)
                {
                    this.date = value;
                    NotiFyPropertyChanged("Date");
                }
            }
        }
        /// <summary>
        /// Player Name
        /// </summary>
        public string Player
        {
            get => player; 

            set
            {
                if (value != this.player)
                {
                    this.player = value;
                    NotiFyPropertyChanged("Player");
                }
            }
        }
        /// <summary>
        /// Number of fields that are selected (choosen)
        /// </summary>
        public int NumberOfFields
        {
            get => numberOfFields; 
            
            set
            {
                if (value != this.numberOfFields)
                {
                    this.numberOfFields = value;
                    NotiFyPropertyChanged("NumberOfFields");
                }
            }
        }
        /// <summary>
        /// Number of colors that are selected (choosen)
        /// </summary>
        public int NumberOfColors
        {
            get => numberOfColors;
            
            set
            {
                if (value != this.numberOfColors)
                {
                    this.numberOfColors = value;
                    NotiFyPropertyChanged("NumberOfColors");
                }
            }
        }
        /// <summary>
        /// Is repeating color in code
        /// </summary>
        public bool IsRepeatColor
        {
            get => isRepeatColor; 
            
            set
            {
                if (value != this.isRepeatColor)
                {
                    this.isRepeatColor = value;
                    NotiFyPropertyChanged("IsRepeatColor");
                }
            }
        }
        /// <summary>
        /// Is empty figure in code
        /// </summary>
        public bool IsEmptyFigure
        {
            get => isEmptyFigure;
            
            set
            {
                if (value != this.isEmptyFigure)
                {
                    this.isEmptyFigure = value;
                    NotiFyPropertyChanged("IsEmptyFigure");
                }
            }
        }
        /// <summary>
        /// Elapsed time
        /// </summary>
        public DateTime ElapsedTime
        {
            get => elapsedTime; 
            
            set
            {
                if (value != this.elapsedTime)
                {
                    this.elapsedTime = value;
                    NotiFyPropertyChanged("ElapsedTime");
                }
            }
        }
        /// <summary>
        /// Number of moves to break code
        /// </summary>
        public int NumberOfMoves
        {
            get => numberOfMoves; 
            
            set
            {
                if (value != this.numberOfMoves)
                {
                    this.numberOfMoves = value;
                    NotiFyPropertyChanged("NumberOfMoves");
                }
            }
        }
        /// <summary>
        /// Succesfull / Not succesfull break code
        /// </summary>
        public bool CodeBroken
        {
            get => codeBroken; 
            
            set
            {
                if (value != this.codeBroken)
                {
                    codeBroken = value;
                    NotiFyPropertyChanged("CodeBroken");

                }
            }
        }


        public void BeginEdit()
        {
            //throw new NotImplementedException();
            if(isEditing == true)
            {
                temp_ObjectStatistics = this.MemberwiseClone() as ObjectStatistics;
                isEditing = true;
            }
        }
        
        public void CancelEdit()
        {
            //throw new NotImplementedException();
            if (isEditing == true)
            {
                this.Date = temp_ObjectStatistics.Date;
                this.Player = temp_ObjectStatistics.Player;
                this.NumberOfFields = temp_ObjectStatistics.NumberOfFields;
                this.NumberOfColors = temp_ObjectStatistics.NumberOfColors;
                this.IsRepeatColor = temp_ObjectStatistics.IsRepeatColor;
                this.IsEmptyFigure = temp_ObjectStatistics.IsEmptyFigure;
                this.ElapsedTime = temp_ObjectStatistics.ElapsedTime;
                this.NumberOfMoves = temp_ObjectStatistics.NumberOfMoves;
                this.CodeBroken = temp_ObjectStatistics.CodeBroken;
                isEditing = false;
            }
        }

        public void EndEdit()
        {
            //throw new NotImplementedException();
            if(isEditing ==  true)
            {
                temp_ObjectStatistics = null;
                isEditing = false;
            }
        }
    }


    public class StatisticsAll : ObservableCollection<ObjectStatistics>
    {

    }
}
