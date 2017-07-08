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
using TimeLine.GamesControls;

namespace TimeLine
{
    /// <summary>
    /// Interaction logic for GamesControl.xaml
    /// </summary>
    public partial class GamesControl : UserControl
    {
        private int counter;
        private readonly int NumberOfQuestion;
        private const int MAXNumberOfQuestion = 30;

        private List<Question> questionList;
        private List<int> usedQuestion = new List<int>();
        private Random rand = new Random();

        public delegate void EndGameDelegate(int counter, int currentAmountOfLife);

        public event EndGameDelegate EndGame;

        public GamesControl()
        {
            InitializeComponent();

            questionList = Question.ReadQuestions();
            NumberOfQuestion = Math.Min(questionList.Count, MAXNumberOfQuestion);

            timeLineControl.CheckingAnswerResult += TimeLineControl_CheckingAnswerResult;

            StartGame();
        }

        private void TimeLineControl_CheckingAnswerResult(bool isAnswerValid)
        {
            if (counter == NumberOfQuestion)
            {
                EndGame?.Invoke(counter, gamesControlLife.CurrentAmountOfLife);
            }
            else if (isAnswerValid || gamesControlLife.Fail())
            {
                UpdateQuestion(questionList[GetRandom()]);
            }
            else
            {
                EndGame?.Invoke(counter, gamesControlLife.CurrentAmountOfLife);
            }
        }

        public int GetRandom()
        {
            int index;
            int listSize = questionList.Count;

            do
            {
                index = rand.Next(listSize);
            } while (usedQuestion.Contains(index));

            usedQuestion.Add(index);

            return index;
        }

        public void StartGame()
        {
            counter = 0;
            usedQuestion.Clear();

            UpdateQuestion(questionList[GetRandom()]);

            timeLineControl.Initialize();
            gamesControlLife.Initialize();
        }

        void UpdateQuestion(Question currentQuestion)
        {
            counter++;
            textBlockNumberOfQuestion.Text = "Подія " + counter.ToString() + " з " + NumberOfQuestion.ToString();
            textBlockQuestion.Text = currentQuestion.Name;

            timeLineControl.CurrentQuestion = currentQuestion;
        }
    }
}
