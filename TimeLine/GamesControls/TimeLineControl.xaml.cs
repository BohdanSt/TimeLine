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

namespace TimeLine.GamesControls
{
    /// <summary>
    /// Interaction logic for TimeLineControl.xaml
    /// </summary>
    public partial class TimeLineControl : UserControl
    {
        public TimeLineControl()
        {
            InitializeComponent();

            AddNewQuestionLine(0, "Створення світу");

            AddNewTimeInterval(1);

            AddNewQuestionLine(2, "Народження Христа");

            AddNewTimeInterval(3);

            AddNewQuestionLine(4, "Вознесіння");
        }

        private void AddNewTimeInterval(int rowNumber)
        {
            timeLineControlContainer.RowDefinitions.Add(new RowDefinition());
            TimeIntervalControl timeInterval = new TimeIntervalControl(rowNumber);

            timeInterval.ControlMouseEnter += TimeInterval_ControlMouseEnter;
            timeInterval.ControlMouseLeave += TimeInterval_ControlMouseLeave;
            timeInterval.ControlMouseDown += TimeInterval_ControlMouseDown;

            Grid.SetRow(timeInterval, rowNumber);
            timeLineControlContainer.Children.Add(timeInterval);
        }

        private void TimeInterval_ControlMouseEnter(int position)
        {
            QuestionControl control = timeLineControlContainer.Children[position - 1] as QuestionControl;
            control.textBlockQuestion.FontSize = 30;

            control = timeLineControlContainer.Children[position + 1] as QuestionControl;
            control.textBlockQuestion.FontSize = 30;
        }

        private void TimeInterval_ControlMouseLeave(int position)
        {
            QuestionControl control = timeLineControlContainer.Children[position - 1] as QuestionControl;
            control.textBlockQuestion.FontSize = 24;

            control = timeLineControlContainer.Children[position + 1] as QuestionControl;
            control.textBlockQuestion.FontSize = 24;
        }

        private void TimeInterval_ControlMouseDown(int position)
        {
            //throw new NotImplementedException();
        }

        private void AddNewQuestionLine(int rowNumber, string question)
        {
            timeLineControlContainer.RowDefinitions.Add(new RowDefinition());
            QuestionControl questionControl = new QuestionControl(question);

            Grid.SetRow(questionControl, rowNumber);
            timeLineControlContainer.Children.Add(questionControl);
        }
    }
}
