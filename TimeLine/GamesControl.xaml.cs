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
        int Counter;
        List<Question> mylist;
        public GamesControl()
        {
            Counter = 0;
            InitializeComponent();

            UpdateNumberOfQuestion();
            UpdateQuestion("Question number 1");
        }
        public static void Random()
        {
            Random rnd = new Random();
            int index = rnd.Next(2, 30);
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
