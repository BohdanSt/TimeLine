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

namespace TimeLine
{
    /// <summary>
    /// Interaction logic for GamesControl.xaml
    /// </summary>
    public partial class GamesControl : UserControl
    {
        private int Counter;

        private List<Question> questionList;

        private List<int> usedQuestion = new List<int>();

        private Random rand = new Random();

        public GamesControl()
        {
            InitializeComponent();

            questionList = Question.ReadQuestions();
        }

        public int GetRandom()
        {
            int index;
            do
            {
                index = rand.Next(questionList.Count);
            } while (usedQuestion.Contains(index));

            usedQuestion.Add(index);

            return index;
        }

        public void StartGame()
        {
            Counter = 0;
            usedQuestion.Clear();

            UpdateNumberOfQuestion();
            UpdateQuestion(questionList[GetRandom()].Name);

            gamesControlLife.Initialize();
        }

        public int GetCounter()
        {
            return Counter;
        }
        public void Addition()
        {
            Counter++;
        }

        void UpdateNumberOfQuestion()
        {
            textBlockNumberOfQuestion.Text = "Подія " + Counter.ToString() + " з 30";
        }

        void UpdateQuestion(string question)
        {
            textBlockQuestion.Text = question;
        }
    }
}
