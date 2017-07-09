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
    /// Interaction logic for GamesResult.xaml
    /// </summary>
    public partial class GamesResult : UserControl
    {
        public delegate void RestartGameDelegate();

        public event RestartGameDelegate RestartGame;

        public delegate void CloseGameDelegate();

        public event CloseGameDelegate CloseGame;

        private List<string> levelList = new List<string>
        {
            "Варвар",
            "Грек",
            "Юдей",
            "Книжник",
            "Раввін"
        };

        public GamesResult()
        {
            InitializeComponent();
        }
        private void buttonGameAgaine_Click(object sender, RoutedEventArgs e)
        {
            RestartGame?.Invoke();
        }

        private void buttonGameOver_Click(object sender, RoutedEventArgs e)
        {
            CloseGame?.Invoke();
        }

        public void ShowResult(int counter, int currentAmountOfLife, int numberOfQuestions)
        {
            textBlockResultAnswers.Text = "Ви протримались " + counter.ToString() + " раундів";

            int levelValue;
            if (counter == numberOfQuestions && currentAmountOfLife == 5)
            {
                levelValue = 4;
            }
            else if (counter == numberOfQuestions)
            {
                levelValue = 3;
            }
            else if (counter >= 2 * numberOfQuestions / 3)
            {
                levelValue = 2;
            }
            else if (counter >= numberOfQuestions / 3)
            {
                levelValue = 1;
            }
            else
            {
                levelValue = 0;
            }

            switch (levelValue)
            {
                case 0:
                    textBlockLevel0.Opacity = 1;
                    textBlockLevel0.Foreground = Brushes.Yellow;
                    imageLevel0.Opacity = 1;
                    break;
                case 1:
                    textBlockLevel1.Opacity = 1;
                    textBlockLevel1.Foreground = Brushes.Yellow;
                    imageLevel1.Opacity = 1;
                    break;
                case 2:
                    textBlockLevel2.Opacity = 1;
                    textBlockLevel2.Foreground = Brushes.Yellow;
                    imageLevel2.Opacity = 1;
                    break;
                case 3:
                    textBlockLevel3.Opacity = 1;
                    textBlockLevel3.Foreground = Brushes.Yellow;
                    imageLevel3.Opacity = 1;
                    break;
                case 4:
                    textBlockLevel4.Opacity = 1;
                    textBlockLevel4.Foreground = Brushes.Yellow;
                    imageLevel4.Opacity = 1;
                    break;
            }

            textBlockResultLevel.Text = "Ви знаєте Біблію на рівні: " + levelList[levelValue];
        }
    }
}
