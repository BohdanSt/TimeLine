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
        public Question CurrentQuestion { get; set; }

        public delegate void CheckingAnswerResultDelegate(bool isAnswerValid);

        public event CheckingAnswerResultDelegate CheckingAnswerResult;

        public TimeLineControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            timeLineControlContainer.Children.Clear();

            for (int i = 0; i < 100; i++)
            {
                timeLineControlContainer.RowDefinitions.Add(new RowDefinition());
            }


            AddNewQuestionLine(0, new Question() { Name = "Створення світу", Index = int.MinValue });

            AddNewTimeInterval(1);

            AddNewQuestionLine(2, new Question() { Name = "Народження Христа", Index = 0 });

            AddNewTimeInterval(3);

            AddNewQuestionLine(4, new Question() { Name = "Вознесіння", Index = int.MaxValue });
        }

        private void AddNewTimeInterval(int rowNumber)
        {
            TimeIntervalControl timeInterval = new TimeIntervalControl(rowNumber);

            timeInterval.ControlMouseEnter += TimeInterval_ControlMouseEnter;
            timeInterval.ControlMouseLeave += TimeInterval_ControlMouseLeave;
            timeInterval.ControlMouseDown += TimeInterval_ControlMouseDown;

            Grid.SetRow(timeInterval, rowNumber);
            timeLineControlContainer.Children.Add(timeInterval);
        }

        private void AddNewQuestionLine(int rowNumber, Question question)
        {
            QuestionControl questionControl = new QuestionControl(question);

            Grid.SetRow(questionControl, rowNumber);
            timeLineControlContainer.Children.Add(questionControl);
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
            TimeIntervalControl clickedTimeIntervalControl = timeLineControlContainer.Children[position] as TimeIntervalControl;
            TimeIntervalControl validTimeIntervalControl = null;

            QuestionControl questionBefore = timeLineControlContainer.Children[position - 1] as QuestionControl;
            QuestionControl questionAfter = timeLineControlContainer.Children[position + 1] as QuestionControl;

            bool isAnswerValid;

            if (CurrentQuestion.Index > questionBefore.Question.Index
                && CurrentQuestion.Index < questionAfter.Question.Index)
            {
                clickedTimeIntervalControl.ExpandControl();

                clickedTimeIntervalControl.ShowAsNormal();

                isAnswerValid = true;
            }
            else
            {
                clickedTimeIntervalControl.ShowAsWrongAnswer();

                for (int i = 0; i < timeLineControlContainer.Children.Count; i++)
                {
                    if (timeLineControlContainer.Children[i] is QuestionControl)
                    {
                        QuestionControl questionControl = timeLineControlContainer.Children[i] as QuestionControl;
                        if (questionControl.Question.Index > CurrentQuestion.Index)
                        {
                            validTimeIntervalControl = timeLineControlContainer.Children[i - 1] as TimeIntervalControl;
                        }
                    }
                }

                validTimeIntervalControl.ExpandControl();

                clickedTimeIntervalControl.ShowAsNormal();
                validTimeIntervalControl.ShowAsNormal();

                isAnswerValid = false;
            }

            CheckingAnswerResult?.Invoke(isAnswerValid);
        }
    }
}
